using Akihabara.Gpu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  ng = Akihabara.Native.Gpu;
using Akihabara.Framework.Port;
using Akihabara.Native;

namespace Akihabara.Framework.Packet
{
    public class GpuBufferPacket : Packet<GpuBuffer>
    {
        public GpuBufferPacket() : base() { }
        public GpuBufferPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public GpuBufferPacket(GpuBuffer gpuBuffer) : base()
        {
            ng.UnsafeNativeMethods.mp__MakeGpuBufferPacket__Rgb(gpuBuffer.MpPtr, out var ptr).Assert();
            gpuBuffer.Dispose(); // respect move semantics

            this.Ptr = ptr;
        }

        public GpuBufferPacket(GpuBuffer gpuBuffer, Timestamp timestamp)
        {
            ng.UnsafeNativeMethods.mp__MakeGpuBufferPacket_At__Rgb_Rts(gpuBuffer.MpPtr, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            gpuBuffer.Dispose(); // respect move semantics

            this.Ptr = ptr;
        }

        public override GpuBuffer Get()
        {
            ng.UnsafeNativeMethods.mp_Packet__GetGpuBuffer(MpPtr, out var gpuBufferPtr).Assert();

            GC.KeepAlive(this);
            return new GpuBuffer(gpuBufferPtr, false);
        }

        public override StatusOr<GpuBuffer> Consume()
        {
            ng.UnsafeNativeMethods.mp_Packet__ConsumeGpuBuffer(MpPtr, out var statusOrGpuBufferPtr).Assert();

            GC.KeepAlive(this);
            return new StatusOrGpuBuffer(statusOrGpuBufferPtr);
        }

        public override Status ValidateAsType()
        {
            ng.UnsafeNativeMethods.mp_Packet__ValidateAsGpuBuffer(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
