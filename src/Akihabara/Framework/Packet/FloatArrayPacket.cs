// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using Akihabara.Framework.Port;
using nf = Akihabara.Native.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akihabara.Native;

namespace Akihabara.Framework.Packet
{
    public class FloatArrayPacket : Packet<float[]>
    {
        int _Length = -1;

        public int Length
        {
            get { return _Length; }
            set
            {
                if (_Length >= 0)
                {
                    throw new InvalidOperationException("Length is already set and cannot be changed");
                }

                _Length = value;
            }
        }

        public FloatArrayPacket() : base() { }

        public FloatArrayPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public FloatArrayPacket(float[] value) : base()
        {
            nf.UnsafeNativeMethods.mp__MakeFloatArrayPacket__Pf_i(value, value.Length, out var ptr).Assert();
            this.Ptr = ptr;
            Length = value.Length;
        }

        public FloatArrayPacket(float[] value, Timestamp timestamp) : base()
        {
            nf.UnsafeNativeMethods.mp__MakeFloatArrayPacket_At__Pf_i_Rt(value, value.Length, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            this.Ptr = ptr;
            Length = value.Length;
        }

        public override float[] Get()
        {
            if (Length < 0)
            {
                throw new InvalidOperationException("The array's length is unknown, set Length first");
            }

            var result = new float[Length];

            unsafe
            {
                float* src = (float*)GetArrayPtr();

                for (var i = 0; i < result.Length; i++)
                {
                    result[i] = *src++;
                }
            }

            return result;
        }

        public IntPtr GetArrayPtr()
        {
            nf.UnsafeNativeMethods.mp_Packet__GetFloatArray(MpPtr, out var value).Assert();
            GC.KeepAlive(this);
            return value;
        }

        public override StatusOr<float[]> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            nf.UnsafeNativeMethods.mp_Packet__ValidateAsFloatArray(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
