// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GlTexture__width(IntPtr glTexture);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_GlTexture__height(IntPtr glTexture);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern uint mp_GlTexture__target(IntPtr glTexture);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern uint mp_GlTexture__name(IntPtr glTexture);
    }
}
