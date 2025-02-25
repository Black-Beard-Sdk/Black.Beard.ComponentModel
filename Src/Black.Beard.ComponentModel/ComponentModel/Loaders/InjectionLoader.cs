using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.Loaders
{

    /// <summary>
    /// Injection loader
    /// </summary>
    public class InjectionLoader
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectionLoader"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="InjectionLoader"/> class.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="context"/> is null.</exception>
        public InjectionLoader(string context, IServiceProvider serviceProvider = null)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));

            if (serviceProvider is LocalServiceProvider s && s.AutoAdd)
                ServiceProvider = s;
            else
                ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };

            Types = new List<Type>();
            Executed = new HashSet<string>();
        }

        /// <summary>
        /// Gets the context used to explore the assemblies.
        /// </summary>
        public string Context { get; }

        /// <summary>
        /// Gets or sets the method used to resolve the value by name to inject.
        /// </summary>
        public Func<string, object> InjectValue { get; internal set; }

        /// <summary>
        /// Gets or sets the service provider.
        /// </summary>
        public LocalServiceProvider ServiceProvider { get; internal set; }

        /// <summary>
        /// Gets the list of types builder found.
        /// </summary>
        public List<Type> Types { get; }

        /// <summary>
        /// Gets the list of builder instances initialized.
        /// </summary>
        public HashSet<string> Executed { get; }

        /// <summary>
        /// Determines whether the module with the specified friendly name should be executed.
        /// </summary>
        /// <param name="friendlyName">The friendly name of the module.</param>
        /// <returns><c>true</c> if the module should be executed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="friendlyName"/> is null.</exception>
        public bool CanExecuteModule(IInjectBuilder friendlyName)
        {

            if (friendlyName == null)
                throw new ArgumentNullException(nameof(friendlyName));

            bool result = true;

            if (!InjectBuilder.ToInjectBuilder(friendlyName))
                result = false;                

            if (result && _parser.TryResolveStringValue(friendlyName.FriendlyName, out string variableValue))
                result = variableValue?.ToLower() != "false";
                 
            return result;

        }

        /// <summary>
        /// Adds the specified types as injection attributes.
        /// </summary>
        /// <param name="types">The types to add as injection attributes.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="types"/> is null.</exception>
        public static void AddInjectionAttribute(params Type[] types)
        {

            if (types == null)
                throw new ArgumentNullException(nameof(types));

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
