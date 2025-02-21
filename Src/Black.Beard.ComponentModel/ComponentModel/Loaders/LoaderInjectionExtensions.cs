using Bb.ComponentModel.Exceptions;
using Bb.ComponentModel.Factories;
using Bb.Expressions;
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
    /// <example>
    /// 
    /// Create a class that will be discovered
    /// <code lang="Csharp">
    /// [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder&lt;MyClass>), LifeCycle = IocScopeEnum.Transiant)]
    /// public class TestInitializer : IInjectBuilder&lt;MyClass>
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
    /// 
    ///     var context = ConstantsCore.Initialization;
    ///     new TestInitializer().Configure(serviceProvider, context);
    ///     ((IServiceProvider)provider).GetInitializedService(typeof(TestInitializer)).Initialize();
    /// 
    /// </code>
    /// 
    /// </example>
    public static class LoaderInjectionExtensions
    {

        static LoaderInjectionExtensions()
        {
            _method = typeof(LoaderInjectionExtensions).GetMethods()
                   .Where(c => c.Name == nameof(LoaderInjectionExtensions.Configure))
                   .First(c => c.IsGenericMethod);
        }


        /// <summary>
        /// Initialize the specified instance with classes that will be discovered
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="initializer">action to execute for every loader</param>
        /// <param name="onInitializationAction">action to initialize for every loader</param>
        /// <returns></returns>
        public static T Configure<T>(this T self, IServiceProvider serviceProvider = null, string? context = null, Action<InjectionLoader<T>> initializer = null, Action<IInjectBuilder<T>> onInitializationAction = null)
        {

            var loader = new InjectionLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider, initializer)
                .LoadModules(onInitializationAction)
                .Execute(self);

            return self;

        }


        /// <summary>
        /// Sets the inject value rescue function.
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="injectRescue">The inject rescue function.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the function that will be called when the system cannot resolve the value to inject.
        /// The function takes a <see cref="PropertyDescriptor"/> representing the property being injected,
        /// a string representing the context, and an <see cref="IInjectBuilder{T}"/> instance.
        /// It should return the value to be injected.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="injectRescue"/> is null.</exception>
        public static InjectionLoader<T> WithInjectRescue<T>(this InjectionLoader<T> self, Func<PropertyDescriptor, string, IInjectBuilder<T>, object> injectRescue)
        {
            self.InjectRescue = injectRescue;
            return self;
        }


        //public static InjectionLoader<T> WithExcludeAbstractTypes<T>(this InjectionLoader<T> self, bool value)
        //{
        //    self.ExcludeAbstractTypes = value;
        //    return self;
        //}

        //public static InjectionLoader<T> WithExcludeGenericTypes<T>(this InjectionLoader<T> self, bool value)
        //{
        //    self.ExcludeGenericTypes = value;
        //    return self;
        //}


        /// <summary>
        /// Sets the services for the injection loader.
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the <paramref name="serviceProvider"/> for the injection loader.
        /// </remarks>
        public static InjectionLoader<T> WithServices<T>(this InjectionLoader<T> self, IServiceProvider serviceProvider)
        {
            self.ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };
            return self;
        }

        /// <summary>
        /// Sets the services for the injection loader.
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="initializer">service initializer</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the <paramref name="serviceProvider"/> for the injection loader.
        /// </remarks>
        public static InjectionLoader<T> WithServices<T>(this InjectionLoader<T> self, IServiceProvider serviceProvider, Action<LocalServiceProvider> initializer)
        {
            self.ServiceProvider = new LocalServiceProvider(serviceProvider) { AutoAdd = true };
            initializer?.Invoke(self.ServiceProvider);
            return self;
        }

        /// <summary>
        /// Apply argument on the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static InjectionLoader<T> WithArguments<T>(this InjectionLoader<T> self, string[] args)
        {
            self._parser = new CommandLineParser(args);
            return self;
        }


        /// <summary>
        /// Sets the inject value function.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self">loader to configure</param>
        /// <param name="injectValue">The inject value function.</param>
        /// <returns>The current instance of <see cref="InjectionLoader{T}"/>.</returns>
        /// <remarks>
        /// This method sets the function that will be called to retrieve the value to be injected.
        /// The function takes a <see cref="string"/> representing the inject value and should return the value to be injected.
        /// </remarks>
        public static InjectionLoader<T> WithInjectValue<T>(this InjectionLoader<T> self, Func<string, object> injectValue)
        {
            self.InjectValue = injectValue;
            return self;
        }

        /// <summary>
        /// create instance and initialize service from service provider
        /// </summary>
        /// <typeparam name="T">type of the service asked</typeparam>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="initializer">action to execute for every loader</param>
        /// <param name="action">action to initialize for every loader</param>
        /// <returns></returns>
        public static T GetConfiguredService<T>(this IServiceProvider serviceProvider, string context, Action<InjectionLoader<T>> initializer = null, Action<IInjectBuilder<T>> action = null)
        {

            var instance = (T)serviceProvider.GetService(typeof(T));

            if (instance != null)
                instance.Configure(serviceProvider, context, initializer, action);

            return instance;

        }

        ///// <summary>
        ///// create instance and initialize service from service provider
        ///// </summary>
        ///// <typeparam name="T">type of the service asked</typeparam>
        ///// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        ///// <param name="context">by default the value is "Initialization"</param>
        ///// <param name="initializer">action to execute for every loader</param>
        ///// <param name="action">action to initialize for every loader</param>
        //public static object GetConfiguredService(this IServiceProvider serviceProvider, Type type, string context, Action<InjectionLoader> initializer = null, Action<IInjectBuilder> action = null)
        //{

        //    var instance = serviceProvider.GetService(type);

        //    if (instance != null)
        //    {
        //        var method = _method.MakeGenericMethod(type);
        //        method.Invoke(instance, new object[] { serviceProvider, context, initializer, action });
        //    }

        //    return instance;

        //}


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

            self.AddInstances(InjectionExtensions.LoadAbstractLoaders(self.Types, initializerAction, self.ServiceProvider));
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