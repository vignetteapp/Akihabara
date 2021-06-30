using System;
using System.Runtime.InteropServices;
using Akihabara.External;

namespace Akihabara.Native.External
{
    public class UnsafeNativeMethods : NativeMethods
    {
        #region ABSL

        [DllImport(MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode absl_Status__i_PKc(int code, string message, out IntPtr status);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern void absl_Status__delete(IntPtr status);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode absl_Status__ToString(IntPtr status, out IntPtr str);

        #endregion

        #region GoogleLogging

        [DllImport(MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode google_InitGoogleLogging__PKc(string name, string logDir);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode google_ShutdownGoogleLogging();

        [DllImport (MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode glog_LOG_INFO__PKc(string str);

        [DllImport (MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode glog_LOG_WARNING__PKc(string str);

        [DllImport (MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode glog_LOG_ERROR__PKc(string str);

        [DllImport (MediaPipeLibrary, ExactSpelling = true, CharSet = CharSet.Unicode)]
        public static extern MpReturnCode glog_LOG_FATAL__PKc(string str);

        [DllImport (MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode google_FlushLogFiles(Glog.Severity severity);

        #endregion

        #region Protobuf Messaging
        
        [DllImport (MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode google_protobuf__SetLogHandler__PF(
            [MarshalAs(UnmanagedType.FunctionPtr)]Protobuf.ProtobufLogHandler logHandler);

        [DllImport (MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_api_SerializedProto__delete(IntPtr serializedProto);

        [DllImport (MediaPipeLibrary, ExactSpelling = true)]
        public static extern void mp_api_SerializedProtoVector__delete(IntPtr serializedProtoVector);

        #endregion

        #region MessageProto

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetClassificationList(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetClassificationListVector(IntPtr packet,
            out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetDetection(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetDetectionVector(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetLandmarkList(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetLandmarkListVector(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetNormalizedLandmarkList(IntPtr packet,
            out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetNormalizedLandmarkListVector(IntPtr packet,
            out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetRect(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetRectVector(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetNormalizedRect(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetNormalizedRectVector(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetTimedModelMatrixProtoList(IntPtr packet,
            out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetFaceGeometry(IntPtr packet, out IntPtr serializedProto);

        [DllImport(MediaPipeLibrary, ExactSpelling = true)]
        public static extern MpReturnCode mp_Packet__GetFaceGeometryVector(IntPtr packet, out IntPtr serializedProto);

        #endregion
    }
}