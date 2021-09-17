#if OPENGL_ES
using Akihabara.Gpu;
using Akihabara.Framework.Port;
using NUnit.Framework;
using System;

namespace Akihabara.Tests.Gpu
{
    public class EglSurfaceHolderTest
    {
        #region Constructor
        [Test, GpuOnly]
        public void Ctor_ShouldInstantiateEglSurfaceHolder()
        {
            var eglSurfaceHolder = new EglSurfaceHolder();

            Assert.False(eglSurfaceHolder.FlipY());
        }
        #endregion

        #region #isDisposed
        [Test, GpuOnly]
        public void isDisposed_ShouldReturnFalse_When_NotDisposedYet()
        {
            var eglSurfaceHolder = new EglSurfaceHolder();

            Assert.False(eglSurfaceHolder.isDisposed);
        }

        [Test, GpuOnly]
        public void isDisposed_ShouldReturnTrue_When_AlreadyDisposed()
        {
            var eglSurfaceHolder = new EglSurfaceHolder();
            eglSurfaceHolder.Dispose();

            Assert.True(eglSurfaceHolder.isDisposed);
        }
        #endregion

        #region #SetFlipY
        [Test, GpuOnly]
        public void SetFilpY_ShouldSetFlipY()
        {
            var eglSurfaceHolder = new EglSurfaceHolder();
            eglSurfaceHolder.SetFlipY(true);

            Assert.True(eglSurfaceHolder.FlipY());
        }
        #endregion

        #region #SetSurface
        void ExpectSetSurfaceOk(IntPtr surface)
        {
            var eglSurfaceHolder = new EglSurfaceHolder();
            var glCalculatorHelper = new GlCalculatorHelper();
            glCalculatorHelper.InitializeForTest(GpuResources.Create().Value());

            var status = glCalculatorHelper.RunInGlContext(() =>
            {
                var glContext = GlContext.GetCurrent();
                eglSurfaceHolder.SetSurface(surface, glContext);

                return Status.Ok();
            });

            Assert.True(status.ok);
        }

        [Test, GpuOnly]
        public void SetSurface_ShouldSetSurface_When_SurfaceIsEglNoSurface()
        {
            ExpectSetSurfaceOk(IntPtr.Zero);
        }

        /*
        // This is a Unity-specific test. I don't know what we can use as an equivalent of Texture2D.
        [Test, GpuOnly]
        public void SetSurface_ShouldSetSurface_When_SurfaceExists()
        {
            var texture = new Texture2D(10, 10);

            ExpectSetSurfaceOk(texture.GetNativeTexturePtr());
        }
        */
        #endregion
    }
}
#endif
