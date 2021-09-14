using System;
using Akihabara.External;
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

            var rect = Protobuf.DeserializeProto<ClassificationList>(serializedProtoPtr, ClassificationList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return rect;
        }

        public override StatusOr<ClassificationList> Consume()
        {
            throw new NotSupportedException();
        }
    }
}
