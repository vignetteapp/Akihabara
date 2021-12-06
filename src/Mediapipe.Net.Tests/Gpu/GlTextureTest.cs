// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Gpu;
using NUnit.Framework;

namespace Mediapipe.Net.Tests.Gpu
{
    [TestFixture]
    public class GlTextureTest
    {
        #region Constructor
        [Test, GpuOnly]
        public void Ctor_ShouldInstantiateGlTexture_When_CalledWithNoArguments()
        {
            var glTexture = new GlTexture();

            Assert.AreEqual(glTexture.Width, 0);
            Assert.AreEqual(glTexture.Height, 0);
        }

        [Test, GpuOnly]
        public void Ctor_ShouldInstantiateGlTexture_When_CalledWithNameAndSize()
        {
            var glTexture = new GlTexture(1, 100, 100);

            Assert.AreEqual(glTexture.Name, 1);
            Assert.AreEqual(glTexture.Width, 100);
            Assert.AreEqual(glTexture.Height, 100);
        }
        #endregion

        #region IsDisposed
        [Test, GpuOnly]
        public void IsDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var glTexture = new GlTexture();

            Assert.False(glTexture.IsDisposed);
        }

        [Test, GpuOnly]
        public void IsDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var glTexture = new GlTexture();
            glTexture.Dispose();

            Assert.True(glTexture.IsDisposed);
        }
        #endregion

        #region Target
        [Test, GpuOnly]
        public void Target_ShouldReturnTarget()
        {
            var glTexture = new GlTexture();

            Assert.AreEqual(glTexture.Target, Gl.GlTexture2D);
        }
        #endregion
    }
}
