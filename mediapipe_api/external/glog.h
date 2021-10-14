// Copyright (c) 2021 homuler
//
// Use of this source code is governed by an MIT-style
// license that can be found in the LICENSE file or at
// https://opensource.org/licenses/MIT.

#ifndef C_MEDIAPIPE_API_EXTERNAL_GLOG_H_
#define C_MEDIAPIPE_API_EXTERNAL_GLOG_H_

#include <string>
#include "mediapipe_api/common.h"

extern "C" {

MP_CAPI(void) glog_LOG_INFO__PKc(const char* str);
MP_CAPI(void) glog_LOG_WARNING__PKc(const char* str);
MP_CAPI(void) glog_LOG_ERROR__PKc(const char* str);
MP_CAPI(void) glog_LOG_FATAL__PKc(const char* str);

MP_CAPI(void) google_FlushLogFiles(google::LogSeverity severity);

}  // extern "C"

#endif  // C_MEDIAPIPE_API_EXTERNAL_GLOG_H_
