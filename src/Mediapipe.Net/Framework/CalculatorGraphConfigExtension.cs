// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using Mediapipe.Net.Native;
using Google.Protobuf;
using Mediapipe.Net.Framework.Protobuf;
using Mediapipe.Net.Native.Framework;
using UnsafeNativeMethods = Mediapipe.Net.Native.Framework.UnsafeNativeMethods;

namespace Mediapipe.Net.Framework
{
    public static class CalculatorGraphConfigExtension
    {
        public static CalculatorGraphConfig ParseFromTextFormat(this MessageParser<CalculatorGraphConfig> parser, string configText)
        {
            UnsafeNativeMethods.mp_api__ConvertFromCalculatorGraphConfigTextFormat(configText, out var serializedProtoPtr).Assert();

            var config = External.Protobuf.DeserializeProto(serializedProtoPtr, CalculatorGraphConfig.Parser);
            Native.UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return config;
        }
    }
}

