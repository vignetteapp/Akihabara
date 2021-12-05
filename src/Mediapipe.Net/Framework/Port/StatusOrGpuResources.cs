// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Native;
using Mediapipe.Net.Gpu;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework.Port
{
    public class StatusOrGpuResources : StatusOr<GpuResources>
    {
        public StatusOrGpuResources(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrGpuResources__delete(Ptr);
        }

        public override bool Ok => SafeNativeMethods.mp_StatusOrGpuBuffer__ok(MpPtr);

        public override Status Status {
            get {
                UnsafeNativeMethods.mp_StatusOrGpuResources__status(MpPtr, out var statusPtr).Assert();

                GC.KeepAlive(this);
                return new Status(statusPtr);
            }
        }

        public override GpuResources Value()
        {
            UnsafeNativeMethods.mp_StatusOrGpuResources__value(MpPtr, out var gpuResourcesPtr).Assert();
            Dispose();

            return new GpuResources(gpuResourcesPtr);
        }
    }
}
