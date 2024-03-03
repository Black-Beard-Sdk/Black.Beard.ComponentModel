using Bb.ComponentModel.Factories;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

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

            AddDirectories(AppDomain.CurrentDomain.BaseDirectory);

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
        /// <exception cref="System.IO.DirectoryNotFoundException">if the directory file is not found and the value of ThrowExceptionIfNotFound is true</exception>
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

            foreach (var item in _paths)
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
        /// Gets the assemblies list.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetAssemblies(Func<FileInfo, bool> filter = null)
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
        /// Gets the assemblies.
        /// </summary>
        /// <param name="directory">The directory path.</param>
        /// <returns></returns>
        public IEnumerable<FileInfo> GetAssemblies(string directory, Func<FileInfo, bool> filter = null)
        {
            return GetAssemblies(new DirectoryInfo(directory), filter);
        }

        /// <summary>
        /// Gets the assemblies.
        /// </summary>
        /// <param name="filter">The filter.</param>
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
        /// Gets the assemblies.
        /// </summary>
        /// <param name="filter">The filter.</param>
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
        /// <param name="fullNames">The full names.</param>
        /// <returns></returns>
        public AssemblyDirectoryResolver AddFileNotLoading(params string[] fullNames)
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
        public AssemblyDirectoryResolver AddFileNotLoading(params FileInfo[] fullNames)
        {
            foreach (var item in fullNames)
                _excludedFiles.Add(item.FullName);
            return this;
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
        private static readonly object _lock = new object();
        private readonly HashSet<string> _paths;
        private readonly HashSet<string> _excludedFiles;
        private static AssemblyDirectoryResolver _instance;
        private bool _initialized;

    }


}
