// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Framework;
using Mediapipe.Net.Framework.ImageFormat;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Framework.Port;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
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

        private static StatusOrImageFrame InitializeSubject()
        {
            var imageFrame = new ImageFrame(ImageFormat.Format.Sbgra, 10, 10);
            var packet = new ImageFramePacket(imageFrame, new Timestamp(1));

            return (StatusOrImageFrame)packet.Consume();
        }
    }
}
