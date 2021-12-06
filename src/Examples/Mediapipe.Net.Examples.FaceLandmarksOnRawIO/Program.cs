using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Mediapipe.Net.External;
using Mediapipe.Net.Framework;
using Mediapipe.Net.Framework.ImageFormat;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Framework.Protobuf;
using UnmanageUtility;

namespace Mediapipe.Net.Examples.OnRawIO
{
    /// This program reads a sequence of raw images from stdin and outputs a sequence of raw images to stdout.
    /// The best way to use this program is to sandwich it between 2 ffmpeg commands to decode
    /// an image or video and encode the output back.
    class Program
    {
        // The name of the input and output streams.
        // If you read the `.pbtxt` file, you will see this name appear at the
        // beginning along with other potential stream names. For example, in
        // mediapipe/graphs/face_mesh/face_mesh_desktop_live.pbtxt, there is
        // also a second output stream called "multi_face_landmarks" containing
        // the actual face landmarks that can be processed by another program.
        const string kInputStream = "input_video";
        const string kOutputStream = "output_video";

        /// Parses arguments and fetches the necessar data before
        /// running the `RunGraph` function and reporting its state.
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Usage();
                return;
            }

            // Since it only receives the raw pixels and no additional information,
            // you have to give it the width and height of the video or image.
            int width = Int32.Parse(args[0]);
            int height = Int32.Parse(args[1]);

            // The content of the `.pbtxt` file used to generate and run the Mediapipe graph.
            string configText = File.ReadAllText(args[2]);

            //
            Glog.Initialize("stuff", "stuff");

            Status runStatus = RunGraph(width, height, configText);

            if (!runStatus.ok)
            {
                Glog.Log(Glog.Severity.Error, $"Failed to run the graph: {runStatus}");
                Environment.Exit(1);
            }
            else
            {
                Glog.Log(Glog.Severity.Info, "Success!");
            }
        }

        /// Runs the Mediapipe graph.
        /// It feeds it from raw RGBA images read from stdin, and outputs a sequence of raw RGBA images to stdout.
        static Status RunGraph(int width, int height, string configText)
        {
            // Initialize the graph
            var graph = new CalculatorGraph(configText);
            var poller = graph.AddOutputStreamPoller<ImageFrame>(kOutputStream).Value();

            // Here we register a delegate that is gonna be called each time the graph is able to
            // detect landmarks from the input video. It will get the landmarks and write them in
            // a new file in plain JSON format.
            Directory.CreateDirectory("landmarks");
            var jserOptions = new JsonSerializerOptions { WriteIndented = true };
            graph.ObserveOutputStream<NormalizedLandmarkListVectorPacket, List<NormalizedLandmarkList>>("multi_face_landmarks", (packet) => {
                var timestamp = packet.Timestamp().Value();
                Glog.Log(Glog.Severity.Info, $"Got landmarks at timestamp {timestamp}");

                var landmarks = packet.Get();

                var jsonLandmarks = JsonSerializer.Serialize(landmarks, jserOptions);
                File.WriteAllText($"landmarks/landmark_{timestamp}.json", jsonLandmarks);

                return Status.Ok();
            }, out var callbackHandle).AssertOk();

            // Preparing image byte buffer
            var length = width * height * 4;
            var inBytes = new byte[length];

            // Using stdin and stdout as buffered streams for IO optimization
            var stdin = new BufferedStream(Console.OpenStandardInput(length));
            var stdout = new BufferedStream(Console.OpenStandardOutput(length));

            // Start the graph
            graph.StartRun().AssertOk();

            // Process one image at a time until we can't read anything more
            for (;;)
            {
                int bytesRead = ReadBytesFromStream(stdin, inBytes);
                if (bytesRead == 0)
                    break;
                else if (bytesRead != length)
                    throw new FormatException($"Expected a raw RGBA image of byte size {length} ({width}x{height}x4), but received {bytesRead} bytes");

                // To make the graph process our images, we have to send it `Packet`s containing data of a
                // specified type. In our case, we need to send images, so we will use an `ImageFramePacket`.
                // To do that, we first have to wrap our raw RGBA bytes into an `ImageFrame`.
                var pixelData = new UnmanagedArray<byte>(length);
                pixelData.CopyFrom(inBytes);
                var inputFrame = new ImageFrame(ImageFormat.Format.Srgba, width, height, width * 4, pixelData);

                // Then, we need a timestamp to package the image frame in an actual `ImageFramePacket`.
                int timestamp = System.Environment.TickCount & int.MaxValue;
                var inputPacket = new ImageFramePacket(inputFrame, new Timestamp(timestamp));

                // Finally send the packet to the graph
                graph.AddPacketToInputStream(kInputStream, inputPacket);

                // It seems like you have to retrieve the image frame packets

                // At this point, the poller can fail to retrieve the next packet,
                // so we break out of the loop if it is the case.
                var packet = new ImageFramePacket();
                if (!poller.Next(packet))
                    break;

                // After getting the packet, we retrieve the image frame and then the raw byte data
                // to finally send it in raw binary form to stdout.
                var imageFrame = packet.Get();
                var outBytes = imageFrame.CopyToByteBuffer(length);

                stdout.Write(outBytes, 0, length);
            }

            // Important things to do before we exit the program
            Glog.Log(Glog.Severity.Info, "Shutting down.");
            graph.CloseInputStream(kInputStream);
            var doneStatus = graph.WaitUntilDone();

            callbackHandle.Free();
            stdin.Dispose();
            stdout.Dispose();

            return doneStatus;
        }

        /// This function is needed because the `Stream.Read` function won't necessarily
        /// read the exact number of bytes that we specified.
        static int ReadBytesFromStream(Stream stream, byte[] bytes)
        {
            int bytesToRead = bytes.Length;
            int totalBytesRead = 0;

            while (bytesToRead > 0)
            {
                int n = stream.Read(bytes, totalBytesRead, bytesToRead);
                if (n == 0) break;
                totalBytesRead += n;
                bytesToRead -= n;
            }

            return totalBytesRead;
        }

        static void Usage()
        {
            Console.WriteLine("Usage: Mediapipe.Net.Examples.OnRawIO <width> <height> <graph-config> < raw_image_input > raw_image_output");
        }
    }
}
