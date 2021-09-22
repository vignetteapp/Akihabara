// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Runtime.InteropServices;
using Akihabara.Gpu;

namespace Akihabara.Native.Gpu
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__(out IntPtr glCalculatorHelper);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_GlCalculatorHelper__delete(IntPtr glCalculatorHelper);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__InitializeForTest__Pgr(IntPtr glCalculatorHelper, IntPtr gpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__RunInGlContext__PF(
            IntPtr glCalculatorHelper, [MarshalAs(UnmanagedType.FunctionPtr)] GlCalculatorHelper.NativeGlStatusFunction glFunc, out IntPtr status);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__CreateSourceTexture__Rif(
            IntPtr glCalculatorHelper, IntPtr imageFrame, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__CreateSourceTexture__Rgb(
            IntPtr glCalculatorHelper, IntPtr gpuBuffer, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__CreateSourceTexture__Rgb_i(
            IntPtr glCalculatorHelper, IntPtr gpuBuffer, int plane, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__CreateDestinationTexture__i_i_ui(
            IntPtr glCalculatorHelper, int outputWidth, int outputHeight, GpuBufferFormat formatCode, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__CreateDestinationTexture__Rgb(
            IntPtr glCalculatorHelper, IntPtr gpuBuffer, out IntPtr glTexture);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GlCalculatorHelper__BindFrameBuffer__Rtexture(IntPtr glCalculatorHelper, IntPtr glTexture);
    }
}
