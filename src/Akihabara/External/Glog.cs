using Akihabara.Native;

namespace Akihabara.External
{
    public class Glog
    {
        public enum Severity : int
        {
            Info = 0,
            Warning = 1,
            Error = 2,
            Fatal = 3
        }

        public static void Initialize(string name, string dir)
        {
            UnsafeNativeMethods.google_InitGoogleLogging__PKc(name, dir);
        }

        public static void Log(Severity severity, string str)
        {
            switch (severity)
            {
                case Severity.Info:
                {
                    UnsafeNativeMethods.glog_LOG_INFO__PKc(str).Assert();
                    break;
                }
                case Severity.Warning:
                {
                    UnsafeNativeMethods.glog_LOG_WARNING__PKc(str).Assert();
                    break;
                }
                case Severity.Error:
                {
                    UnsafeNativeMethods.glog_LOG_ERROR__PKc(str).Assert();
                    break;
                }
                case Severity.Fatal:
                {
                    UnsafeNativeMethods.glog_LOG_FATAL__PKc(str).Assert();
                    break;
                }
                default:
                {
                    // just to appease Roslyn and ReSharper
                    UnsafeNativeMethods.glog_LOG_INFO__PKc(str);
                    break;
                }
            }
        }
    }
}