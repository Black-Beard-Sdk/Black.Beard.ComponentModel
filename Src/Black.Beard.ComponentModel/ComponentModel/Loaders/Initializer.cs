using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
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
    /// Run the initializer
    /// <code lang="Csharp">
    /// </code>
    ///     
    ///     Initializer.Initialize(args);
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
        /// <param name="args"></param>
        public static Initializer Initialize(params string[] args)
        {

            Initializer initializer;

            if (args != null && args.Length > 0)
                initializer = Creator(args);
            else
                initializer = Creator(Environment.GetCommandLineArgs());

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
            _args = Parse(args);
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
            if (ResolveValue(friendlyName, out string variableValue))
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
        public T Map<T>(T instance)
        {

            var collection = instance.GetType().GetProperties();

            foreach (var item in collection)
                if (ResolveVariableName(item, out string variableName))
                    if (ResolveValue(variableName, out string variableValue))
                    {
                        var value = Convert.ChangeType(variableValue, item.PropertyType);
                        item.SetValue(instance, value);
                    }

            return instance;

        }

        /// <summary>
        /// Resolve a value from the command line args and environment variables
        /// </summary>
        /// <param name="name"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool ResolveValue(string name, out string result)
        {

            if (_args.TryGetValue(name, out result))
                return true;

            result = Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
            var r = !string.IsNullOrEmpty(result);
            var r2 = r ? "Successed" : "Failed";
            Console.WriteLine($"Resolving {name} from configuration : {r2}");
            return r;
        }

        /// <summary>
        /// return the last initializer instance
        /// </summary>
        public static Initializer Last { get; private set; }


        #region IServiceProvider

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns>return the service</returns>
        public object? GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <typeparam name="T">type to append</param>
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
        /// <type name="type">implementation of the service</typeparam>
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
        /// <type name="factory">factory to append</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>

        public Initializer Add(Factory factory)
        {
            _serviceProvider.Add(factory.ExposedType, factory);
            return this;
        }

        #endregion IServiceProvider


        #region private

        private void Initialize()
        {

            var loader = new InjectionLoader<Initializer>(Context, new LocalServiceProvider())
                .LoadModules()
                .Execute(this);

        }

        private static bool ResolveVariableName(System.Reflection.PropertyInfo property, out string name)
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

        private static Dictionary<string, string> Parse(params string[] parts)
        {
            var variables = new Dictionary<string, string>();
            for (int i = 0; i < parts.Length; i++)
            {
                string key = null;
                string value = null;

                // Format --key=value
                if (parts[i].StartsWith("--"))
                {
                    var keyValue = parts[i].Substring(2).Split(new[] { '=' }, 2);
                    if (keyValue.Length == 2)
                    {
                        key = keyValue[0];
                        value = keyValue[1];
                    }
                }
                // Format -key value
                else if (parts[i].StartsWith("-") && i + 1 < parts.Length && !parts[i + 1].StartsWith("-"))
                {
                    key = parts[i].Substring(1);
                    value = parts[++i]; // Increment i pour by passed the value already read.
                }

                if (key != null && value != null && !variables.ContainsKey(key))
                    variables.Add(key, value);

            }

            return variables;
        }

        private readonly Dictionary<string, string> _args;


        private LocalServiceProvider _serviceProvider = new LocalServiceProvider();

        #endregion private


    }

}
