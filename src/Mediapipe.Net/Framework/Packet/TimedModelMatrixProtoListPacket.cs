// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Framework.Protobuf;
using Mediapipe.Net.Native;

namespace Mediapipe.Net.Framework.Packet
{
    public class TimedModelMatrixProtoListPacket : Packet<TimedModelMatrixProtoList>
    {
        public TimedModelMatrixProtoListPacket() : base() { }
        public TimedModelMatrixProtoListPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public override TimedModelMatrixProtoList Get()
        {
            UnsafeNativeMethods.mp_Packet__GetTimedModelMatrixProtoList(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var matrixProtoList = External.Protobuf.DeserializeProto<TimedModelMatrixProtoList>(serializedProtoPtr, TimedModelMatrixProtoList.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return matrixProtoList;
        }

        public override StatusOr<TimedModelMatrixProtoList> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            throw new NotSupportedException();
        }
    }
}
