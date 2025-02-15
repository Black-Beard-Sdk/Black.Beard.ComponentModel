using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Metadata;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using Xunit;
using Bb.Decompilers;
using ICSharpCode.Decompiler.TypeSystem;

namespace DynamicDescriptors.Tests
{
    public sealed class ExceptionsTest
    {

        [Fact]
        public void Test1()
        {


            try
            {

                var ex = new Exception();
                throw ex;

            }
            catch (Exception ex)
            {

                var stack = new StackTrace(ex);

                for (int i = 0; i < stack.FrameCount; i++)
                {

                    var frame = stack.GetFrame(i);
                    var ilOffset = frame.GetNativeOffset();
                    var method = frame.GetMethod();

                    var type = frame.GetMethod().DeclaringType;

                    var assembly = method.DeclaringType.Assembly;
                    if (!assembly.IsDynamic)
                    {

                        var assemblyPath = assembly.Location.ToString();

                        using (var peFile = new PEFile(assemblyPath))
                        {

                            DecompilerSettings settings = new DecompilerSettings() { ThrowOnAssemblyResolveErrors = false };
                            var typeSystem = peFile.CreateTypeSystem(settings, out var assemblyResolver, out var decompiler);
                            var resolver = new CSharpResolver(typeSystem);
                            var metadata = peFile.Metadata;

                            foreach (var handle in metadata.MethodDefinitions)
                            {

                                IMethod method1 = peFile.Module
                                    .GetDefinition((MethodDefinitionHandle)handle);
                                var type2 = method1.DeclaringType;

                                if (type2.Match(type))
                                {

                                    if (method1.Match(method))
                                    {

                                        var o = decompiler.Decompile(handle);

                                    }


                                }


                            }


                        }

                    }
                }


            }

        }

    }


}
