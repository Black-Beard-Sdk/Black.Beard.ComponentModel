﻿// NOSONAR
// Copyright (c) 2014 Daniel Grunwald
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Diagnostics;

namespace ICSharpCode.Decompiler.IL
{
	partial class StLoc
	{
		/// <summary>
		/// If true, this stloc represents a stack type adjustment.
		/// This field is only used in ILReader and BlockBuilder, and should be ignored by ILAst transforms.
		/// </summary>
		internal bool IsStackAdjustment;

		/// <summary>
		/// Gets whether the IL stack was empty after this store.
		/// Only set for store instructions from the IL; not for stores to the stack
		/// or other stores generated by transforms.
		/// </summary>
		internal bool ILStackWasEmpty;

		internal override void CheckInvariant(ILPhase phase)
		{
			base.CheckInvariant(phase);
			Debug.Assert(phase <= ILPhase.InILReader || this.IsDescendantOf(variable.Function));
			Debug.Assert(phase <= ILPhase.InILReader || variable.Function.Variables[variable.IndexInFunction] == variable);
			Debug.Assert(value.ResultType == variable.StackType);
		}
	}
}
