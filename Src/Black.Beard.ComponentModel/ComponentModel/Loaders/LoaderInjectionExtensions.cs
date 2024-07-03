using Bb.ComponentModel.Attributes;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Bb.ComponentModel.Loaders
{


    /// <summary>
    /// Initialize an instance with class that will be discovered
    /// </summary>
    public static class LoaderInjectionExtensions
    {


        /// <summary>
        /// Initialize the specified instance with classes that will be discovered
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="action">action to execute for every loader</param>
        /// <returns></returns>
        public static T Initialize<T>(this T self, IServiceProvider serviceProvider, string? context = null, Action<IInjectBuilder<T>> action = null)
        {

            var loader = new InjectionLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider)
                .LoadModules(action)
                .Execute(self);

            return self;

        }

        /// <summary>
        /// create instance and initialize service from service provider
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="context"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static T GetInitializedService<T>(this IServiceProvider serviceProvider, string context, Action<IInjectBuilder<T>> initializer = null)
        {

            var instance = (T)serviceProvider.GetService(typeof(T));
            if (instance != null)
            {
                var loader = new InjectionLoader<T>(context, serviceProvider)
                    .LoadModules(initializer)
                    .Execute(instance)
                    ;

            }

            return instance;

        }


        /// <summary>
        /// Load assemblies and initialize the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static InjectionLoader<T> LoadModules<T>(this InjectionLoader<T> self, Action<IInjectBuilder<T>> initializer = null)
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


    }


}
