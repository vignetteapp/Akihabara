namespace Akihabara.Native.External
{
    public partial class NativeMethods
    {
        // originally this would be different definitions as per the Unity
        // variant we're basing off, which you can find here: https://git.io/Jc3y1
        //
        // However, since we're targeting PC for now, we'll go for mediapipe_c for now.
        internal const string MediaPipeLibrary = "mediapipe_c";
    }
}