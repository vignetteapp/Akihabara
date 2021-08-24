using System;
using Akihabara.Gpu;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Framework.Port
{
    public class StatusOrGpuResources : StatusOr<GpuResources>
    {
        public StatusOrGpuResources(IntPtr ptr) : base(ptr) {}

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrGpuResources__delete(Ptr);
        }

        public override bool Ok => SafeNativeMethods.mp_StatusOrGpuBuffer__ok(MpPtr);

        public override Status status
        {
            get
            {
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