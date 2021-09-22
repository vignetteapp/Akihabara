// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Akihabara.Core;

namespace Akihabara.Native
{
    public enum MpReturnCode : int
    {
        /// <summary>
        /// A standard Exception is thrown
        /// </summary>
        Success = 0,
        /// <summary>
        /// An error beyond standard Exception is thrown
        /// </summary>
        UnknownError = 70,
        /// <summary>
        /// SDK failed to set the status code
        /// </summary>
        Unset = 128,
        /// <summary>
        ///  Received an abort signal (SIGABRT)
        /// </summary>
        Aborted = 134
    }

    public static class MpReturnCodeExtension
    {
        public static void Assert(this MpReturnCode code)
        {
            switch (code)
            {
                case MpReturnCode.Success: return;
                case MpReturnCode.Aborted:
                    throw new MediapipeException("MediaPipe has aborted. See Glog files for details.");
                default:
                    throw new MediapipePluginException($"Failed to call a native function (code={code})");
            }
        }
    }
}
