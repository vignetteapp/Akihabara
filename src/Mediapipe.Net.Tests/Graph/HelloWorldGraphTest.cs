// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Framework;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Framework.Port;
using NUnit.Framework;

namespace Mediapipe.Net.Tests.Graph
{
    [TestFixture]
    public class HelloWorldTest
    {
        private const string input_stream = "in";
        private const string output_stream = "out";
        private const string graph_config_text = @"
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

        private static CalculatorGraph helloWorldGraph;
        private static OutputStreamPoller<string> outputStreamPoller;
        private static StringPacket outputPacket;

        [Test]
        public static void MainTest()
        {
            Assert.DoesNotThrow(() => {
                helloWorldGraph = new CalculatorGraph(graph_config_text);
                outputStreamPoller = helloWorldGraph.AddOutputStreamPoller<string>(output_stream).Value();
            });

            Status graphStartResult = helloWorldGraph.StartRun();
            Assert.True(graphStartResult.Ok);

            Assert.DoesNotThrow(() => {
                int timestamp = System.Environment.TickCount & int.MaxValue;
                var inputPacket = new StringPacket("Hello World", new Timestamp(timestamp));
                outputPacket = new StringPacket();
                helloWorldGraph.AddPacketToInputStream(input_stream, inputPacket);
            });

            if (outputStreamPoller.Next(outputPacket))
                Assert.AreEqual(outputPacket.Get(), "Hello World");
        }
    }
}
