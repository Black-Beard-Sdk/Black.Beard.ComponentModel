﻿// Copyright (c) 2014 Daniel Grunwald
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

using System.Linq;

using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.Semantics;

namespace ICSharpCode.Decompiler.CSharp.Transforms
{
	/// <summary>
	/// Escape invalid identifiers.
	/// </summary>
	/// <remarks>
	/// This transform is not enabled by default.
	/// </remarks>
	public class EscapeInvalidIdentifiers : IAstTransform
	{
		bool IsValid(char ch)
		{
			if (char.IsLetterOrDigit(ch))
				return true;
			if (ch == '_')
				return true;
			return false;
		}

		string ReplaceInvalid(string s)
		{
			string name = string.Concat(s.Select(ch => IsValid(ch) ? ch.ToString() : string.Format("_{0:X4}", (int)ch)));
			if (name.Length >= 1 && !(char.IsLetter(name[0]) || name[0] == '_'))
				name = "_" + name;
			return name;
		}

		public void Run(AstNode rootNode, TransformContext context)
		{
			foreach (var ident in rootNode.DescendantsAndSelf.OfType<Identifier>())
			{
				ident.Name = ReplaceInvalid(ident.Name);
			}
		}
	}

	/// <summary>
	/// This transform is used to remove assembly-attributes that are generated by the compiler,
	/// thus don't need to be declared. (We have to remove them, in order to avoid conflicts while compiling.)
	/// </summary>
	/// <remarks>This transform is only enabled, when exporting a full assembly as project.</remarks>
	public class RemoveCompilerGeneratedAssemblyAttributes : IAstTransform
	{
		public void Run(AstNode rootNode, TransformContext context)
		{
			foreach (var section in rootNode.Children.OfType<AttributeSection>())
			{
				if (section.AttributeTarget != "assembly")
					continue;
				foreach (var attribute in section.Attributes)
				{
					var trr = attribute.Type.Annotation<TypeResolveResult>();
					if (trr != null && trr.Type.FullName == "System.Runtime.Versioning.TargetFrameworkAttribute")
						attribute.Remove();
				}
				if (section.Attributes.Count == 0)
					section.Remove();
			}
		}
	}
}