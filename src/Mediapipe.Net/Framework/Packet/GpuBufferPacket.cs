// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Native;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Gpu;
using Mediapipe.Net.Native.Gpu;
using UnsafeNativeMethods = Mediapipe.Net.Native.Gpu.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework.Packet
{
    public class GpuBufferPacket : Packet<GpuBuffer>
    {
        public GpuBufferPacket() : base() { }
        public GpuBufferPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public GpuBufferPacket(GpuBuffer gpuBuffer) : base()
        {
            UnsafeNativeMethods.mp__MakeGpuBufferPacket__Rgb(gpuBuffer.MpPtr, out var ptr).Assert();
            gpuBuffer.Dispose(); // respect move semantics

            Ptr = ptr;
        }

        public GpuBufferPacket(GpuBuffer gpuBuffer, Timestamp timestamp)
        {
            UnsafeNativeMethods.mp__MakeGpuBufferPacket_At__Rgb_Rts(gpuBuffer.MpPtr, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            gpuBuffer.Dispose(); // respect move semantics

            Ptr = ptr;
        }

        public override GpuBuffer Get()
        {
            UnsafeNativeMethods.mp_Packet__GetGpuBuffer(MpPtr, out var gpuBufferPtr).Assert();

            GC.KeepAlive(this);
            return new GpuBuffer(gpuBufferPtr, false);
        }

        public override StatusOr<GpuBuffer> Consume()
        {
            UnsafeNativeMethods.mp_Packet__ConsumeGpuBuffer(MpPtr, out var statusOrGpuBufferPtr).Assert();

            GC.KeepAlive(this);
            return new StatusOrGpuBuffer(statusOrGpuBufferPtr);
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsGpuBuffer(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
