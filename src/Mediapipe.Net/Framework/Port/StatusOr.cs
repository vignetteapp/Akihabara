// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using Mediapipe.Net.Core;

namespace Mediapipe.Net.Framework.Port
{
    public abstract class StatusOr<T> : MpResourceHandle
    {
        public StatusOr(IntPtr ptr) : base(ptr)
        {
        }

        public abstract bool Ok { get; }
        public abstract Status Status { get; }
        public abstract T Value();

        public virtual T ValueOr(T defaultVal)
        {
            return !Ok ? defaultVal : Value();
        }
    }
}
