using System;
using Mediapipe.Net.Framework;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Framework.Port;

namespace Mediapipe.Net.Examples.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var status = PrintHelloWorld();
            Console.WriteLine($"Status: {status}");
        }

        static Status PrintHelloWorld()
        {
            // Configure a simple graph, which concatenates 2 PassThroughCalculators.
            const string graphConfigText = @"
                input_stream: ""in""
                output_stream: ""out""
                node {
                  calculator: ""PassThroughCalculator""
                  input_stream: ""in""
                  output_stream: ""out1""
                }
                node {
                  calculator: ""PassThroughCalculator""
                  input_stream: ""out1""
                  output_stream: ""out""
                }
                ";

            var graph = new CalculatorGraph(graphConfigText);
            var poller = graph.AddOutputStreamPoller<string>("out").Value();

            graph.StartRun();

            // Give 10 input packets that contain the same string "Hello World!".
            for (int i = 0; i < 10; i++)
            {
                var inputPacket = new StringPacket("Hello World!", new Timestamp(i));
                graph.AddPacketToInputStream("in", inputPacket);
            }

            // Close the input stream "in".
            graph.CloseInputStream("in");

            // Get the output string packets.
            for (var packet = new StringPacket(); poller.Next(packet);)
                Console.WriteLine($"| Timestamp {packet.Timestamp().DebugString()}: {packet.Get()}");

            return graph.WaitUntilDone();
        }
    }
}
