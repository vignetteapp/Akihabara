// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;
using Mediapipe.Net.Framework.Packet;
using Mediapipe.Net.Native;
using Mediapipe.Net.Native.Framework;
using UnsafeNativeMethods = Mediapipe.Net.Native.Framework.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework
{
    public class OutputStreamPoller<T> : MpResourceHandle
    {
        public OutputStreamPoller(IntPtr ptr) : base(ptr)
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
