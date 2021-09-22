// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;

namespace Akihabara.Core
{
    public class MediapipePluginException : Exception
    {
        public MediapipePluginException(string message) : base(message) { }
    }
}
