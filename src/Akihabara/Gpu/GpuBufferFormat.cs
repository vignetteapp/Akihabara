// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System.Runtime.InteropServices;
using Akihabara.Framework.ImageFormat;
using Akihabara.Native.Gpu;

namespace Akihabara.Gpu
{
    public enum GpuBufferFormat : uint
    {
        KUnknown = 0,
        KBgra32 = ('B' << 24) + ('G' << 16) + ('R' << 8) + ('A'),
        KGrayFloat32 = ('L' << 24) + ('0' << 16) + ('0' << 8) + ('f'),
        KGrayHalf16 = ('L' << 24) + ('0' << 16) + ('0' << 8) + ('h'),
        KOneComponent8 = ('L' << 24) + ('0' << 16) + ('0' << 8) + ('8'),
        KTwoComponentHalf16 = ('2' << 24) + ('C' << 16) + ('0' << 8) + ('h'),
        KTwoComponentFloat32 = ('2' << 24) + ('C' << 16) + ('0' << 8) + ('f'),
        KBiPlanar420YpCbCr8VideoRange = ('4' << 24) + ('2' << 16) + ('0' << 8) + ('v'),
        KBiPlanar420YpCbCr8FullRange = ('4' << 24) + ('2' << 16) + ('0' << 8) + ('f'),
        KRgb24 = 0x00000018, // Note: prefer BGRA32 whenever possible.
        KRgbaHalf64 = ('R' << 24) + ('G' << 16) + ('h' << 8) + ('A'),
        KRgbaFloat128 = ('R' << 24) + ('G' << 16) + ('f' << 8) + ('A'),
    }

    public static class GpuBufferFormatExtension
    {
        public static ImageFormat.Format ImageFormatFor(this GpuBufferFormat gpuBufferFormat)
        {
            return SafeNativeMethods.mp__ImageFormatForGpuBufferFormat__ui(gpuBufferFormat);
        }

        public static GlTextureInfo GlTextureInfoFor(this GpuBufferFormat gpuBufferFormat, int plane,
            GlVersion glVersion = GlVersion.KGles3)
        {
            UnsafeNativeMethods.mp__GlTextureInfoForGpuBufferFormat__ui_i_ui(gpuBufferFormat, plane, glVersion,
                out var glTextureInfoPtr);
            var glTextureInfo = Marshal.PtrToStructure<GlTextureInfo>(glTextureInfoPtr);
            UnsafeNativeMethods.mp_GlTextureInfo__delete(glTextureInfoPtr);

            return glTextureInfo;
        }
    }
}
