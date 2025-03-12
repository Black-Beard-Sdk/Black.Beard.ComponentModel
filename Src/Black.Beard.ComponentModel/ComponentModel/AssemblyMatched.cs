using System;
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
        public FileInfo AssemblyLocation { get; internal set; }

        /// <summary>
        /// Gets the name of the assembly.
        /// </summary>
        /// <value>
        /// The name of the assembly.
        /// </value>
        public string AssemblyName { get; internal set; }

        /// <summary>
        /// Gets the assembly version.
        /// </summary>
        /// <value>
        /// The assembly version.
        /// </value>
        public Version AssemblyVersion { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether [assembly is loaded].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [assembly is loaded]; otherwise, <c>false</c>.
        /// </value>
        public bool AssemblyIsLoaded => _isLoaded.HasValue
            ? (_isLoaded.Value && _isLoaded.Value)
            : (_isLoaded = TypeDiscovery.Instance.IsLoaded(this.AssemblyLocation)).Value;


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
                if (_assembly == null && AssemblyIsLoaded)
                    Assembly = TypeDiscovery.Instance.GetAssembly(this.AssemblyName);
                return _assembly;
            }
            private set
            {
                if (value != null)
                {
                    _assembly = value;
                    _isLoaded = this.Assembly != null;
                    IsEntryDirectory = AssemblyDirectoryResolver.IsEntryDirectory(_assembly);
                    IsSystemDirectory = AssemblyDirectoryResolver.IsSystemDirectory(_assembly);
                    IsSdk = _assembly.IsSdk();
                }
                else
                {
                    _assembly = null;
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
        public virtual void Load(bool failedOnloadError = true)
        {

            if (!AssemblyIsLoaded && !failedOnloadError)
                try
                {
                    this.Assembly = AssemblyLoader.Instance.LoadAssembly(this.AssemblyLocation, null);
                }
                catch (Exception)
                {
                    this.FailedToLoad = true;
                    if (failedOnloadError)
                        throw;
                }

        }

        public virtual void ResolveIfLoaded()
        {

            if (_assembly == null && AssemblyIsLoaded)
                this.Assembly = AssemblyLoader.Instance.LoadAssembly(this.AssemblyLocation, null);

        }


        private bool? _isLoaded;

        public bool IsEntryDirectory { get; internal set; }
        public bool IsSystemDirectory { get; internal set; }
        public bool IsSdk { get; internal set; }

        private Assembly _assembly;

    }


}



