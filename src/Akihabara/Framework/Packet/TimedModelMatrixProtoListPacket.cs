// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using Akihabara.Framework.Port;
using Akihabara.Framework.Protobuf;
using Akihabara.Native;
using System;

namespace Akihabara.Framework.Packet
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
