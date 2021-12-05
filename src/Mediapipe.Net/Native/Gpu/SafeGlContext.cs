// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        #region GlContext

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_SharedGlContext__get(IntPtr sharedGlContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__egl_display(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__egl_config(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__egl_context(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__eagl_context(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__nsgl_context(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlContext__nsgl_pixel_format(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_GlContext__IsCurrent(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GlContext__gl_major_version(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GlContext__gl_minor_version(IntPtr glContext);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern long mp_GlContext__gl_finish_count(IntPtr glContext);

        #endregion

        #region GlSyncToken

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern IntPtr mp_GlSyncToken__get(IntPtr glSyncToken);

        #endregion
    }
}
