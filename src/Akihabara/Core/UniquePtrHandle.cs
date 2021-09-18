// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Akihabara.Core
{
    public abstract class UniquePtrHandle : MpResourceHandle
    {
        protected UniquePtrHandle(IntPtr ptr, bool isOwner = true) : base(ptr, isOwner) { }

        /// <returns>The owning pointer</returns>
        public abstract IntPtr Get();

        /// <summary>Release the owning pointer</summary>
        public abstract IntPtr Release();
    }
}
