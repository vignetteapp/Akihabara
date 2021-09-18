// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Gpu
{
    public partial class UnsafeNativeMethods : NativeMethods
    {
        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_SharedGpuResources__delete(IntPtr gpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_SharedGpuResources__reset(IntPtr gpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GpuResources_Create(out IntPtr statusOrGpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_GpuResources_Create__Pv(IntPtr externalContext,
            out IntPtr statusOrGpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_StatusOrGpuResources__delete(IntPtr statusOrGpuResources);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_StatusOrGpuResources__status(IntPtr statusOrGpuResources,
            out IntPtr status);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_StatusOrGpuResources__value(IntPtr statusOrGpuResources,
            out IntPtr gpuResources);
    }
}
