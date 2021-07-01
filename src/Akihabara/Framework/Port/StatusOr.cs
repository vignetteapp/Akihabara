using System;
using Akihabara.Core;
using Google.Protobuf.WellKnownTypes;

namespace Akihabara.Framework.Port
{
    public abstract  class StatusOr<T> : MpResourceHandle
    {
        public StatusOr(IntPtr ptr) : base(ptr)
        {
        }
        
        public abstract bool Ok { get; }
        public abstract  Status status { get; }
        public abstract T Value();

        public virtual T ValueOr(T defaultVal)
        {
            return !Ok ? defaultVal : Value();
        }
    }
}