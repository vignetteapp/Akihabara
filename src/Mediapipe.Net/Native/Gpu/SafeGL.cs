// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Gpu
{
    internal partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary)]
        public static extern IntPtr eglGetCurrentContext();
    }
}
