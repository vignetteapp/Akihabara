namespace Akihabara.Native.External
{
    public enum MpReturnCode : int
    {
        /// <summary>
        /// A standard Exception is thrown
        /// </summary>
        Success = 0,
        /// <summary>
        /// An error beyond standard Exception is thrown
        /// </summary>
        UnknownError = 70,
        /// <summary>
        /// SDK failed to set the status code
        /// </summary>
        Unset = 128,
        /// <summary>
        ///  Received an abort signal (SIGABRT)
        /// </summary>
        Aborted = 134
    }
}