// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Framework.Protobuf;
using Mediapipe.Net.Native;

namespace Mediapipe.Net.Framework.Packet
{
    public class NormalizedLandmarkListPacket : Packet<NormalizedLandmarkList>
    {
        public NormalizedLandmarkListPacket() : base() { }
        public NormalizedLandmarkListPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override NormalizedLandmarkList Get()
        {
            UnsafeNativeMethods.mp_Packet__GetNormalizedLandmarkList(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var normalizedLandmarkList = External.Protobuf.DeserializeProto<NormalizedLandmarkList>(serializedProtoPtr, NormalizedLandmarkList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return normalizedLandmarkList;
        }

        public override StatusOr<NormalizedLandmarkList> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
