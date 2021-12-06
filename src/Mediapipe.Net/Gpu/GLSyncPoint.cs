// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Gpu;
using SafeNativeMethods = Mediapipe.Net.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Gpu
{
    public class GlSyncPoint : MpResourceHandle
    {
        private SharedPtrHandle sharedPtrHandle;

        public GlSyncPoint(IntPtr ptr) : base(ptr)
        {
            sharedPtrHandle = new GlSyncPointSharedPtr(ptr);

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

        /// <summary>
        /// This will do nothing
        /// </summary>
        protected override void DeleteMpPtr() { }

        public IntPtr SharedPtr => sharedPtrHandle?.MpPtr ?? IntPtr.Zero;

        public void Wait() => UnsafeNativeMethods.mp_GlSyncPoint__Wait(MpPtr).Assert();

        public void WaitOnGpu() => UnsafeNativeMethods.mp_GlSyncPoint__WaitOnGpu(MpPtr).Assert();

        public bool IsReady()
        {
            UnsafeNativeMethods.mp_GlSyncPoint__IsReady(MpPtr, out bool val).Assert();

            GC.KeepAlive(this);
            return val;
        }

        public GlContext GetContext()
        {
            UnsafeNativeMethods.mp_GlSyncPoint__GetContext(MpPtr, out IntPtr sharedGlContextPtr).Assert();

            GC.KeepAlive(this);
            return new GlContext(sharedGlContextPtr);
        }

    }

    internal class GlSyncPointSharedPtr : SharedPtr
    {
        public GlSyncPointSharedPtr(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.mp_GlSyncToken__delete(Ptr);

        public override IntPtr Get() => SafeNativeMethods.mp_GlSyncToken__get(MpPtr);

        public override void Reset() => UnsafeNativeMethods.mp_GlSyncToken__reset(MpPtr);
    }
}
