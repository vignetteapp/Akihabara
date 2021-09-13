using System;

using Akihabara.Core;
using Akihabara.Native;
using Akihabara.Framework.Packet;
using nf = Akihabara.Native.Framework;

namespace Akihabara.Framework
{
    public class OutputStreamPoller<T> : MpResourceHandle
    {
        public OutputStreamPoller(IntPtr Ptr) : base(Ptr)
        {
        }

        protected override void DeleteMpPtr()
        {
            nf.UnsafeNativeMethods.mp_OutputStreamPoller__delete(Ptr);
        }

        public bool Next(Packet<T> packet)
        {
            nf.UnsafeNativeMethods.mp_OutputStreamPoller__Next_Ppacket(MpPtr, packet.MpPtr, out var result).Assert();

            GC.KeepAlive(this);
            return result;
        }

        public void Reset()
        {
            nf.UnsafeNativeMethods.mp_OutputStreamPoller__Reset(MpPtr).Assert();
        }

        public void SetMaxQueueSize(int queueSize)
        {
            nf.UnsafeNativeMethods.mp_OutputStreamPoller__SetMaxQueueSize(MpPtr, queueSize).Assert();
        }

        public int QueueSize()
        {
            nf.UnsafeNativeMethods.mp_OutputStreamPoller__QueueSize(MpPtr, out var result).Assert();

            GC.KeepAlive(this);
            return result;
        }
    }
}
