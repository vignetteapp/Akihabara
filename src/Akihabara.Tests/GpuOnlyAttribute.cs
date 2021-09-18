// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

using NUnit.Framework;
using System;

[AttributeUsage(AttributeTargets.Method, AllowMultiple=false)]
public class GpuOnlyAttribute : CategoryAttribute {}
