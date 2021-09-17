using Akihabara.Native;
using System;
using System.Runtime.InteropServices;

namespace Akihabara.Core
{
    public abstract class MpResourceHandle : DisposableObject, IMpResourceHandle
    {
        protected IntPtr Ptr;

        protected MpResourceHandle(bool isOwner = true) : this(IntPtr.Zero, isOwner)
        {
        }

        protected MpResourceHandle(IntPtr ptr, bool isOwner = true) : base(isOwner)
        {
            Ptr = ptr;
        }

        #region IMpResourceHandle

        public IntPtr MpPtr
        {
            get
            {
                ThrowIfDisposed();
                return Ptr;
            }
        }

        public void ReleaseMpResource()
        {
            if (OwnsResource())
            {
                DeleteMpPtr();
            }
            TransferOwnership();
        }

        public bool OwnsResource()
        {
            return IsOwner && Ptr != IntPtr.Zero;
        }

        #endregion

        protected override void DisposeUnmanaged()
        {
            if (OwnsResource())
            {
                ReleaseMpPtr();
            }
        }

        /// <summary>
        /// Forget pointer address.
        /// After calling this method, <see cref="OwnsResource"/> will return false.
        /// </summary>
        protected void ReleaseMpPtr()
        {
            Ptr = IntPtr.Zero;
        }

        /// <summary>
        ///  Relase the memory (call `delete` or `delete[]`) whether or not it owns it
        /// </summary>
        /// <remarks>In most cases, this shouldn't be called at all or directly.</remarks>
        protected abstract void DeleteMpPtr();

        protected delegate MpReturnCode StringOutFunc(IntPtr ptr, out IntPtr strPtr);

        protected string MarshalStringFromNative(StringOutFunc func)
        {
            func(MpPtr, out var strPtr).Assert();
            GC.KeepAlive(this);

            var str = Marshal.PtrToStringAnsi(strPtr);
            UnsafeNativeMethods.delete_array__PKc(strPtr);

            return str;
        }
    }
}
