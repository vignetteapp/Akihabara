using System;

using Akihabara.Native;
using nf = Akihabara.Native.Framework;

namespace Akihabara.Framework.Port
{
    public class StatusOrPoller<T> : StatusOr<OutputStreamPoller<T>>
    {
        public StatusOrPoller(IntPtr Ptr) : base(Ptr)
        {
        }

        protected override void DeleteMpPtr()
        {
            nf.UnsafeNativeMethods.mp_StatusOrPoller__delete(Ptr);
        }

        public override bool Ok
        {
            get { return nf.SafeNativeMethods.mp_StatusOrPoller__ok(MpPtr); }
        }

        public override Status Status
        {
            get
            {
                nf.UnsafeNativeMethods.mp_StatusOrPoller__status(MpPtr, out var statusPtr).Assert();

                GC.KeepAlive(this);
                return new Status(statusPtr);
            }
        }

        public override OutputStreamPoller<T> Value()
        {
            nf.UnsafeNativeMethods.mp_StatusOrPoller__value(MpPtr, out var pollerPtr).Assert();
            Dispose();

            return new OutputStreamPoller<T>(pollerPtr);
        }
    }
}
