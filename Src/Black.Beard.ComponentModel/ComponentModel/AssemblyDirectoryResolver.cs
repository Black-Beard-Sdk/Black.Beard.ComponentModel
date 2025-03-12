using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{



    /// <summary>
    /// Manage the assemblies folders
    /// </summary>
    public class AssemblyDirectoryResolver
    {

        #region Singleton & ctors

        /// <summary>
        /// Initializes the <see cref="AssemblyDirectoryResolver"/> class.
        /// </summary>
        static AssemblyDirectoryResolver()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyDirectoryResolver"/> class.
        /// </summary>
        /// <param name="paths"></param>
        public AssemblyDirectoryResolver(params string[] paths)
        {

            _excludedFiles = new HashSet<string>();
            if (paths == null)
                _paths = new HashSet<string>();

            else
                _paths = new HashSet<string>(paths);

            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!string.IsNullOrEmpty(path))
                AddDirectories(path);

            var dir = FolderBinResolver.GetBinPaths().ToList();
            AddDirectories(dir);

        }

        /// <summary>
        /// Prevents a default instance of the <see cref="AssemblyDirectoryResolver"/> class from being created.
        /// </summary>
        public static AssemblyDirectoryResolver Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                        if (_instance == null)
                            _instance = new AssemblyDirectoryResolver();
                return _instance;
            }
        }

        #endregion Singleton & ctors

        #region Remove directories

        /// <summary>
        /// Clears all paths.
        /// </summary>
        /// <returns></returns>
        public AssemblyDirectoryResolver Clear()
        {
            _paths.Clear();
            _initialized = false;
            return this;
        }

        /// <summary>
        /// Deletes the directories.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver DelDirectories(IEnumerable<string> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    DelDirectories(new DirectoryInfo(item));
            return this;
        }

        /// <summary>
        /// Deletes the directories.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver DelDirectories(params string[] paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    DelDirectories(new DirectoryInfo(item));
            return this;
        }

        /// <summary>
        /// Deletes the directories.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver DelDirectories(IEnumerable<DirectoryInfo> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    _paths.Remove(item.FullName.Trim(Path.DirectorySeparatorChar));
            return this;

        }

        /// <summary>
        /// Deletes the directories.
        /// </summary>
        /// <param name="paths">The paths.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver DelDirectories(params DirectoryInfo[] paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    _paths.Remove(item.FullName.Trim(Path.DirectorySeparatorChar));
            return this;
        }

        #endregion Remove directories

        #region Add directories

        /// <summary>
        /// Adds the directories path's.
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        public AssemblyDirectoryResolver AddDirectories(params string[] paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(new DirectoryInfo(item));
            return this;
        }

        /// <summary>
        /// Adds the directories path's.
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectories(IEnumerable<string> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(new DirectoryInfo(item));
            return this;
        }

        /// <summary>
        /// Adds the directories path's.
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectories(IEnumerable<DirectoryInfo> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(item);
            return this;
        }

        /// <summary>
        /// Adds the directories path's form files location
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectoryFromFiles(params string[] paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(new FileInfo(item).Directory);
            return this;
        }

        /// <summary>
        /// Adds the directories path's form files location
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectoryFromFiles(IEnumerable<string> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(new FileInfo(item).Directory);
            return this;
        }

        /// <summary>
        /// Adds the directories path's form files location
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectoryFromFiles(params FileInfo[] paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(item.Directory);
            return this;
        }

        /// <summary>
        /// Adds the directories path's form files location
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectoryFromFiles(IEnumerable<FileInfo> paths)
        {
            if (paths != null)
                foreach (var item in paths)
                    AddDirectories(item.Directory);
            return this;
        }

        /// <summary>
        /// Adds the directories path's.
        /// </summary>
        /// <param name="paths">The paths of the directories.</param>
        /// <returns><see cref="AssemblyDirectoryResolver"/> </returns>
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
        public AssemblyDirectoryResolver AddDirectories(params DirectoryInfo[] paths)
        {

            if (paths != null)
                foreach (var item in paths)
                {

                    item.Refresh();

                    if (item.Exists)
                        _paths.Add(item.FullName.Trim(Path.DirectorySeparatorChar));

                    else if (ThrowExceptionIfNotFound)
                        throw new DirectoryNotFoundException(item.FullName);

                }

            return this;

        }

        #endregion Add directories

        /// <summary>
        /// Gets the system directories.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSystemDirectories()
        {
            var list = GetPaths().Where(c => !c.StartsWith(Environment.CurrentDirectory)).ToList();
            return list;
        }

        /// <summary>
        /// return system Directory that contains the root assemblies
        /// </summary>
        public static DirectoryInfo SystemDirectory => _sSystemDirectory ?? (_sSystemDirectory = new FileInfo(typeof(object).Assembly.Location).Directory);

        /// <summary>
        /// return true if the specified path is the system directory
        /// </summary>
        /// <param name="path">path to evaluate</param>
        /// <returns></returns>
        public static bool IsSystemDirectory(string path)
        {
            return SystemDirectory.FullName == path;
        }

        /// <summary>
        /// return true if the specified path is the system directory
        /// </summary>
        /// <param name="path">path to evaluate</param>
        /// <returns></returns>
        public static bool IsSystemDirectory(DirectoryInfo path)
        {
            return SystemDirectory.FullName == path.FullName;
        }

        /// <summary>
        /// return true if the specified assembly is in System
        /// </summary>
        /// <param name="assembly">assembly to evaluate</param>
        /// <returns></returns>
        public static bool IsSystemDirectory(Assembly assembly)
        {
            return IsSystemDirectory(new FileInfo(assembly.Location).Directory);
        }        

    


        public static DirectoryInfo EntryDirectory => _sEntryDirectory ?? (_sEntryDirectory = new FileInfo(Assembly.GetEntryAssembly().Location).Directory);

        /// <summary>
        /// return true if the specified path is the entry directory
        /// </summary>
        /// <param name="path">path to evaluate</param>
        /// <returns></returns>
        public static bool IsEntryDirectory(string path)
        {
            return EntryDirectory.FullName == path;
        }

        /// <summary>
        /// return true if the specified path is the entry directory
        /// </summary>
        /// <param name="path">path to evaluate</param>
        /// <returns></returns>
        public static bool IsEntryDirectory(DirectoryInfo path)
        {
            return EntryDirectory.FullName == path.FullName;
        }

        /// <summary>
        /// return true if the specified path is the entry directory
        /// </summary>
        /// <param name="assembly">assembly to evaluate</param>
        /// <returns></returns>
        public static bool IsEntryDirectory(Assembly assembly)
        {
            return IsEntryDirectory(new FileInfo(assembly.Location).Directory);
        }



        #region Get Paths

        /// <summary>
        /// return the list of directories of loaded assemblies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetPaths()
        {

            if (!_initialized)
                lock (_lock)
                    if (!_initialized)
                    {
                        _initialized = true;
                        AddDirectories(TypeDiscovery.Instance.GetDirectoryPathFromAssemblies());
                    }

            var paths = _paths.ToList();
            foreach (var item in paths)
                yield return item;

        }

        /// <summary>
        /// return the list of directories of loaded assemblies.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DirectoryInfo> GetDirectories()
        {
            foreach (var item in GetPaths())
                yield return new DirectoryInfo(item);
        }

        #endregion Get Paths


        #region Get assembly files

        /// <summary>
        /// try to resolve assembly location from the specified assembly name.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        public bool TryToResolveAssemblyLocation(AssemblyName assemblyName, out FileInfo file)
        {
            foreach (var directory in this.GetDirectories())
            {
                file = assemblyName.ResolveAssemblyFilename(directory);
                if (file != null)
                    return true;
            }
            file = null;
            return false;
        }

        /// <summary>
        /// Gets the assemblies list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetAssembliesOfDirectories(Func<FileInfo, bool> filter = null)
        {

            HashSet<string> files = new HashSet<string>();
            var dirs = this.GetDirectories().ToArray();
            var _excludes = new HashSet<string>(_excludedFiles);
            foreach (var directory in dirs)
            {

                foreach (var file in directory.GetFiles("*.dll"))
                    if (filter == null || filter(file))
                    {
                        var name = Path.GetFileNameWithoutExtension(file.Name.ToLower());
                        if (files.Add(name) && !_excludes.Contains(file.FullName))
                            yield return file;
                    }

                foreach (var file in directory.GetFiles("*.exe"))
                    if (filter == null || filter(file))
                    {
                        var name = Path.GetFileNameWithoutExtension(file.Name.ToLower());
                        if (files.Add(name) && !_excludes.Contains(file.FullName))
                            yield return file;
                    }

            }
        }

        /// <summary>
        /// Gets the assemblies of the specified folder.
        /// </summary>
        /// <param name="directory">The directory path.</param>
        /// <param name="filter">file filter.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetAssemblies(string directory, Func<FileInfo, bool> filter = null)
        {
            return GetAssemblies(new DirectoryInfo(directory), filter);
        }

        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <param name="directory">The directory path.</param>
        /// <param name="filter">The file filter.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetAssemblies(DirectoryInfo directory, Func<FileInfo, bool> filter = null)
        {

            directory.Refresh();
            HashSet<string> files = new HashSet<string>();
            var _excludes = new HashSet<string>(_excludedFiles);

            foreach (var file in directory.GetFiles("*.dll"))
                if (filter == null || filter(file))
                {
                    var name = Path.GetFileNameWithoutExtension(file.Name.ToLower());
                    if (files.Add(name) && !_excludes.Contains(file.FullName))
                        yield return file;
                }

            foreach (var file in directory.GetFiles("*.exe"))
                if (filter == null || filter(file))
                {
                    var name = Path.GetFileNameWithoutExtension(file.Name.ToLower());
                    if (files.Add(name) && !_excludes.Contains(file.FullName))
                        yield return file;
                }


        }

        /// <summary>
        /// Gets the assembly file.
        /// </summary>
        /// <param name="assemblyName">The assembly to resolve.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> ResolveAssemblyFilenames(AssemblyName assemblyName)
        {
            foreach (var directory in this.GetDirectories())
            {
                var ass = assemblyName.ResolveAssemblyFilename(directory);
                if (ass != null)
                    yield return ass;
            }
        }

        /// <summary>
        /// Adds the file on the list of file must don't to load.
        /// </summary>
        /// <param name="fullNames">The full-name's list.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver AddFileForNotLoad(params string[] fullNames)
        {
            foreach (var item in fullNames)
                _excludedFiles.Add(item);
            return this;

        }

        /// <summary>
        /// Adds the file on the list of file must don't to load.
        /// </summary>
        /// <param name="fullNames">The full names.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver AddFileForNotLoad(params FileInfo[] fullNames)
        {
            foreach (var item in fullNames)
                _excludedFiles.Add(item.FullName);
            return this;
        }

        /// <summary>
        /// return true id the specified assembly is in System
        /// </summary>
        /// <param name="assembly">assembly to evaluate</param>
        /// <returns></returns>
        public bool IsInSystemDirectory(Assembly assembly)
        {
            if (assembly.IsDynamic || string.IsNullOrEmpty(assembly.Location))
                return false;   

            return IsInSystemDirectory(new FileInfo(assembly.Location).Directory);
        }

        /// <summary>
        /// return true if the specified file is in System folder
        /// </summary>
        /// <param name="file">file</param>
        /// <returns></returns>
        public bool IsInSystemDirectory(FileInfo file)
        {
            return IsInSystemDirectory(file?.Directory);
        }

        /// <summary>
        /// Return true if the directory is System directory
        /// </summary>
        /// <param name="path">path o evaluate</param>
        /// <returns></returns>
        public bool IsInSystemDirectory(DirectoryInfo path)
        {

            var pathEntry = EntryDirectory.FullName;
            var pathSystem = SystemDirectory.FullName;

            if (pathEntry == pathSystem)
                return false;

            if (path.FullName == pathSystem)
                return true;

            return false;

        }

        /// <summary>
        /// Return true if the directory is entry directory
        /// </summary>
        /// <param name="path">path o evaluate</param>
        /// <returns></returns>
        public bool IsInEntryDirectory(DirectoryInfo path)
        {
            var pathEntry = EntryDirectory.FullName;
            return path.FullName == pathEntry;
        }

        #endregion Get assembly files


        /// <summary>
        /// Gets or sets a value indicating whether [throw exception if the directory file is not found].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [throw exception if not found]; otherwise, <c>false</c>.
        /// </value>
        public bool ThrowExceptionIfNotFound { get; set; } = false;

        private static DirectoryInfo _sSystemDirectory;
        private static DirectoryInfo _sEntryDirectory;
        private static readonly object _lock = new object();
        private readonly HashSet<string> _paths;
        private readonly HashSet<string> _excludedFiles;
        private static AssemblyDirectoryResolver _instance;
        private bool _initialized;

    }


}
