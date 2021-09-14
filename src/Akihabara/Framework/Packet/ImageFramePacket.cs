using Akihabara.Framework.ImageFormat;
using Akihabara.Framework.Port;
using ff = Akihabara.Native.Framework.Format;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akihabara.Native;

namespace Akihabara.Framework.Packet
{
    public class ImageFramePacket : Packet<ImageFrame>
    {
        public ImageFramePacket() : base() { }

        public ImageFramePacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public ImageFramePacket(ImageFrame imageFrame) : base()
        {
            ff.UnsafeNativeMethods.mp__MakeImageFramePacket__Pif(imageFrame.MpPtr, out var ptr).Assert();
            imageFrame.Dispose(); // respect move semantics

            this.Ptr = ptr;
        }

        public ImageFramePacket(ImageFrame imageFrame, Timestamp timestamp) : base()
        {
            ff.UnsafeNativeMethods.mp__MakeImageFramePacket_At__Pif_Rt(imageFrame.MpPtr, timestamp.MpPtr, out var ptr).Assert();
            GC.KeepAlive(timestamp);
            imageFrame.Dispose(); // respect move semantics

            this.Ptr = ptr;
        }

        public override ImageFrame Get()
        {
            ff.UnsafeNativeMethods.mp_Packet__GetImageFrame(MpPtr, out var imageFramePtr).Assert();

            GC.KeepAlive(this);
            return new ImageFrame(imageFramePtr, false);
        }

        public override StatusOr<ImageFrame> Consume()
        {
            ff.UnsafeNativeMethods.mp_Packet__ConsumeImageFrame(MpPtr, out var statusOrImageFramePtr).Assert();

            GC.KeepAlive(this);
            return new StatusOrImageFrame(statusOrImageFramePtr);
        }

        public override Status ValidateAsType()
        {
            ff.UnsafeNativeMethods.mp_Packet__ValidateAsImageFrame(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
}
