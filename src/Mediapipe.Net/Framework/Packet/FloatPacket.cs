// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Framework;
using UnsafeNativeMethods = Mediapipe.Net.Native.Framework.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework.Packet
{
    public class FloatPacket : Packet<float>
    {
        public FloatPacket() : base() { }

        public FloatPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public FloatPacket(float value) : base()
        {
            UnsafeNativeMethods.mp__MakeFloatPacket__f(value, out var ptr).Assert();
            Ptr = ptr;
        }

        public FloatPacket(float value, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeFloatPacket_At__f_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            Ptr = ptr;
        }

        public override float Get()
        {
            UnsafeNativeMethods.mp_Packet__GetFloat(MpPtr, out var value).Assert();

            GC.KeepAlive(this);
            return value;
        }

        public override StatusOr<float> Consume()
        {
            // Yup. Not supported. Cf. BoolPacket.cs...
            // Maybe there's something to figure out here.
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsFloat(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
