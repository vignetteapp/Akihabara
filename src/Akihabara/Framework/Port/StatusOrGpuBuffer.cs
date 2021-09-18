// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;
using Akihabara.Gpu;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Framework.Port
{
    public class StatusOrGpuBuffer : StatusOr<GpuBuffer>
    {
        public StatusOrGpuBuffer(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrGpuBuffer__delete(Ptr);
        }

        public override bool Ok
        {
            get { return SafeNativeMethods.mp_StatusOrGpuBuffer__ok(MpPtr); }
        }

        public override Status Status
        {
            get
            {
                UnsafeNativeMethods.mp_StatusOrGpuBuffer__status(MpPtr, out var statusPtr).Assert();

                GC.KeepAlive(this);
                return new Status(statusPtr);
            }
        }

        public override GpuBuffer Value()
        {
            UnsafeNativeMethods.mp_StatusOrGpuBuffer__value(MpPtr, out var gpuBufferPtr).Assert();
            Dispose();

            return new GpuBuffer(gpuBufferPtr);
        }
    }
}
