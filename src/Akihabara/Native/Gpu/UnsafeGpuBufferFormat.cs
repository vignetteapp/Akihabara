using Akihabara.Gpu;
using System;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp__GlTextureInfoForGpuBufferFormat__ui_i_ui(
            GpuBufferFormat format, int plane, GlVersion glVersion, out IntPtr glTextureInfo);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_GlTextureInfo__delete(IntPtr glTextureInfo);
    }
}
