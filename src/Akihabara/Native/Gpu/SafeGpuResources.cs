using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        // HACK: ONLY CALL THIS IF YOU'RE DOING iOS STUFF!
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GpuResources__ios_gpu_data(IntPtr gpuResources);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_SharedGpuResources__get(IntPtr gpuResources);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_StatusOrGpuResources__ok(IntPtr statusOrGpuResources);
    }
}
