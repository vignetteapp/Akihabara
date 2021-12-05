// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.IO;
using Mediapipe.Net.External;
using Mediapipe.Net.Native.Util;
using static Mediapipe.Net.Native.Util.SafeNativeMethods;

namespace Mediapipe.Net.Util
{
    /// <summary>
    /// A class that handles resolving paths and obtaining resources for Mediapipe.
    /// </summary>
    /// <remarks>There should only be one instance of <see cref="ResourceManager"/> in the entire lifespan of an application.</remarks>
    public abstract class ResourceManager
    {
        private static readonly object initLock = new object();
        private static ResourceManager instance;
        private static SafeNativeMethods.PathResolver pathResolver;
        private static SafeNativeMethods.ResourceProvider resourceProvider;

        public ResourceManager() : base()
        {
            lock (initLock)
            {
                if (instance != null)
                    throw new InvalidOperationException($"{nameof(ResourceManager)} can only be initialized once.");

                // Hold instances in a variable to prevent garbage collection from cleaning it.
                pathResolver = resolvePath;
                resourceProvider = getResource;

                mp__SetCustomGlobalPathResolver__P(pathResolver);
                mp__SetCustomGlobalResourceProvider__P(resourceProvider);

                instance = this;
            }
        }

        /// <summary>
        /// Resolves a string path from Mediapipe to be used by <see cref="GetResource(string)"/>
        /// </summary>
        /// <param name="path">The path passed by Mediapipe.</param>
        /// <returns>The resolved path.</returns>
        protected abstract string ResolvePath(string path);

        /// <summary>
        /// Gets the resource as a <see cref="Stream"/> to be passed to Mediapipe.
        /// </summary>
        /// <param name="path">The path to the resource.</param>
        /// <returns>The stream containing data to be passed to Mediapipe.</returns>
        protected abstract Stream GetResource(string path);

        private static string resolvePath(string path) => instance.ResolvePath(path);

        private static bool getResource(string path, IntPtr dest)
        {
            try
            {
                string resolved = instance.ResolvePath(path);
                var resource = instance.GetResource(resolved);

                using var memory = new MemoryStream();
                resource.CopyTo(memory);

                using var source = new StdString(memory.ToArray());
                source.Swap(new StdString(dest, false));

                return true;
            }
            catch (Exception)
            {
                // TODO: Handle errors
                return false;
            }
        }
    }
}
