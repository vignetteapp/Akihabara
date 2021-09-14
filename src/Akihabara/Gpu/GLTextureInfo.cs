using System.Runtime.InteropServices;

namespace Akihabara.Gpu
{
    [StructLayout(LayoutKind.Sequential)]
    public struct GlTextureInfo
    {
        public int glInternalFormat;
        public uint glFormat;
        public uint glType;
        public int downscale;
    }
}
