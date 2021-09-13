using System;
using Google.Protobuf;
using Akihabara.Framework.ProtoCalculator;
using Akihabara.External;
using Akihabara.Native;
using nf = Akihabara.Native.Framework;

namespace Akihabara.Framework
{
    public static class CalculatorGraphConfigExtension
    {
        public static CalculatorGraphConfig ParseFromTextFormat(this MessageParser<CalculatorGraphConfig> parser, string configText)
        {
            nf.UnsafeNativeMethods.mp_api__ConvertFromCalculatorGraphConfigTextFormat(configText, out var serializedProtoPtr).Assert();

            var config = Protobuf.DeserializeProto(serializedProtoPtr, CalculatorGraphConfig.Parser);
            UnsafeNativeMethods.mp_api_SerializedProto__delete(serializedProtoPtr);

            return config;
        }
    }
}
