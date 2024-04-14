using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;

namespace Bb.ComponentModel.Loaders
{
    /// <summary>
    /// Loader of application builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InjectionLoader<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InitializationLoader{T}"/> class.
        /// </summary>
        public InjectionLoader(IServiceProvider serviceProvider, string context)
        {
            this.Context = context;
            ServiceProvider = new LocalServiceProvider(serviceProvider) {  AutoAdd = true };
            Types = new List<Type>();
            Instances = new List<IInjectBuilder<T>>();
            Executed = new HashSet<string>();
        }

        public string Context { get; }

        public LocalServiceProvider ServiceProvider { get; }

        /// <summary>
        /// List of types builder found
        /// </summary>
        public List<Type> Types { get; }

        /// <summary>
        /// List of builder instances
        /// </summary>
        public List<IInjectBuilder<T>> Instances { get; }

        /// <summary>
        /// List of builder instances initialized
        /// </summary>
        public HashSet<string> Executed { get; }

        public bool ExcludeAbstractTypes { get; set; } = true;
        
        public bool ExcludeGenericTypes { get; internal set; } = true;

    }


}
