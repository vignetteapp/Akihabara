using System;
using Akihabara.Framework.Port;
using Akihabara.Native;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework.Packet
{
    public class FloatPacket : Packet<float>
    {
        public FloatPacket() : base() { }

        public FloatPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public FloatPacket(float value) : base()
        {
            UnsafeNativeMethods.mp__MakeFloatPacket__f(value, out var ptr).Assert();
            this.Ptr = ptr;
        }

        public FloatPacket(float value, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeFloatPacket_At__f_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            this.Ptr = ptr;
        }

        public override float Get()
        {
            UnsafeNativeMethods.mp_Packet__GetFloat(MpPtr, out var value).Assert();

            GC.KeepAlive(this);
            return value;
        }

        public override StatusOr<float> Consume()
        {
            // Yup. Not supported. Cf. BoolPacket.cs...
            // Maybe there's something to figure out here.
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsFloat(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
