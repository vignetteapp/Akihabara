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
