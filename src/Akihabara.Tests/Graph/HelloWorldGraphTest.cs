using NUnit.Framework;
using System;
using Akihabara.Framework;
using Akihabara.Framework.Port;
using Akihabara.Framework.Packet;

namespace Akihabara.Tests.Graph
{
    [TestFixture]
    class HelloWorldTest
    {
        private const string inputStream = "in";
        private const string outputStream = "out";
        private const string graphConfigText = @"
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
        private static Status pushedInput;

        [Test]
        public static void MainTest()
        {
            Assert.DoesNotThrow(() =>
            {
                helloWorldGraph = new CalculatorGraph(graphConfigText);
                outputStreamPoller = helloWorldGraph.AddOutputStreamPoller<string>(outputStream).Value();
            });

            Status graphStartResult = helloWorldGraph.StartRun();
            Assert.True(graphStartResult.ok);

            Assert.DoesNotThrow(() =>
            {
                int timestamp = System.Environment.TickCount & System.Int32.MaxValue;
                var inputPacket = new StringPacket("Hello World", new Timestamp(timestamp));
                outputPacket = new StringPacket();
                pushedInput = helloWorldGraph.AddPacketToInputStream(inputStream, inputPacket);
            });

            if (outputStreamPoller.Next(outputPacket))
                Assert.AreEqual(outputPacket.Get(), "Hello World");
        }
    }
}
