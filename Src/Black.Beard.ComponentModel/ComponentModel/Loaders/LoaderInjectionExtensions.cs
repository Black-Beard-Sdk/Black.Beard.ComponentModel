using Bb.ComponentModel.Attributes;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Bb.ComponentModel.Loaders
{


    public static class LoaderInjectionExtensions
    {


        /// <summary>
        /// create instance and initialize service from service provider
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="context"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public static T GetInitializedService<T>(this IServiceProvider serviceProvider, string context, Action<InjectionLoader<T>> initializer = null)
        {

            var instance = (T)serviceProvider.GetService(typeof(T));
            if (instance != null)
            {
                var loader = new InjectionLoader<T>(context, serviceProvider)
                    .LoadModules()
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
                    Trace.WriteLine($"builder '{name}' initialize", TraceLevel.Info.ToString());
                    item.Execute(builder);
                    self.Executed.Add(name);
                }

            return self;

        }


    }


}
