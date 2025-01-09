using System;
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
            self.Types.AddRange(InjectionExtensions.CollectTypes<IInjectBuilder<T>>(self.Context));
            //foreach (var item in self.Types)
            //    self.ServiceProvider.Add<IInjectBuilder<T>>(item);
            self.Instances.AddRange(InjectionExtensions.LoadAbstractLoaders(self.Types, initializer, self.ServiceProvider));
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

        private static MethodInfo _method;


    }


}
