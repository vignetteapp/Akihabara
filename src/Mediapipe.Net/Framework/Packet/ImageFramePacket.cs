// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Native;
using Mediapipe.Net.Framework.ImageFormat;
using Mediapipe.Net.Framework.Port;
using Mediapipe.Net.Native.Framework.Format;
using UnsafeNativeMethods = Mediapipe.Net.Native.Framework.Format.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework.Packet
{
    public class ImageFramePacket : Packet<ImageFrame>
    {
        public ImageFramePacket() : base() { }

        public ImageFramePacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public ImageFramePacket(ImageFrame imageFrame) : base()
        {
            UnsafeNativeMethods.mp__MakeImageFramePacket__Pif(imageFrame.MpPtr, out var ptr).Assert();
            imageFrame.Dispose(); // respect move semantics

            Ptr = ptr;
        }

        public ImageFramePacket(ImageFrame imageFrame, Timestamp timestamp) : base()
        {
            UnsafeNativeMethods.mp__MakeImageFramePacket_At__Pif_Rt(imageFrame.MpPtr, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            imageFrame.Dispose(); // respect move semantics

            Ptr = ptr;
        }

        public override ImageFrame Get()
        {
            UnsafeNativeMethods.mp_Packet__GetImageFrame(MpPtr, out var imageFramePtr).Assert();

            GC.KeepAlive(this);
            return new ImageFrame(imageFramePtr, false);
        }

        public override StatusOr<ImageFrame> Consume()
        {
            UnsafeNativeMethods.mp_Packet__ConsumeImageFrame(MpPtr, out var statusOrImageFramePtr).Assert();

            GC.KeepAlive(this);
            return new StatusOrImageFrame(statusOrImageFramePtr);
        }

        public override Status ValidateAsType()
        {
            UnsafeNativeMethods.mp_Packet__ValidateAsImageFrame(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
