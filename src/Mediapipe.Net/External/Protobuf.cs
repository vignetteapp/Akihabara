// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Mediapipe.Net.Native;
using pb = Google.Protobuf;

namespace Mediapipe.Net.External
{
    public class Protobuf
    {
        public delegate void ProtobufLogHandler(int level, string filename, int line, string message);

        private static readonly ProtobufLogHandler protobufLogHandler = logProtobufMessage;

        static Protobuf()
        {
            UnsafeNativeMethods.google_protobuf__SetLogHandler__PF(protobufLogHandler).Assert();
        }

        private static void logProtobufMessage(int level, string filename, int line, string message) =>
            Debug.Print($"[libprotobuf ({formatProtobufLogLevel(level)}) {filename}:{line}] {message}");

        private static string formatProtobufLogLevel(int level) => level switch
        {
            1 => "WARNING",
            2 => "ERROR",
            3 => "FATAL",
            _ => "INFO",
        };

        public static T DeserializeProto<T>(IntPtr ptr, pb::MessageParser<T> parser)
            where T : pb::IMessage<T>
        {
            SerializedProto serializedProto = Marshal.PtrToStructure<SerializedProto>(ptr);
            byte[] bytes = new byte[serializedProto.Length];

            Marshal.Copy(serializedProto.Str, bytes, 0, bytes.Length);

            return parser.ParseFrom(bytes);
        }

        public static List<T> DeserializeProtoVector<T>(IntPtr ptr, pb::MessageParser<T> parser)
            where T : pb::IMessage<T>
        {
            SerializedProtoVector serializedProtoVector = Marshal.PtrToStructure<SerializedProtoVector>(ptr);
            var protos = new List<T>(serializedProtoVector.Size);

            // UNSAFE CODE AHOY!
            // Do not touch this one unless you have an idea with pointers!
            unsafe
            {
                byte** protoPtr = (byte**)serializedProtoVector.Data;

                for (int i = 0; i < serializedProtoVector.Size; i++)
                {
                    protos.Add(Protobuf.DeserializeProto<T>((IntPtr)(*protoPtr++), parser));
                }
            }

            return protos;
        }
    }
}
