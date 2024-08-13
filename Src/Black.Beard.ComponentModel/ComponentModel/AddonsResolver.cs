using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bb.ComponentModel.Attributes;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace Bb.ComponentModel
{

    public class AddonsResolver
    {


        public AddonsResolver(AssemblyDirectoryResolver paths = null)
        {

            Paths = paths ?? AssemblyDirectoryResolver.Instance;
            _interfaces = new HashSet<Type>();
            _BaseTypes = new HashSet<Type>();

            _excludedAssemblies = new HashSet<string>();
            FilterAssembly = c => true;
            _excludedAssemblies = new HashSet<string>();

        }


        #region Add directories

        public AddonsResolver AddDirectories(params DirectoryInfo[] paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        public AddonsResolver AddDirectories(IEnumerable<DirectoryInfo> paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        public AddonsResolver AddDirectories(params string[] paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        public AddonsResolver AddDirectories(IEnumerable<string> paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        #endregion Add directories


        #region Filters

        #region ExcludeAbstract

        /// <summary>
        /// set excluding abstract types filter
        /// </summary>
        /// <param name="excludeAbstract"></param>
        /// <returns></returns>
        public AddonsResolver ExcludeAbstractTypes(bool excludeAbstract = true)
        {
            ExcludeAbstracts = excludeAbstract;
            return this;
        }

        /// <summary>
        /// excluding abstract types filter
        /// </summary>
        public bool ExcludeAbstracts { get; set; } = true;

        #endregion

        #region ExcludeAbstract

        /// <summary>
        /// set excluding abstract types filter
        /// </summary>
        /// <param name="excludeAbstract"></param>
        /// <returns></returns>
        public AddonsResolver ExcludeGenericTypes(bool excludeGenerics = true)
        {
            ExcludeGenerics = excludeGenerics;
            return this;
        }

        /// <summary>
        /// excluding abstract types filter
        /// </summary>
        public bool ExcludeGenerics { get; set; } = true;

        #endregion

        #region Assembly

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterAssembly"></param>
        /// <returns></returns>
        public AddonsResolver WhereAssembly(Func<PEFile, bool> filterAssembly)
        {
            FilterAssembly = filterAssembly;
            return this;
        }

        /// <summary>
        /// Define a filter for assemblies to use in the register
        /// </summary>
        public Func<PEFile, bool> FilterAssembly { get; private set; }

        #endregion Assembly


        #region Context

        public AddonsResolver InContext(string context)
        {
            Context = context;
            return this;
        }

        public string Context { get; private set; }

        #endregion Context


        #region Interfaces

        /// <summary>
        /// Add a filter on all interfaces must be implemented
        /// </summary>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        public AddonsResolver Implements(IEnumerable<Type> interfaces)
        {
            foreach (var item in interfaces)
                if (!item.IsInterface)
                    _interfaces.Add(item);
                else
                    throw new ArgumentException($"The type {item.FullName} is an interface");
            return this;
        }

        /// <summary>
        /// Add a filter on all interfaces must be implemented
        /// </summary>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        public AddonsResolver Implements()
        {
            _interfaces.Clear();
            return this;
        }

        /// <summary>
        /// Add a filter on all interfaces must be implemented
        /// </summary>
        /// <param name="interfaces"></param>
        /// <returns></returns>
        public AddonsResolver Implements(params Type[] interfaces)
        {
            foreach (var item in interfaces)
                if (item.IsInterface)
                    _interfaces.Add(item);
                else
                    throw new ArgumentException($"The type {item.FullName} is not an interface");
            return this;
        }

        #endregion Interfaces


        #region base types

        /// <summary>
        /// Add a filter on the possible base types
        /// </summary>
        /// <param name="baseTypes"></param>
        /// <returns></returns>
        public AddonsResolver WithBaseType(IEnumerable<Type> baseTypes)
        {
            foreach (var item in baseTypes)
                _BaseTypes.Add(item);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseTypes"></param>
        /// <returns></returns>
        public AddonsResolver ClearBaseType(IEnumerable<Type> baseTypes)
        {
            _BaseTypes.Clear();
            return this;
        }

        /// <summary>
        /// Add a filter on the possible base types
        /// </summary>
        /// <param name="baseTypes"></param>
        /// <returns></returns>
        public AddonsResolver WithBaseType(params Type[] baseTypes)
        {
            foreach (var item in baseTypes)
                _BaseTypes.Add(item);
            return this;
        }

        #endregion base types


        #region Files

        /// <summary>
        /// Add a filter on file must be evaluated.
        /// </summary>
        /// <param name="fileFilter"></param>
        /// <returns></returns>
        public AddonsResolver WithFile(Func<FileInfo, bool> fileFilter)
        {
            FileFilter = fileFilter;
            return this;
        }

        /// <summary>
        /// Remove filter on <see cref="FileInfo"/>
        /// </summary>
        /// <returns></returns>
        public AddonsResolver ClearWithFile()
        {
            FileFilter = null;
            return this;
        }

        /// <summary>
        /// Filter on <see cref="FileInfo"/>
        /// </summary>
        public Func<FileInfo, bool> FileFilter { get; private set; }

        #endregion Files


        #region Types

        /// <summary>
        /// Add a filter on type must be returned.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public AddonsResolver FilterType(Func<TypeMatched, bool> filter)
        {
            TypeFilter = filter;
            return this;
        }

        /// <summary>
        /// Remove the filter on type
        /// </summary>
        /// <returns></returns>
        public AddonsResolver ClearFilterType()
        {
            TypeFilter = null;
            return this;
        }

        /// <summary>
        /// filter on the finals types selected
        /// </summary>
        public Func<TypeMatched, bool> TypeFilter { get; private set; }

        #endregion Types


        #region Exclude filenames

        /// <summary>
        /// Add filter for exclude filenames
        /// </summary>
        /// <param name="filenames"></param>
        /// <returns></returns>
        public AddonsResolver ExcludeFile(params string[] filenames)
        {
            foreach (var item in filenames)
                _excludedAssemblies.Add(item);
            return this;
        }

        /// <summary>
        /// Clear the list of excluded filenames
        /// </summary>
        /// <param name="filenames"></param>
        /// <returns></returns>
        public AddonsResolver ClearFileFilters(params string[] filenames)
        {
            _excludedAssemblies.Clear();
            return this;
        }


        /// <summary>
        /// List of excluded filenames
        /// </summary>
        public IEnumerable<string> ExcludedAssemblies => _excludedAssemblies.ToArray();

        #endregion Exclude filenames


        #endregion Filters


        /// <summary>
        /// Apply filters and return the list of types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeMatched> Search()
        {

            Filter filter = AddImplementations(AddBaseTypes(AddContext(AddRemoveAsbstract(AddRemoveGenerics()))));

            foreach (FileInfo assemblyPath in Paths.GetAssemblies(FileFilter))
                if (_excludedAssemblies.Count == 0 || _excludedAssemblies.Contains(assemblyPath.Name))
                {

                    PEFile file = GetAssembly(assemblyPath);

                    if (file != null)
                        try
                        {

                            if (FilterAssembly == null || FilterAssembly(file))
                                foreach (var item in file.Module.TypeDefinitions)
                                    if (filter == null || filter.Evaluate(item))
                                    {
                                        TypeMatched result = BuildModel(assemblyPath, file, item);
                                        if (TypeFilter == null || TypeFilter(result))
                                            yield return result;
                                    }

                        }
                        finally
                        {
                            file.Dispose();
                        }

                }

        }

        private static GenericTypeMatched BuildModel(MetadataTypeParameter genericType)
        {

            List<string> contraints = new List<string>(genericType.TypeConstraints.Count);
            foreach (TypeConstraint genericConstraint in genericType.TypeConstraints)
                if (genericConstraint.Type.FullName != "System.Object")
                    contraints.Add(genericConstraint.Type.FullName);

            return new GenericTypeMatched()
            {
                Index = genericType.Index,
                Name = genericType.Name,
                HasDefaultConstructorConstraint = genericType.HasDefaultConstructorConstraint,
                HasValueTypeConstraint = genericType.HasValueTypeConstraint,
                HasReferenceTypeConstraint = genericType.HasReferenceTypeConstraint,
                Constraints = contraints,
            };

        }

        private static TypeMatched BuildModel(FileInfo assemblyPath, PEFile file, ITypeDefinition item)
        {

            List<GenericTypeMatched> list = new List<GenericTypeMatched>();
            foreach (IType subItem in item.TypeArguments)
            {

                var t = subItem as MetadataTypeParameter;

                if (t != null)
                    list.Add(BuildModel(t));

                else
                {

                }
            }

            return new TypeMatched()
            {
                AssemblyLocation = assemblyPath,
                AssemblyName = file.Name,
                AssemblyVersion = file.Version,
                FullName = item.FullName,
                TypeNamespace = item.Namespace,
                TypeName = item.Name,
                DeclaringTypeFullName = item.DeclaringType?.FullName,
                GenericParameters = list,
            };

        }


        /// <summary>
        /// Apply filters and return the list of types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> GetAssemblies()
        {

            foreach (FileInfo assemblyPath in Paths.GetAssemblies(FileFilter))
                if (_excludedAssemblies.Count == 0 || _excludedAssemblies.Contains(assemblyPath.Name))
                {

                    PEFile file = GetAssembly(assemblyPath);

                    if (file != null)
                        try
                        {
                            if (FilterAssembly == null || FilterAssembly(file))
                                yield return new KeyValuePair<string, string>(file.FileName, file.Module.FullAssemblyName);
                        }
                        finally
                        {
                            file.Dispose();
                        }

                }

        }


        public PEFile GetAssembly(FileInfo file)
        {

            PEFile peFile = null;
            try
            {
                peFile = new PEFile(file.FullName);
            }
            catch (PEFileNotSupportedException)
            {
                Paths.AddFileNotLoading(file.FullName);
            }

            return peFile;

        }


        #region Apply filters

        private Filter AddImplementations(Filter parent)
        {


            if (this._interfaces.Count > 0)
            {
                var f = new Filter(candidate =>
                {
                    foreach (var item in _interfaces)
                    {
                        HashSet<IType> list = new HashSet<IType>();
                        var itemBase = candidate.Compilation.FindType(item);
                        if (!EvaluateSubInterface(itemBase, candidate, list))
                            return false;
                    }

                    return true;

                });

                if (parent != null)
                    parent.Fill(f);
                else
                    parent = f;

            }

            return parent;

        }

        private Filter AddRemoveAsbstract(Filter parent = null)
        {

            if (this.ExcludeAbstracts)
            {

                var f = new Filter(candidate => !candidate.IsAbstract);

                if (parent != null)
                    parent.Fill(f);
                else
                    parent = f;

            }

            return parent;

        }

        private Filter AddRemoveGenerics(Filter parent = null)
        {

            if (this.ExcludeGenerics)
            {

                var f = new Filter(candidate => !candidate.TypeArguments.Any());

                if (parent != null)
                    parent.Fill(f);
                else
                    parent = f;

            }

            return parent;

        }


        private Filter AddContext(Filter parent = null)
        {

            if (!string.IsNullOrEmpty(this.Context))
            {

                var f = new Filter(candidate =>
                {
                    var attr = candidate.GetAttributes().Where(k => k.AttributeType.FullName == typeof(ExposeClassAttribute).FullName).FirstOrDefault();
                    if (attr != null)
                    {

                        var context = attr.FixedArguments.FirstOrDefault();
                        if (context.Value != null && context.Value.ToString() == this.Context)
                            return true;

                        var context2 = attr.NamedArguments.Where(c => c.Name == nameof(ExposeClassAttribute.Context)).FirstOrDefault();
                        if (context2.Value != null && context2.Value.ToString() == this.Context)
                            return true;

                    }

                    return false;

                });

                if (parent != null)
                    parent.Fill(f);
                else
                    parent = f;

            }

            return parent;

        }

        private Filter AddBaseTypes(Filter parent)
        {

            if (this._BaseTypes.Count > 0)
            {
                var f = new Filter(c =>
                {

                    if (c.DirectBaseTypes != null)
                        foreach (Type item in _BaseTypes)
                        {

                            var itemBase = c.Compilation.FindType(item);

                            if (EvaluateSubType(itemBase, c))
                                return true;

                        }

                    return false;
                });

                if (parent != null)
                    parent.Fill(f);
                else
                    parent = f;

            }

            return parent;

        }

        private bool EvaluateSubInterface(IType baseTypeToFind, IType baseTypeToEvaluate, HashSet<IType> list)
        {

            if (list.Add(baseTypeToEvaluate))
            {

                var types = baseTypeToEvaluate.GetAllBaseTypes();

                foreach (var item2 in types)
                {

                    if (item2.FullName == baseTypeToFind.FullName)
                        return true;

                    if (EvaluateSubInterface(baseTypeToFind, item2, list))
                        return true;

                }

            }

            return false;

        }

        private bool EvaluateSubType(IType baseTypeToFind, IType baseTypeToEvaluate)
        {

            foreach (var baseType in baseTypeToEvaluate.GetNonInterfaceBaseTypes())
            {

                if (baseTypeToFind.FullName == baseType.FullName)
                    return true;

                var t = baseType as MetadataTypeDefinition;
                if (t != null)
                    return EvaluateSubType(baseTypeToFind, t);

            }

            return false;

        }

        internal object ExcludeAbstractTypes(object excludeAbstractTypes)
        {
            throw new NotImplementedException();
        }

        internal object ExcludeGenericTypes(object excludeGenericTypes)
        {
            throw new NotImplementedException();
        }


        #endregion Apply filters


        public AssemblyDirectoryResolver Paths { get; }
        public static bool HasValueTypeConstraint { get; private set; }
        public static bool HasReferenceTypeConstraint { get; private set; }

        private readonly HashSet<Type> _interfaces;
        private readonly HashSet<Type> _BaseTypes;
        private HashSet<string> _excludedAssemblies;

    }



}
