﻿using System;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Framework
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [Pure, DllImport(MediaPipeLibrary, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool mp_StatusOrPoller__ok(IntPtr statusOrPoller);
    }
}
