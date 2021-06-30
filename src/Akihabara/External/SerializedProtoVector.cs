using System;
using System.Runtime.InteropServices;

namespace Akihabara.External
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SerializedProtoVector
    {
        public IntPtr data;
        public int size;
    }
}