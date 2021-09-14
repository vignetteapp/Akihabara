using System;
using Akihabara.Core;
using Akihabara.Native;

namespace Akihabara.Framework.Port
{
    public class Status : MpResourceHandle
    {
        public enum StatusCode : int
        {
            Ok = 0,
            Cancelled = 1,
            Unknown = 2,
            InvalidArgument = 3,
            DeadlineExceeded = 4,
            NotFound = 5,
            AlreadyExists = 6,
            PermissionDenied = 7,
            ResourceExhausted = 8,
            FailedPrecondition = 9,
            Aborted = 10,
            OutOfRange = 11,
            Unimplemented = 12,
            Internal = 13,
            Unavailable = 14,
            DataLoss = 15,
            Unauthenticated = 16,
        }

        public Status(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner)
        {
        }

        protected override void DeleteMpPtr() => UnsafeNativeMethods.absl_Status__delete(Ptr);

        public bool ok => SafeNativeMethods.absl_Status__ok(Ptr);

        public void AssertOk()
        {
            if (!ok)
                throw new MediapipeException(ToString());
        }

        public StatusCode Code => (StatusCode)RawCode;
        public int RawCode => SafeNativeMethods.absl_Status__raw_code(MpPtr);

        public override string ToString() => MarshalStringFromNative(UnsafeNativeMethods.absl_Status__ToString);

        public static Status Build(StatusCode code, string message, bool isOwner = true)
        {
            UnsafeNativeMethods.absl_Status__i_PKc((int)code, message, out var ptr).Assert();

            return new Status(ptr, isOwner);
        }

        public static Status Ok(bool isOwner = true) => Status.Build(StatusCode.Ok, "", isOwner);

        public static Status FailedPrecondition(string message = "", bool isOwner = true) =>
            Status.Build(StatusCode.FailedPrecondition, message, isOwner);

    }
}
