// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using Akihabara.Framework;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Port;
using Akihabara.Framework.ImageFormat;
using NUnit.Framework;

namespace Tests
{
    public class StatusOrImageFrameTest
    {
        #region #status
        [Test]
        public void status_ShouldReturnOk_When_StatusIsOk()
        {
            var statusOrImageFrame = InitializeSubject();

            Assert.True(statusOrImageFrame.Ok);
            Assert.AreEqual(statusOrImageFrame.Status.Code, Status.StatusCode.Ok);
        }
        #endregion

        #region #isDisposed
        [Test]
        public void isDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var statusOrImageFrame = InitializeSubject();

            Assert.False(statusOrImageFrame.IsDisposed);
        }

        [Test]
        public void isDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var statusOrImageFrame = InitializeSubject();
            statusOrImageFrame.Dispose();

            Assert.True(statusOrImageFrame.IsDisposed);
        }
        #endregion

        #region #Value
        [Test]
        public void Value_ShouldReturnImageFrame_When_StatusIsOk()
        {
            var statusOrImageFrame = InitializeSubject();
            Assert.True(statusOrImageFrame.Ok);

            var imageFrame = statusOrImageFrame.Value();
            Assert.AreEqual(imageFrame.Width(), 10);
            Assert.AreEqual(imageFrame.Height(), 10);
            Assert.True(statusOrImageFrame.IsDisposed);
        }
        #endregion

        private StatusOrImageFrame InitializeSubject()
        {
            var imageFrame = new ImageFrame(ImageFormat.Format.Sbgra, 10, 10);
            var packet = new ImageFramePacket(imageFrame, new Timestamp(1));

            return (StatusOrImageFrame)packet.Consume();
        }
    }
}
