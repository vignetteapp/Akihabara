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
    public class GpuBuffer : MpResourceHandle
    {
        public GpuBuffer(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public GpuBuffer(GlTextureBuffer glTextureBuffer) : base()
        {
            UnsafeNativeMethods.mp_GpuBuffer__PSgtb(glTextureBuffer.SharedPtr, out var ptr).Assert();
            glTextureBuffer.Dispose();

            Ptr = ptr;
        }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.mp_GpuBuffer__delete(Ptr);

        public GlTextureBuffer GetGlTextureBuffer() =>
            new GlTextureBuffer(SafeNativeMethods.mp_GpuBuffer__GetGlTextureBufferSharedPtr(MpPtr),
                false);

        public GpuBufferFormat Format() => SafeNativeMethods.mp_GpuBuffer__format(MpPtr);

        public int Width() => SafeNativeMethods.mp_GpuBuffer__width(MpPtr);

        public int Height() => SafeNativeMethods.mp_GpuBuffer__height(MpPtr);
    }
}
