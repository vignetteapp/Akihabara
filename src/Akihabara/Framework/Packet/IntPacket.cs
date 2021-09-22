// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Framework.Port;
using Akihabara.Native;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework.Packet
{
    public class IntPacket : Packet<int>
    {
        public IntPacket() : base() { }

        public IntPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public IntPacket(int value) : base()
        {
            UnsafeNativeMethods.mp__MakeIntPacket__i(value, out var ptr).Assert();
            Ptr = ptr;
        }

        public IntPacket(int value, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeIntPacket_At__i_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            Ptr = ptr;
        }

        public override int Get()
        {
            UnsafeNativeMethods.mp_Packet__GetInt(MpPtr, out var value).Assert();

            GC.KeepAlive(this);
            return value;
        }

        public override StatusOr<int> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsInt(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
