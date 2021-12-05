// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;

namespace Mediapipe.Net.Core
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
