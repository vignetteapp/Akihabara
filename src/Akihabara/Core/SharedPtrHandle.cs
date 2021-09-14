using System;

namespace Akihabara.Core
{
    public abstract class SharedPtrHandle : MpResourceHandle
    {
        public SharedPtrHandle(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        /// <summary>
        /// Get the owning pointer
        /// </summary>
        public abstract IntPtr Get();

        /// <summary>
        /// Release the owning pointer
        /// </summary>
        public abstract void Reset();
    }
}
