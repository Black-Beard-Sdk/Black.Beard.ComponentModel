using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace Bb.ComponentModel
{


    public class TypeDiscovery
    {

        #region Initialize

        private TypeDiscovery(AssemblyDirectoryResolver? paths = null)
        {

            if (paths == null)
                Paths = AssemblyDirectoryResolver.Instance;
            else
                Paths = paths;


            ExcludedAssemblies = new List<string>();
            FilterAssembly = c => true;
            FilterFilename = c => true;

            Assemblies = () => AppDomain.CurrentDomain
                    .GetAssemblies()
                    .Where(c => !ExcludedAssemblies.Contains(c.GetName().Name))
                    .ToList();

            //OnRegisterException = e => Logger.Error(e);
            HideAssemblyLoadException = true;

            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            var a = this.GetAssemblies();   //.OrderBy(c => c.FullName).ToList();
            foreach (var assembly in a)
                AddAssembly(assembly);

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
                        _instance = new TypeDiscovery();

            _instance.Paths.AddDirectories(paths);

            return _instance;
        }

        /// <summary>
        /// Initializes the singleton instance with specified paths.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public static TypeDiscovery Initialize(AssemblyDirectoryResolver paths)
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                        _instance = new TypeDiscovery(paths);

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

        private Assembly AssemblyLoad(AssemblyName item)
        {
            var ass = Assembly.Load(item);
            AddAssembly(ass);
            return ass;
        }

        private Assembly AssemblyLoad(string item)
        {
            var ass = Assembly.LoadFile(item);
            AddAssembly(ass);
            return ass;
        }

        private void AddAssembly(Assembly ass)
        {
            lock (_lock2)
            {
                if (!_loadedByFile.ContainsKey(ass.Location))
                    _loadedByFile.Add(ass.Location, ass);

                var name = ass.GetName();
                if (!_assemblyNames.TryGetValue(name.Name, out var dic))
                    _assemblyNames.Add(name.Name, dic = new HashSet<string>());

                Paths.AddDirectoryFromFiles(ass.Location);
                dic.Add(name.Version.ToString());

            }
        }

        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {

            lock (_lock2)
            {

                var a = args.LoadedAssembly;
                if (!_loadedByFile.ContainsKey(a.Location))
                    _loadedByFile.Add(a.Location, a);

                var name = args.LoadedAssembly.GetName();
                if (!_assemblyNames.TryGetValue(name.Name, out var dic))
                    _assemblyNames.Add(name.Name, dic = new HashSet<string>());

                Paths.AddDirectoryFromFiles(a.Location);
                dic.Add(name.Version.ToString());

            }

        }

        private bool IsLoadedByFile(string fullname)
        {
            return _loadedByFile.ContainsKey(fullname);
        }

        private bool IsLoadedByFile(FileInfo filename)
        {
            return _loadedByFile.ContainsKey(filename.FullName);
        }

        /// <summary>
        /// Return true if assembly is already loaded
        /// </summary>
        /// <param name="name">assemblyName</param>
        /// <param name="acceptAllversions">if false don't try to match the version</param>
        /// <returns></returns>
        public bool IsLoadedByAssemblyByName(AssemblyName name, bool acceptAllversions)
        {

            if (!_assemblyNames.TryGetValue(name.Name, out var dic))
                return false;

            if (acceptAllversions)
                return true;

            return dic.Contains(name.Version.ToString());

        }

        /// <summary>
        /// Determines whether assembly name is loaded.
        /// </summary>
        /// <param name="assemblyName">Name of the assembly.</param>
        /// <param name="acceptAllVersion">if set to <c>true</c> [accept all version].</param>
        /// <returns>
        ///   <c>true</c> if is loaded otherwise, <c>false</c>.
        /// </returns>
        private bool IsLoadedByAssemblyByName(string assemblyName, bool acceptAllVersion)
        {
            return IsLoadedByAssemblyByName(AssemblyName.GetAssemblyName(assemblyName), acceptAllVersion);
        }

        /// <summary>
        /// try to load all referenced assemblies
        /// </summary>
        /// <param name="acceptAllVersion"></param>
        public void EnsureAllAssembliesAreLoaded(bool acceptAllVersion = true)
        {

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {
                HashSet<string> _hash = new HashSet<string>();
                foreach (var ass in Assemblies())
                    if (_hash.Add(ass.FullName))
                        EnsureAssemblyIsLoadedWithReferences(ass, acceptAllVersion, true, _hash);

            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        /// <summary>
        /// Ensures that all referenced the assembly are loaded.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="acceptAllVersion">if set to <c>true</c> [accept all version].</param>
        /// <param name="recursively">if set to <c>true</c> [recursively].</param>
        public void EnsureAssemblyIsLoaded(Assembly assembly, bool acceptAllVersion = true, bool recursively = false)
        {

            var hash = new HashSet<string>();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {

                var assemblies = assembly.GetReferencedAssemblies();
                foreach (AssemblyName ass in assemblies)
                    if (hash.Add(ass.FullName))
                    {

                        Assembly refAssembly;
                        if (IsLoadedByAssemblyByName(ass, acceptAllVersion))
                            refAssembly = AssemblyLoad(ass);
                        else
                            refAssembly = GetAssembly(ass);

                        if (recursively && refAssembly != null)
                            EnsureAssemblyIsLoadedWithReferences(refAssembly, acceptAllVersion, recursively, hash);

                    }

            }
            finally
            {

                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;

            }


        }


        private void EnsureAssemblyIsLoadedWithReferences(Assembly ass, bool acceptAllVersion, bool recursively, HashSet<string> hash)
        {

            AssemblyName[] assemblies = ass.GetReferencedAssemblies();

            foreach (var item in assemblies)
            {

                Assembly assembly = null;

                if (!IsLoadedByAssemblyByName(item, acceptAllVersion))
                    try
                    {
                        assembly = AssemblyLoad(item);
                    }
                    catch (Exception ex)
                    {
                    }
                else
                    assembly = GetAssembly(item, acceptAllVersion);

                if (recursively && assembly != null)
                    if (hash.Add(assembly.FullName))
                        EnsureAssemblyIsLoadedWithReferences(assembly, acceptAllVersion, recursively, hash);

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
        /// Gets the already assemblies lodaded that match with specified namespaces.
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
                if (assembly.IsDynamic)
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
        ///     Return a list of type that match with the specified filter
        /// </summary>
        /// <param name="typeFilter"></param>
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
        public IEnumerable<Type> GetTypesWithAttributes<T>(Type typebase, Func<T, bool> filterOnAttribute) where T : Attribute
        {

            var assemblies = Assemblies().ToArray();

            var list = Collect(type =>
            {

                if (typebase == null || typebase.IsAssignableFrom(type))
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

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            Type typeResult = null;
            try
            {
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

            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return typeResult;

        }

        /// <summary>
        ///     return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public IEnumerable<Type> GetTypes(Type typeFilter)
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

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            var n = new AssemblyName(args.Name);

            foreach (var filename in Paths.ResolveAssemblyFilenames(n))
            {

                Assembly assembly;

                if (!IsLoadedByFile(filename))
                    assembly = AssemblyLoad(filename.FullName);
                else
                    assembly = _loadedByFile[filename.FullName];

                return assembly;

            }

            var str = $"the assembly '{args.Name}' can't be resolved'";

            Console.Write(str);

            return null;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileAssembly">filename of the assembly</param>
        /// <param name="withPdb">if true, test if the pdb exist and load it</param>
        /// <returns></returns>
        public Assembly AddAssemblyFile(string fileAssembly, bool withPdb)
        {

            var file = new System.IO.FileInfo(fileAssembly);

            if (withPdb)
            {
                FileInfo filePdb = new FileInfo(Path.Combine(file.Directory.FullName, Path.GetFileNameWithoutExtension(file.Name)) + ".pdb");
                filePdb.Refresh();
                if (filePdb.Exists)
                    return LoadAssembly(file, filePdb);

            }

            return LoadAssembly(file, null);

        }

        /// <summary>
        /// Get assembly by assembly name. load this if not yet loaded.
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <returns></returns>
        public Assembly AddAssemblyname(AssemblyName assemblyName, bool acceptAllVersion)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {

                if (!IsLoadedByAssemblyByName(assemblyName, acceptAllVersion))
                    return AssemblyLoad(assemblyName);

                return GetAssembly(assemblyName);

            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        /// <summary>
        /// Get assembly by assembly name. load this if not yet loaded.
        /// </summary>
        /// <param name="assemblyName">name of the assembly</param>
        /// <returns></returns>
        public Assembly AddAssemblyname(string assemblyName, bool acceptAllVersion)
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {

                var name = AssemblyName.GetAssemblyName(assemblyName);

                if (!IsLoadedByAssemblyByName(name, acceptAllVersion))
                    return AssemblyLoad(assemblyName);

                return GetAssembly(name);

            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Assembly LoadAssembly(FileInfo fileAssembly, FileInfo filePdb)
        {

            Assembly assembly = null;

            fileAssembly.Refresh();
            if (!IsLoadedByFile(fileAssembly.FullName) && fileAssembly.Exists)
            {

                var name1 = Path.GetFileNameWithoutExtension(fileAssembly.Name);
                assembly = GetLoadedAssembly(name1);

                if (assembly == null)
                    assembly = LoadAssembly_Impl(fileAssembly, filePdb);

            }
            else
                assembly = AssemblyLoad(fileAssembly.FullName);

            return assembly;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Assembly LoadAssembly_Impl(FileInfo fileAssembly, FileInfo filePdb)
        {

            Assembly assembly = null;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            if (IsLoadedByFile(fileAssembly.FullName))
                foreach (var item in GetAssemblies())
                    if (item.Location == fileAssembly.FullName)
                        return item;

            var name1 = Path.GetFileNameWithoutExtension(fileAssembly.Name);

            if (filePdb == null)
            {
                var path = Path.Combine(fileAssembly.Directory.FullName, name1) + ".pdb";
                var filePdbBuilded = new FileInfo(path);
                filePdb = filePdbBuilded.Exists ? filePdbBuilded : null;
            }

            try
            {

                if (IsLoadedByAssemblyByName(name1, false))
                {
                    try
                    {
                        bool test()
                        {
                            if (filePdb != null)
                            {
                                filePdb.Refresh();
                                return filePdb.Exists;
                            }
                            return false;
                        };

                        if (filePdb == null && test())
                            assembly = AssemblyLoad(fileAssembly.FullName);

                        else
                        {
                            Trace.WriteLine($"Loading assembly {fileAssembly.FullName}");
                            var data = File.ReadAllBytes(fileAssembly.FullName);
                            if (filePdb != null)
                            {
                                var pdbData = File.ReadAllBytes(filePdb.FullName);
                                assembly = Assembly.Load(data, pdbData);
                            }
                            else
                                assembly = Assembly.Load(data);

                        }
                    }
                    catch (Exception e)
                    {
                        OnRegisterException(e);
                        Trace.WriteLine(e, TraceLevel.Error.ToString());
                    }
                }
            }

            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return assembly;
        }

        private Assembly GetLoadedAssembly(string filename)
        {

            foreach (Assembly assembly in Assemblies())
            {

                var name2 = Path.GetFileNameWithoutExtension(assembly.ManifestModule.ScopeName);

                if (filename == name2)
                    return assembly;

            }

            return null;

        }

        /// <summary>
        ///     Load in memory all the assemblies from the directory bin.
        /// </summary>
        public void LoadAssembliesFromFolders()
        {
            foreach (var path in Paths.GetDirectories())
                LoadAssembliesFrom(path);
        }

        /// <summary>
        ///     Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        public int LoadAssembliesFrom(string directory)
        {

            int result = 0;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var files = Paths.GetAssemblies(directory, c => FilterFilename(c));
                foreach (var file in files)
                    if (!IsLoadedByFile(file.FullName))
                    {

                        Assembly ass = null;
                        try
                        {
                            ass = AssemblyLoad(file.FullName);
                            result += ass.ExportedTypes.Count();
                        }
                        catch (Exception e)
                        {
                            OnRegisterException(e);
                            Trace.TraceError(e.ToString());
                        }

                    }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return result;

        }

        /// <summary>
        ///     Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        public int LoadAssembliesFrom(DirectoryInfo directory)
        {

            int result = 0;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var files = Paths.GetAssemblies(directory, c => FilterFilename(c));
                foreach (var file in files)
                    if (!IsLoadedByFile(file.FullName))
                    {

                        Assembly ass = null;
                        try
                        {
                            ass = AssemblyLoad(file.FullName);
                            result += ass.ExportedTypes.Count();
                        }
                        catch (Exception e)
                        {
                            OnRegisterException(e);
                            Trace.TraceError(e.ToString());
                        }

                    }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

            return result;

        }

        /// <summary>
        /// Get assembly if allready loaded
        /// </summary>
        /// <param name="name"></param>
        /// <param name="AcceptAllVersion"></param>
        /// <returns></returns>
        public Assembly GetAssembly(AssemblyName name, bool AcceptAllVersion = true)
        {

            foreach (var item in GetAssemblies())
            {

                var n = item.GetName();

                if (n.Name == name.Name)
                {

                    if (n.Version.ToString() == name.Version.ToString())
                        return item;

                    if (AcceptAllVersion)
                        return item;

                }
            }

            return null;

        }

        /// <summary>
        ///     Registers the specified assemblies.
        /// </summary>
        /// <param name="assemblies">The assemblies.</param>
        private IEnumerable<Type> Collect(Func<Type, bool> typeFilter, params Assembly[] assemblies)
        {

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            try
            {
                foreach (var item in assemblies)
                {
                    var list = Resolve(item, typeFilter);
                    foreach (var type in list)
                        yield return type;
                }
            }
            finally
            {
                AppDomain.CurrentDomain.AssemblyResolve -= CurrentDomain_AssemblyResolve;
            }

        }

        /// <summary>
        ///     Register all exported type in the specified assembly
        /// </summary>
        /// <param name="ass"></param>
        private List<Type> Resolve(Assembly ass, Func<Type, bool> typeFilter)
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
                    Trace.TraceError(e.ToString());
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
        /// return the list of available assemblies.
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
        /// return the list of available assemblies.
        /// </summary>
        /// <returns>list of assemblies and a flag that indicate the filename and if the assembly is loaded.</returns>
        public HashSet<string> GetDirectoryPathFromAssemblies()
        {

            HashSet<string> _hash = new HashSet<string>(50);

            foreach (var item in Assemblies())
                if (!item.IsDynamic)
                {
                    var file = new FileInfo(item.Location);
                    file.Refresh();
                    if (file.Directory.Exists)
                        _hash.Add(file.Directory.FullName);
                }

            return _hash;

        }

        public IEnumerable<TypeMatched> Search(Action<AddonsResolver> action, bool autoload = false, bool failedOnloadError = false, AssemblyDirectoryResolver paths = null)
        {

            var resolver = new AddonsResolver(paths ?? Paths);

            action(resolver);

            foreach (var item in resolver.Search())
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
        private static readonly object _lock2 = new object();
        private static TypeDiscovery _instance;
        private Dictionary<string, HashSet<string>> _assemblyNames = new Dictionary<string, HashSet<string>>();
        private Dictionary<string, Assembly> _loadedByFile = new Dictionary<string, Assembly>();



    }
}



