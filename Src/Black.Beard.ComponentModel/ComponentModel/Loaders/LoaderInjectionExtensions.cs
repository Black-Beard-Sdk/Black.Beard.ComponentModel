using Bb.ComponentModel.Exceptions;
using Bb.Expressions;
using ICSharpCode.Decompiler.Disassembler;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Initialize an instance with class that will be discovered
    /// </summary>
    // <example>
    /// 
    /// Create a class that will be discovered
    /// <code lang="Csharp">
    /// [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder<MyClass>), LifeCycle = IocScopeEnum.Transiant)]
    /// public class TestInitializer : IInjectBuilder<MyClass>
    /// {
    /// 
    ///     public string FriendlyName => typeof(TestInitializer).Name;
    /// 
    ///     public Type Type => typeof(MyClass);
    /// 
    ///     public bool CanExecute(MyClass context) => context.CanExecuteModule(FriendlyName);
    /// 
    ///     public bool CanExecute(object context) => CanExecute((MyClass)context);
    /// 
    ///     public object Execute(object context) => Execute((MyClass)context);
    /// 
    ///     public object Execute(MyClass context)
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
    ///     new TestInitializer().Initialize();
    ///     ((IServiceProvider)provider).GetInitializedService(typeof(TestInitializer)).Initialize();
    /// 
    /// </example>
    public static class LoaderInjectionExtensions
    {

        static LoaderInjectionExtensions()
        {
            _method = typeof(LoaderInjectionExtensions).GetMethods()
                   .Where(c => c.Name == nameof(LoaderInjectionExtensions.Initialize))
                   .First(c => c.IsGenericMethod);
        }


        /// <summary>
        /// Initialize the specified instance with classes that will be discovered
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="action">action to execute for every loader</param>
        /// <returns></returns>
        public static T Initialize<T>(this T self, IServiceProvider serviceProvider = null, string? context = null, Action<IInjectBuilder<T>> action = null)
        {

            var loader = new InjectionLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider)
                .LoadModules(action)
                .Execute(self);

            return self;

        }


        /// <summary>
        /// create instance and initialize service from service provider
        /// </summary>
        /// <typeparam name="T">type of the service asked</typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="context"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static T GetInitializedService<T>(this IServiceProvider serviceProvider, string context, Action<IInjectBuilder<T>> initializer = null)
        {

            var instance = (T)serviceProvider.GetService(typeof(T));

            if (instance != null)
                instance.Initialize(serviceProvider, context, initializer);

            return instance;

        }

        /// <summary>
        /// create instance and initialize service from service provider
        /// </summary>
        /// <typeparam name="T">type of the service asked</typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="context"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static object GetInitializedService(this IServiceProvider serviceProvider, Type type, string context, Action<IInjectBuilder> initializer = null)
        {

            var instance = serviceProvider.GetService(type);

            if (instance != null)
            {
                var method = _method.MakeGenericMethod(type);
                method.Invoke(instance, new object[] { serviceProvider, context, initializer });
            }

            return instance;

        }


        /// <summary>
        /// Load assemblies and initialize the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static InjectionLoader<T> LoadModules<T>(this InjectionLoader<T> self, Action<IInjectBuilder<T>> initializer)
        {

            self._parser ??= new CommandLineParser();
            self.Types.AddRange(InjectionExtensions.CollectTypes<IInjectBuilder<T>>(self.Context));

            Action<IInjectBuilder<T>> initializerAction = c =>
            {
                c.Map(self.InjectValue, self.InjectRescue, self._parser);
                initializer?.Invoke(c);
            };

            self.Instances.AddRange(InjectionExtensions.LoadAbstractLoaders(self.Types, initializerAction, self.ServiceProvider));
            return self;
        }

        /// <summary>
        /// Initialize the builder with all application builder found
        /// </summary>
        /// <typeparam name="T">Builder type</typeparam>
        /// <param name="self">repository of builder initializer</param>
        /// <param name="builder">builder to initialize</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static InjectionLoader<T> Execute<T>(this InjectionLoader<T> self, T builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            foreach (IInjectBuilder<T> item in self.Instances)
                if (item.CanExecute(builder))
                {
                    var name = item.FriendlyName ?? item.GetType().FullName;
                    item.Execute(builder);
                    Trace.WriteLine($"add-on '{name}' initialized", TraceLevel.Info.ToString());
                    self.Executed.Add(name);
                }

            return self;

        }


        private static bool ResolveVariableName(PropertyDescriptor property, out string name, out bool required)
        {

            required = false;
            name = property.Name;

            var attribute = property.Attributes.OfType<InjectValueAttribute>().FirstOrDefault();
            if (attribute != null)
            {

                if (!string.IsNullOrEmpty(attribute.VariableName))
                {
                    name = attribute.VariableName;
                    required = attribute.Required;
                }
            }

            return true;

        }

        /// <summary>
        /// Map a class with the command line args and environment variables
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static IInjectBuilder<T> Map<T>(this IInjectBuilder<T> instance, Func<string, object> injectValue, Func<PropertyDescriptor, string, IInjectBuilder<T>, object> injectRescue, CommandLineParser parser)
        {

            var propertyCollection = TypeDescriptor.GetProperties(instance);

            foreach (PropertyDescriptor property in propertyCollection)
            {

                object value = property.GetValue(instance);

                if (MustSet(value, property))
                {

                    bool resolved = false;
                    bool required = false;
                    string variableName = property.Name;
                    if (ResolveVariableName(property, out string n, out bool r))
                    {
                        variableName = n;
                        required = r;
                        if (injectValue != null)
                        {
                            value = injectValue(variableName);
                            if (!MustSet(value, property))
                                resolved = true;
                        }
                    }

                    if (!resolved)
                    {

                        if (parser.TryResolveStringValue(variableName, out string v2))
                        {
                            value = v2;
                            resolved = true;
                        }
                        else if (injectRescue != null && TryToResolve(injectRescue, property, variableName, instance, out value))
                            resolved = true;

                    }

                    if (value != null && property.PropertyType != value.GetType())
                        try
                        {
                            value = ConverterHelper.ConvertToObject(value, property.PropertyType);
                        }
                        catch (Exception e)
                        {
                            throw new InvalidCastException($"var '{variableName}' can't be convert to '{property.PropertyType.Name}'.", e);
                        }

                    if (value != default)
                        property.SetValue(instance, value);

                    else if (required && !resolved)
                    {
                        throw new UndefinedException(nameof(variableName));
                    }

                }

            }
            return instance;

        }

        private static bool MustSet(object value, PropertyDescriptor property)
        {

            if (value == null)
                return true;

            if (value is string s && string.IsNullOrEmpty(s))
                return true;

            if (value is bool b && !b)
                return true;

            if (value is short i && i == 0)
                return true;

            if (value is int j && j == 0)
                return true;

            if (value is long k && k == 0)
                return true;

            if (value is ushort i2 && i2 == 0)
                return true;

            if (value is ulong j2 && j2 == 0)
                return true;

            if (value is ulong k2 && k2 == 0)
                return true;

            return value == default;

        }

        private static bool TryToResolve<T>(Func<PropertyDescriptor, string, IInjectBuilder<T>, object> injectRescue, PropertyDescriptor property, string variableName, IInjectBuilder<T> instance, out object value)
        {
            value = injectRescue(property, variableName, instance);
            return value != null;
        }

        private static MethodInfo _method;

    }

}