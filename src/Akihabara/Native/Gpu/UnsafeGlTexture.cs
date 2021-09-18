// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__(out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode
            mp_GlTexture__ui_i_i(UInt32 name, int width, int height, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_GlTexture__delete(IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__Release(IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__GetGpuBufferFrame(IntPtr glTexture, out IntPtr gpuBuffer);
    }
}
