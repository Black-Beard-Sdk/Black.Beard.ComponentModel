using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;


namespace Bb.ComponentModel
{


    public class TypeDiscovery
    {


        #region Initialize

        public TypeDiscovery(AssemblyDirectoryResolver folders = null)
        {

            Paths = folders ?? AssemblyDirectoryResolver.Instance;

            ExcludedAssemblies = new List<string>();
            FilterAssembly = c => true;
            FilterFilename = c => true;

            Assemblies = () => AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(c => !ExcludedAssemblies.Contains(c.GetName().Name))
                    .ToList();

            //OnRegisterException = e => Logger.Error(e);
            HideAssemblyLoadException = true;

        }

        /// <summary>
        /// Initializes the singleton instance with specified paths.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public static TypeDiscovery Initialize(params string[] paths)
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                    {
                        _instance = new TypeDiscovery();
                        _instance.Paths.AddDirectories(paths);
                    }

            return _instance;
        }

        /// <summary>
        /// Initializes the singleton instance with specified paths.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public static TypeDiscovery Initialize()
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                        _instance = new TypeDiscovery();

            return _instance;
        }


        /// <summary>
        /// Gets the instance singleton.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TypeDiscovery Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new TypeDiscovery();
                return _instance;
            }
        }


        /// <summary>
        /// Gets the paths folder list for resolver types.
        /// </summary>
        /// <value>
        /// <see cref="AssemblyDirectoryResolver"/> 
        /// </value>
        public AssemblyDirectoryResolver Paths { get; }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLoadedByFile(string fullname)
        {
            return _loadedByFile.ContainsKey(fullname);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsLoadedByFile(FileInfo filename)
        {
            return _loadedByFile.ContainsKey(filename.FullName);
        }


        /// <summary>
        /// try to load all referenced assemblies
        /// </summary>
        /// <param name="acceptAllVersion">Accept all version</param>
        /// <param name="recursively">drop down in assemblies and load</param>
        public void EnsureAllAssembliesAreLoaded(bool acceptAllVersion = true, bool recursively = true)
        {

            using (var _ = ComponentModelActivityProvider.StartActivity("loading assemblies"))
                lock (_lock3)
                {
                    HashSet<string> _hash = new HashSet<string>();
                    foreach (var ass in Assemblies())
                        if (_hash.Add(ass.FullName))
                        {
                            EnsureAssemblyIsLoadedWithReferences(ass, acceptAllVersion, recursively, _hash);
                        }
                }

        }

        /// <summary>
        /// try to load all referenced assemblies in the specified assembly
        /// </summary>
        /// <param name="assembly to load">Accept all version</param>
        /// <param name="acceptAllVersion">Accept all version</param>
        /// <param name="recursively">drop down in assemblies and load</param>
        public void EnsureAssemblyIsLoadedWithReferences(Assembly assembly, bool acceptAllVersion, bool recursively, HashSet<string> hash)
        {

            if (!Paths.IsInSystemDirectory(assembly))
            {
                AssemblyName[] assemblies = assembly.GetReferencedAssemblies();

                foreach (AssemblyName item in assemblies)
                {

                    Assembly assembly1 = null;
                    if (!AssemblyLoader.Instance.IsLoadedByAssemblyByName(item, acceptAllVersion))
                        try
                        {
                            assembly1 = AssemblyLoader.Instance.LoadAssemblyName(item);
                        }
                        catch (Exception ex)
                        {
                        }
                    else
                        assembly1 = GetAssembly(item, acceptAllVersion);

                    if (recursively && assembly1 != null)
                        if (hash.Add(assembly1.FullName))
                            EnsureAssemblyIsLoadedWithReferences(assembly1, acceptAllVersion, recursively, hash);

                }
            }

        }

        public void AddDirectories(params string[] paths)
        {
            Paths.AddDirectories(paths);
        }

        /// <summary>
        /// Add a new directory for search types
        /// </summary>
        /// <param name="configuration"></param>
        public void AddDirectories(params DirectoryInfo[] paths)
        {
            Paths.AddDirectories(paths);
        }


        /// <summary>
        /// Gets the already assemblies loaded that match with specified namespaces.
        /// </summary>
        /// <param name="namespaces">The namespaces filter.</param>
        /// <returns></returns>
        public IEnumerable<Assembly> GetAssemblies(IEnumerable<string> namespaces = null)
        {

            HashSet<Assembly> assemblies = new HashSet<Assembly>(10);
            HashSet<string> n = namespaces as HashSet<string>;

            if (n == null)
            {
                if (namespaces != null)
                    n = new HashSet<string>(namespaces);
                else
                    n = new HashSet<string>();
            }

            foreach (var assembly in this.Assemblies())
            {

                Type[] types = null;
                if (assembly.IsDynamic || string.IsNullOrEmpty(assembly.Location))
                    types = assembly.GetTypes();
                else
                    types = assembly.GetExportedTypes();

                try
                {
                    foreach (var item in types)
                        if (n.Count == 0 || n.Contains(item.Namespace))
                        {
                            assemblies.Add(assembly);
                            break;
                        }

                }
                catch (Exception e)
                {
                    Trace.TraceError(e.ToString());
                    throw;
                }
            }

            return assemblies;

        }

        #endregion Initialize

        #region Resolve methods

        /// <summary>
        ///    Return a list of static type that match with the specified filter
        /// </summary>
        /// /// <param name="assemblyFilter">filter for parsing assemblies</param>
        /// <param name="typeFilter">filter for select types</param>
        /// <returns></returns>
        public IEnumerable<Type> GetStaticTypes(Func<Assembly, bool> assemblyFilter, Func<Type, bool> typeFilter = null)
        {

            if (assemblyFilter == null)
                assemblyFilter = c => true;

            Func<Type, bool> localTypefilter = null;
            if (typeFilter == null)
                localTypefilter = t => t.IsClass && t.IsSealed && t.IsAbstract;
            else
                localTypefilter = t => t.IsClass && t.IsSealed && t.IsAbstract && typeFilter(t);

            var assemblies = Assemblies().Where(assemblyFilter).ToArray();
            var result = Collect(localTypefilter, assemblies);

            return result;

        }

        /// <summary>
        ///    Return a list of static type that match with the specified filter
        /// </summary>
        /// <param name="typeFilter">filter for select types</param>
        /// <returns></returns>
        public IEnumerable<Type> GetStaticTypes(Func<Type, bool> typeFilter = null)
        {

            Func<Type, bool> localFypefilter = null;
            if (typeFilter == null)
                localFypefilter = t => t.IsClass && t.IsSealed && t.IsAbstract;
            else
                localFypefilter = t => t.IsClass && t.IsSealed && t.IsAbstract && typeFilter(t);

            var assemblies = Assemblies().ToArray();
            var result = Collect(localFypefilter, assemblies);

            return result;

        }

        /// <summary>
        ///     Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="typeFilter">filter for select types</param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypes(Func<Type, bool> typeFilter)
        {

            if (typeFilter == null)
                typeFilter = t => true;

            var assemblies = Assemblies().ToArray();
            var result = Collect(typeFilter, assemblies);

            return result;

        }

        /// <summary>
        ///     Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="assemblyFilter">filter for parsing assemblies</param>
        /// <param name="typeFilter">filter for select types</param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypes(Func<Assembly, bool> assemblyFilter, Func<Type, bool> typeFilter)
        {

            if (assemblyFilter == null)
                assemblyFilter = c => true;

            if (typeFilter == null)
                typeFilter = t => true;

            var assemblies = Assemblies().Where(assemblyFilter).ToArray();
            var result = Collect(typeFilter, assemblies);

            return result;

        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypesWithAttributes(Type baseType, Type typeFilter)
        {

            if (baseType == null)
                baseType = typeof(object);

            if (typeFilter == null)
                typeFilter = typeof(Attribute);

            var assemblies = Assemblies().ToArray();
            var result = Collect(type =>
            {
                return baseType.IsAssignableFrom(type) && TypeDescriptor.GetAttributes(type).ToList().Any(c => c.GetType() == typeFilter);
            }, assemblies);

            return result;

        }

        /// <summary>
        /// return a list of type that contains specified attribute
        /// </summary>
        /// <param name="attributeTypeFilter"></param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypesWithAttributes(Type attributeTypeFilter)
        {

            if (attributeTypeFilter == null)
                attributeTypeFilter = typeof(Attribute);

            var assemblies = Assemblies().ToArray();
            var result = Collect(type =>
            {
                return TypeDescriptor.GetAttributes(type).ToList().Any(c => c.GetType() == attributeTypeFilter);
            }, assemblies);

            return result;
        }


        /// <summary>
        /// return a list of type that contains specified attribute and the filter must be valid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterOnAttribute">filter to apply on the attributes</param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypesWithAttributes<T>(Type baseType, Func<T, bool> filterOnAttribute) where T : Attribute
        {

            var assemblies = Assemblies().ToArray();

            var list = Collect(type =>
            {

                if (baseType == null || baseType.IsAssignableFrom(type))
                {

                    var attributes = TypeDescriptor.GetAttributes(type).OfType<T>().ToArray();

                    if (attributes.Length == 0)
                        return false;

                    foreach (T attribute in attributes)
                        if (filterOnAttribute(attribute))
                            return true;

                }

                return false;

            }, assemblies);

            return list;

        }

        /// <summary>
        /// Resolves the type by specified name.
        /// </summary>
        /// <param name="targetType">Type of the target.</param>
        /// <returns></returns>
        /// <exception cref="DllNotFoundException"></exception>
        public Type ResolveByName(string targetType)
        {

            Type typeResult = null;

            typeResult = Type.GetType(targetType);

            if (typeResult == null)
            {
                var targetype = targetType.Split(',');
                if (targetype.Length == 1)
                    return null;

                var assemblyName = targetype[0].Trim();
                var typeName = targetype[1].Trim();

                Assembly assembly = null;

                #region resolve assembly

                var result = new List<Type>();
                var assemblies = Assemblies().ToArray();
                foreach (var item in assemblies)
                {

                    string name = item.GetName().Name;
                    if (name == assemblyName)
                    {
                        assembly = item;
                        break;
                    }
                }

                if (assembly == null)
                    throw new DllNotFoundException(assemblyName);

                #endregion resolve assembly

                foreach (Type type in assembly.ExportedTypes)
                {
                    string ns = type.Namespace + "." + type.Name;
                    if (ns == typeName)
                    {
                        typeResult = type;
                        break;
                    }
                }

            }
            return typeResult;

        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypesAssignableFrom(Type typeFilter)
        {
            var assemblies = Assemblies().ToArray();
            foreach (var item in Collect(type => typeFilter.IsAssignableFrom(type) && type != typeFilter, assemblies))
                yield return item;
        }

        /// <summary>
        /// Gets the exposed types for the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetExposedTypes(string context)
        {
            return ExposedTypes.Instance.GetTypes(context);
        }

        /// <summary>
        /// Gets the exposed types for the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="typeExposedFilter">The type exposed filter.</param>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetExposedTypes(string context, Func<Type, bool> filter)
        {
            return ExposedTypes.Instance.GetTypes(context).Where(c => filter(c.Key));
        }

        /// <summary>
        /// Gets the exposed types for the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="typeExposedFilter">The type exposed filter.</param>
        /// <returns>List of types</returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetExposedTypes(string context, Type typeExposedFilter)
        {
            return ExposedTypes.Instance.GetTypes(context, typeExposedFilter);
        }

        /// <summary>
        /// Gets the exposed types for the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="typeExposedFilter">The type exposed filter.</param>
        /// <param name="filter">type filter.</param>
        /// <returns>List of types</returns>
        public IEnumerable<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> GetExposedTypes(string context, Type typeExposedFilter, Func<Type, bool> filter)
        {
            return ExposedTypes.Instance.GetTypes(context, typeExposedFilter).Where(c => filter(c.Key));
        }


        #endregion Resolve methods

        #region Load assemblies


        /// <summary>
        /// Get assembly by assembly name. load this if not yet loaded.
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <returns></returns>
        public Assembly AddAssemblyname(AssemblyName assemblyName, bool acceptAllVersion)
        {

            if (!AssemblyLoader.Instance.IsLoadedByAssemblyByName(assemblyName, acceptAllVersion))
                return AssemblyLoader.Instance.LoadAssemblyName(assemblyName);

            return GetAssembly(assemblyName);

        }

        /// <summary>
        /// Get assembly by assembly name. load this if not yet loaded.
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <returns></returns>
        public Assembly AddAssemblyname(string assemblyName, bool acceptAllVersion)
        {

            var name = AssemblyName.GetAssemblyName(assemblyName);

            if (!AssemblyLoader.Instance.IsLoadedByAssemblyByName(name, acceptAllVersion))
                return AssemblyLoader.Instance.LoadAssembly(assemblyName);

            return GetAssembly(name);

        }


        //private Assembly GetLoadedAssembly(string filename)
        //{
        //    foreach (Assembly assembly in Assemblies())
        //    {
        //        var name2 = Path.GetFileNameWithoutExtension(assembly.ManifestModule.ScopeName);
        //        if (filename == name2)
        //            return assembly;
        //    }
        //    return null;
        //}


        /// <summary>
        ///     Load in memory all the assemblies from the directory bin.
        /// </summary>
        public void LoadAssembliesFromFolders(IEnumerable<DirectoryInfo> dirs)
        {
            foreach (var path in dirs)
                if (!Paths.IsInSystemDirectory(path))
                    LoadAssembliesFrom(path);
        }

        ///// <summary>
        /////     Load in memory all the assemblies from the specified with directory.
        ///// </summary>
        ///// <returns></returns>
        //public int LoadAssembliesFrom(string directory)
        //{

        //    int result = 0;

        //    var files = Paths.GetAssemblies(directory, c => FilterFilename(c));
        //    foreach (var file in files)
        //        if (!IsLoadedByFile(file.FullName))
        //        {

        //            Assembly ass = null;
        //            try
        //            {
        //                ass = AssemblyLoader.Instance.LoadAssembly(file);
        //                result += ass.ExportedTypes.Count();
        //            }
        //            catch (Exception e)
        //            {
        //                OnRegisterException(e);
        //                Trace.TraceError(e.ToString());
        //            }

        //        }

        //    return result;

        //}

        /// <summary>
        ///     Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        public int LoadAssembliesFrom(DirectoryInfo directory)
        {

            var instance = AssemblyLoader.Instance;
            int result = 0;

            var files = Paths.GetAssemblies(directory, c => FilterFilename(c));
            foreach (var file in files)
                if (!IsLoadedByFile(file.FullName))
                {
                    Assembly ass = null;
                    try
                    {
                        ass = instance.LoadAssembly(file);
                        if (ass != null)
                            result += ass.ExportedTypes.Count();
                    }
                    catch (Exception e)
                    {
                        OnRegisterException(e);
                        Trace.TraceError(e.ToString());
                    }
                }

            return result;

        }

        /// <summary>
        /// Get assembly if already loaded
        /// </summary>
        /// <param name="name">assemblyName</param>
        /// <param name="acceptAllVersion"></param>
        /// <returns></returns>
        public Assembly GetAssembly(string name, bool acceptAllVersion = true)
        {
            return GetAssembly(new AssemblyName(name), acceptAllVersion);
        }

        /// <summary>
        /// Get assembly if already loaded
        /// </summary>
        /// <param name="name">assembly name</param>
        /// <param name="acceptAllVersion"></param>
        /// <returns></returns>
        public Assembly GetAssembly(AssemblyName name, bool acceptAllVersion = true)
        {

            foreach (var item in GetAssemblies())
            {

                var n = item.GetName();

                if (n.Name == name.Name)
                {

                    if (n.Version.ToString() == name.Version.ToString())
                        return item;

                    if (acceptAllVersion)
                        return item;

                }
            }

            return null;

        }

        /// <summary>
        /// Return the list of loaded assemblies
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Assembly> GetAssemblies(string name)
        {

            foreach (var item in GetAssemblies())
            {
                var n = item.GetName();
                if (n?.Name == name)
                    yield return item;
            }

        }

        /// <summary>
        /// Registers the specified assemblies.
        /// </summary>
        /// <param name="typeFilter">filter to apply on the type to validate.</param>
        /// <param name="assemblies">The assemblies.</param>
        private IEnumerable<Type> Collect(Func<Type, bool> typeFilter, params Assembly[] assemblies)
        {

            foreach (var item in assemblies)
            {

                Trace.TraceInformation(item.FullName);

                var list = GetTypes(item, typeFilter);
                foreach (var type in list)
                    yield return type;

            }

        }

        /// <summary>
        ///     Register all exported type in the specified assembly
        /// </summary>
        /// <param name="ass"></param>
        /// <param name="typeFilter">filter to apply on the type to validate.</param>
        public List<Type> GetTypes(Assembly ass, Func<Type, bool> typeFilter)
        {
            var result = new List<Type>();

            if (ass != null && (FilterAssembly == null || FilterAssembly(ass)))
            {
                var n = ass.GetName();
                try
                {
                    result.AddRange(Register(ass, typeFilter));
                    //Debug.WriteLine($"assembly {ass.GetName().Name} analyzed");
                }
                catch (Exception e)
                {
                    OnRegisterException(e);
                    Trace.TraceError($"Failed to analyze assembly {ass.GetName().Name}. {e.ToString()}");
                }
            }

            return result;
        }

        private static List<Type> Register(Assembly assembly, Func<Type, bool> typeFilter)
        {

            var types = new Type[0];

            try
            {
                types = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e) // TypeLoadException e1
            {
                OnRegisterException(e);
                types = e.Types;
            }

            var _r = types.Where(type =>
            {

                var result = (!type.IsAbstract && !type.IsSealed || type.IsAbstract && type.IsSealed)
                                           && !type.IsInterface && !type.IsGenericTypeDefinition;

                return result;

            }).ToList();

            return _r.Where(typeFilter).ToList();

        }

        #endregion Load assemblies

        #region Properties

        /// <summary>
        ///     The on register exception
        /// </summary>
        public static Action<Exception> OnRegisterException = e => { };

        /// <summary>
        ///     The on registration event
        /// </summary>
        public static Action<string> OnRegistrationEvent = e => Debug.WriteLine(e);

        /// <summary>
        ///     define a filter for filter the assemblies to use in the register
        /// </summary>
        public Func<Assembly, bool> FilterAssembly { get; set; }

        /// <summary>
        ///     The filter fileinfo
        /// </summary>
        public Func<FileInfo, bool> FilterFilename { get; set; }

        /// <summary>
        ///     The exclude assemblies
        /// </summary>
        public static List<string> ExcludedAssemblies { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether [hide assembly load exception].
        /// </summary>
        /// <value>
        ///     <c>true</c> if [hide assembly load exception]; otherwise, <c>false</c>.
        /// </value>
        public static bool HideAssemblyLoadException { get; set; }

        #endregion Properties              

        #region Factories

        /// <summary>
        /// Resolve types argument and Creates an optimized factory for the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> Create<T>(params dynamic[] args)
            where T : class
        {
            var types = ObjectCreator.ResolveTypesOfArguments(args);
            var factory = ObjectCreator.GetActivatorByArguments<T>(types);
            return factory;
        }

        /// <summary>
        /// Creates an optimized factory for the specified arguments.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> CreateWithTypes<T>(params Type[] types)
            where T : class
        {
            var factory = ObjectCreator.GetActivatorByArguments<T>(types);
            return factory;
        }

        /// <summary>
        /// Resolve types argument and Creates an optimized factory for the specified arguments. The real type instance is the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The real type instance.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public IFactory<T> CreateFrom<T>(Type type, params dynamic[] args)
            where T : class
        {
            var types = ObjectCreator.ResolveTypesOfArguments(args);
            var factory = ObjectCreator.GetActivatorByArguments<T>(types);
            return factory;
        }

        /// <summary>
        /// Creates an optimized factory for the specified arguments. The real type instance is the specified type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The real type instance.</param>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        public IFactory<T> CreateFromWithTypes<T>(Type type, params Type[] types)
            where T : class
        {
            return ObjectCreator.GetActivatorByTypeAndArguments<T>(type, types);
        }

        public bool IsLoaded(FileInfo location)
        {
            return IsLoaded(location.FullName);
        }

        public bool IsLoaded(string location)
        {

            if (File.Exists(location))
                foreach (var item in Assemblies())
                    if (!item.IsDynamic && item.Location == location)
                        return true;

            return false;

        }

        #endregion Factories               


        /// <summary>
        /// return the list of loaded assemblies
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetLoadedAssemblies()
        {
            foreach (var item in Assemblies())
                yield return item.FullName;
        }

        /// <summary>
        /// return the list of directories of loaded assemblies.
        /// </summary>
        /// <returns>list of assemblies and a flag that indicate the filename and if the assembly is loaded.</returns>
        public IDictionary<string, KeyValuePair<string, bool>> GetAllAssemblies()
        {

            Dictionary<string, KeyValuePair<string, bool>> _hash = new Dictionary<string, KeyValuePair<string, bool>>();

            foreach (var item in Assemblies())
            {

                string key = item.IsDynamic
                    ? item.FullName
                    : item.Location;

                if (!_hash.ContainsKey(key))
                    _hash.Add(key, new KeyValuePair<string, bool>(item.FullName, true));
            }

            var resolver = new AddonsResolver(Paths);
            foreach (var item in resolver.GetAssemblies())
                if ((!_hash.ContainsKey(item.Key)))
                    _hash.Add(item.Key, new KeyValuePair<string, bool>(item.Value, false));


            return _hash;

        }

        /// <summary>
        /// return the list of available location of loaded assemblies.
        /// </summary>
        /// <returns>list of assemblies and a flag that indicate the filename and if the assembly is loaded.</returns>
        public HashSet<string> GetDirectoryPathFromAssemblies()
        {

            HashSet<string> _hash = new HashSet<string>(50);

            foreach (var item in Assemblies())
                if (!item.IsDynamic && !string.IsNullOrEmpty(item.Location))
                {
                    var file = new FileInfo(item.Location);
                    file.Refresh();
                    if (file.Directory.Exists)
                        _hash.Add(file.Directory.FullName);
                }

            return _hash;

        }

        /// <summary>
        /// Load all assemblies that matches with criteria 
        /// </summary>
        /// <param name="action">delegate to specify criteria</param>
        /// <param name="autoload">load assemblies that matche</param>
        /// <param name="failedOnloadError">throw a exception if failed to load assembly</param>
        /// <param name="paths">List of path</param>
        /// <returns></returns>
        public IEnumerable<TypeMatched> Search(Action<AddonsResolver> action, bool autoload = false, bool failedOnloadError = false, AssemblyDirectoryResolver paths = null)
        {

            var resolver = new AddonsResolver(paths ?? Paths);

            action(resolver);

            foreach (var item in resolver.SearchTypes())
            {

                if (autoload)
                    item.Load(failedOnloadError);

                yield return item;

            }
        }

        /// <summary>
        ///     function  return the list of loaded assemblies
        /// </summary>
        public readonly Func<IEnumerable<Assembly>> Assemblies;
        private static readonly object _lock = new object();
        private static readonly object _lock3 = new object();
        private static TypeDiscovery _instance;
        private Dictionary<string, Assembly> _loadedByFile = new Dictionary<string, Assembly>();



    }
}



