using Akihabara.Core;
using System;

namespace Akihabara.Gpu
{
    internal abstract class SharedPtr : SharedPtrHandle, ISharedPtr
    {
        protected SharedPtr(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        /// <summary>
        /// Gets the Mediapipe shared pointer to be used by other classes for your specific native implementation.
        /// </summary>
        public override IntPtr Get()
        {
            // as we're expecting it to be implemented and overriden by the implementing class
            // this should never get called.
            return IntPtr.Zero;
        }

        /// <summary>
        /// Calls reset() on the native side of the implementing class. GpuResources and GLSyncPoint is expected
        /// to have this implemented since they their synchronization context might need to get reset on
        /// specific cases.
        /// </summary>
        public override void Reset() { }

        /// <summary>
        /// Inherited from MpResourceHandle. This deletes the Mediapipe pointer associated with the shared pointer.
        /// </summary>
        protected override void DeleteMpPtr() { }
    }
}
