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
    public class NormalizedRectVectorPacket : Packet<List<NormalizedRect>>
    {
        public NormalizedRectVectorPacket() : base() { }
        public NormalizedRectVectorPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override List<NormalizedRect> Get()
        {
            UnsafeNativeMethods.mp_Packet__GetNormalizedRectVector(MpPtr, out var serializedProtoVectorPtr).Assert();
            GC.KeepAlive(this);

            var normalizedRects = External.Protobuf.DeserializeProtoVector<NormalizedRect>(serializedProtoVectorPtr, NormalizedRect.Parser);
            UnsafeNativeMethods.mp_api_SerializedProtoVector__delete(serializedProtoVectorPtr);

            return normalizedRects;
        }

        public override StatusOr<List<NormalizedRect>> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
