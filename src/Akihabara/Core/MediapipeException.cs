// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

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
