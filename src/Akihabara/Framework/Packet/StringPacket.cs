// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;
using System.Runtime.InteropServices;
using Akihabara.Framework.Port;
using Akihabara.Native;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework.Packet
{
    public class StringPacket : Packet<string>
    {
        public StringPacket() : base() { }

        public StringPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public StringPacket(string value) : base()
        {
            UnsafeNativeMethods.mp__MakeStringPacket__PKc(value, out var ptr).Assert();
            this.Ptr = ptr;
        }

        public StringPacket(byte[] bytes) : base()
        {
            UnsafeNativeMethods.mp__MakeStringPacket__PKc_i(bytes, bytes.Length, out var ptr).Assert();
            this.Ptr = ptr;
        }

        public StringPacket(string value, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeStringPacket_At__PKc_Rt(value, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            this.Ptr = ptr;
        }

        public StringPacket(byte[] bytes, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeStringPacket_At__PKc_i_Rt(bytes, bytes.Length, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            this.Ptr = ptr;
        }

        public override string Get()
        {
            return MarshalStringFromNative(UnsafeNativeMethods.mp_Packet__GetString);
        }

        public byte[] GetByteArray()
        {
            UnsafeNativeMethods.mp_Packet__GetByteString(MpPtr, out var strPtr, out int size);
            GC.KeepAlive(this);

            var bytes = new byte[size];
            Marshal.Copy(strPtr, bytes, 0, size);
            Native.UnsafeNativeMethods.delete_array__PKc(strPtr);

            return bytes;
        }

        public override StatusOr<string> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsString(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
