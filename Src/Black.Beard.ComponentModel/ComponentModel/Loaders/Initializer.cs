using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Exceptions;
using Bb.ComponentModel.Factories;
using Bb.Expressions;
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Initialize the application
    /// </summary>
    /// <example>
    /// 
    /// Create a class that will be discovered
    /// <code lang="Csharp">
    /// [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;Initializer &gt;), LifeCycle = IocScopeEnum.Transiant)]
    /// public class NLogInitializer : IInjectBuilder &lt;Initializer &gt;
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
    /// Run the initializer
    /// <code lang="Csharp">
    ///     Initializer.Initialize(args);
    /// </code>
    /// 
    /// </example>
    public class Initializer : IServiceProvider
    {

        static Initializer()
        {
            Creator = (args) => new Initializer(args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <returns></returns>
        public static Initializer Initialize(params string[] args)
        {
            return Initialize((i) => { }, args);
        }

        /// <summary>
        /// Discover all initializer and execute them for initializing the application
        /// </summary>
        /// <param name="args">arguments to push in the initialization process</param>
        /// <param name="init">method to configure the process of initialization</param>
        public static Initializer Initialize(Action<Initializer> init, params string[] args)
        {

            init ??= (i) => { };

            if (args == null || args.Length == 0)
                args = Environment.GetCommandLineArgs();

            Initializer initializer = Creator(args);

            init(initializer);

            initializer.Initialize();

            return initializer;

        }

        /// <summary>
        /// Override the default service provider
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public Initializer With(IServiceProvider serviceProvider)
        {
            _serviceProvider = new LocalServiceProvider(serviceProvider);
            return this;
        }

        /// <summary>
        /// Override the default creator
        /// </summary>
        public static Func<string[], Initializer> Creator { get; set; }

        /// <summary>
        /// The context of the initialization
        /// </summary>
        public static string Context { get; set; } = ConstantsCore.Initialization;

        /// <summary>
        /// initialize the initializer
        /// </summary>
        /// <param name="args"></param>
        protected Initializer(params string[] args)
        {
            _parser = new CommandLineParser(args);
            Initializer.Last = this;
        }

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
                Console.WriteLine($"initializer {friendlyName} must be executed");
            else
                Console.WriteLine($"initializer {friendlyName} by passed");
            return result;

        }


        /// <summary>
        /// called if the system can't resolve the value
        /// </summary>
        public Func<PropertyDescriptor, string, IInjectBuilder<Initializer>, object> InjectRescue { get; set; }

        /// <summary>
        /// called if the system can't resolve the value
        /// </summary>
        public Func<string, object> InjectValue { get; set; }


        /// <summary>
        /// Add a type to the list of types that will be resolved by the injection attribute
        /// </summary>
        /// <param name="types"></param>
        public static void AddInjectionAttribute(params Type[] types)
        {
            foreach (var item in types)
                ObjectCreatorByIoc.SetInjectionAttribute(item);
        }


        /// <summary>
        /// return the last initializer instance
        /// </summary>
        public static Initializer Last { get; private set; }


        #region IServiceProvider

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <param name="serviceType">type of the value to reach</param>
        /// <returns>return the service</returns>
        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <typeparam name="T">type to append</typeparam>
        /// <returns>return the service</returns>
        public LocalServiceProvider Add<T>()
            where T : class
        {
            return _serviceProvider.Add<T>();
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <typeparam name="T">type to append for resolve</typeparam>
        /// <param name="type">implementation of the service</param>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public LocalServiceProvider Add<T>(Type type)
            where T : class
        {
            return _serviceProvider.Add<T>(type);
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <type name="type">type to append for resolve</typeparam>
        /// <type name="instance">instance of the service</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public Initializer Add(Type type, object instance)
        {
            _serviceProvider.Add(type, instance);
            return this;
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public Initializer Add(Factory factory)
        {
            _serviceProvider.Add(factory.ExposedType, factory);
            return this;
        }

        #endregion IServiceProvider


        public Action<IInjectBuilder<Initializer>> OnInitialization { get; set; }


        #region private

        private void Initialize()
        {

            var loader = new InjectionLoader<Initializer>(Context, this._serviceProvider)
            {
                _parser = _parser,
            }
            .SetInjectRescue(InjectRescue)
            .SetInjectValue(InjectValue)
            .LoadModules(OnInitialization)
            .Execute(this);

        }

        public Initializer SetInjectValue(Func<string, object> value)
        {
            InjectValue = value;
            return this;
        }

        private CommandLineParser _parser;
        private LocalServiceProvider _serviceProvider = new LocalServiceProvider() { AutoAdd = true };

        #endregion private


    }

}
