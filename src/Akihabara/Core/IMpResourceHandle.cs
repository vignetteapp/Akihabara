// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;

namespace Akihabara.Core
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
