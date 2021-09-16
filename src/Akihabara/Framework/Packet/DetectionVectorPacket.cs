using Akihabara.External;
using Akihabara.Framework.Port;
using Akihabara.Framework.Protobuf;
using Akihabara.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akihabara.Framework.Packet
{
    public class DetectionVectorPacket : Packet<List<Detection>>
    {
        public DetectionVectorPacket() : base() { }
        public DetectionVectorPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override List<Detection> Get()
        {
            UnsafeNativeMethods.mp_Packet__GetDetectionVector(MpPtr, out var serializedProtoVectorPtr).Assert();
            GC.KeepAlive(this);

            var detections = External.Protobuf.DeserializeProtoVector<Detection>(serializedProtoVectorPtr, Detection.Parser);
            UnsafeNativeMethods.mp_api_SerializedProtoVector__delete(serializedProtoVectorPtr);

            return detections;
        }

        public override StatusOr<List<Detection>> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
