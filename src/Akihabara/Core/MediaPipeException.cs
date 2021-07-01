using System;

namespace Akihabara.Core
{
    /// <summary>
    /// An Exception within the Mediapipe Subsystem.
    /// </summary>
    public class MediaPipeException : Exception
    {
        public MediaPipeException(string message) : base(message) {}
    }
}