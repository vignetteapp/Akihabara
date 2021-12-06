// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Gpu
{
    internal partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__(out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode
            mp_GlTexture__ui_i_i(uint name, int width, int height, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_GlTexture__delete(IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__Release(IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlTexture__GetGpuBufferFrame(IntPtr glTexture, out IntPtr gpuBuffer);
    }
}
