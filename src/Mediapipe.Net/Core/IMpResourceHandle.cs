// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;

namespace Mediapipe.Net.Core
{
    public interface IMpResourceHandle : IDisposable
    {
        IntPtr MpPtr { get; }

        /// <summary>
        ///  Relinquishes the ownership and release the resource, if necessary.
        ///  Method should be called only if the underlying native API moves the ptr.
        /// </summary>
        /// <remarks>If the object is no longer used, call <see cref="Dispose"/> instead.</remarks>
        void ReleaseMpResource();

        /// <summary>
        ///  Relinquish ownership of the resource.
        /// </summary>
        void TransferOwnership();

        /// <summary>
        ///  If the resource is owned.
        /// </summary>
        /// <returns>true if owned by the handler, false if not.</returns>
        bool OwnsResource();
    }
}
