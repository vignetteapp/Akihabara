using System;

using Akihabara.Core;
using Akihabara.Native;
using Akihabara.Framework.Packet;
using UnsafeNativeMethods = Akihabara.Native.Framework.UnsafeNativeMethods;

namespace Akihabara.Framework
{
    public class OutputStreamPoller<T> : MpResourceHandle
    {
        public OutputStreamPoller(IntPtr Ptr) : base(Ptr)
        {
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_OutputStreamPoller__delete(Ptr);
        }

        public bool Next(Packet<T> packet)
        {
            UnsafeNativeMethods.mp_OutputStreamPoller__Next_Ppacket(MpPtr, packet.MpPtr, out var result).Assert();

            GC.KeepAlive(this);
            return result;
        }

        public void Reset()
        {
            UnsafeNativeMethods.mp_OutputStreamPoller__Reset(MpPtr).Assert();
        }

        public void SetMaxQueueSize(int queueSize)
        {
            UnsafeNativeMethods.mp_OutputStreamPoller__SetMaxQueueSize(MpPtr, queueSize).Assert();
        }

        public int QueueSize()
        {
            UnsafeNativeMethods.mp_OutputStreamPoller__QueueSize(MpPtr, out var result).Assert();

            GC.KeepAlive(this);
            return result;
        }
    }
}
