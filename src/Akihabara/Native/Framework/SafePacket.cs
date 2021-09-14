using System;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Framework
{
    public partial class SafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_SidePacket__clear(IntPtr sidePacket);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern int mp_SidePacket__size(IntPtr sidePacket);
    }
}
