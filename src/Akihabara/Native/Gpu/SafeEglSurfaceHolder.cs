// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    // in the original code this is usually for Linux and Android, as this is useful with GLES, but we probably want it too.
    // DO NOT CALL THIS METHODS if in desktop or in a non-Linux environment!
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_EglSurfaceHolderUniquePtr__get(IntPtr eglSurfaceHolder);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_EglSurfaceHolderUniquePtr__release(IntPtr eglSurfaceHolder);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_EglSurfaceHolder__flip_y(IntPtr eglSurfaceHolder);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_EglSurfaceHolder__SetFlipY__b(IntPtr eglSurfaceHolder, [MarshalAs(UnmanagedType.I1)] bool flipY);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_EglSurfaceHolder__flip(IntPtr eglSurfaceHolder);
    }
}
