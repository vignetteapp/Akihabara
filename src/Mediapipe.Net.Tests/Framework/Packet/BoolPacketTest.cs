// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;
using Mediapipe.Net.Framework;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Framework.Port;
using NUnit.Framework;

namespace Mediapipe.Net.Tests.Framework.Packet
{
    [TestFixture]
    public class BoolPacketTest
    {
        #region Constructor
        [Test, SignalAbort]
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

            Assert.True(packet.ValidateAsType().Ok);
            Assert.True(packet.Get());
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithFalse()
        {
            var packet = new BoolPacket(false);

            Assert.True(packet.ValidateAsType().Ok);
            Assert.False(packet.Get());
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithValueAndTimestamp()
        {
            var timestamp = new Timestamp(1);
            var packet = new BoolPacket(true, timestamp);

            Assert.True(packet.ValidateAsType().Ok);
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
