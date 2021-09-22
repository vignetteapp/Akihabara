// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    // in the original code this is usually for Linux and Android, as this is useful with GLES, but we probably want it too.
    // DO NOT CALL THIS METHODS if in desktop or in a non-Linux environment!
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary)]
        public static extern MpReturnCode mp_EglSurfaceHolderUniquePtr__(out IntPtr eglSurfaceHolder);

        [DllImport(MediaPipeLibrary)]
        public static extern void mp_EglSurfaceHolderUniquePtr__delete(IntPtr eglSurfaceHolder);

        [DllImport(MediaPipeLibrary)]
        public static extern MpReturnCode mp_EglSurfaceHolder__SetSurface__P_Pgc(
            IntPtr eglSurfaceHolder, IntPtr eglSurface, IntPtr glContext, out IntPtr status);

        [DllImport(MediaPipeLibrary)]
        public static extern MpReturnCode mp_MakeEglSurfaceHolderUniquePtrPacket__Reshup(IntPtr eglSurfaceHolder,
            out IntPtr packet);

        [DllImport(MediaPipeLibrary)]
        public static extern MpReturnCode mp_Packet__GetEglSurfaceHolderUniquePtr(IntPtr packet,
            out IntPtr eglSurfaceHolder);

        [DllImport(MediaPipeLibrary)]
        public static extern MpReturnCode mp_Packet__ValidateAsEglSurfaceHolderUniquePtr(IntPtr packet,
            out IntPtr status);
    }
}
