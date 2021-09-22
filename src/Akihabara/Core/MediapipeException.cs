// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;

namespace Akihabara.Core
{
    /// <summary>
    /// An Exception within the Mediapipe Subsystem.
    /// </summary>
    public class MediapipeException : Exception
    {
        public MediapipeException(string message) : base(message) { }
    }
}
