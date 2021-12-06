// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native
{
    internal partial class SafeNativeMethods : NativeMethods
    {
        #region ABSL

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool absl_Status__ok(IntPtr status);

        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int absl_Status__raw_code(IntPtr status);

        #endregion

    }
}
