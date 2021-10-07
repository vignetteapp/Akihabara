// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using static Akihabara.Native.Util.SafeNativeMethods;

namespace Akihabara.Util
{
    public abstract class ResourceManager
    {
        public abstract PathResolver PathResolver { get; }

        public abstract ResourceProvider ResourceProvider { get; }

        private static readonly object initLock = new object();
        private static bool isInitialized = false;

        public ResourceManager() : base()
        {
            lock (initLock)
            {
                if (isInitialized)
                    throw new InvalidOperationException($"{nameof(ResourceManager)} can only be initialized once.");

                mp__SetCustomGlobalPathResolver__P(PathResolver);
                mp__SetCustomGlobalResourceProvider__P(ResourceProvider);

                isInitialized = true;
            }
        }
    }
}
