using Akihabara.Framework.Port;
using Akihabara.Framework.Protobuf;
using Akihabara.Native;
using System;

namespace Akihabara.Framework.Packet
{
    public class DetectionPacket : Packet<Detection>
    {
        public DetectionPacket() : base() { }
        public DetectionPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override Detection Get()
        {
            UnsafeNativeMethods.mp_Packet__GetDetection(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var detection = External.Protobuf.DeserializeProto<Detection>(serializedProtoPtr, Detection.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return detection;
        }

        public override StatusOr<Detection> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
