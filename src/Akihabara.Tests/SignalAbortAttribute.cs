// Copyright (c) homuler & The Vignette Authors. Licensed under the MIT license.
// See the LICENSE file in the repository root for more details.

using System;
using NUnit.Framework;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class SignalAbortAttribute : CategoryAttribute
{
    public SignalAbortAttribute() : base("SignalAbortTest") { }
}
