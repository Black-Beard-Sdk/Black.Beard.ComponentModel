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
        /// Load assemblies and initialize the loader
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static InitializationLoader<T> LoadModules<T>(this InitializationLoader<T> self, Action<IApplicationBuilderInitializer<T>> initializer = null)
        {

            if (self.AssembliesToLoad != null)
                self.AssembliesToLoad.Load();

            self.CollecteInitializationTypes()
                .LoadAbstractLoaders(initializer)
            ;

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
        public static InitializationLoader<T> Initialize<T>(this InitializationLoader<T> self, T builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));


            List<IApplicationBuilderInitializer<T>> items = self.InstancesBuilders.OrderBy(c => c.OrderPriority).ToList();
            List<IApplicationBuilderInitializer<T>> list_to_remove = new List<IApplicationBuilderInitializer<T>>();

            while (items.Count > 0)
            {

                foreach (IApplicationBuilderInitializer<T> item in items)
                    if (item.CanInitialize(builder, self))
                    {
                        var name = item.FriendlyName ?? item.GetType().FullName;
                        Trace.WriteLine($"builder '{name}' initialize", TraceLevel.Info.ToString());
                        item.Initialize(builder);
                        self.Initialized.Add(name);
                        list_to_remove.Add(item);
                    }

                foreach (var item in list_to_remove)
                    items.Remove(item);

            }


            return self;
        }


        /// <summary>
        /// Configure the builder with all application builder found
        /// </summary>
        /// <typeparam name="T">Builder type</typeparam>
        /// <param name="self">repository of builder initializer</param>
        /// <param name="builder">builder to initialize</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static InitializationLoader<T> Configure<T>(this InitializationLoader<T> self, T builder)
        {

            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            List<IApplicationBuilderInitializer<T>> items = self.InstancesBuilders.OrderBy(c => c.OrderPriority).ToList();
            List<IApplicationBuilderInitializer<T>> list_to_remove = new List<IApplicationBuilderInitializer<T>>();

            while (items.Count > 0)
            {

                foreach (IApplicationBuilderInitializer<T> item in items)
                    if (item.CanConfigure(builder, self))
                    {
                        var name = item.FriendlyName ?? item.GetType().FullName;
                        Trace.WriteLine($"builder '{name}' initialize", TraceLevel.Info.ToString());
                        item.Configure(builder);
                        self.Configured.Add(name);
                        list_to_remove.Add(item);
                    }

                foreach (var item in list_to_remove)
                    items.Remove(item);

            }

            return self;

        }



        private static InitializationLoader<T> CollecteInitializationTypes<T>(this InitializationLoader<T> self)
        {

            var _allBuilders = TypeDiscovery.Instance.GetExposedTypes(ConstantsCore.Initialization);
            var toRemove = new List<KeyValuePair<Type, HashSet<ExposeClassAttribute>>>();
            var _types = new HashSet<Type>();


            foreach (var service in _allBuilders.Where(c => typeof(IApplicationBuilderInitializer<T>).IsAssignableFrom(c.Key)))
                if (_types.Add(service.Key))
                {
                    Trace.WriteLine($"builder '{service}' found and loaded", TraceLevel.Info.ToString());
                    self.Builders.Add(service.Key);
                    toRemove.Add(service);
                }

            return self;

        }


        private static InitializationLoader<T> LoadAbstractLoaders<T>(this InitializationLoader<T> self, Action<IApplicationBuilderInitializer<T>> initializer)
        {

            foreach (var type in self.Builders)
            {

                if (Activator.CreateInstance(type) is not IApplicationBuilderInitializer<T> srv)
                    throw new InvalidCastException(type.FullName);

                if (initializer != null)
                    initializer(srv);

                self.InstancesBuilders.Add(srv);

            }

            return self;

        }



    }


}
