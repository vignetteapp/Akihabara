using System;
using Akihabara.Core;
using Akihabara.Native;
using SafeNativeMethods = Akihabara.Native.Gpu.SafeNativeMethods;
using UnsafeNativeMethods = Akihabara.Native.Gpu.UnsafeNativeMethods;

namespace Akihabara.Gpu
{
    public class GlContext : MpResourceHandle
    {
        private SharedPtrHandle _sharedPtrHandle;

        public static GlContext GetCurrent()
        {
            UnsafeNativeMethods.mp_GlContext_GetCurrent(out var glContextPtr).Assert();

            return glContextPtr == IntPtr.Zero ? null : new GlContext(glContextPtr);
        }

        public GlContext(IntPtr ptr, bool isOwner = true) : base(isOwner)
        {
            _sharedPtrHandle = new GlContextSharedPtr(ptr);
            this.ptr = _sharedPtrHandle.Get();
        }

        protected override void DisposeManaged()
        {
            if (_sharedPtrHandle != null)
            {
                _sharedPtrHandle.Dispose();
                _sharedPtrHandle = null;
            }
            base.DisposeManaged();
        }

        protected override void DeleteMpPtr()
        {
            // this does nothing
            // if this apparently gets called
            // might as well donate my life savings to Kronii
        }

        public IntPtr SharedPtr => _sharedPtrHandle?.MpPtr ?? IntPtr.Zero;
        
        // GLES functions here!
        // only use this if you're invoking this from a GLES device
        public IntPtr EglDisplay => SafeNativeMethods.mp_GlContext__egl_display(MpPtr);

        public IntPtr EglConfig => SafeNativeMethods.mp_GlContext__egl_config(MpPtr);

        public IntPtr EglContext => SafeNativeMethods.mp_GlContext__egl_context(MpPtr);

        public IntPtr NsglContext => SafeNativeMethods.mp_GlContext__nsgl_context(MpPtr);

        public IntPtr EaglContext => SafeNativeMethods.mp_GlContext__eagl_context(MpPtr);
        // end of GLES functions

        public bool IsCurrent => SafeNativeMethods.mp_GlContext__IsCurrent(MpPtr);

        public int GlMajorVersion => SafeNativeMethods.mp_GlContext__gl_major_version(MpPtr);

        public int GlMinorVersion => SafeNativeMethods.mp_GlContext__gl_minor_version(MpPtr);

        public long GlFinishCount => SafeNativeMethods.mp_GlContext__gl_finish_count(MpPtr);
    }

    internal class GlContextSharedPtr : SharedPtr
    {
        public GlContextSharedPtr(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) {}

        protected override void DeleteMpPtr()
        {
            UnsafeNativeMethods.mp_SharedGlContext__delete(ptr);
        }

        public override IntPtr Get()
        {
            return SafeNativeMethods.mp_SharedGlContext__get(MpPtr);
        }

        public override void Reset()
        {
            UnsafeNativeMethods.mp_SharedGlContext__reset(MpPtr);
        }
    }
}