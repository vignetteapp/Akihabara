using System;
using Akihabara.Core;
using Akihabara.Native;

namespace Akihabara.External
{
    public class StdString : MpResourceHandle
    {
        public StdString(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner)
        {
        }

        public StdString(byte[] bytes) : base()
        {
            UnsafeNativeMethods.std_string__PKc_i(bytes, bytes.Length, out var ptr);
            this.Ptr = ptr;
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.std_string__delete(Ptr);
        }

        public void Swap(StdString str)
        {
            UnsafeNativeMethods.std_string__swap__Rstr(MpPtr, str.MpPtr);
            GC.KeepAlive(this);
        }
    }
}