using System;
using System.Buffers;
using Akihabara.Core;
using Akihabara.Native.Framework.Format;

namespace Akihabara.Framework.ImageFormat
{
    public class ImageFrame : MpResourceHandle
    {
        public static readonly uint kDefaultAligmentBoundary = 16;
        public static readonly uint kGlDefaultAlignmentBoundary = 4;

        public delegate void Deleter(IntPtr ptr);

        public ImageFrame() : base()
        {
            UnsafeNativeMethods.mp_ImageFrame__(out var ptr);
            this.Ptr = ptr;
        }

        public ImageFrame(IntPtr imageFramePtr, bool isOwner = true) : base(imageFramePtr, isOwner) {}
        
        public ImageFrame(ImageFormat.Format format, int width, int height) : this(format, width, height, kDefaultAligmentBoundary) {}

        public ImageFrame(ImageFormat.Format format, int width, int height, uint alignmentBoundary) : base()
        {
            UnsafeNativeMethods.mp_ImageFrame__ui_i_i_ui(format, width, height, alignmentBoundary, out var ptr);
            this.Ptr = ptr;
        }
        
        // there is no equivalent of NativeArray<T> so the closest thing we have is ArrayPool<T>, which is recommended
        // by MSDN anyways.
        // https://docs.microsoft.com/en-us/dotnet/standard/native-interop/best-practices
        public ImageFrame(ImageFormat.Format format, int width, int height, int widthStep, ArrayPool<byte> pixelData)
        {
            // TODO: Reimplement NativeArray implementation to something .NET standard!
        }
    }
}