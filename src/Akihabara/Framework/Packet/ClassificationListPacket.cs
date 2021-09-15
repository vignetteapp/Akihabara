using System;
using Akihabara.Framework.Protobuf;
using Akihabara.Framework.Port;
using Akihabara.Native;

namespace Akihabara.Framework.Packet
{
    public class ClassificationListPacket : Packet<ClassificationList>
    {
        public ClassificationListPacket() : base() { }
        public ClassificationListPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override ClassificationList Get()
        {
            UnsafeNativeMethods.mp_Packet__GetClassificationList(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var rect = External.Protobuf.DeserializeProto<ClassificationList>(serializedProtoPtr, ClassificationList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return rect;
        }

        public override StatusOr<ClassificationList> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            /*
            // This won't work as ValidateAsClassificationList doesn't exist as a C binding.
            // However, I suspect that it exists somewhere in Mediapipe, and if so, we can bind it ourselves.
            UnsafeNativeMethods.mp_Packet__ValidateAsClassificationList(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
            */

            throw new NotSupportedException();
        }
    }
}
