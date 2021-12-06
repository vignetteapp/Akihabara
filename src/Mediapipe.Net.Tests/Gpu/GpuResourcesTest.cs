// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Gpu;
using NUnit.Framework;

namespace Mediapipe.Net.Tests
{
    [TestFixture]
    public class GpuResourcesTest
    {
        #region Create
        [Test, GpuOnly]
        public void Create_ShouldReturnStatusOrGpuResources()
        {
            var statusOrGpuResources = GpuResources.Create();

            Assert.True(statusOrGpuResources.Ok);
        }
        #endregion

        #region IsDisposed
        [Test, GpuOnly]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var gpuResources = GpuResources.Create().Value();

            Assert.False(gpuResources.IsDisposed);
        }

        [Test, GpuOnly]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var gpuResources = GpuResources.Create().Value();
            gpuResources.Dispose();

            Assert.True(gpuResources.IsDisposed);
        }
        #endregion
    }
}
