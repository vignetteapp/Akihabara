using System;
using System.Runtime.InteropServices;

using Google.Protobuf;
using Akihabara.Core;
using Akihabara.Framework.Port;
using Akihabara.Framework.Packet;
using Akihabara.Framework.Protobuf;
using Akihabara.Gpu;
using Akihabara.Native;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;
using SafeNativeMethods = Akihabara.Native.Framework.SafeNativeMethods;

namespace Akihabara.Framework
{
    public class CalculatorGraph : MpResourceHandle
    {
        public delegate IntPtr NativePacketCallback(IntPtr packetPtr);
        public delegate Status PacketCallback<T, TU>(T packet) where T : Packet<TU>;

        public CalculatorGraph() : base()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__(out var ptr).Assert();
            this.Ptr = ptr;
        }

        public CalculatorGraph(string textFormatConfig) : base()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__PKc(textFormatConfig, out var ptr).Assert();
            this.Ptr = ptr;
        }

        public CalculatorGraph(byte[] serializedConfig) : base()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__PKc_i(serializedConfig, serializedConfig.Length, out var ptr).Assert();
            this.Ptr = ptr;
        }

        public CalculatorGraph(CalculatorGraphConfig config) : this(config.ToByteArray()) { }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.mp_CalculatorGraph__delete(Ptr);

        public Status Initialize(CalculatorGraphConfig config)
        {
            var bytes = config.ToByteArray();
            UnsafeNativeMethods.mp_CalculatorGraph__Initialize__PKc_i(MpPtr, bytes, bytes.Length, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status Initialize(CalculatorGraphConfig config, SidePacket sidePacket)
        {
            var bytes = config.ToByteArray();
            UnsafeNativeMethods.mp_CalculatorGraph__Initialize__PKc_i_Rsp(MpPtr, bytes, bytes.Length, sidePacket.MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        /// <remarks>Crashes if config is not set</remarks>
        public CalculatorGraphConfig Config()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__Config(MpPtr, out var serializedProtoPtr).Assert();
            GC.KeepAlive(this);

            var config = External.Protobuf.DeserializeProto<CalculatorGraphConfig>(serializedProtoPtr, CalculatorGraphConfig.Parser);
            Native.UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return config;
        }

        public Status ObserveOutputStream(string streamName, NativePacketCallback nativePacketCallback)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__ObserveOutputStream__PKc_PF(MpPtr, streamName, nativePacketCallback, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status ObserveOutputStream<T, TU>(string streamName, PacketCallback<T, TU> packetCallback, out GCHandle callbackHandle) where T : Packet<TU>
        {
            NativePacketCallback nativePacketCallback = (IntPtr packetPtr) =>
            {
                Status status = null;
                try
                {
                    T packet = (T)Activator.CreateInstance(typeof(T), packetPtr, false);
                    status = packetCallback(packet);
                }
                catch (Exception e)
                {
                    status = Status.FailedPrecondition(e.ToString());
                }
                return status.MpPtr;
            };
            callbackHandle = GCHandle.Alloc(nativePacketCallback, GCHandleType.Pinned);

            return ObserveOutputStream(streamName, nativePacketCallback);
        }

        public StatusOrPoller<T> AddOutputStreamPoller<T>(string streamName)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__AddOutputStreamPoller__PKc(MpPtr, streamName, out var statusOrPollerPtr).Assert();

            GC.KeepAlive(this);
            return new StatusOrPoller<T>(statusOrPollerPtr);
        }

        public Status Run() => Run(new SidePacket());

        public Status Run(SidePacket sidePacket)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__Run__Rsp(MpPtr, sidePacket.MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(sidePacket);
            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status StartRun() => StartRun(new SidePacket());

        public Status StartRun(SidePacket sidePacket)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__StartRun__Rsp(MpPtr, sidePacket.MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(sidePacket);
            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status WaitUntilIdle()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__WaitUntilIdle(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status WaitUntilDone()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__WaitUntilDone(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public bool HasError() => SafeNativeMethods.mp_CalculatorGraph__HasError(MpPtr);

        public Status AddPacketToInputStream<T>(string streamName, Packet<T> packet)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__AddPacketToInputStream__PKc_Ppacket(MpPtr, streamName, packet.MpPtr, out var statusPtr).Assert();
            packet.Dispose(); // respect move semantics

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status SetInputStreamMaxQueueSize(string streamName, int maxQueueSize)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__SetInputStreamMaxQueueSize__PKc_i(MpPtr, streamName, maxQueueSize, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status CloseInputStream(string streamName)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__CloseInputStream__PKc(MpPtr, streamName, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public Status CloseAllPacketSources()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__CloseAllPacketSources(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }

        public void Cancel()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__Cancel(MpPtr).Assert();
            GC.KeepAlive(this);
        }

        public bool GraphInputStreamsClosed() => SafeNativeMethods.mp_CalculatorGraph__GraphInputStreamsClosed(MpPtr);

        public bool IsNodeThrottled(int nodeId)
        {
            return SafeNativeMethods.mp_CalculatorGraph__IsNodeThrottled__i(MpPtr, nodeId);
        }

        public bool UnthrottleSources() => SafeNativeMethods.mp_CalculatorGraph__UnthrottleSources(MpPtr);

        public GpuResources GetGpuResources()
        {
            UnsafeNativeMethods.mp_CalculatorGraph__GetGpuResources(MpPtr, out var gpuResourcesPtr).Assert();

            GC.KeepAlive(this);
            return new GpuResources(gpuResourcesPtr);
        }

        public Status SetGpuResources(GpuResources gpuResources)
        {
            UnsafeNativeMethods.mp_CalculatorGraph__SetGpuResources__SPgpu(MpPtr, gpuResources.SharedPtr, out var statusPtr).Assert();

            GC.KeepAlive(gpuResources);
            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
