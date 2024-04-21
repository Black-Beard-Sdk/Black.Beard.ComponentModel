using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;

namespace Bb.ComponentModel.Loaders
{
    public static class LoaderInjectionExtensions
    {

        /// <summary>
        /// Load assemblies and initialize the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static InjectionLoader<T> LoadModules<T>(this InjectionLoader<T> self, Action<IInjectBuilder<T>> initializer = null)
        {

            self.CollecteInitializationTypes()
                .LoadAbstractLoaders(initializer)
            ;

            return self;

        }



        private static InjectionLoader<T> CollecteInitializationTypes<T>(this InjectionLoader<T> self)
        {

            var _allBuilders = TypeDiscovery.Instance.GetExposedTypes(self.Context);

            foreach (var service in _allBuilders.Where(c => typeof(IInjectBuilder<T>).IsAssignableFrom(c.Key)))
            {
                Trace.WriteLine($"Inject '{service}' found and loaded", TraceLevel.Info.ToString());
                self.ServiceProvider.Add<IInjectBuilder<T>>(service.Key);
            }

            return self;

        }

        private static InjectionLoader<T> LoadAbstractLoaders<T>(this InjectionLoader<T> self, Action<IInjectBuilder<T>> initializer)
        {

            foreach (var type in self.Types)
            {

                IInjectBuilder<T> srv = null;

                try
                {
                    srv = (IInjectBuilder<T>)self.ServiceProvider.GetService(type);
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    throw;
                }                

                if (initializer != null)
                    initializer(srv);

                self.Instances.Add(srv);

            }

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
