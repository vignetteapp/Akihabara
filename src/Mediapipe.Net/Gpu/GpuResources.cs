// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Gpu
{
    public class GpuResources : MpResourceHandle
    {
        private SharedPtrHandle sharedPtrHandle;

        public GpuResources(IntPtr ptr) : base()
        {
            sharedPtrHandle = new GpuResourceSharedPtr(ptr);

            Ptr = sharedPtrHandle.Get();
        }

        protected override void DisposeManaged()
        {
            if (sharedPtrHandle != null)
            {
                sharedPtrHandle.Dispose();
                sharedPtrHandle = null;
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

        public IntPtr SharedPtr => sharedPtrHandle?.MpPtr ?? IntPtr.Zero;

        public static StatusOrGpuResources Create()
        {
            UnsafeNativeMethods.mp_GpuResources_Create(out IntPtr statusOrGpuResourcesPtr).Assert();

            return new StatusOrGpuResources(statusOrGpuResourcesPtr);
        }

        public static StatusOrGpuResources Create(IntPtr externalContext)
        {
            UnsafeNativeMethods.mp_GpuResources_Create__Pv(externalContext, out IntPtr statusOrGpuResourcesPtr).Assert();

            return new StatusOrGpuResources(statusOrGpuResourcesPtr);
        }

        public IntPtr IosGpuData => SafeNativeMethods.mp_GpuResources__ios_gpu_data(MpPtr);
    }

    internal class GpuResourceSharedPtr : SharedPtr
    {
        public GpuResourceSharedPtr(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.mp_StatusOrGpuResources__delete(Ptr);

        public override IntPtr Get() => SafeNativeMethods.mp_SharedGpuResources__get(MpPtr);

        public override void Reset() => UnsafeNativeMethods.mp_SharedGlContext__reset(MpPtr);
    }
}
