using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.Expressions;
using System;
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

            if (init == null)
                init = (i) => { };

            if (args == null || args.Length == 0)
                args = Environment.GetCommandLineArgs();

            Initializer initializer = Creator(args);

            init(initializer);
            initializer.Initialize();

            return initializer;

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
        /// Map a class with the command line args and environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        private IInjectBuilder<Initializer> Map(IInjectBuilder<Initializer> instance)
        {

            var propertyCollection = instance.GetType().GetProperties();

            foreach (var property in propertyCollection)
            {

                object value = null;

                if (ResolveVariableName(property, out string variableName)
                    && _parser.TryResolveStringValue(variableName, out string variableValue))
                {
                    try
                    {
                        value = ConverterHelper.ConvertToObject(variableValue, property.PropertyType);
                    }
                    catch (Exception e)
                    {
                        throw new InvalidCastException( $"var '{variableName}' can't be convert in '{property.PropertyType.Name}'." , e);
                    }
                }
                if (value != null)
                    property.SetValue(instance, value);

            }

            return instance;

        }

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
                .LoadModules(c =>
                {

                    Map(c);

                    if (OnInitialization != null)
                        OnInitialization(c);

                })
                .Execute(this);

        }

        private bool ResolveMappingValue(PropertyInfo property, Type type, out object value)
        {

            value = null;

            var attribute2 = property.GetCustomAttributes()
                .Where(c => c.GetType() == type)
                .FirstOrDefault();

            if (attribute2 != null)
                value = ConverterHelper.ConvertToObject(GetService(property.PropertyType), property.PropertyType);

            return true;

        }

        private bool ResolveVariableName(System.Reflection.PropertyInfo property, out string name)
        {

            name = property.Name;

            var attribute = property.GetCustomAttribute<EnvironmentMapAttribute>();
            if (attribute != null)
            {

                if (!attribute.Map)
                    return false;

                if (!string.IsNullOrEmpty(attribute.VariableName))
                    name = attribute.VariableName;

            }

            return true;

        }

        private CommandLineParser _parser;
        private LocalServiceProvider _serviceProvider = new LocalServiceProvider() { AutoAdd = true };

        #endregion private


    }

}
