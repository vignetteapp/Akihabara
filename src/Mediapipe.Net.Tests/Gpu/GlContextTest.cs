// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Gpu;
using NUnit.Framework;

namespace Mediapipe.Net.Tests.Gpu
{
    [TestFixture]
    public class GlContextTest
    {
        #region GetCurrent
        [Test, GpuOnly]
        public void GetCurrent_ShouldReturnNull_When_CalledOutOfGlContext()
        {
            var glContext = GlContext.GetCurrent();

            Assert.Null(glContext);
        }

        [Test, GpuOnly]
        public void GetCurrent_ShouldReturnCurrentContext_When_CalledInGlContext()
        {
            var glCalculatorHelper = new GlCalculatorHelper();
            glCalculatorHelper.InitializeForTest(GpuResources.Create().Value());

            glCalculatorHelper.RunInGlContext(() => {
                var glContext = GlContext.GetCurrent();

                Assert.NotNull(glContext);
                Assert.True(glContext.IsCurrent);
                return Status.Ok();
            }).AssertOk();
        }
        #endregion

        #region IsCurrent
        public void IsCurrent_ShouldReturnFalse_When_CalledOutOfGlContext()
        {
            var glContext = GetGlContext();

            Assert.False(glContext.IsCurrent);
        }
        #endregion

        #region properties
        [Test, GpuOnly]
        public void ShouldReturnProperties()
        {
            var glContext = GetGlContext();

#if OPENGL_ES
            Assert.AreNotEqual(glContext.eglDisplay, IntPtr.Zero);
            Assert.AreNotEqual(glContext.eglConfig, IntPtr.Zero);
            Assert.AreNotEqual(glContext.eglContext, IntPtr.Zero);
            Assert.AreEqual(glContext.glMajorVersion, 3);
            Assert.AreEqual(glContext.glMinorVersion, 2);
            Assert.AreEqual(glContext.glFinishCount, 0);
#endif
        }
        #endregion

        private static GlContext GetGlContext()
        {
            GlContext glContext = null;

            var glCalculatorHelper = new GlCalculatorHelper();
            glCalculatorHelper.InitializeForTest(GpuResources.Create().Value());

            glCalculatorHelper.RunInGlContext(() => {
                glContext = GlContext.GetCurrent();
                return Status.Ok();
            }).AssertOk();

            return glContext;
        }
    }
}
