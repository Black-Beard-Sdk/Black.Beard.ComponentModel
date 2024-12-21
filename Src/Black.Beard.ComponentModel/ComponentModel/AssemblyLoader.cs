using Bb.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;

namespace Bb.ComponentModel
{
    public class AssemblyLoader
    {


        #region ctors

        static AssemblyLoader()
        {
            AssemblyLoader._instance = new AssemblyLoader();         
        }

        private AssemblyLoader()
        {

            Paths = AssemblyDirectoryResolver.Instance;

            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;

            var list = AppDomain.CurrentDomain.GetAssemblies().ToList();

            foreach (var item in list)
                AddAssembly(item, null);
        }

        #endregion ctors

        /// <summary>
        /// Return the list of loaded assemblies
        /// </summary>
        public IEnumerable<Assembly> Assemblies => AssemblyLoadContext.CurrentContextualReflectionContext.Assemblies;

        /// <summary>
        /// Return the <see cref="AssemblyDirectoryResolver"/>
        /// </summary>
        public AssemblyDirectoryResolver Paths { get; set; }

        /// <summary>
        /// return the instance of the <see cref="AssemblyLoader"/>
        /// </summary>
        public static AssemblyLoader Instance => _instance;


        /// <summary>
        /// Intercept the event when an assembly is not resolved
        /// </summary>
        public Func<ResolveEventArgs, Assembly> AssemblyNotResolved { get; set; }

        /// <summary>
        /// Ensures that all referenced the assembly are loaded.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="acceptAllVersion">if set to <c>true</c> [accept all version].</param>
        /// <param name="recursively">if set to <c>true</c> [recursively].</param>
        public void EnsureAssemblyIsLoaded(Assembly assembly, bool acceptAllVersion = true, bool recursively = false)
        {

            var hash = new HashSet<string>();
            if (!Paths.IsInSystemDirectory(assembly))
                using (var _ = ComponentModelActivityProvider.StartActivity("loading assemblies"))
                {
                    var assemblies = assembly.GetReferencedAssemblies();
                    foreach (AssemblyName ass in assemblies)
                    {
                        var filename = ass.FullName;
                        if (!string.IsNullOrEmpty(filename) && hash.Add(filename))
                        {

                            Assembly refAssembly;
                            if (AssemblyLoader.Instance.IsLoadedByAssemblyByName(ass, acceptAllVersion))
                                refAssembly = AssemblyLoader.Instance.LoadAssemblyName(ass);
                            else
                                refAssembly = TypeDiscovery.Instance.GetAssembly(ass);

                            if (recursively && refAssembly != null)
                                TypeDiscovery.Instance.EnsureAssemblyIsLoadedWithReferences(refAssembly, acceptAllVersion, recursively, hash);

                        }
                    }
                }
        }

        /// <summary>
        /// Load assembly by the specified assembly name
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        public Assembly LoadAssemblyName(string assemblyName)
        {

            try
            {
                var ass = Assembly.Load(assemblyName);
                if (ComponentModelActivityProvider.WithTelemetry)
                    ComponentModelActivityProvider.AddProperty("added_ass" + _loadedByFile.Count().ToString(), assemblyName);
                AddAssembly(ass, null);
                return ass;
            }
            catch (Exception ex)
            {
                Trace.TraceError($"Failed to resolve {assemblyName}");
                if (ComponentModelActivityProvider.WithTelemetry)
                    ComponentModelActivityProvider.AddProperty("failed_ass" + _loadedByFile.Count().ToString(), assemblyName);
            }

            return null;

        }

        /// <summary>
        /// Load assembly name
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Assembly LoadAssemblyName(AssemblyName item)
        {

            try
            {
                var ass = Assembly.Load(item);
                if (ComponentModelActivityProvider.WithTelemetry)
                    ComponentModelActivityProvider.AddProperty("added_ass" + _loadedByFile.Count().ToString(), item.FullName);
                AddAssembly(ass, null);
                
                return ass;

            }
            catch (Exception ex)
            {
                Trace.TraceError($"Failed to resolve {item.Name}");
                if (ComponentModelActivityProvider.WithTelemetry)
                    ComponentModelActivityProvider.AddProperty("failed_ass" + _loadedByFile.Count().ToString(), item.FullName);
            }

            return null;

        }


        /// <summary>
        /// Try to get assembly in the list of loaded assemblies
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryToGet(string fullname, out Assembly assembly)
        {
            return _loadedByFile.TryGetValue(fullname, out assembly);
        }


        /// <summary>
        /// Try to get assembly in the list of loaded assemblies
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryToGet(FileInfo filename, out Assembly assembly)
        {
            return _loadedByFile.TryGetValue(filename.FullName, out assembly);
        }

        /// <summary>
        /// return true if assembly is already loaded
        /// </summary>
        /// <param name="fullname"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLoadedByFile(string fullname)
        {
            return _loadedByFile.ContainsKey(fullname);
        }

        /// <summary>
        /// return true if assembly is already loaded
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLoadedByFile(FileInfo filename)
        {
            return _loadedByFile.ContainsKey(filename.FullName);
        }

        /// <summary>
        /// return assembly
        /// </summary>
        /// <param name="fileAssembly"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Assembly LoadAssembly(string fileAssembly)
        {
            return LoadAssembly(new FileInfo(fileAssembly));
        }

        /// <summary>
        /// Load assembly by the specified filename
        /// </summary>
        /// <param name="fileAssembly">filename of the assembly</param>
        /// <param name="withPdb">if true, load the pdb if exists</param>
        /// <returns></returns>
        public Assembly LoadAssembly(string fileAssembly, bool withPdb)
        {

            var file = new System.IO.FileInfo(fileAssembly);
            return LoadAssembly(file, withPdb);

        }

