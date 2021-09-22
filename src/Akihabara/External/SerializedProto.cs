// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;

namespace Akihabara.External
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SerializedProto
    {
        public IntPtr str;
        public int length;
    }
}