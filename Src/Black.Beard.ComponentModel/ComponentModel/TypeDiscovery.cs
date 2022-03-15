using Bb.ComponentModel.Factories;
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

    public class TypeDiscovery //: ITypeReferential
    {

        #region Initialize

        private TypeDiscovery(params string[] paths)
        {

            _paths = new HashSet<string>();

            if (paths == null)
                paths = new string[] { };

            ExcludedAssemblies = new List<string>();
            FilterAssembly = c => true;
            FilterFilename = c => true;
            Assemblies = () => AppDomain.CurrentDomain.GetAssemblies()
                .Where(c => !ExcludedAssemblies.Contains(c.GetName().Name)
                ).ToList();
            //OnRegisterException = e => Logger.Error(e);
            HideAssemblyLoadException = true;

            var dir = FolderBinResolver.GetConsoleBinPath().ToList();

            AddDirectories(dir.Where(c => c.Exists).ToArray());
            AddDirectories(paths);


            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
            var a = this.GetAssemblies();   //.OrderBy(c => c.FullName).ToList();
            foreach (var assembly in a)
                AddAssembly(assembly);

        }

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

                dic.Add(name.Version.ToString());
            }

        }


        private bool IsLoadedByFile(string fullname)
        {
            return _loadedByFile.ContainsKey(fullname);
        }

        /// <summary>
        /// Return true if assembly is allready loaded
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

        public void EnsureAssemblyIsLoaded(Assembly assembly, bool acceptAllVersion = true, bool recursively = false)
        {


            var hash = new HashSet<string>();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {

                var assemblies = assembly.GetReferencedAssemblies();
                foreach (AssemblyName ass in assemblies)
                {
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


        public static TypeDiscovery Initialize(params string[] paths)
        {
            if (_instance == null)
                lock (_lock)
                    if (_instance == null)
                        _instance = new TypeDiscovery(paths);
                    else
                        _instance.AddDirectories(paths);
            else
                _instance.AddDirectories(paths);

            return _instance;
        }

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

        public void AddDirectories(params string[] paths)
        {
            foreach (var path in paths)
                if (!string.IsNullOrEmpty(path))
                {

                    if (!Directory.Exists(path))
                        throw new DirectoryNotFoundException(path);

                    _paths.Add(path);

                }

        }

        /// <summary>
        /// Add a new directory for search types
        /// </summary>
        /// <param name="configuration"></param>
        public void AddDirectories(params DirectoryInfo[] paths)
        {

            foreach (var configuration in paths)
            {

                configuration.Refresh();

                if (!configuration.Exists)
                    throw new DirectoryNotFoundException(configuration.FullName);

                _paths.Add(configuration.FullName);

            }
        }

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

            var test = n.Count == 0;

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
                        if (n.Contains(item.Namespace) || test)
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
        public List<Type> GetTypes(Func<Type, bool> typeFilter)
        {

            if (typeFilter == null)
                typeFilter = t => true;

            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(typeFilter, assemblies));
            return result;
        }

        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public List<Type> GetTypesWithAttributes(Type baseType, Type typeFilter)
        {

            if (baseType == null)
                baseType = typeof(object);

            if (typeFilter == null)
                typeFilter = typeof(Attribute);

            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type =>
            {
                return baseType.IsAssignableFrom(type)
                        && ToList(TypeDescriptor.GetAttributes(type)).Any(c => c.GetType() == typeFilter);
            }, assemblies));

            return result;

        }

        /// <summary>
        /// return a list of type that contains specified attibute
        /// </summary>
        /// <param name="attributeTypeFilter"></param>
        /// <returns></returns>
        public List<Type> GetTypesWithAttributes(Type attributeTypeFilter)
        {

            if (attributeTypeFilter == null)
                attributeTypeFilter = typeof(Attribute);

            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type =>
            {
                return ToList(TypeDescriptor.GetAttributes(type)).Any(c => c.GetType() == attributeTypeFilter);
            }, assemblies));

            return result;
        }

        private IEnumerable<Attribute> ToList(AttributeCollection attributes)
        {
            foreach (Attribute attribute in attributes)
                yield return attribute;
        }

        /// <summary>
        /// return a list of type that contains specified attibute and filter is valid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterOnAttribute">filter to apply on the attributes</param>
        /// <returns></returns>
        public List<Type> GetTypesWithAttributes<T>(Type typebase, Func<T, bool> filterOnAttribute) where T : Attribute
        {

            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();

            result.AddRange(Collect(type =>
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

            }, assemblies));

            return result;
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
        public List<Type> GetTypes(Type typeFilter)
        {
            var result = new List<Type>();
            var assemblies = Assemblies().ToArray();
            result.AddRange(Collect(type => typeFilter.IsAssignableFrom(type) && type != typeFilter, assemblies));

            return result;
        }

        #endregion Resolve methods

        #region Load assembly

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            var n = new AssemblyName(args.Name);

            foreach (var baseDirectory in _paths)
            {
                Assembly assembly;
                var filename = Directory.GetFiles(baseDirectory, n.Name + ".dll", SearchOption.AllDirectories).FirstOrDefault();
                if (filename != null)
                {


                    if (!IsLoadedByFile(filename))
                        assembly = AssemblyLoad(filename);
                    else
                        assembly = _loadedByFile[filename];

                    return assembly;

                }
                filename = Directory.GetFiles(baseDirectory, n.Name + ".exe").FirstOrDefault();
                if (filename != null)
                {

                    if (!IsLoadedByFile(filename))
                        assembly = AssemblyLoad(filename);
                    else
                        assembly = _loadedByFile[filename];

                    return assembly;
                }
            }

            var str =
                $"the assembly '{args.Name}' can't be resolved in the folder '{AppDomain.CurrentDomain.BaseDirectory}'";

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
            foreach (var path in _paths)
                LoadAssembliesFrom(path);
        }

        /// <summary>
        ///     Load in memory all the assemblies from the specified with directory.
        /// </summary>
        /// <returns></returns>
        public int LoadAssembliesFrom(string dir)
        {

            int result = 0;
            var directory = new DirectoryInfo(dir);

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

            try
            {
                var files = directory.GetFiles("*.dll").Where(c => FilterFilename(c));
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

        #endregion Load assembly

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

        ///// <summary>
        ///// Gets the specified type.
        ///// </summary>
        ///// <param name="type">The type.</param>
        ///// <returns></returns>
        //public AccessorList GetProperties(Type type, bool withSubType = false)
        //{
        //    return AccessorItem.Get(type, withSubType);
        //}

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

        #endregion Factories

        //#region Serializers

        //public Func<string, Type, object> DeserializeObject { get => Serializer.DeserializeObject; }

        //public Func<object, string> SerializeObject { get => Serializer.SerializeObject; }

        //public Action<string, object> PopulateObject { get => Serializer.PopulateObject; }

        //#endregion Serializers

        //public void GetTypeDescriptor(Type type)
        //{

        //    //TypeDescriptor.

        //}

        /// <summary>
        ///     function  return the list of loaded assemblies
        /// </summary>
        public readonly Func<IEnumerable<Assembly>> Assemblies;
        private readonly HashSet<string> _paths;
        private static readonly object _lock = new object();
        private static readonly object _lock2 = new object();
        private static TypeDiscovery _instance;
        private Dictionary<string, HashSet<string>> _assemblyNames = new Dictionary<string, HashSet<string>>();
        private Dictionary<string, Assembly> _loadedByFile = new Dictionary<string, Assembly>();



    }
}



