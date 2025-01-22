using Bb.ComponentModel;
using Bb.Decompilers;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Resolver;
using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.Semantics;
using ICSharpCode.Decompiler.TypeSystem;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Bb.Diagnostics
{
    public static class ActivityExtensions
    {


        public static IEnumerable<ActivitySourceInstance> FindActivitySourceCreations(this Type type)
        {
            return type.Assembly.FindActivitySourceCreations();
        }

        public static IEnumerable<ActivitySourceInstance> FindActivitySourceCreations(this Assembly assembly)
        {
            return assembly.Location.FindActivitySourceCreations();
        }

        public static IEnumerable<ActivitySourceInstance> FindActivitySourceCreations(this string assemblyPath)
        {

            if (!File.Exists(assemblyPath))
                throw new FileNotFoundException(assemblyPath);

            var activitySources = new HashSet<ActivitySourceInstance>();
            var type = typeof(ActivitySource);
            using (var peFile = new PEFile(assemblyPath))
                if (peFile.Reference(type))
                {

                    DecompilerSettings settings = new DecompilerSettings() { ThrowOnAssemblyResolveErrors = false };
                    var typeSystem = peFile.CreateTypeSystem(settings, out var assemblyResolver, out var decompiler);
                    var resolver = new CSharpResolver(typeSystem);
                    var metadata = peFile.Metadata;

                    HashSet<IType> _typeToExporing = ResolveTypeToExplore(type, peFile, metadata);

                    foreach (var handle in metadata.MethodDefinitions)
                    {

                        var method = peFile.Module.GetDefinition((MethodDefinitionHandle)handle);
                        if (!_typeToExporing.Contains(method.DeclaringType))
                            continue;

                        var o = decompiler.Decompile(handle);
                        o.Search(c =>
                        {
                            c.OnObjectCreateExpression(f => f.Match(type), d =>
                            {
                                var o = d.Arguments.FirstOrDefault();
                                if (o != null)
                                {
                                    ActivitySourceInstance? txt = Resolve(peFile, method, handle, o, decompiler);
                                    if (txt.HasValue)
                                        activitySources.Add(txt.Value);
                                }
                            });
                        });

                    }

                }

            return activitySources;

        }

        private static HashSet<IType> ResolveTypeToExplore(Type type, PEFile peFile, MetadataReader metadata)
        {
            HashSet<IType> _typeToExporing = new HashSet<IType>();
            foreach (var handle in metadata.FieldDefinitions)
            {
                var m = peFile.Module.GetDefinition((FieldDefinitionHandle)handle);
                if (m.Type.Match(type))
                    _typeToExporing.Add(m.DeclaringType);
            }

            return _typeToExporing;
        }

        private static ActivitySourceInstance? Resolve(PEFile peFile, IMethod method, MethodDefinitionHandle handle, Expression o, CSharpDecompiler decompiler)
        {

            var pp = o.ResolveSemantic();
            switch (pp)
            {

                case SemanticEnum.Member:
                    var result = ResolveMember(peFile, o);
                    if (result.HasValue)
                        return result.Value;

                    break;

                case SemanticEnum.Constant:
                    return ResolveConstant(peFile, method, o);

                case SemanticEnum.LocalVariable:
                    return ResolveLocalVariable(peFile, method, handle, o, decompiler);

                default:
                    break;

            }

            return null;

        }

        private static ActivitySourceInstance? ResolveLocalVariable(PEFile peFile, IMethod method, MethodDefinitionHandle handle, Expression o, CSharpDecompiler decompiler)
        {
            ActivitySourceInstance? result = null;
            var variableName = o.AsIdentifier()?.Identifier;
            var o2 = decompiler.Decompile(handle);
            o2.Search(c =>
            {
                c.OnVariableDeclarationStatement(f => f.Variables.Any(d => d.Name == variableName),
                    d =>
                    {
                        VariableInitializer v = d.Variables.Last();
                        result = Resolve(peFile, method, handle, v.Initializer, decompiler);
                    });

                c.OnAssignmentExpression(f => f.Left.ToString() == variableName,
                    d =>
                    {

                    });
            });

            return result;

        }

        private static ActivitySourceInstance? ResolveConstant(PEFile peFile, IMethod method, Expression o)
        {
            var member2 = o.ResolveSemantic<ConstantResolveResult>();
            if (member2 != null)
            {
                if (member2.Type.Name == "String")
                    return new ActivitySourceInstance(peFile.Module.AssemblyName, method.DeclaringType.FullName, member2.ConstantValue.ToString());
                else
                {

                }
            }
            else
            {
                var value = o as PrimitiveExpression;
                if (value != null && value.Value is string txt)
                    return new ActivitySourceInstance(peFile.Module.AssemblyName, method.DeclaringType.FullName, txt);
                else
                {

                }
            }

            return null;

        }

        private static ActivitySourceInstance? ResolveMember(PEFile peFile, Expression o)
        {

            var member = o.ResolveSemantic<MemberResolveResult>()?.Member;
            if (member.IsStatic)
            {
                var n = member.DeclaringTypeDefinition.Compilation.MainModule.FullAssemblyName;
                var assembly = TypeDiscovery.Instance.GetAssembly(n);
                var type = assembly.GetType(member.DeclaringTypeDefinition.FullName);

                var fields = type.GetFields();
                var field = fields.FirstOrDefault(c => c.Name == member.Name);
                if (field != null)
                {
                    var value = field?.GetValue(null);
                    if (value != null)
                        return new ActivitySourceInstance(peFile.Module.AssemblyName, member.DeclaringType.FullName, value.ToString());
                }

                var properties = type.GetProperties();
                var property = properties.FirstOrDefault(c => c.Name == member.Name);
                if (property != null)
                {
                    var value = property?.GetValue(null);
                    if (value != null)
                        return new ActivitySourceInstance(peFile.Module.AssemblyName, member.DeclaringType.FullName, value.ToString());
                }

            }
            else
            {

            }

            return null;

        }
    }

    /// <summary>
    /// Temporary structure to store the activity source.
    /// </summary>
    [DebuggerDisplay("{AssemblyName} {SourceName}")]
    public struct ActivitySourceInstance
    {

        public ActivitySourceInstance(string assemblyName, string type, string activitySourceName)
        {
            this.AssemblyName = assemblyName;
            this.Type = type;
            this.SourceName = activitySourceName;
        }

        public string AssemblyName { get; }

        public string Type { get; }

        public string SourceName { get; }

    }

}
