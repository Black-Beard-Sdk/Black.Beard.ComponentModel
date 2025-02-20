using Bb.ComponentModel.Factories;
using ICSharpCode.Decompiler.Disassembler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

namespace Bb.ComponentModel.Loaders
{

    public class InjectionLoader
    {


        public InjectionLoader(string context, IServiceProvider serviceProvider = null)
        {

            this.Context = context;

            if (serviceProvider is LocalServiceProvider s && s.AutoAdd)
                ServiceProvider = s;

            else
                ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };

            Types = new List<Type>();
            Executed = new HashSet<string>();

        }

        /// <summary>
        /// Context the match for explore the assemblies
        /// </summary>
        public string Context { get; }

        /// <summary>
        /// method to resolve the value by name to inject
        /// </summary>
        public Func<string, object> InjectValue { get; internal set; }

        /// <summary>
        /// Service provider
        /// </summary>
        public LocalServiceProvider ServiceProvider { get; internal set; }

        /// <summary>
        /// List of types builder found
        /// </summary>
        public List<Type> Types { get; }

        /// <summary>
        /// List of builder instances initialized
        /// </summary>
        public HashSet<string> Executed { get; }

        //public bool ExcludeAbstractTypes { get; internal set; } = true;

        //public bool ExcludeGenericTypes { get; internal set; } = true;

        /// <summary>
        /// return true if the module must be evaluated
        /// </summary>
        /// <param name="friendlyName"></param>
        /// <returns></returns>
        public bool CanExecuteModule(string friendlyName)
        {

            bool result = true;
            if (_parser.TryResolveStringValue(friendlyName, out string variableValue))
                result = variableValue?.ToLower() != "false";

            if (result)
                Debug.WriteLine($"injectionLoader {friendlyName} must be executed");
            else
                Debug.WriteLine($"injectionLoader {friendlyName} by passed");
            return result;

        }

        /// <summary>
        /// add attribute to match for inject instance
        /// </summary>
        /// <param name="types"></param>
        public static void AddInjectionAttribute(params Type[] types)
        {
            foreach (var item in types)
                ObjectCreatorByIoc.SetInjectionAttribute(item);
        }

        internal CommandLineParser _parser;

    }


    /// <summary>
    /// Loader of application builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <example>
    /// 
    /// Create a class that will be discovered
    /// <code lang="Csharp">
    /// [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder<Initializer>), LifeCycle = IocScopeEnum.Transiant)]
    /// public class NLogInitializer : IInjectBuilder<Initializer>
    /// {
    /// 
    ///     public string FriendlyName => typeof(NLogInitializer).Name;
    /// 
    ///     public Type Type => typeof(Initializer);
    /// 
    ///     public bool CanExecute(Initializer context) => context.CanExecuteModule(FriendlyName);
    /// 
    ///     public bool CanExecute(object context) => CanExecute((Initializer)context);
    /// 
    ///     public object Execute(object context) => Execute((Initializer)context);
    /// 
    ///     public object Execute(Initializer context)
    ///     {
    ///         // execute your code here
    ///         return null;
    ///     }
    /// 
    /// }
    /// </code>
    /// 
    /// Initialize the instance
    /// <code lang="Csharp">
    ///     var loader = new InjectionLoader<T>(context, serviceProvider)
    ///         .LoadModules()
    ///         .Execute(instance);
    /// </code>
    /// </example>
    public class InjectionLoader<T> : InjectionLoader
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="InjectionLoader{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="InjectionLoader{T}"/> class.
        /// </remarks>        
        public InjectionLoader(string context, IServiceProvider serviceProvider = null, Action<InjectionLoader<T>> initializer = null)
            : base(context, serviceProvider)
        {

            Instances = new List<IInjectBuilder<T>>();

            if (initializer != null)
                initializer(this);

        }

        public Func<PropertyDescriptor, string, IInjectBuilder<T>, object> InjectRescue { get; internal set; }


        internal void AddInstances(IEnumerable<IInjectBuilder<T>> instances)
        {
            var i = Instances as List<IInjectBuilder<T>>;
            i.AddRange(instances);
        }

        /// <summary>
        /// List of builder instances
        /// </summary>
        public IEnumerable<IInjectBuilder<T>> Instances { get; }

    }

}
