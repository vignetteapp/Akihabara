// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using Akihabara.Native;
using ng = Akihabara.Native.Gpu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Akihabara.Framework.Port;
using Akihabara.Gpu;

namespace Akihabara.Framework.Packet
{
    /* 
     * defined on Linux, but useful only with OpenGL ES
     * (https://github.com/homuler/MediaPipeUnityPlugin/blob/master/Packages/com.github.homuler.mediapipe/Runtime/Scripts/Framework/Packet/EglSurfaceHolderPacket.cs)
     */
#if OPENGL_ES
    public class EglSurfaceHolderPacket : Packet<EglSurfaceHolder>
    {
        public EglSurfaceHolderPacket() : base() { }

        public EglSurfaceHolderPacket(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        public EglSurfaceHolderPacket(EglSurfaceHolder eglSurfaceHolder) : base()
        {
            ng.UnsafeNativeMethods.mp_MakeEglSurfaceHolderUniquePtrPacket__Reshup(eglSurfaceHolder.uniquePtr, out var ptr).Assert();
            eglSurfaceHolder.Dispose(); // respect move semantics
            this.Ptr = ptr;
        }

        public override EglSurfaceHolder Get()
        {
            ng.UnsafeNativeMethods.mp_Packet__GetEglSurfaceHolderUniquePtr(MpPtr, out var eglSurfaceHolderPtr).Assert();

            GC.KeepAlive(this);
            return new EglSurfaceHolder(eglSurfaceHolderPtr, false);
        }

        public override StatusOr<EglSurfaceHolder> Consume()
        {
            throw new NotSupportedException();
        }

        public override Status ValidateAsType()
        {
            ng.UnsafeNativeMethods.mp_Packet__ValidateAsEglSurfaceHolderUniquePtr(MpPtr, out var statusPtr).Assert();

            GC.KeepAlive(this);
            return new Status(statusPtr);
        }
    }
#endif
}
