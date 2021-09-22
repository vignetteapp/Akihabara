// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Framework.Port;
using Akihabara.Native;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework.Packet
{
    public class BoolPacket : Packet<bool>
    {
        public BoolPacket() : base() { }

        public BoolPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public BoolPacket(bool value) : base()
        {
            UnsafeNativeMethods.mp__MakeBoolPacket__b(value, out var ptr).Assert();

            Ptr = ptr;
        }

        public BoolPacket(bool value, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeBoolPacket_At__b_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            Ptr = ptr;
        }

        public override bool Get()
        {
            UnsafeNativeMethods.mp_Packet__GetBool(MpPtr, out var val).Assert();

            GC.KeepAlive(this);
            return val;
        }

        // This is not supported for some reason...
        // oh well...
        public override StatusOr<bool> Consume()
        {
            // if you ever managed to encounter this, god save your soul.
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsBool(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
