// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.Native.Framework
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_api__ConvertFromCalculatorGraphConfigTextFormat(string configText, out IntPtr serializedProto);
    }
}
