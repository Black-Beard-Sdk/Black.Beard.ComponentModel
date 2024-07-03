//using Bb.ComponentModel.Attributes;
//using Bb.ComponentModel.Factories;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;

//namespace Bb.ComponentModel.Loaders
//{


//    /// <summary>
//    /// Loader of application builder
//    /// </summary>
//    /// <typeparam name="T"></typeparam>
//    public class InitializationLoader<T>
//    {

//        /// <summary>
//        /// Initializes a new instance of the <see cref="InitializationLoader{T}"/> class.
//        /// </summary>
//        public InitializationLoader(string context, IServiceProvider serviceProvider  = null)
//        {
//            Context = context;
//            ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };
//            Types = new List<Type>();
//            Instances = new List<IApplicationBuilderInitializer<T>>();
//            Executed = new HashSet<string>();
//        }

//        public string Context { get; }

//        public InitializationLoader<T> WithServices(IServiceProvider serviceProvider)
//        {
//            ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };
//            return this;    
//        }

//        public LocalServiceProvider ServiceProvider { get; private set; }

//        /// <summary>
//        /// List of types builder found
//        /// </summary>
//        public List<Type> Types { get; }

//        /// <summary>
//        /// List of builder instances
//        /// </summary>
//        public List<IApplicationBuilderInitializer<T>> Instances { get; }

//        /// <summary>
//        /// List of builder instances initialized
//        /// </summary>
//        public HashSet<string> Executed { get; }

//    }


//}
