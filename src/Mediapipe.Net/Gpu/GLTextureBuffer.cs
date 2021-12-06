// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Gpu
{
    public class GlTextureBuffer : MpResourceHandle
    {
        private SharedPtrHandle sharedPtrHandle;

        /// <remarks>
        ///  According to homuler, DeletionCallback should only recieve GlSyncToken.
        ///  As we are not shackled by the IL2CPP limitations that requires the texture name
        ///  to specify the instance, we will only use the GlSyncToken from now on.
        ///
        ///  TODO: UNTESTED! Please write proper unit tests to see if the behavior works.
        ///  See: https://git.io/JECPU
        /// </remarks>
        public delegate void DeletionCallback(IntPtr glSyncToken);

        public GlTextureBuffer(IntPtr ptr, bool isOwner = true) : base(isOwner)
        {
            sharedPtrHandle = new GlTextureBufferSharedPtr(ptr, isOwner);

            Ptr = sharedPtrHandle.Get();
        }

        public GlTextureBuffer(uint target, uint name, int width, int height, GpuBufferFormat format,
            DeletionCallback callback, GlContext context)
        {
            IntPtr sharedCtxPtr = context?.SharedPtr ?? IntPtr.Zero;
            UnsafeNativeMethods.mp_SharedGlTextureBuffer__ui_ui_i_i_ui_PF_PSgc(target, name, width, height, format,
                callback, sharedCtxPtr, out IntPtr ptr).Assert();

            sharedPtrHandle = new GlTextureBufferSharedPtr(ptr);
            base.Ptr = sharedPtrHandle.Get();
        }

        public GlTextureBuffer(uint name, int width, int height, GpuBufferFormat format, DeletionCallback callback,
            GlContext context = null) : this(Gl.GlTexture2D, name, width, height, format, callback, context)
        {
        }

        protected override void DisposeManaged()
        {
            if (sharedPtrHandle != null)
            {
                sharedPtrHandle.Dispose();
                sharedPtrHandle = null;
            }

            base.DisposeManaged();
        }

        /// <summary>
        /// This does nothing.
        /// </summary>
        protected override void DeleteMpPtr() { }

        public IntPtr SharedPtr => sharedPtrHandle?.MpPtr ?? IntPtr.Zero;

        public uint Name => SafeNativeMethods.mp_GlTextureBuffer__name(MpPtr);

        public uint Target => SafeNativeMethods.mp_GlTextureBuffer__target(MpPtr);

        public int Width => SafeNativeMethods.mp_GlTextureBuffer__width(MpPtr);

        public int Height => SafeNativeMethods.mp_GlTextureBuffer__height(MpPtr);

        public GpuBufferFormat Format => SafeNativeMethods.mp_GlTextureBuffer__format(MpPtr);

        public void WaitUntilComplete() => UnsafeNativeMethods.mp_GlTextureBuffer__WaitUntilComplete(MpPtr).Assert();

        public void WaitOnGpu() => UnsafeNativeMethods.mp_GlTextureBuffer__WaitOnGpu(MpPtr).Assert();

        public void Reuse() => UnsafeNativeMethods.mp_GlTextureBuffer__Reuse(MpPtr).Assert();

        public void Updated(GlSyncPoint prodToken) =>
            UnsafeNativeMethods.mp_GlTextureBuffer__Updated__Pgst(MpPtr, prodToken.SharedPtr).Assert();

        public void DidRead(GlSyncPoint consToken) =>
            UnsafeNativeMethods.mp_GlTextureBuffer__DidRead__Pgst(MpPtr, consToken.SharedPtr).Assert();

        public void WaitForConsumers() => UnsafeNativeMethods.mp_GlTextureBuffer__WaitForConsumers(MpPtr).Assert();

        public void WaitForConsumersOnGpu() => UnsafeNativeMethods.mp_GlTextureBuffer__WaitForConsumersOnGpu(MpPtr);

        public GlContext GetProducerContext() =>
            new(SafeNativeMethods.mp_GlTextureBuffer__GetProducerContext(MpPtr), false);
    }

    internal class GlTextureBufferSharedPtr : SharedPtr
    {
        public GlTextureBufferSharedPtr(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.mp_SharedGlTextureBuffer__delete(Ptr);

        public override IntPtr Get() => SafeNativeMethods.mp_SharedGlTextureBuffer__get(MpPtr);

        public override void Reset() => UnsafeNativeMethods.mp_SharedGlTextureBuffer__reset(MpPtr);
    }
}
