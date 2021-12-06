// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Gpu;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework.Port
{
    public class StatusOrGpuBuffer : StatusOr<GpuBuffer>
    {
        public StatusOrGpuBuffer(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrGpuBuffer__delete(Ptr);
        }

        public override bool Ok {
            get { return SafeNativeMethods.mp_StatusOrGpuBuffer__ok(MpPtr); }
        }

        public override Status Status {
            get {
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
