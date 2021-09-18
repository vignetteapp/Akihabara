// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using Akihabara.Framework.ImageFormat;
using Akihabara.Gpu;

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
