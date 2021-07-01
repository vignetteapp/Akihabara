using System;
using System.Buffers.Text;
using Akihabara.Framework.Port;
using Akihabara.Native.Framework;

namespace Akihabara.Framework.Packet
{
    public class BoolPacket : Packet<bool>
    {
        public BoolPacket() : base() {}
        
        public BoolPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) {}

        public BoolPacket(bool value) : base()
        {
            UnsafeNativeMethods.mp__MakeBoolPacket__b(value, out var ptr);

            this.Ptr = ptr;
        }

        public override bool Get()
        {
            UnsafeNativeMethods.mp_Packet__GetBool(MpPtr, out var val);
            
            GC.KeepAlive(this);
            return val;
        }
        
        // This is not supported for some reason...
        // oh well...
        public override StatusOr<bool> Consume()
        {
            // if you ever managed to encounter this, god save your soul.
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsBool(MpPtr, out var statusPtr);
            
            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}