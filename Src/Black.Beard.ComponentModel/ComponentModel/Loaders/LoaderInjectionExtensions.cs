using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Exceptions;
using Bb.ComponentModel.Factories;
using Bb.Converters;
using Bb.Expressions;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

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
    ///     new TestInitializer().AutoConfigure(serviceProvider, context);
    ///     ((IServiceProvider)provider).GetInitializedService(typeof(TestInitializer)).Initialize();
    /// 
    /// </code>
    /// 
    /// </example>
    public static class LoaderInjectionExtensions
    {

        static LoaderInjectionExtensions()
        {
            //_method = typeof(LoaderInjectionExtensions).GetMethods()
            //       .Where(c => c.Name == nameof(LoaderInjectionExtensions.AutoConfigure))
            //       .First(c => c.IsGenericMethod);
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
        /// <param name="postExecution">to execute after ran</param>
        /// <returns></returns>
        public static T AutoConfigure<T>(
            this T self,
            IServiceProvider serviceProvider = null,
            string? context = null,
            Action<InjectionLoader<T>> initializer = null,
            Action<IInjectBuilder<T>> onInitializationAction = null,
            Action<InjectionLoader<T>> postExecution = null
            )
        {

            var loader = new InjectionLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider)
                .LoadModules(initializer, onInitializationAction)
                .Execute(self);

            if (postExecution != null)
                postExecution(loader);

            return self;

        }

        /// <summary>
        /// Prepare the configuration for the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object to be resolved by discovery.</typeparam>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="context">The context value. By default, it is set to "Initialization".</param>
        /// <param name="initializer">The action to execute for every loader.</param>
        /// <param name="onInitializationAction">The action to initialize for every loader.</param>
        /// <returns>The prepared <see cref="InjectionLoader{T}"/> instance.</returns>
        /// <remarks>
        /// This method prepares the configuration for the specified type.
        /// It initializes the <see cref="InjectionLoader{T}"/> instance with the specified context, service provider, and initializer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// IServiceProvider sp;
        /// var i = new WebApplicationBuilder();
        /// var loader = sp.PrepareConfiguration&lt;WebApplicationBuilder>(ConstantCore.Initialization);
        /// loader.Execute(i);
        /// </code>
        /// </example>
        public static InjectionLoader<T> PrepareAutoConfiguration<T>(
            this IServiceProvider serviceProvider,
            string? context = null,
            Action<InjectionLoader<T>> initializer = null,
            Action<IInjectBuilder<T>> onInitializationAction = null
            )
        {

            var loader = new InjectionLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider)
                .LoadModules(initializer, onInitializationAction);

            return loader;

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
            self.ServiceProvider = new LocalServiceProvider(true, serviceProvider);
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
            self.ServiceProvider = new LocalServiceProvider(true, serviceProvider);
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
        /// Creates an instance and initializes the service from the service provider.
        /// </summary>
        /// <typeparam name="T">The type of the service to be resolved by discovery.</typeparam>
        /// <param name="serviceProvider">The service provider. Must not be null.</param>
        /// <param name="context">The context value. By default, it is set to "Initialization".</param>
        /// <param name="initializer">The action to execute for every loader. Can be null.</param>
        /// <param name="action">The action to initialize for every loader. Can be null.</param>
        /// <returns>The configured service instance of type <see cref="T"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="serviceProvider"/> is null.</exception>
        /// <remarks>
        /// This method creates an instance of the specified service type and initializes it using the provided service provider and context.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// IServiceProvider serviceProvider = new ServiceCollection().BuildServiceProvider();
        /// var configuredService = serviceProvider.GetConfiguredService&lt;MyService>("Initialization", loader => { /* initializer code */ }, builder => { /* action code */ });
        /// </code>
        /// </example>
        public static T GetConfiguredService<T>(this IServiceProvider serviceProvider, string context, Action<InjectionLoader<T>> initializer = null, Action<IInjectBuilder<T>> action = null)
        {

            var instance = (T)serviceProvider.GetService(typeof(T));

            if (instance != null)
                instance.AutoConfigure(serviceProvider, context, initializer, action);

            return instance;

        }

        /// <summary>
        /// Loads modules and initializes the loader with the specified actions.
        /// </summary>
        /// <typeparam name="T">The type of object to be resolved by discovery.</typeparam>
        /// <param name="self">The instance of <see cref="InjectionLoader{T}"/> to initialize. Must not be null.</param>
        /// <param name="initializer">The action to execute for every loader. Must not be null.</param>
        /// <param name="onInitializationAction">The action to initialize for every loader. Must not be null.</param>
        /// <returns>The initialized <see cref="InjectionLoader{T}"/> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="self"/>, <paramref name="initializer"/>, or <paramref name="onInitializationAction"/> is null.</exception>
        /// <remarks>
        /// This method loads modules and initializes the loader with the specified actions.
        /// It collects types that implement <see cref="IInjectBuilder{T}"/> and adds instances of these types to the loader.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loader = new InjectionLoader&lt;MyClass>(context, serviceProvider);
        /// loader.LoadModules(
        ///     initializer: l => { /* initializer code */ },
        ///     onInitializationAction: b => { /* initialization action code */ }
        /// );
        /// </code>
        /// </example>
        public static InjectionLoader<T> LoadModules<T>(this InjectionLoader<T> self, Action<InjectionLoader<T>> initializer, Action<IInjectBuilder<T>> onInitializationAction)
        {

            self._parser ??= new CommandLineParser();
            self.Types.AddRange(InjectionExtensions.CollectTypes<IInjectBuilder<T>>(self.Context));

            if (initializer != null)
                initializer(self);

            Action<IInjectBuilder<T>> initializerAction = c =>
            {
                c.Map(self.InjectValue, self.InjectRescue, self._parser);
                onInitializationAction?.Invoke(c);
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
            {

                var name = item.FriendlyName ?? item.GetType().FullName;
                var msg = $"add-on '{self.Context}'.'{name}' is";
                if (self.CanExecuteModule(item))
                {
                    if (item.CanExecute(builder))
                    {
                        try
                        {
                            item.Execute(builder);
                            Trace.WriteLine($"{msg} initialized");
                            self.Executed.Add(name);
                        }
                        catch (Exception e)
                        {
                            Trace.TraceError($"{msg} failed." + e.Message);
                        }
                    }
                    else
                        Trace.WriteLine($"{msg} bypassed");

                }
                else
                    Trace.WriteLine($"{msg} refused to run");

            }

            return self;

        }


        private static bool ResolveVariableName(PropertyDescriptor property, out string name, out bool required)
        {

            required = false;
            name = property.Name;

            var attribute = property.Attributes.OfType<InjectValueByIocAttribute>().FirstOrDefault();
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
                            value = ConverterHelper.ConvertTo(value, property.PropertyType);
                        }
                        catch (Exception e)
                        {
                            throw new InvalidCastException($"{typeof(T).FullName}.{property.Name} required variable '{variableName}' that can't be converted to '{property.PropertyType.Name}'.", e);
                        }

                    if (value != default)
                        property.SetValue(instance, value);

                    else if (required && !resolved)
                        throw new UndefinedException($"{typeof(T).FullName}.{property.Name} required variable '{variableName}'");

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

        // private static MethodInfo _method;

    }

}