// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

namespace Akihabara.Native
{
    /// <summary>
    /// A base class where <see cref="SafeNativeMethods"/> and <see cref="UnsafeNativeMethods"/> relies on.
    /// only fields that will be used by both classes are to be used here.
    /// </summary>
    public partial class NativeMethods
    {
        // originally this would be different definitions as per the Unity
        // variant we're basing off, which you can find here: https://git.io/Jc3y1
        //
        // However, since we're targeting PC for now, we'll go for mediapipe_c for now.
        internal const string MediaPipeLibrary = "mediapipe_c";
    }
}
