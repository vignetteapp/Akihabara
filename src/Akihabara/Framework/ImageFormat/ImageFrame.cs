using System;
using Akihabara.Core;
using Akihabara.Native;
using UnmanageUtility;
using SafeNativeMethods = Akihabara.Native.Framework.Format.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Framework.Format.UnsafeNativeMethods;

namespace Akihabara.Framework.ImageFormat
{
    public class ImageFrame : MpResourceHandle
    {
        // do not edit arbitrary values here unless you know what you're doing
        // since this basically defines the alignment boundary on the GL context
        public static readonly uint KDefaultAligmentBoundary = 16;
        public static readonly uint KGlDefaultAlignmentBoundary = 4;

        public delegate void Deleter(IntPtr ptr);

        public ImageFrame() : base()
        {
            UnsafeNativeMethods.mp_ImageFrame__(out var ptr);
            this.Ptr = ptr;
        }

        public ImageFrame(IntPtr imageFramePtr, bool isOwner = true) : base(imageFramePtr, isOwner) { }

        public ImageFrame(ImageFormat.Format format, int width, int height) : this(format, width, height, KDefaultAligmentBoundary) { }

        public ImageFrame(ImageFormat.Format format, int width, int height, uint alignmentBoundary) : base()
        {
            UnsafeNativeMethods.mp_ImageFrame__ui_i_i_ui(format, width, height, alignmentBoundary, out var ptr);
            this.Ptr = ptr;
        }

        // there is no equivalent of NativeArray<T> so the closest thing we have is UnmanagedArray<T> or ArrayPooL<T>, which is recommended
        // by MSDN anyways and this is what a friend from Discord said :D.
        // https://docs.microsoft.com/en-us/dotnet/standard/native-interop/best-practices
        public ImageFrame(ImageFormat.Format format, int width, int height, int widthStep, UnmanagedArray<byte> pixelData)
        {
            unsafe
            {
                UnsafeNativeMethods.mp_ImageFrame__ui_i_i_i_Pui8_PF(
                    format, width, height, widthStep,
                    (IntPtr)pixelData.Ptr,
                    ReleasePixelData,
                    out var ptr
                );

                this.Ptr = ptr;
            }
        }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_ImageFrame__delete(Ptr);
        }

        private static void ReleasePixelData(IntPtr ptr)
        {
            // This does nothing since pixelData is already removed.
            // probably just a shim so ImageFrame() works.
        }

        public bool IsEmpty()
        {
            return SafeNativeMethods.mp_ImageFrame__IsEmpty(MpPtr);
        }

        public bool IsContiguous()
        {
            return SafeNativeMethods.mp_ImageFrame__IsContiguous(MpPtr);
        }

        public bool IsAligned(uint alignmentBoundary)
        {
            SafeNativeMethods.mp_ImageFrame__IsAligned__ui(MpPtr, alignmentBoundary, out var value);

            GC.KeepAlive(this);
            return value;
        }

        public ImageFormat.Format Format()
        {
            return SafeNativeMethods.mp_ImageFrame__Format(MpPtr);
        }

        public int Width()
        {
            return SafeNativeMethods.mp_ImageFrame__Width(MpPtr);
        }

        public int Height()
        {
            return SafeNativeMethods.mp_ImageFrame__Height(MpPtr);
        }

        public int ChannelSize()
        {
            SafeNativeMethods.mp_ImageFrame__ChannelSize(MpPtr, out var val);

            // This is supposed to have a ValueOrFormatException() Function but we don't know
            // what it implements.
            GC.KeepAlive(this);
            return val;
        }

        public int NumberOfChannels()
        {
            SafeNativeMethods.mp_ImageFrame__NumberOfChannels(MpPtr, out var val).Assert();

            GC.KeepAlive(this);
            return val;
        }

        public int ByteDepth()
        {
            SafeNativeMethods.mp_ImageFrame__ByteDepth(MpPtr, out var val).Assert();

            GC.KeepAlive(this);
            return val;
        }

        public int WidthStep()
        {
            return SafeNativeMethods.mp_ImageFrame__WidthStep(MpPtr);
        }

        public int MutablePixelData()
        {
            return (int)SafeNativeMethods.mp_ImageFrame__MutablePixelData(MpPtr);
        }

        public int PixelDataSize()
        {
            return SafeNativeMethods.mp_ImageFrame__PixelDataSize(MpPtr);
        }

        public int PixelDataSizeStoredContiguously()
        {
            SafeNativeMethods.mp_ImageFrame__PixelDataSizeStoredContiguously(MpPtr, out var val);

            GC.KeepAlive(this);
            return val;
        }

        public void SetToZero()
        {
            UnsafeNativeMethods.mp_ImageFrame__SetToZero(MpPtr).Assert();

            GC.KeepAlive(this);
        }

        public void SetAlignmentPaddingAreas()
        {
            UnsafeNativeMethods.mp_ImageFrame__SetAlignmentPaddingAreas(MpPtr).Assert();
            GC.KeepAlive(this);
        }

        public byte[] CopyToByteBuffer(int bufferSize)
        {
            return CopyToBuffer<byte>(UnsafeNativeMethods.mp_ImageFrame__CopyToBuffer__Pui8_i, bufferSize);
        }

        public ushort[] CopyToUshortBuffer(int bufferSize)
        {
            return CopyToBuffer<ushort>(UnsafeNativeMethods.mp_ImageFrame__CopyToBuffer__Pui16_i, bufferSize);
        }

        public float[] CopyToFloatBuffer(int bufferSize)
        {
            return CopyToBuffer<float>(UnsafeNativeMethods.mp_ImageFrame__CopyToBuffer__Pf_i, bufferSize);
        }

        private delegate MpReturnCode CopyToBufferHandler(IntPtr ptr, IntPtr buffer, int bufferSize);

        private T[] CopyToBuffer<T>(CopyToBufferHandler handler, int bufferSize) where T : unmanaged
        {
            var buffer = new T[bufferSize];

            unsafe
            {
                fixed (T* bufferPtr = buffer)
                {
                    handler(MpPtr, (IntPtr)bufferPtr, bufferSize);
                }
            }

            GC.KeepAlive(this);
            return buffer;
        }

        private T ValueOrFormatException<T>(MpReturnCode code, T val)
        {
            try
            {
                code.Assert();
                return val;
            }
            catch (MediapipeException)
            {
                throw new FormatException($"Invalid image format: {Format()}");
            }
        }
    }
}
