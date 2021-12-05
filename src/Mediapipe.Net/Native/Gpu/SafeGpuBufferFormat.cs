// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Mediapipe.Net.Framework.ImageFormat;
using Mediapipe.Net.Gpu;

namespace Mediapipe.Net.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern ImageFormat.Format mp__ImageFormatForGpuBufferFormat__ui(GpuBufferFormat format);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern ImageFormat.Format mp__GpuBufferFormatForImageFormat__ui(ImageFormat.Format format);
    }
}
