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
    public class GlTexture : MpResourceHandle
    {
        public GlTexture() : base()
        {
            UnsafeNativeMethods.mp_GlTexture__(out var ptr).Assert();

            Ptr = ptr;
        }

        public GlTexture(uint name, int width, int height) : base()
        {
            UnsafeNativeMethods.mp_GlTexture__ui_i_i(name, width, height, out var ptr).Assert();

            Ptr = ptr;
        }

        public GlTexture(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_GlTexture__delete(Ptr);
        }

        public int Width => SafeNativeMethods.mp_GlTexture__width(MpPtr);

        public int Height => SafeNativeMethods.mp_GlTexture__height(MpPtr);

        public uint Target => SafeNativeMethods.mp_GlTexture__target(MpPtr);

        public uint Name => SafeNativeMethods.mp_GlTexture__name(MpPtr);

        public void Release()
        {
            UnsafeNativeMethods.mp_GlTexture__Release(MpPtr).Assert();
            GC.KeepAlive(this);
        }

        public GpuBuffer GetGpuBufferFrame()
        {
            UnsafeNativeMethods.mp_GlTexture__GetGpuBufferFrame(MpPtr, out var gpuBufferPtr).Assert();

            GC.KeepAlive(this);
            return new GpuBuffer(gpuBufferPtr);
        }
    }
}
