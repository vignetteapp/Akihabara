using System;
using Akihabara.Core;
using Akihabara.Native.Gpu;

namespace Akihabara.Gpu
{
    internal class SharedPtr : SharedPtrHandle
    {
        public SharedPtr(IntPtr ptr) : base(ptr) {}

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_SharedGpuResources__delete(Ptr);
        }

        public override IntPtr Get()
        {
            return SafeNativeMethods.mp_SharedGpuResources__get(MpPtr);
        }

        public override void Reset()
        {
            UnsafeNativeMethods.mp_SharedGlContext__reset(MpPtr);
        }
    }
}