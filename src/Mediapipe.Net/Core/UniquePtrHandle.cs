// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;

namespace Mediapipe.Net.Core
{
    public abstract class UniquePtrHandle : MpResourceHandle
    {
        protected UniquePtrHandle(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        /// <returns>The owning pointer</returns>
        public abstract IntPtr Get();

        /// <summary>Release the owning pointer</summary>
        public abstract IntPtr Release();
    }
}
