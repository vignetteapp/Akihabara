using Akihabara.Gpu;
using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GpuBuffer__GetGlTextureBufferSharedPtr(IntPtr gpuBuffer);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GpuBuffer__width(IntPtr gpuBuffer);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GpuBuffer__height(IntPtr gpuBuffer);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern GpuBufferFormat mp_GpuBuffer__format(IntPtr gpuBuffer);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_StatusOrGpuBuffer__ok(IntPtr statusOrGpuBuffer);
    }
}
