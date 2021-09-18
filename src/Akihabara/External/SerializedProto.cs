// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

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