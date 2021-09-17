using Akihabara.Framework.Port;
using Akihabara.Framework.Protobuf;
using Akihabara.Native;
using System;
using System.Collections.Generic;

namespace Akihabara.Framework.Packet
{
    public class NormalizedLandmarkListVectorPacket : Packet<List<NormalizedLandmarkList>>
    {
        public NormalizedLandmarkListVectorPacket() : base() { }
        public NormalizedLandmarkListVectorPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override List<NormalizedLandmarkList> Get()
        {
            UnsafeNativeMethods.mp_Packet__GetNormalizedLandmarkListVector(MpPtr, out var serializedProtoVectorPtr).Assert();
            GC.KeepAlive(this);

            var normalizedLandmarkLists = External.Protobuf.DeserializeProtoVector<NormalizedLandmarkList>(serializedProtoVectorPtr, NormalizedLandmarkList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProtoVector__delete(serializedProtoVectorPtr);

            return normalizedLandmarkLists;
        }

        public override StatusOr<List<NormalizedLandmarkList>> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
