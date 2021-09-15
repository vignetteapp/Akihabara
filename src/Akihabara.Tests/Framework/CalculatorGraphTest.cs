using NUnit.Framework;
using Akihabara.Framework;
using Akihabara.Framework.Port;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Protobuf;

namespace Akihabara.Tests.Framework
{
    [TestFixture]
    public class CalculatorGraphTest
    {
        private static string validConfigText = @"node {
  calculator: ""PassThroughCalculator""
  input_stream: ""in""
  output_stream: ""out1""
}
node {
  calculator: ""PassThroughCalculator""
  input_stream: ""out1""
  output_stream: ""out""
}
input_stream: ""in""
output_stream: ""out""
";

        #region Constructor
        [Test]
        public void Ctor_ShouldInstantiateCalculatorGraph_When_CalledWithNoArguments()
        {
            Assert.DoesNotThrow(() => { new CalculatorGraph(); });
        }

        [Test]
        public void Ctor_ShouldInstantiateCalculatorGraph_When_CalledWithConfigText()
        {
            var graph = new CalculatorGraph(validConfigText);
            var config = graph.Config();

            Assert.AreEqual(config.InputStream[0], "in");
            Assert.AreEqual(config.OutputStream[0], "out");
        }
        #endregion

        #region #IsDisposed
        [Test]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var graph = new CalculatorGraph();

            Assert.False(graph.IsDisposed);
        }

        [Test]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var graph = new CalculatorGraph();
            graph.Dispose();

            Assert.True(graph.IsDisposed);
        }
        #endregion

        #region #Initialize
        [Test]
        public void Initialize_ShouldReturnOk_When_CalledWithConfig_And_ConfigIsNotSet()
        {
            var graph = new CalculatorGraph();
            var status = graph.Initialize(CalculatorGraphConfig.Parser.ParseFromTextFormat(validConfigText));
            Assert.True(status.ok);

            var config = graph.Config();
            Assert.AreEqual(config.InputStream[0], "in");
            Assert.AreEqual(config.OutputStream[0], "out");
        }

        [Test]
        public void Initialize_ShouldReturnInternalError_When_CalledWithConfig_And_ConfigIsSet()
        {
            var graph = new CalculatorGraph(validConfigText);
            var status = graph.Initialize(CalculatorGraphConfig.Parser.ParseFromTextFormat(validConfigText));

            Assert.AreEqual(status.Code, Status.StatusCode.Internal);
        }

        [Test]
        public void Initialize_ShouldReturnOk_When_CalledWithConfigAndSidePacket_And_ConfigIsNotSet()
        {
            var graph = new CalculatorGraph();
            var config = CalculatorGraphConfig.Parser.ParseFromTextFormat(validConfigText);
            var sidePacket = new SidePacket();
            sidePacket.Emplace("flag", new BoolPacket(true));
            var status = graph.Initialize(config, sidePacket);

            Assert.True(status.ok);
        }

        [Test]
        public void Initialize_ShouldReturnInternalError_When_CalledWithConfigAndSidePacket_And_ConfigIsSet()
        {
            var graph = new CalculatorGraph(validConfigText);
            var config = CalculatorGraphConfig.Parser.ParseFromTextFormat(validConfigText);
            var sidePacket = new SidePacket();
            sidePacket.Emplace("flag", new BoolPacket(true));
            var status = graph.Initialize(config, sidePacket);

            Assert.AreEqual(status.Code, Status.StatusCode.Internal);
        }
        #endregion

        #region lifecycle
        [Test]
        public void LifecycleMethods_ShouldControlGraphLifeCycle()
        {
            using (var graph = new CalculatorGraph(validConfigText))
            {
                Assert.True(graph.StartRun().ok);
                Assert.False(graph.GraphInputStreamsClosed());

                Assert.True(graph.WaitUntilIdle().ok);
                Assert.True(graph.CloseAllPacketSources().ok);
                Assert.True(graph.GraphInputStreamsClosed());
                Assert.True(graph.WaitUntilDone().ok);
                Assert.False(graph.HasError());
            }
        }

        [Test]
        public void Cancel_ShouldCancelGraph()
        {
            using (var graph = new CalculatorGraph(validConfigText))
            {
                Assert.True(graph.StartRun().ok);
                graph.Cancel();
                Assert.AreEqual(graph.WaitUntilDone().Code, Status.StatusCode.Cancelled);
            }
        }
        #endregion
    }
}
