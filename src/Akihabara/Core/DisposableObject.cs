using System;
using System.Threading;

namespace Akihabara.Core
{
    // based on OpenCVSharp
    // https://git.io/Jc3xr
    public abstract class DisposableObject : IDisposable
    {
        private volatile int disposeSignaled = 0;

        public bool isDisposed { get; protected set; }
        protected bool isOwner { get; private set; }

        protected DisposableObject() : this(true)
        {
        }

        protected DisposableObject(bool isOwner)
        {
            isDisposed = false;
            this.isOwner = isOwner;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.Exchange(ref disposeSignaled, 1) != 0)
            {
                return;
            }

            isDisposed = true;

            if (disposing)
            {
                DisposeManaged();
            }

            DisposeUnmanaged();
        }

        ~DisposableObject()
        {
            Dispose(false);
        }

        protected virtual void DisposeManaged()
        {
        }

        protected virtual void DisposeUnmanaged()
        {
        }

        public void TransferOwnership()
        {
            isOwner = false;
        }

        public void ThrowIfDisposed()
        {
            if (isDisposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
        }
    }
}
