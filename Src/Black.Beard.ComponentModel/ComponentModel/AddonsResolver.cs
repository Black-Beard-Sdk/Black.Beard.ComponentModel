using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.Decompiler.TypeSystem.Implementation;

namespace Bb.ComponentModel
{

    /// <summary>
    /// The AddonsResolver class is responsible for resolving and filtering assemblies and types based on various criteria.
    /// </summary>
    /// <remarks>
    /// This class provides methods to add directories, filter assemblies and types, and search for types and assemblies that match the specified criteria.
    /// </remarks>
    public class AddonsResolver
    {


        /// <summary>
        /// Helper for creating a new instance of <see cref="AddonsResolver"/>
        /// </summary>
        public static AddonsResolver New { get; } = new();

        /// <summary>
        /// Initialize a new instance of <see cref="AddonsResolver"/>
        /// </summary>
        /// <param name="paths">Path to add for analyses. Must not be null.</param>
        public AddonsResolver(params string[] paths)
            : this(AssemblyDirectoryResolver.Instance)
        {
            Paths.AddDirectories(paths);
        }

        /// <summary>
        /// Create a new instance of <see cref="AddonsResolver"/>
        /// </summary>
        /// <param name="paths">Path to add for analyses. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when paths is null.</exception>
        public AddonsResolver(AssemblyDirectoryResolver? paths)
        {

            Paths = paths ?? AssemblyDirectoryResolver.Instance;
            _interfaces = new HashSet<Type>();
            _BaseTypes = new HashSet<Type>();

            _excludedAssemblies = new HashSet<string>();
            _restrictAssemblies = new HashSet<string>();

        }


        /// <summary>
        /// Add a list of repositories
        /// </summary>
        /// <param name="repositories">The repositories to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method adds the specified repositories to the resolver's path list for analysis.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when repositories is null.</exception>
        public AddonsResolver With(ExposedAssemblyRepositories repositories)
        {
            if (repositories != null)
            {

                foreach (var item in repositories.ByFolder)
                    AddDirectories(item.Path);

                foreach (var item in repositories.ByName)
                    AddAssemblyByName(item.AssemblyName);

            }
            return this;

        }


        #region Add directories

