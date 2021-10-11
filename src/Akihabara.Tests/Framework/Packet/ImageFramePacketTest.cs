// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Akihabara.Core;
using Akihabara.Framework;
using Akihabara.Framework.ImageFormat;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Port;
using NUnit.Framework;
using System;

namespace Akihabara.Tests.Framework.Packet
{
    [TestFixture]
    public class ImageFramePacketTest
    {
        #region Constructor
        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithNoArguments()
        {
            var packet = new ImageFramePacket();
            var statusOrImageFrame = packet.Consume();

            Assert.AreEqual(packet.ValidateAsType().Code, Status.StatusCode.Internal);
            Assert.AreEqual(statusOrImageFrame.Status.Code, Status.StatusCode.Internal);
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithValue()
        {
            var srcImageFrame = new ImageFrame();
            var packet = new ImageFramePacket(srcImageFrame);

            Assert.True(srcImageFrame.IsDisposed);
            Assert.True(packet.ValidateAsType().ok);
            Assert.AreEqual(packet.Timestamp(), Timestamp.Unset());

            var statusOrImageFrame = packet.Consume();
            Assert.True(statusOrImageFrame.Ok);

            var imageFrame = statusOrImageFrame.Value();
            Assert.AreEqual(imageFrame.Format(), ImageFormat.Format.Unknown);
        }

        [Test]
        public void Ctor_ShouldInstantiatePacket_When_CalledWithValueAndTimestamp()
        {
            var srcImageFrame = new ImageFrame();
            var timestamp = new Timestamp(1);
            var packet = new ImageFramePacket(srcImageFrame, timestamp);

            Assert.True(srcImageFrame.IsDisposed);
            Assert.True(packet.ValidateAsType().ok);

            var statusOrImageFrame = packet.Consume();
            Assert.True(statusOrImageFrame.Ok);

            var imageFrame = statusOrImageFrame.Value();
            Assert.AreEqual(imageFrame.Format(), ImageFormat.Format.Unknown);
            Assert.AreEqual(packet.Timestamp(), timestamp);
        }
        #endregion

        #region #isDisposed
        [Test]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var packet = new ImageFramePacket();

            Assert.False(packet.IsDisposed);
        }

        [Test]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var packet = new ImageFramePacket();
            packet.Dispose();

            Assert.True(packet.IsDisposed);
        }
        #endregion

        #region #Get
        [Test, SignalAbort]
        public void Get_ShouldThrowMediaPipeException_When_DataIsEmpty()
        {
            var packet = new ImageFramePacket();

            Assert.Throws<MediapipeException>(() => { packet.Get(); });
        }

        public void Get_ShouldReturnImageFrame_When_DataIsNotEmpty()
        {
            var packet = new ImageFramePacket(new ImageFrame(ImageFormat.Format.Sbgra, 10, 10));
            var imageFrame = packet.Get();

            Assert.AreEqual(imageFrame.Format(), ImageFormat.Format.Sbgra);
            Assert.AreEqual(imageFrame.Width(), 10);
            Assert.AreEqual(imageFrame.Height(), 10);
        }
        #endregion

        #region #Consume
        [Test]
        public void Consume_ShouldReturnImageFrame()
        {
            var packet = new ImageFramePacket(new ImageFrame(ImageFormat.Format.Sbgra, 10, 10));
            var statusOrImageFrame = packet.Consume();
            Assert.True(statusOrImageFrame.Ok);

            var imageFrame = statusOrImageFrame.Value();
            Assert.AreEqual(imageFrame.Format(), ImageFormat.Format.Sbgra);
            Assert.AreEqual(imageFrame.Width(), 10);
            Assert.AreEqual(imageFrame.Height(), 10);
        }
        #endregion

        #region #DebugTypeName
        [Test]
        public void DebugTypeName_ShouldReturnFloat_When_ValueIsSet()
        {
            var packet = new ImageFramePacket(new ImageFrame());

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                Assert.AreEqual(packet.DebugTypeName(), "class mediapipe::ImageFrame");
            }
            else
            {
                Assert.AreEqual(packet.DebugTypeName(), "mediapipe::ImageFrame");
            }
        }
        #endregion
    }
}
