#!/usr/bin/python

import argparse
import subprocess

class MediaMetadata:
    def __init__(self, width, height, framerate):
        self.width = width
        self.height = height
        self.framerate = framerate

    def from_filepath(filepath):
        output = subprocess.check_output([
            "ffprobe", "-v", "0",
            "-select_streams", "v:0",
            "-show_entries", "stream=width,height,r_frame_rate",
            "-of", "default=noprint_wrappers=1", filepath
        ]).decode('ascii').splitlines()
        [warr, harr, farr] = [l.split('=')[1] for l in output]
        width = int(warr)
        height = int(harr)
        [nfarr, dfarr] = farr.split('/')
        framerate = int(nfarr) / int(dfarr)
        return MediaMetadata(width, height, framerate)



parser = argparse.ArgumentParser(
    prog='track_landmarks.py',
    description='Pipe a video or image into Mediapipe to track a face and register the landmarks.',
    epilog='Dame da ne, dame yo, dame na no yo...')

parser.add_argument('media',
    help='The media to feed into a Medapipe graph.')
parser.add_argument('-g', '--graph',
    default='mediapipe/graphs/face_mesh/face_mesh_desktop_live.pbtxt',
    help='The Mediapipe graph to feed some media to.')
parser.add_argument('-o', '--output',
    default='bin/video-out.mp4',
    help='Where to put the output file.')

args = parser.parse_args()



mm = MediaMetadata.from_filepath(args.media)

p_decode = subprocess.Popen([
    "ffmpeg", "-hide_banner",
    "-an", "-i", args.media,
    "-pix_fmt", "rgba", "-f", "rawvideo", "-"
], stdout=subprocess.PIPE, stderr=subprocess.DEVNULL)

p_track = subprocess.Popen([
    "bin/Debug/net5.0/Akihabara.Examples.FaceLandmarksOnRawIO",
    str(mm.width), str(mm.height), args.graph,
], stdin=p_decode.stdout, stdout=subprocess.PIPE)
p_decode.stdout.close()

p_encode = subprocess.Popen([
    "ffmpeg", "-hide_banner", "-y",
    "-vn", "-i", args.media,
    "-s", f"{mm.width}x{mm.height}", "-r", str(mm.framerate),
    "-pix_fmt", "rgba", "-f", "rawvideo", "-i", "-",
    "-pix_fmt", "yuv420p", args.output
], stdin=p_track.stdout)
p_track.stdout.close()

p_decode.wait()
p_track.wait()
p_encode.wait()
