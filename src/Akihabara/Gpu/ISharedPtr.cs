// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;

namespace Akihabara.Gpu
{
    public interface ISharedPtr
    {

        /// <summary>
        /// Gets the shared Mediapipe pointer
        /// </summary>
        public IntPtr Get();

        /// <summary>
        /// A implementation specific reset method. This is implemented by the wrapping
        /// class if the unsafe method has a reset() function.
        /// </summary>
        public void Reset();
    }
}
