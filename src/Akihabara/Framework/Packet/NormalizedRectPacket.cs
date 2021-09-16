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
    public class NormalizedRectPacket : Packet<NormalizedRect>
    {
        public NormalizedRectPacket() : base() { }
        public NormalizedRectPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override NormalizedRect Get()
        {
            UnsafeNativeMethods.mp_Packet__GetNormalizedRect(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var normalizedRect = External.Protobuf.DeserializeProto<NormalizedRect>(serializedProtoPtr, NormalizedRect.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return normalizedRect;
        }

        public override StatusOr<NormalizedRect> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotImplementedException();
        }
    }
}
