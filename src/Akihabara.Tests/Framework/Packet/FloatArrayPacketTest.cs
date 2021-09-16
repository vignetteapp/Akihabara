using Akihabara.Core;
using Akihabara.Framework;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Port;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akihabara.Tests.Framework.Packet
{
    public class FloatArrayPacketTest
    {
        #region Constructor
        [Test]// previously [Test, SignalAbort] - I don't know why it was there
        public void Ctor_ShouldInstantiatePacket_When_CalledWithNoArguments()
        {
            var packet = new FloatArrayPacket();
            packet.Length = 0;

            Assert.AreEqual(packet.ValidateAsType().Code, Status.StatusCode.Internal);
            Assert.Throws<MediapipeException>(() => { packet.Get(); });
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithEmptyArray()
        {
            float[] array = { };
            var packet = new FloatArrayPacket(array);

            Assert.True(packet.ValidateAsType().ok);
            Assert.AreEqual(packet.Get(), array);
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithArray()
        {
            float[] array = { 0.01f };
            var packet = new FloatArrayPacket(array);

            Assert.True(packet.ValidateAsType().ok);
            Assert.AreEqual(packet.Get(), array);
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithValueAndTimestamp()
        {
            var timestamp = new Timestamp(1);
            float[] array = { 0.01f, 0.02f };
            var packet = new FloatArrayPacket(array, timestamp);

            Assert.True(packet.ValidateAsType().ok);
            Assert.AreEqual(packet.Get(), array);
            Assert.AreEqual(packet.Timestamp(), timestamp);
        }
        #endregion

        #region #isDisposed
        [Test]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var packet = new FloatArrayPacket();

            Assert.False(packet.IsDisposed);
        }

        [Test]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var packet = new FloatArrayPacket();
            packet.Dispose();

            Assert.True(packet.IsDisposed);
        }
        #endregion

        #region #Consume
        [Test]
        public void Consume_ShouldThrowNotSupportedException()
        {
            var packet = new FloatArrayPacket();

            Assert.Throws<NotSupportedException>(() => { packet.Consume(); });
        }
        #endregion

        #region #DebugTypeName
        [Test]
        public void DebugTypeName_ShouldReturnFloat_When_ValueIsSet()
        {
            float[] array = { 0.01f };
            var packet = new FloatArrayPacket(array);

            Assert.AreEqual(packet.DebugTypeName(), "float []");
        }
        #endregion
    }
}
