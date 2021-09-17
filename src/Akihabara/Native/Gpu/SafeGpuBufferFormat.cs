using Akihabara.Framework.ImageFormat;
using Akihabara.Gpu;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern ImageFormat.Format mp__ImageFormatForGpuBufferFormat__ui(GpuBufferFormat format);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern ImageFormat.Format mp__GpuBufferFormatForImageFormat__ui(ImageFormat.Format format);
    }
}
