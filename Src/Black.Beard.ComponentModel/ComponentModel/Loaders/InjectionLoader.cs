using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.Loaders
{


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
    public class InjectionLoader<T>
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="InjectionLoader{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="InjectionLoader{T}"/> class.
        /// </remarks>        
        public InjectionLoader(string context, IServiceProvider serviceProvider = null)
        {

            this.Context = context;

            if (serviceProvider is LocalServiceProvider s && s.AutoAdd)
                ServiceProvider = s;

            else
                ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };


            Types = new List<Type>();
            Instances = new List<IInjectBuilder<T>>();
            Executed = new HashSet<string>();
        }

        /// <summary>
        /// Sets the inject value rescue function.
        /// </summary>
        /// <param name="injectRescue">The inject rescue function.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the function that will be called when the system cannot resolve the value to inject.
        /// The function takes a <see cref="PropertyDescriptor"/> representing the property being injected,
        /// a string representing the context, and an <see cref="IInjectBuilder{T}"/> instance.
        /// It should return the value to be injected.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="injectRescue"/> is null.</exception>
        public InjectionLoader<T> SetInjectRescue(Func<PropertyDescriptor, string, IInjectBuilder<T>, object> injectRescue)
        {
            InjectRescue = injectRescue;
            return this;
        }

        /// <summary>
        /// Sets the inject value function.
        /// </summary>
        /// <param name="injectValue">The inject value function.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the function that will be called to retrieve the value to be injected.
        /// The function takes a <see cref="string"/> representing the inject value and should return the value to be injected.
        /// </remarks>
        public InjectionLoader<T> SetInjectValue(Func<string, object> injectValue)
        {
            InjectValue = injectValue;
            return this;
        }

        /// <summary>
        /// Sets the services for the injection loader.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the <paramref name="serviceProvider"/> for the injection loader.
        /// </remarks>
        public InjectionLoader<T> WithServices(IServiceProvider serviceProvider)
        {
            ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };
            return this;
        }

        public Func<PropertyDescriptor, string, IInjectBuilder<T>, object> InjectRescue { get; private set; }

        /// <summary>
        /// method to resolve the value by name to inject
        /// </summary>
        public Func<string, object> InjectValue { get; private set; }

        public string Context { get; }


        /// <summary>
        /// Service provider
        /// </summary>
        public LocalServiceProvider ServiceProvider { get; private set; }

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

        internal CommandLineParser _parser;

    }

}
