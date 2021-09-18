// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

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
