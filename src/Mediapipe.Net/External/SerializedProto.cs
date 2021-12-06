// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Mediapipe.Net.External
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SerializedProto
    {
        public IntPtr Str;
        public int Length;
    }
}
