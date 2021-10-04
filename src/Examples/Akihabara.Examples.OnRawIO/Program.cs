using System;
using System.IO;
using Akihabara.External;
using Akihabara.Framework;
using Akihabara.Framework.ImageFormat;
using Akihabara.Framework.Packet;
using UnmanageUtility;

namespace Akihabara.Examples.OnRawIO
{
    class Program
    {
        const string kInputStream = "input_video";
        const string kOutputStream = "output_video";

        static void Main(string[] args)
        {
            Glog.Initialize("stuff", "stuff");
            if (args.Length != 4)
            {
                Usage();
                return;
            }

            int width = Int32.Parse(args[0]);
            int height = Int32.Parse(args[1]);
            byte[] srcBytes = File.ReadAllBytes(args[2]);
            string configText = File.ReadAllText(args[3]);

            Console.WriteLine($"srcBytes: {srcBytes.Length}");

            var graph = new CalculatorGraph(configText);
            var poller = graph.AddOutputStreamPoller<ImageFrame>(kOutputStream).Value();

            graph.StartRun();

            var length = width * height * 4;
            var pixelData = new UnmanagedArray<byte>(length);
            pixelData.CopyFrom(srcBytes);
            using (var inputFrame = new ImageFrame(ImageFormat.Format.Srgba, width, height, width * 4, pixelData))
            {
                int timestamp = System.Environment.TickCount & int.MaxValue;
                var inputPacket = new ImageFramePacket(inputFrame, new Timestamp(timestamp));

                graph.AddPacketToInputStream(kInputStream, inputPacket);
                graph.CloseInputStream(kInputStream);

                graph.WaitUntilIdle();

                var packet = new ImageFramePacket();
                Console.WriteLine("Waiting for packet...");
                if (!poller.Next(packet))
                {
                    Console.WriteLine("IT FUCKING FAILED TO RETRIEVE THE PACKET");
                    return;
                }
                var imageFrame = packet.Get();
                var bytes = imageFrame.CopyToByteBuffer(length);

                Console.WriteLine("IT FUCKING WORKED");
                ByteArrayToFile("outputImage.rawstuff", bytes);
            }
        }

        static void Usage()
        {
            Console.WriteLine("Usage: dotnet run <width> <height> <image> <graph-config>");
        }

        static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }
    }
}
