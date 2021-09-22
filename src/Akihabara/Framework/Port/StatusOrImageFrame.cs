// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Akihabara.Framework.ImageFormat;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Framework.Format.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Framework.Format.UnsafeNativeMethods;

namespace Akihabara.Framework.Port
{
    public class StatusOrImageFrame : StatusOr<ImageFrame>
    {
        public StatusOrImageFrame(IntPtr ptr) : base(ptr) { }

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_StatusOrImageFrame__delete(Ptr);
        }

        public override bool Ok {
            get { return SafeNativeMethods.mp_StatusOrImageFrame__ok(MpPtr); }
        }

        public override Status Status {
            get {
                UnsafeNativeMethods.mp_StatusOrImageFrame__status(MpPtr, out var statusPtr).Assert();

                GC.KeepAlive(this);
                return new Status(statusPtr);
            }
        }

        public override ImageFrame Value()
        {
            UnsafeNativeMethods.mp_StatusOrImageFrame__value(MpPtr, out var imageFramePtr).Assert();
            Dispose();

            return new ImageFrame(imageFramePtr);
        }
    }
}
