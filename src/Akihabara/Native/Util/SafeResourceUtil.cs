using System.Resources;
using System.Runtime.InteropServices;

namespace Akihabara.Native.Util
{
    public partial class SafeNativeMethods : NativeMethods
    {
        //TODO: Change this to .NET native! This is a Unity API!
        // https://docs.unity3d.com/Packages/com.unity.resourcemanager@1.6/manual/index.html
        public static extern void mp__SetCustomGlobalResourceProvider__P(
            [MarshalAs(UnmanagedType.FunctionPtr)]ResourceManager.ResourceProvider provider);

        [DllImport (MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp__SetCustomGlobalPathResolver__P(
            [MarshalAs(UnmanagedType.FunctionPtr)]ResourceManager.PathResolver resolver);        
    }
}