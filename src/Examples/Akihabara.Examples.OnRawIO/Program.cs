using System;
using System.IO;
using Akihabara.External;
using Akihabara.Framework;
using Akihabara.Framework.ImageFormat;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Port;
using UnmanageUtility;

namespace Akihabara.Examples.OnRawIO
{
    class Program
    {
        const string kInputStream = "input_video";
        const string kOutputStream = "output_video";

        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Usage();
                return;
            }
            
            int width = Int32.Parse(args[0]);
            int height = Int32.Parse(args[1]);
            string configText = File.ReadAllText(args[2]);

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

        static Status RunGraph(int width, int height, string configText)
        {
            var graph = new CalculatorGraph(configText);
            var poller = graph.AddOutputStreamPoller<ImageFrame>(kOutputStream).Value();

            graph.StartRun();

            var length = width * height * 4;
            var inBytes = new byte[length];

            Stream stdin = Console.OpenStandardInput(length);
            Stream stdout = Console.OpenStandardOutput(length);

            while (true)
            {
                int bytesRead = ReadBytesFromStream(stdin, inBytes);
                if (bytesRead == 0)
                    break;
                else if (bytesRead != length)
                    throw new FormatException($"Expected a raw RGBA image of byte size {length} ({width}x{height}x4), but received {bytesRead} bytes");

                var pixelData = new UnmanagedArray<byte>(length);
                pixelData.CopyFrom(inBytes);

                var inputFrame = new ImageFrame(ImageFormat.Format.Srgba, width, height, width * 4, pixelData);
                int timestamp = System.Environment.TickCount & int.MaxValue;
                var inputPacket = new ImageFramePacket(inputFrame, new Timestamp(timestamp));

                graph.AddPacketToInputStream(kInputStream, inputPacket);

                var packet = new ImageFramePacket();
                if (!poller.Next(packet))
                    break;
                
                var imageFrame = packet.Get();
                var outBytes = imageFrame.CopyToByteBuffer(length);
                stdout.Write(outBytes, 0, length);
            }

            Glog.Log(Glog.Severity.Info, "Shutting down.");
            graph.CloseInputStream(kInputStream);
            var doneStatus = graph.WaitUntilDone();

            stdin.Dispose();
            stdout.Dispose();

            return doneStatus;
        }

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
            Console.WriteLine("Usage: Akihabara.Examples.OnRawIO <width> <height> <graph-config> < raw_image_input > raw_image_output");
        }
    }
}
