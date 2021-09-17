using Akihabara.Framework.Port;
using Akihabara.Native;
using System;
using nf = Akihabara.Native.Framework;

namespace Akihabara.Framework.Packet
{
    public class IntPacket : Packet<int>
    {
        public IntPacket() : base() { }

        public IntPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public IntPacket(int value) : base()
        {
            nf.UnsafeNativeMethods.mp__MakeIntPacket__i(value, out var ptr).Assert();
            Ptr = ptr;
        }

        public IntPacket(int value, Timestamp timestamp) : base()
        {
            nf.UnsafeNativeMethods.mp__MakeIntPacket_At__i_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            Ptr = ptr;
        }

        public override int Get()
        {
            nf.UnsafeNativeMethods.mp_Packet__GetInt(MpPtr, out var value).Assert();

            GC.KeepAlive(this);
            return value;
        }

        public override StatusOr<int> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            nf.UnsafeNativeMethods.mp_Packet__ValidateAsInt(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
