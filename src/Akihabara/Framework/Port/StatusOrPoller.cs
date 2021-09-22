// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Framework.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework.Port
{
    public class StatusOrPoller<T> : StatusOr<OutputStreamPoller<T>>
    {
        public StatusOrPoller(IntPtr Ptr) : base(Ptr)
        {
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrPoller__delete(Ptr);
        }

        public override bool Ok {
            get { return SafeNativeMethods.mp_StatusOrPoller__ok(MpPtr); }
        }

        public override Status Status {
            get {
                UnsafeNativeMethods.mp_StatusOrPoller__status(MpPtr, out var statusPtr).Assert();

                GC.KeepAlive(this);
                return new Status(statusPtr);
            }
        }

        public override OutputStreamPoller<T> Value()
        {
            UnsafeNativeMethods.mp_StatusOrPoller__value(MpPtr, out var pollerPtr).Assert();
            Dispose();

            return new OutputStreamPoller<T>(pollerPtr);
        }
    }
}
