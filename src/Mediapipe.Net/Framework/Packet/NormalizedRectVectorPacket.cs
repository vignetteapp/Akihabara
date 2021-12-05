// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Collections.Generic;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Framework.Protobuf;
using Mediapipe.Net.Native;

namespace Mediapipe.Net.Framework.Packet
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
