using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Bb.ComponentModel.Loaders
{


    public static class LoaderInitializerExtensions
    {


        /// <summary>
        /// Initialize an instance with class that will be discovered
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/></param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="action">action to execute for every loader</param>
        /// <returns></returns>
        public static T Initialize<T>(this T self, IServiceProvider serviceProvider, string? context = null, Action<IApplicationBuilderInitializer<T>> action = null)
        {

            var loader = new InitializationLoader<T>(context ?? ConstantsCore.Initialization, serviceProvider)
                .LoadModules(action)
                .Execute(self);

            return self;

        }

        /// <summary>
        /// Initialize an instance with class that will be discovered
        /// </summary>
        /// <typeparam name="T">Type of object must by resolved by discovery</typeparam>
        /// <param name="self">instance to initialize</param>
        /// <param name="context">by default the value is "Initialization"</param>
        /// <param name="action">action to execute on every loader</param>
        /// <returns></returns>
        public static T Initialize<T>(this T self, string? context = null, Action<IApplicationBuilderInitializer<T>> action = null)
        {

            var loader = new InitializationLoader<T>(context ?? ConstantsCore.Initialization)
                .LoadModules(action)
                .Execute(self);

            return self;

        }


        /// <summary>
        /// Load assemblies and initialize the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static InitializationLoader<T> LoadModules<T>(this InitializationLoader<T> self, Action<IApplicationBuilderInitializer<T>> initializer = null)
        {
            self.Types.AddRange(InjectionExtensions.CollectTypes<IApplicationBuilderInitializer<T>>(self.Context));
            //foreach (var item in self.Types)
            //    self.ServiceProvider.Add<IApplicationBuilderInitializer<T>>(item);
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
        public static InitializationLoader<T> Execute<T>(this InitializationLoader<T> self, T builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));


            List<IApplicationBuilderInitializer<T>> items = self.Instances.OrderBy(c => c.OrderPriority).ToList();
            List<IApplicationBuilderInitializer<T>> list_to_remove = new List<IApplicationBuilderInitializer<T>>();

            while (items.Count > 0)
            {

                foreach (IApplicationBuilderInitializer<T> item in items)
                    if (item.CanExecute(builder, self))
                    {
                        var name = item.FriendlyName ?? item.GetType().FullName;
                        Trace.WriteLine($"builder '{name}' initialize", TraceLevel.Info.ToString());
                        item.Execute(builder);
                        self.Executed.Add(name);
                        list_to_remove.Add(item);
                    }

                foreach (var item in list_to_remove)
                    items.Remove(item);

            }


            return self;
        }



    }


}
