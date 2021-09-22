// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Core;
using Akihabara.Framework.Port;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Gpu
{
    public class GpuResources : MpResourceHandle
    {
        private SharedPtrHandle _sharedPtrHandle;

        public GpuResources(IntPtr ptr) : base()
        {
            _sharedPtrHandle = new GpuResourceSharedPtr(ptr);

            Ptr = _sharedPtrHandle.Get();
        }

        protected override void DisposeManaged()
        {
            if (_sharedPtrHandle != null)
            {
                _sharedPtrHandle.Dispose();
                _sharedPtrHandle = null;
            }
            base.DisposeManaged();
        }

        protected override void DeleteMpPtr()
        {
            // This is supposed to do nothing
            // if it does anything please let me know
            // because I will donate my life savings to the HoloCouncil
            // actually I won't because I have to care about a roof
            // if you are seeing this please help me this is a call for help
        }

        public IntPtr SharedPtr => _sharedPtrHandle?.MpPtr ?? IntPtr.Zero;

        public static StatusOrGpuResources Create()
        {
            UnsafeNativeMethods.mp_GpuResources_Create(out var statusOrGpuResourcesPtr).Assert();

            return new StatusOrGpuResources(statusOrGpuResourcesPtr);
        }

        public static StatusOrGpuResources Create(IntPtr externalContext)
        {
            UnsafeNativeMethods.mp_GpuResources_Create__Pv(externalContext, out var statusOrGpuResourcesPtr).Assert();

            return new StatusOrGpuResources(statusOrGpuResourcesPtr);
        }

        public IntPtr IosGpuData => SafeNativeMethods.mp_GpuResources__ios_gpu_data(MpPtr);
    }

    internal class GpuResourceSharedPtr : SharedPtr
    {
        public GpuResourceSharedPtr(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrGpuResources__delete(MpPtr);
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
