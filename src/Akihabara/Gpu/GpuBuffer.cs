// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Core;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Gpu
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
