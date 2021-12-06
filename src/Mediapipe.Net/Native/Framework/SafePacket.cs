// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Framework
{
    internal partial class SafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_SidePacket__clear(IntPtr sidePacket);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_SidePacket__size(IntPtr sidePacket);
    }
}
