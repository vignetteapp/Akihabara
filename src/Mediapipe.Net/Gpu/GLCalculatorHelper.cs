// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;
using Mediapipe.Net.Native;
using Mediapipe.Net.Core;
using Mediapipe.Net.Framework.ImageFormat;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Gpu
{
    public class GlCalculatorHelper : MpResourceHandle
    {
        public delegate IntPtr NativeGlStatusFunction();

        public delegate Status GlStatusFunction();

        public GlCalculatorHelper() : base()
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__(out var ptr).Assert();

            Ptr = ptr;
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__delete(Ptr);
        }

        public void InitializeForTest(GpuResources gpuResources)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__InitializeForTest__Pgr(MpPtr, gpuResources.MpPtr).Assert();

            GC.KeepAlive(gpuResources);
            GC.KeepAlive(this);
        }

        public Status RunInGlContext(NativeGlStatusFunction nativeGlStatusFunction)
        {
            UnsafeNativeMethods
                .mp_GlCalculatorHelper__RunInGlContext__PF(MpPtr, nativeGlStatusFunction, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status RunInGlContext(GlStatusFunction glStatusFunction)
        {
            Status tmpStatus = null;

            IntPtr NativeGlStatusFunction()
            {
                try
                {
                    tmpStatus = glStatusFunction();
                }
                catch (Exception e)
                {
                    tmpStatus = Status.FailedPrecondition(e.ToString());
                }

                return tmpStatus.MpPtr;
            }

            var nativeGlStatusFuncHandle = GCHandle.Alloc((NativeGlStatusFunction)NativeGlStatusFunction, GCHandleType.Pinned);
            var status = RunInGlContext(NativeGlStatusFunction);
            nativeGlStatusFuncHandle.Free();

            tmpStatus?.Dispose();

            return status;
        }

        public GlTexture CreateSourceTexture(ImageFrame imageFrame)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__CreateSourceTexture__Rif(MpPtr, imageFrame.MpPtr, out var texPtr).Assert();

            GC.KeepAlive(this);
            GC.KeepAlive(imageFrame);
            return new GlTexture(texPtr);
        }

        public GlTexture CreateSourceTexture(GpuBuffer gpuBuffer)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__CreateSourceTexture__Rgb(MpPtr, gpuBuffer.MpPtr, out var texPtr).Assert();

            GC.KeepAlive(this);
            GC.KeepAlive(gpuBuffer);
            return new GlTexture(texPtr);
        }

        public GlTexture CreateSourceTexture(GpuBuffer gpuBuffer, int plane)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__CreateSourceTexture__Rgb_i(MpPtr, gpuBuffer.MpPtr, plane, out var texPtr).Assert();

            GC.KeepAlive(this);
            GC.KeepAlive(gpuBuffer);
            return new GlTexture(texPtr);
        }

        public GlTexture CreateDestinationTexture(int width, int height, GpuBufferFormat format)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__CreateDestinationTexture__i_i_ui(MpPtr, width, height, format, out var texPtr).Assert();

            GC.KeepAlive(this);
            return new GlTexture(texPtr);
        }

        public GlTexture CreateDestinationTexture(GpuBuffer gpuBuffer)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__CreateDestinationTexture__Rgb(MpPtr, gpuBuffer.MpPtr, out var texPtr).Assert();

            GC.KeepAlive(this);
            GC.KeepAlive(gpuBuffer);
            return new GlTexture(texPtr);
        }

        public uint Framebuffer => SafeNativeMethods.mp_GlCalculatorHelper__framebuffer(MpPtr);

        public void BindFramebuffer(GlTexture glTexture)
        {
            UnsafeNativeMethods.mp_GlCalculatorHelper__BindFrameBuffer__Rtexture(MpPtr, glTexture.MpPtr).Assert();

            GC.KeepAlive(glTexture);
            GC.KeepAlive(this);
        }

        public GlContext GetGlContext()
        {
            var glCtxPtr = SafeNativeMethods.mp_GlCalculatorHelper__GetGlContext(MpPtr);

            GC.KeepAlive(this);
            return new GlContext(glCtxPtr);
        }

        public bool Initialized => SafeNativeMethods.mp_GlCalculatorHelper__Initialized(MpPtr);
    }
}
