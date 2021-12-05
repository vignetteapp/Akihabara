// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Mediapipe.Net.Native;
using pb = global::Google.Protobuf;

namespace Mediapipe.Net.External
{
    public class Protobuf
    {
        public delegate void ProtobufLogHandler(int level, string filename, int line, string message);

        private static readonly ProtobufLogHandler protobufLogHandler = LogProtobufMessage;

        static Protobuf()
        {
            UnsafeNativeMethods.google_protobuf__SetLogHandler__PF(protobufLogHandler).Assert();
        }

        static void LogProtobufMessage(int level, string filename, int line, string message)
        {
            Debug.Print($"[libprotobuf ({FormatProtobufLogLevel(level)}) {filename}:{line}] {message}");
        }

        private static string FormatProtobufLogLevel(int level)
        {
            switch (level)
            {
                case 1: return "WARNING";
                case 2: return "ERROR";
                case 3: return "FATAL";
                default: return "INFO";
            }
        }

        public static T DeserializeProto<T>(IntPtr ptr, pb::MessageParser<T> parser)
            where T : pb::IMessage<T>
        {
            var serializedProto = Marshal.PtrToStructure<SerializedProto>(ptr);
            var bytes = new byte[serializedProto.length];

            Marshal.Copy(serializedProto.str, bytes, 0, bytes.Length);

            return parser.ParseFrom(bytes);
        }

        public static List<T> DeserializeProtoVector<T>(IntPtr ptr, pb::MessageParser<T> parser)
            where T : pb::IMessage<T>
        {
            var serializedProtoVector = Marshal.PtrToStructure<SerializedProtoVector>(ptr);
            var protos = new List<T>(serializedProtoVector.size);

            // UNSAFE CODE AHOY!
            // Do not touch this one unless you have an idea with pointers!
            unsafe
            {
                byte** protoPtr = (byte**)serializedProtoVector.data;

                for (var i = 0; i < serializedProtoVector.size; i++)
                {
                    protos.Add(Protobuf.DeserializeProto<T>((IntPtr)(*protoPtr++), parser));
                }
            }

            return protos;
        }
    }
}
