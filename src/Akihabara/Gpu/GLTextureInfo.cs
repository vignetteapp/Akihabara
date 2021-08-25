using System;
using System.Runtime.InteropServices;

namespace Akihabara.Gpu
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GlTextureInfo
    {
        public int glInternalFormat;
        public UInt32 glFormat;
        public UInt32 glType;
        public int downscale;        
    }
}