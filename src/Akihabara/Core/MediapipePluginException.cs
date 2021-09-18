// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;

namespace Akihabara.Core
{
    public class MediapipePluginException : Exception
    {
        public MediapipePluginException(string message) : base(message) { }
    }
}
