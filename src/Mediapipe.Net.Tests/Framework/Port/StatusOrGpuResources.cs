// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Gpu;
using NUnit.Framework;

namespace Mediapipe.Net.Framework.Port
{
    [TestFixture]
    public class StatusOrGpuResourcesTest
    {
        #region #status
        [Test, GpuOnly]
        public void status_ShouldReturnOk_When_StatusIsOk()
        {
            var statusOrGpuResources = GpuResources.Create();

            Assert.AreEqual(statusOrGpuResources.Status.Code, Status.StatusCode.Ok);
        }
        #endregion

        #region #isDisposed
        [Test, GpuOnly]
        public void isDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var statusOrGpuResources = GpuResources.Create();

            Assert.False(statusOrGpuResources.IsDisposed);
        }

        [Test, GpuOnly]
        public void isDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var statusOrGpuResources = GpuResources.Create();
            statusOrGpuResources.Dispose();

            Assert.True(statusOrGpuResources.IsDisposed);
        }
        #endregion

        #region #Value
        [Test, GpuOnly]
        public void Value_ShouldReturnGpuResources_When_StatusIsOk()
        {
            var statusOrGpuResources = GpuResources.Create();
            Assert.True(statusOrGpuResources.Ok);

            var gpuResources = statusOrGpuResources.Value();
            Assert.IsInstanceOf<GpuResources>(gpuResources);
            Assert.True(statusOrGpuResources.IsDisposed);
        }
        #endregion
    }
}
