// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Gpu
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary)]
        public static extern void glFlush();

        [DllImport(MediaPipeLibrary)]
        public static extern void glReadPixels(int x, int y, int width, int height, uint glFormat, uint glType,
            IntPtr pixels);
    }
}
