// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System.Runtime.InteropServices;

namespace Mediapipe.Net.Gpu
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