        /// <summary>
        /// Add a list of directories to the resolver's path list for analysis.
        /// </summary>
        /// <param name="paths">The paths of the directories to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <exception cref="ArgumentNullException">Thrown when paths is null.</exception>
        /// <remarks>
        /// This method adds the specified directories to the resolver's path list for analysis.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var resolver = new AddonsResolver();
        /// resolver.AddDirectories(new DirectoryInfo("path1"), new DirectoryInfo("path2"));
        /// </code>
        /// </example>
        public AddonsResolver AddDirectories(params DirectoryInfo[] paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        /// <summary>
        /// Add a list of directories to the resolver's path list for analysis.
        /// </summary>
        /// <param name="paths">The paths of the directories to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <exception cref="ArgumentNullException">Thrown when paths is null.</exception>
        /// <remarks>
        /// This method adds the specified directories to the resolver's path list for analysis.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var resolver = new AddonsResolver();
        /// resolver.AddDirectories(new [] { new DirectoryInfo("path1"), new DirectoryInfo("path2" }));
        /// </code>
        /// </example>
        public AddonsResolver AddDirectories(IEnumerable<DirectoryInfo> paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        /// <summary>
        /// Add a list of directories to the resolver's path list for analysis.
        /// </summary>
        /// <param name="paths">The paths of the directories to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <exception cref="ArgumentNullException">Thrown when paths is null.</exception>
        /// <remarks>
        /// This method adds the specified directories to the resolver's path list for analysis.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var resolver = new AddonsResolver();
        /// resolver.AddDirectories("path1", "path2");
        /// </code>
        /// </example>
        public AddonsResolver AddDirectories(params string[] paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        /// <summary>
        /// Add a list of directories to the resolver's path list for analysis.
        /// </summary>
        /// <param name="paths">The paths of the directories to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <exception cref="ArgumentNullException">Thrown when paths is null.</exception>
        /// <remarks>
        /// This method adds the specified directories to the resolver's path list for analysis.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var resolver = new AddonsResolver();
        /// resolver.AddDirectories(new string[] { "path1", "path2" });
        /// </code>
        /// </example>
        public AddonsResolver AddDirectories(IEnumerable<string> paths)
        {
            Paths.AddDirectories(paths);
            return this;
        }

        #endregion Add directories


        #region Filters

        #region ExcludeAbstract

        /// <summary>
        /// Set excluding abstract types filter
        /// </summary>
        /// <param name="excludeAbstract">If true, exclude abstract types.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to exclude abstract types from the analysis.
        /// </remarks>
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
        /// Set excluding generic types filter
        /// </summary>
        /// <param name="excludeGenerics">If true, exclude generic types.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to exclude generic types from the analysis.
        /// </remarks>
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
        /// Add an assembly name to the resolver's list for analysis.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to add. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method adds the specified assembly name to the resolver's list for analysis.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when assemblyName is null.</exception>
        public AddonsResolver AddAssemblyByName(string assemblyName)
        {
            AssemblyLoader.Instance.LoadAssemblyName(assemblyName);
            return this;
        }

        /// <summary>
        /// Filter on assembly name
        /// </summary>
        /// <param name="type">The type whose assembly to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only assemblies that reference the specified type's assembly.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when type is null.</exception>
        public AddonsResolver WithReference(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var ass = type.Assembly;
            WithReference(ass);
            return this;
        }

        /// <summary>
        /// Filter on assembly name
        /// </summary>
        /// <param name="assembly">The assembly to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only assemblies that reference the specified assembly.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when assembly is null.</exception>
        public AddonsResolver WithReference(Assembly assembly)
        {

            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            WithReference(assembly.GetName());
            return this;
        }

        /// <summary>
        /// Filter on assembly name
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only assemblies that reference the specified assembly name.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when assemblyName is null.</exception>
        public AddonsResolver WithReference(AssemblyName assemblyName)
        {
            this.WhereAssembly(c => assemblyName.Name != c.Name && c.AssemblyReferences.References(assemblyName));
            return this;
        }

        /// <summary>
        /// Evaluate if the assembly must be used
        /// </summary>
        /// <param name="filterAssembly">The filter function to evaluate assemblies. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter function to evaluate if an assembly must be used.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when filterAssembly is null.</exception>
        public AddonsResolver WhereAssembly(Func<PEFile, bool> filterAssembly)
        {
            if (FilterAssembly == null)
                FilterAssembly = filterAssembly;
            else
            {
                var old = FilterAssembly;
                FilterAssembly = c => old(c) && filterAssembly(c);
            }
            return this;
        }

        /// <summary>
        /// Define a filter for assemblies to use in the register
        /// </summary>
        public Func<PEFile, bool> FilterAssembly { get; private set; }

        #endregion Assembly

        #region Context

        /// <summary>
        /// Set the context for the resolver
        /// </summary>
        /// <param name="context">The context to set. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets the context for the resolver.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when context is null.</exception>
        public AddonsResolver InContext(string context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            return this;
        }

        /// <summary>
        /// The context for the resolver
        /// </summary>
        public string Context { get; private set; }

        #endregion Context

        #region Interfaces

        /// <summary>
        /// Add a filter on all interfaces must be implemented
        /// </summary>
        /// <param name="interfaces">The interfaces to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only types that implement the specified interfaces.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when interfaces is null.</exception>
        /// <exception cref="ArgumentException">Thrown when an item in interfaces is not an interface.</exception>
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
        /// Clear the filter on all interfaces must be implemented
        /// </summary>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method clears the filter on all interfaces that must be implemented.
        /// </remarks>
        public AddonsResolver ClearImplements()
        {
            _interfaces.Clear();
            return this;
        }

        /// <summary>
        /// Add a filter on all interfaces must be implemented
        /// </summary>
        /// <param name="interfaces">The interfaces to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only types that implement the specified interfaces.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when interfaces is null.</exception>
        /// <exception cref="ArgumentException">Thrown when an item in interfaces is not an interface.</exception>
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
        /// <param name="baseTypes">The base types to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only types that have the specified base types.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when baseTypes is null.</exception>
        public AddonsResolver WithBaseType(IEnumerable<Type> baseTypes)
        {
            foreach (var item in baseTypes)
                _BaseTypes.Add(item);
            return this;
        }

        /// <summary>
        /// Clear the filter on the possible base types
        /// </summary>
        /// <param name="baseTypes">The base types to clear. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method clears the filter on the possible base types.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when baseTypes is null.</exception>
        public AddonsResolver ClearBaseType(IEnumerable<Type> baseTypes)
        {
            _BaseTypes.Clear();
            return this;
        }

        /// <summary>
        /// Add a filter on the possible base types
        /// </summary>
        /// <param name="baseTypes">The base types to filter. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to include only types that have the specified base types.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when baseTypes is null.</exception>
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
        /// <param name="fileFilter">The filter function to evaluate files. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter function to evaluate if a file must be used.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when fileFilter is null.</exception>
        public AddonsResolver WithFile(Func<FileInfo, bool> fileFilter)
        {
            if (FileFilter == null)
                FileFilter = fileFilter;

            else
            {
                var p = FileFilter;
                FileFilter = c => p(c) && fileFilter(c);
            }

            return this;
        }

        /// <summary>
        /// Remove filter on <see cref="FileInfo"/>
        /// </summary>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method removes the filter on <see cref="FileInfo"/>.
        public AddonsResolver ClearWithFile()
        {
            FileFilter = null;
            return this;
        }

        /// <summary>
        /// Filter on <see cref="FileInfo"/>
        /// </summary>
        public Func<FileInfo, bool> FileFilter { get; private set; }

        private bool Filter(FileInfo assemblyPath)
        {
            if (_excludedAssemblies.Count == 0 || !_excludedAssemblies.Contains(assemblyPath.Name))
                if (_restrictAssemblies.Count == 0 || _restrictAssemblies.Contains(assemblyPath.Name))
                    return true;

            return false;

        }

        #endregion Files

        #region Types

        /// <summary>
        /// Add a filter on type must be returned.
        /// </summary>
        /// <param name="filter">The filter function to evaluate types. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter function to evaluate if a type must be returned.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when filter is null.</exception>
        public AddonsResolver FilterType(Func<TypeMatched, bool> filter)
        {
            if (TypeFilter == null)
                TypeFilter = filter;

            else
            {
                var p = TypeFilter;
                TypeFilter = c => p(c) && filter(c);
            }

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
        /// Filter on the final types selected
        /// </summary>
        public Func<TypeMatched, bool> TypeFilter { get; private set; }

        #endregion Types

        #region Exclude filenames

        /// <summary>
        /// Add filter for exclude filenames
        /// </summary>
        /// <param name="assemblies">list of assembly to exclude</param>
        /// <returns></returns>
        public AddonsResolver AddExcludeAssemblies(params string[] assemblies)
        {
            foreach (var item in assemblies)
            {

                var p = item;
                if (p.ToLower().EndsWith(".dll") || p.ToLower().EndsWith(".exe"))
                    p = p.Substring(0, p.Length - 4);

                _excludedAssemblies.Add(p + ".dll");
                _excludedAssemblies.Add(p + ".exe");

            }

            return this;
        }

        /// <summary>
        /// Add filter for restrict assembly name
        /// </summary>
        /// <param name="assemblies">list of assembly to restrict</param>
        /// <returns></returns>
        public AddonsResolver AddRestrictAssemblies(params string[] assemblies)
        {
            foreach (var item in assemblies)
            {

                var p = item;
                if (p.ToLower().EndsWith(".dll") || p.ToLower().EndsWith(".exe"))
                    p = p.Substring(0, p.Length - 4);

                _restrictAssemblies.Add(p + ".dll");
                _restrictAssemblies.Add(p + ".exe");

            }

            return this;
        }

        /// <summary>
        /// Add filter for restrict assembly name
        /// </summary>
        /// <param name="assemblies">list of assembly to restrict</param>
        /// <returns></returns>
        public AddonsResolver AddRestrictAssemblies(params AssemblyMatched[] assemblies)
        {
            foreach (var item in assemblies)
            {
                var p = item.AssemblyName;
                if (p.ToLower().EndsWith(".dll") || p.ToLower().EndsWith(".exe"))
                    p = p.Substring(0, p.Length - 4);

                _restrictAssemblies.Add(p + ".dll");
                _restrictAssemblies.Add(p + ".exe");

            }
            return this;
        }

        /// <summary>
        /// Add filter for restrict assembly name
        /// </summary>
        /// <param name="assemblies">list of assembly to restrict</param>
        /// <returns></returns>
        public AddonsResolver AddRestrictAssemblies(IEnumerable<AssemblyMatched> assemblies)
        {
            foreach (var item in assemblies)
            {
                var p = item.AssemblyName;
                if (p.ToLower().EndsWith(".dll") || p.ToLower().EndsWith(".exe"))
                    p = p.Substring(0, p.Length - 4);

                _restrictAssemblies.Add(p + ".dll");
                _restrictAssemblies.Add(p + ".exe");

            }
            return this;
        }

        /// <summary>
        /// remove all excluded filenames
        /// </summary>
        /// <param name="filenames">The filenames to exclude. Must not be null.</param>
        /// <returns><see cref="AddonsResolver"/> fluent syntax</returns>
        /// <remarks>
        /// This method sets a filter to exclude the specified filenames.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when filenames is null.</exception>
        public AddonsResolver ClearAssemblyFilters(params string[] filenames)
        {
            _excludedAssemblies.Clear();
            return this;
        }


        /// <summary>
        /// List of excluded filenames
        /// </summary>
        public IEnumerable<string> ExcludedAssemblies => _excludedAssemblies.ToArray();

        public IEnumerable<string> RestrictAssemblies => _restrictAssemblies.ToArray();


        #endregion Exclude filenames


        #endregion Filters



        /// <summary>
        /// Apply filters and return the list of types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TypeMatched> SearchTypes()
        {

            Filter filter = AddImplementations(AddBaseTypes(AddContext(AddRemoveAsbstract(AddRemoveGenerics()))));

            foreach (PEFile file in ParseAssemblies())
                foreach (var item in file.Module.TypeDefinitions)
                    if (filter == null || filter.Evaluate(item))
                    {
                        TypeMatched result = BuildModel(new FileInfo(file.FullName), file, item);
                        if (TypeFilter == null || TypeFilter(result))
                            yield return result;
                    }

        }


        /// <summary>
        /// Return a list of assembly referenced by entry assembly
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssemblyMatched> SearchListOfReferences()
        {
            return SearchListReferences(Assembly.GetEntryAssembly());

        }

        /// <summary>
        /// Return a list of assembly referenced by specified assembly
        /// </summary>
        /// <param name="assembly">assembly to evaluate</param>
        /// <returns></returns>
        public IEnumerable<AssemblyMatched> SearchListReferences(Assembly assembly)
        {
            Dictionary<string, AssemblyMatched> _list = new Dictionary<string, AssemblyMatched>();
            var filePath = new FileInfo(assembly.Location);
            if (TryToLoadFile(filePath, out PEFile peFile))
            {

                if (FilterAssembly == null || FilterAssembly(peFile))
                {
                    var ass = BuildModelAssembly(filePath, peFile);
                    if (!_list.ContainsKey(assembly.GetName().Name))
                        _list.Add(assembly.GetName().Name, ass);
                }

                EvaluateReferences(peFile, _list);
            }
            return _list.Values;

        }

        /// <summary>
        /// Apply filters and return the list of assemblies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AssemblyMatched> SearchAssemblies()
        {
            foreach (PEFile file in ParseAssemblies())
            {
                AssemblyMatched result = BuildModelAssembly(new FileInfo(file.FileName), file);
                yield return result;
            }
        }

        /// <summary>
        /// Apply filters and return the list of types
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<string, string>> GetAssemblies()
        {
            foreach (PEFile file in ParseAssemblies())
                yield return new KeyValuePair<string, string>(file.FileName, file.Module.FullAssemblyName);
        }

        /// <summary>
        /// Return a list of types that match the specified criteria.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PEFile> ParseAssemblies()
        {

            foreach (FileInfo assemblyPath in Paths.GetAssembliesOfDirectories(FileFilter))
                if (Filter(assemblyPath))
                    if (TryToLoadFile(assemblyPath, out PEFile file))
                        try
                        {
                            if (FilterAssembly == null || FilterAssembly(file))
                                yield return file;
                        }
                        finally
                        {
                            file.Dispose();
                        }

        }

        /// <summary>
        /// Try to load file for Assembly
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="peFile">file loaded is succeed</param>
        /// <returns></returns>
        public bool TryToLoadFile(FileInfo filename, out PEFile peFile)
        {

            peFile = null;
            try
            {
                peFile = new PEFile(filename.FullName);
            }
            catch (PEFileNotSupportedException)
            {
                Paths.AddFileForNotLoad(filename.FullName);
            }

            return peFile != null;

        }


        private void EvaluateReferences(PEFile file, Dictionary<string, AssemblyMatched> list)
        {
            foreach (var item in file.AssemblyReferences)
                if (!list.ContainsKey(item.Name))
                    Resolve(item, list);
        }

        /// <summary>
        /// Resolves the specified assembly reference and adds it to the list if it is not already present.
        /// </summary>
        /// <param name="item">The assembly reference to resolve. Must not be null.</param>
        /// <param name="list">The dictionary to add the resolved assembly to. Must not be null.</param>
        /// <exception cref="ArgumentNullException">Thrown when item or list is null.</exception>
        /// <remarks>
        /// This method attempts to resolve the specified assembly reference and adds it to the provided dictionary if it is not already present.
        /// </remarks>
        private void Resolve(AssemblyReference item, Dictionary<string, AssemblyMatched> list)
        {
            if (Paths.TryToResolveAssemblyLocation(new AssemblyName(item.FullName), out var filePath))
                if (Filter(filePath))
                    if (TryToLoadFile(filePath, out PEFile peFile))
                        if (FilterAssembly == null || FilterAssembly(peFile))
                        {
                            var assembly = BuildModelAssembly(filePath, peFile);
                            if (!list.ContainsKey(assembly.AssemblyName))
                                list.Add(assembly.AssemblyName, assembly);
                            EvaluateReferences(peFile, list);
                        }
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

        /// <summary>
        /// List of path where assemblies are stored
        /// </summary>
        public AssemblyDirectoryResolver Paths { get; }

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

        private static AssemblyMatched BuildModelAssembly(FileInfo assemblyPath, PEFile file)
        {

            var isEntryDirectory = AssemblyDirectoryResolver.IsEntryDirectory(assemblyPath.Directory);
            var isSystemDirectory = AssemblyDirectoryResolver.IsSystemDirectory(assemblyPath.Directory);

            var result = new AssemblyMatched()
            {
                AssemblyLocation = assemblyPath,
                AssemblyName = file.Name,
                AssemblyVersion = file.Version,
                IsEntryDirectory = isEntryDirectory,
                IsSystemDirectory = isSystemDirectory,
                IsSdk = isSystemDirectory || file.IsSdk()
            };

            result.ResolveIfLoaded();

            return result;

        }

        private readonly HashSet<Type> _interfaces;
        private readonly HashSet<Type> _BaseTypes;
        private HashSet<string> _excludedAssemblies;
        private HashSet<string> _restrictAssemblies;

    }


}
