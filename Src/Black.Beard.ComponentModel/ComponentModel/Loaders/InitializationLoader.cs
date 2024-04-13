using System;
using System.Collections.Generic;

namespace Bb.ComponentModel.Loaders
{

    /// <summary>
    /// Loader of application builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InitializationLoader<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationLoader{T}"/> class.
        /// </summary>
        public InitializationLoader()
        {
            Builders = new List<Type>();
            InstancesBuilders = new List<IApplicationBuilderInitializer<T>>();
            Initialized = new HashSet<string>();
            Configured = new HashSet<string>();
        }

        /// <summary>
        /// Set the assemblies to load
        /// </summary>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        public InitializationLoader<T> InitializeAssemblies(ExposedAssemblyRepositories assemblies)
        {
            AssembliesToLoad = assemblies;
            return this;
        }

        /// <summary>
        /// Strategy for loading assemblies
        /// </summary>
        public ExposedAssemblyRepositories AssembliesToLoad { get; private set; }

        /// <summary>
        /// List of types builder found
        /// </summary>
        public List<Type> Builders { get; }

        /// <summary>
        /// List of builder instances
        /// </summary>
        public List<IApplicationBuilderInitializer<T>> InstancesBuilders { get; }

        /// <summary>
        /// List of builder instances initialized
        /// </summary>
        public HashSet<string> Initialized { get; }

        /// <summary>
        /// List of builder instances configured
        /// </summary>
        public HashSet<string> Configured { get; }

    }


}
