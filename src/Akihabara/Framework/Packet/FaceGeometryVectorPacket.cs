// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Collections.Generic;
using Akihabara.Framework.Port;
using Akihabara.Framework.Protobuf.FaceGeometry;
using Akihabara.Native;

namespace Akihabara.Framework.Packet
{
    public class FaceGeometryVectorPacket : Packet<List<FaceGeometry>>
    {
        public FaceGeometryVectorPacket() : base() { }
        public FaceGeometryVectorPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override List<FaceGeometry> Get()
        {
            UnsafeNativeMethods.mp_Packet__GetFaceGeometryVector(MpPtr, out var serializedProtoVectorPtr).Assert();
            GC.KeepAlive(this);

            var geometries = External.Protobuf.DeserializeProtoVector<FaceGeometry>(serializedProtoVectorPtr, FaceGeometry.Parser);
            UnsafeNativeMethods.mp_api_SerializedProtoVector__delete(serializedProtoVectorPtr);

            return geometries;
        }

        public override StatusOr<List<FaceGeometry>> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
