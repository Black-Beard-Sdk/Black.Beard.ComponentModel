using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Bb.ComponentModel
{

    [DebuggerDisplay("{AssemblyName}")]
    /// <summary>
    /// Type matched
    /// </summary>
    public class AssemblyMatched
    {

        public AssemblyMatched()
        {

        }

        /// <summary>
        /// Gets the assembly location.
        /// </summary>
        /// <value>
        /// The assembly location.
        /// </value>
        public FileInfo AssemblyLocation { get; set; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>
        /// The name of the assembly.
        /// </value>
        public string AssemblyName { get; internal set; }

        /// <summary>
        /// Gets the full name of the assembly.
        /// </summary>
        public AssemblyName AssemblyFullName { get; internal set; }


        /// <summary>
        /// Gets a value indicating whether [assembly is loaded].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [assembly is loaded]; otherwise, <c>false</c>.
        /// </value>
        public bool AssemblyIsLoaded
        {
            get
            {
                if (_isLoaded.HasValue)
                    return _isLoaded.Value;

                if (this.AssemblyLocation != null)
                    _isLoaded = AssemblyLoader.Instance.IsLoadedByFile(this.AssemblyLocation);

                else if (!string.IsNullOrEmpty(this.AssemblyName))
                    _isLoaded = AssemblyLoader.Instance.IsLoadedByAssemblyByName(this.AssemblyFullName, false);

                return _isLoaded.HasValue ? _isLoaded.Value : false;

            }
        }

        /// <summary>
        /// Gets the assembly of the type. Call the method Load for load the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        public Assembly Assembly
        {
            get
            {

                if (_assembly == null)
                {

                    if(AssemblyLoader.Instance.IsLoadedByAssemblyByName(this.AssemblyFullName, false))
                        _assembly = TypeDiscovery.Instance.GetAssembly(this.AssemblyFullName);

                    else if (AssemblyLoader.Instance.IsLoadedByAssemblyByName(this.AssemblyFullName, true))
                            _assembly = TypeDiscovery.Instance.GetAssembly(this.AssemblyFullName);

                    else if (this.AssemblyLocation != null)
                        _assembly = AssemblyLoader.Instance.LoadAssembly(this.AssemblyLocation);

                    else
                        _assembly = TypeDiscovery.Instance.GetAssembly(this.AssemblyFullName);
                
                }

                return _assembly;

            }
            private set
            {
                if (value != null)
                {
                    _assembly = value;
                    AssemblyName = _assembly.GetName().Name;
                    _isLoaded = value != null;
                    IsEntryDirectory = AssemblyDirectoryResolver.IsEntryDirectory(_assembly);
                    IsSystemDirectory = AssemblyDirectoryResolver.IsSystemDirectory(_assembly);
                    IsSdk = _assembly.IsSdk();
                }
                else
                {
                    _assembly = null;
                    AssemblyName = null;
                    _isLoaded = false;
                    IsEntryDirectory = false;
                    IsSystemDirectory = false;
                    IsSdk = false;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether [failed to load].
        /// </summary>
        public bool FailedToLoad { get; protected set; }


        /// <summary>
        /// Try to load the assembly.
        /// </summary>
        /// <param name="failedOnloadError">if set to <c>true</c> [failed onload error].</param>
        /// <exception cref="System.ArgumentException">name is invalid. -or- The length of name exceeds 1024 characters</exception>
        /// <exception cref="System.TypeLoadException">throwOnError is true, and the type cannot be found</exception>
        /// <exception cref="System.IO.FileNotFoundException">name requires a dependent assembly that could not be found.</exception>
        /// <exception cref="System.IO.FileLoadException">
        ///     name requires a dependent assembly that was found but could not be loaded. -or-
        ///     The current assembly was loaded into the reflection-only context, and name requires
        ///     a dependent assembly that was not preloaded.
        ///</exception>
        /// <exception cref="System.BadImageFormatException">
        ///     name requires a dependent assembly, but the file is not a valid assembly. -or-
        ///     name requires a dependent assembly which was compiled for a version of the runtime
        ///     later than the currently loaded version.
        /// </exception>
        public virtual bool Load(bool failedOnloadError = true)
        {

            bool result = false;

            if (!AssemblyIsLoaded && !FailedToLoad)
                try
                {
                    
                    this.Assembly = AssemblyLoader
                        .Instance.LoadAssembly(this.AssemblyLocation, null);

                    result = true;
                }
                catch (Exception)
                {
                    this.FailedToLoad = true;
                    if (failedOnloadError)
                        throw;
                }

            return result;

        }

        /// <summary>
        /// Resolve the assembly if it is loaded.
        /// </summary>
        public virtual void ResolveIfLoaded()
        {
            if (_assembly == null && AssemblyIsLoaded)
            {
                this.Assembly = AssemblyLoader.Instance.LoadAssembly(this.AssemblyLocation, null);
                IsLoaded = Assembly != null;
            }
        }

        /// <summary>
        /// Return the list of assemblies by name already loaded.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Assembly> GetAssembliesByName()
        {
            return TypeDiscovery.Instance.GetAssemblies(this.AssemblyName);
        }


        public bool IsEntryDirectory { get; internal set; }

        public bool IsSystemDirectory { get; internal set; }

        public bool IsSdk { get; internal set; }
        public bool IsLoaded { get; internal set; }

        private Assembly _assembly;
        private bool? _isLoaded;

    }


}



