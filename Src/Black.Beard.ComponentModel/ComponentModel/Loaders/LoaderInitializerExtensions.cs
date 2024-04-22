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
            self.Types.AddRange(InjectionExtensions.CollectTypes<IApplicationBuilderInitializer<T>>(self.Context));
            foreach (var item in self.Types)
                self.ServiceProvider.Add<IApplicationBuilderInitializer<T>>(item);
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


        //private static InitializationLoader<T> CollecteInitializationTypes<T>(this InitializationLoader<T> self)
        //{

        //    var _allBuilders = TypeDiscovery.Instance.GetExposedTypes(self.Context);
        //    var _types = new HashSet<Type>();

        //    foreach (var service in _allBuilders)
        //        if (_types.Add(service.Key))
        //        {
        //            if (typeof(IApplicationBuilderInitializer<T>).IsAssignableFrom(service.Key))
        //            {
        //                Trace.TraceInformation($"'{service}' found for {typeof(InitializationLoader<T>).Name}", TraceLevel.Info.ToString());
        //                self.ServiceProvider.Add<IInjectBuilder<T>>(service.Key);
        //                self.Types.Add(service.Key);
        //            }
        //        }

        //    return self;

        //}


        //private static InitializationLoader<T> LoadAbstractLoaders<T>(this InitializationLoader<T> self, Action<IApplicationBuilderInitializer<T>> initializer)
        //{

        //    foreach (var type in self.Types)
        //    {

        //        IApplicationBuilderInitializer<T> srv = null;

        //        if (self.ServiceProvider != null)
        //            try
        //            {
        //                srv = (IApplicationBuilderInitializer<T>)self.ServiceProvider.GetService(type);
        //            }
        //            catch (Exception ex)
        //            {
        //                Trace.TraceError(ex.Message);
        //                throw;
        //            }

        //        if (srv == null)
        //            if (Activator.CreateInstance(type) is IApplicationBuilderInitializer<T> srv1)
        //                srv = srv1;

        //        if (initializer != null)
        //            initializer(srv);

        //        self.Instances.Add(srv);

        //    }

        //    return self;

        //}



    }


}
