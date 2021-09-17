using Akihabara.Native.Gpu;
using System;

namespace Akihabara.Gpu
{
    public class Gl
    {
        public static uint glTexture2D = 0x0DE1;

        public static void Flush()
        {
            UnsafeNativeMethods.glFlush();
        }

        public static void ReadPixels(int x, int y, int width, int height, uint glFormat, uint glType,
            IntPtr pixels)
        {
            UnsafeNativeMethods.glReadPixels(x, y, width, height, glFormat, glType, pixels);
        }
    }
}