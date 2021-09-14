using System;
using Akihabara.Core;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Gpu
{
    public class GlTexture : MpResourceHandle
    {
        public GlTexture() : base()
        {
            UnsafeNativeMethods.mp_GlTexture__(out var ptr).Assert();

            this.Ptr = ptr;
        }

        public GlTexture(uint name, int width, int height) : base()
        {
            UnsafeNativeMethods.mp_GlTexture__ui_i_i(name, width, height, out var ptr).Assert();

            this.Ptr = ptr;
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
