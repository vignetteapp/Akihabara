// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

#include <functional>
#include <string>

#include "google/protobuf/stubs/logging.h"
#include "mediapipe_api/external/protobuf.h"

using google::protobuf::LogLevel;

namespace {
  LogHandler* logHandler;
}

void HandleProtobufLog(LogLevel level, const char* filename, int line, const std::string& message) {
  logHandler(level, filename, line, message.c_str());
}

MpReturnCode google_protobuf__SetLogHandler__PF(LogHandler* handler) {
  TRY {
    logHandler = handler;
    google::protobuf::SetLogHandler(&HandleProtobufLog);
    RETURN_CODE(MpReturnCode::Success);
  } CATCH_EXCEPTION
}

void mp_api_SerializedProto__delete(mp_api::SerializedProto* serialized_proto) {
  delete serialized_proto;
}

void mp_api_SerializedProtoVector__delete(mp_api::SerializedProtoVector* serialized_proto_vector) {
  delete serialized_proto_vector;
}
