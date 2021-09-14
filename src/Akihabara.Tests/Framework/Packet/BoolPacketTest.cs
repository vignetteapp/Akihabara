using System;
using NUnit.Framework;
using Akihabara.Core;
using Akihabara.Framework;
using Akihabara.Framework.Port;
using Akihabara.Framework.Packet;

namespace Akihabara.Tests.Framework.Packet
{
    public class BoolPacketTest
    {
        #region Constructor
        [Test] // previously [Test, SignalAbort] - I don't know why it was there
        public void Ctor_ShouldInstantiatePacket_When_CalledWithNoArguments()
        {
            var packet = new BoolPacket();

            Assert.AreEqual(packet.ValidateAsType().Code, Status.StatusCode.Internal);
            Assert.Throws<MediapipeException>(() => { packet.Get(); });
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithTrue()
        {
            var packet = new BoolPacket(true);

            Assert.True(packet.ValidateAsType().ok);
            Assert.True(packet.Get());
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithFalse()
        {
            var packet = new BoolPacket(false);

            Assert.True(packet.ValidateAsType().ok);
            Assert.False(packet.Get());
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithValueAndTimestamp()
        {
            var timestamp = new Timestamp(1);
            var packet = new BoolPacket(true, timestamp);

            Assert.True(packet.ValidateAsType().ok);
            Assert.True(packet.Get());
            Assert.AreEqual(packet.Timestamp(), timestamp);
        }
        #endregion

        #region #IsDisposed
        [Test]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var packet = new BoolPacket();

            Assert.False(packet.IsDisposed);
        }

        [Test]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var packet = new BoolPacket();
            packet.Dispose();

            Assert.True(packet.IsDisposed);
        }
        #endregion

        #region #Consume
        [Test]
        public void Consume_ShouldThrowNotSupportedException()
        {
            var packet = new BoolPacket();

            Assert.Throws<NotSupportedException>(() => { packet.Consume(); });
        }
        #endregion

        #region #DebugTypeName
        [Test]
        public void DebugTypeName_ShouldReturnBool_When_ValueIsSet()
        {
            var packet = new BoolPacket(true);

            Assert.AreEqual(packet.DebugTypeName(), "bool");
        }
        #endregion
    }
}
