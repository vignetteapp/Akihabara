// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Collections.Generic;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Framework.Protobuf;
using Mediapipe.Net.Native;

namespace Mediapipe.Net.Framework.Packet
{
    public class ClassificationListVectorPacket : Packet<List<ClassificationList>>
    {
        public ClassificationListVectorPacket() : base() { }
        public ClassificationListVectorPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override List<ClassificationList> Get()
        {
            UnsafeNativeMethods.mp_Packet__GetClassificationListVector(MpPtr, out var serializedProtoVectorPtr).Assert();
            GC.KeepAlive(this);

            var detections = External.Protobuf.DeserializeProtoVector<ClassificationList>(serializedProtoVectorPtr, ClassificationList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProtoVector__delete(serializedProtoVectorPtr);

            return detections;
        }

        public override StatusOr<List<ClassificationList>> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