        /// <summary>
        /// return assembly
        /// </summary>
        /// <param name="fileAssembly"></param>
        /// <param name="filePdb"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Assembly LoadAssembly(FileInfo fileAssembly, FileInfo filePdb = null)
        {

            if (fileAssembly == null)
                throw new ArgumentNullException(nameof(fileAssembly));

            if (string.IsNullOrEmpty(fileAssembly.Name))
                throw new ArgumentNullException(nameof(fileAssembly.Name));

            if (!fileAssembly.Exists)
                throw new FileNotFoundException(fileAssembly.FullName);

            fileAssembly.Refresh();
            if (TryToGet(fileAssembly.FullName, out Assembly assembly))
                return assembly;

            var name1 = Path.GetFileNameWithoutExtension(fileAssembly.Name);
            assembly = GetLoadedAssembly(name1);

            if (assembly == null)
                assembly = LoadAssembly_Impl(fileAssembly, filePdb);

            else
                AddAssembly(assembly, fileAssembly.FullName);

            return assembly;

        }

        /// <summary>
        ///     The on register exception
        /// </summary>
        public static Action<Exception> OnRegisterException { get; set; }



        /// <summary>
        /// Return true if assembly is already loaded
        /// </summary>
        /// <param name="name">assemblyName</param>
        /// <param name="acceptAllversions">if false don't try to match the version</param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool IsLoadedByAssemblyByName(string assemblyName, bool acceptAllVersion)
        {

            if (assemblyName.EndsWith(".resources"))
            {
                var oo = assemblyName.Substring(0, assemblyName.Length - 10);
                var result = IsLoadedByAssemblyByName(oo, acceptAllVersion);
                if (result)
                    return true;
            }

            try
            {
                var name = AssemblyName.GetAssemblyName(assemblyName);
                return IsLoadedByAssemblyByName(name, acceptAllVersion);
            }
            catch (Exception ex)
            {
            }

            return false;

        }



        /// <summary>
        /// Load assembly by the specified filename
        /// </summary>
        /// <param name="fileAssembly">file of the assembly</param>
        /// <param name="withPdb">if true, load the pdb if exists</param>
        /// <returns></returns>
        private Assembly LoadAssembly(FileInfo file, bool withPdb)
        {
            if (withPdb)
            {
                FileInfo filePdb = new FileInfo(Path.Combine(file.Directory.FullName, Path.GetFileNameWithoutExtension(file.Name)) + ".pdb");
                filePdb.Refresh();
                if (filePdb.Exists)
                    return LoadAssembly(file, filePdb);

            }

            return LoadAssembly(file, null);
        }

        private Assembly GetLoadedAssembly(string filename)
        {

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (Assembly assembly in assemblies)
            {

                var name2 = Path.GetFileNameWithoutExtension(assembly.ManifestModule.ScopeName);

                if (filename == name2)
                    return assembly;

            }

            return null;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Assembly LoadAssembly_Impl(FileInfo fileAssembly, FileInfo filePdb)
        {

            Assembly assembly = null;

            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            if (IsLoadedByFile(fileAssembly.FullName))
                foreach (var item in assemblies)
                    if (item.Location == fileAssembly.FullName)
                        return item;

            var name1 = Path.GetFileNameWithoutExtension(fileAssembly.Name);

            if (filePdb == null)
            {
                var path = Path.Combine(fileAssembly.Directory.FullName, name1) + ".pdb";
                var filePdbBuilded = new FileInfo(path);
                filePdb = filePdbBuilded.Exists ? filePdbBuilded : null;
            }

            if (!IsLoadedByAssemblyByName(name1, false))
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
                        assembly = LoadAssembly(fileAssembly.FullName);

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
                    if (OnRegisterException != null)
                        OnRegisterException(e);
                    Trace.WriteLine(e, TraceLevel.Error.ToString());
                }
            }

            return assembly;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AddAssembly(Assembly ass, string location)
        {

            if (ass.IsDynamic)
                return;

            if (string.IsNullOrWhiteSpace(location))
                location = ass.Location;

            if (!_loadedByFile.ContainsKey(location))
                lock (_lock2)
                    if (!_loadedByFile.ContainsKey(location))
                    {
                        Trace.TraceInformation($"Assembly {ass} is loaded from {location}");
                        _loadedByFile.Add(location, ass);
                        Paths.AddDirectoryFromFiles(location);
                    }

            var name = ass.GetName();

            if (!_assemblyNames.TryGetValue(name.Name, out var dic))
                lock (_lock2)
                    if (!_assemblyNames.TryGetValue(name.Name, out dic))
                        _assemblyNames.Add(name.Name, dic = new HashSet<string>() { name.Version.ToString() });

        }

        private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            AddAssembly(args.LoadedAssembly, null);
        }

        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            var n = new AssemblyName(args.Name);

            foreach (var filename in Paths.ResolveAssemblyFilenames(n))
                if (filename != null && filename.Exists)
                {
                    Assembly assembly;

                    if (!IsLoadedByFile(filename))
                        assembly = LoadAssembly(filename.FullName);
                    else
                        assembly = _loadedByFile[filename.FullName];

                    return assembly;

                }

            if (AssemblyNotResolved != null)
                return AssemblyNotResolved(args);

            return null;

        }

        private Dictionary<string, HashSet<string>> _assemblyNames = new Dictionary<string, HashSet<string>>();
        private volatile object _lock2 = new object();
        private Dictionary<string, Assembly> _loadedByFile = new Dictionary<string, Assembly>();
        private static readonly AssemblyLoader _instance;

    }


}
