using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Bb.ComponentModel;

namespace Bb.ComponentModel.Loaders
{

    public static class InjectionExtensions
    {



        /// <summary>
        /// Adds the specified types to the injection loader.
        /// </summary>
        /// <typeparam name="T">The type of the injection loader.</typeparam>
        /// <param name="self">The injection loader instance. Cannot be null.</param>
        /// <param name="context">The context used to explore the assemblies. Cannot be null.</param>
        /// <returns>The updated injection loader instance of type <see cref="InjectionLoader{T}"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="self"/> or <paramref name="context"/> is null.</exception>
        /// <remarks>
        /// This method collects all types that implement the specified interface from the given context and adds them to the injection loader.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loader = new InjectionLoader&lt;MyType&gt;("myContext");
        /// loader.AddTypes("myContext");
        /// </code>
        /// </example>
        public static InjectionLoader<T> AddTypes<T>(this InjectionLoader<T> self, string context)
        {
            List<Type> list = CollectTypes<IInjectBuilder<T>>(context);
            self.Types.AddRange(list);
            return self;
        }


        /// <summary>
        /// Collects types that implement the specified interface from the given context.
        /// </summary>
        /// <typeparam name="T">The interface type to collect.</typeparam>
        /// <param name="context">The context used to explore the assemblies. Cannot be null.</param>
        /// <returns>A list of types that implement the specified interface <see cref="Type"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="context"/> is null.</exception>
        /// <remarks>
        /// This method collects all types that implement the specified interface from the given context.
        /// It uses the TypeDiscovery instance to get exposed types and filters them based on the interface type.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var types = InjectionExtensions.CollectTypes&gt;IInjectBuilder&gt;MyContext>>("myContext");
        /// </code>
        /// </example>
        public static List<Type> CollectTypes<T>(string context)
            where T : class
        {

            List<Type> result = new List<Type>();
            var _allBuilders = TypeDiscovery.Instance.GetExposedTypes(context);
            var _types = new HashSet<Type>();

            foreach (var service in _allBuilders)
                if (_types.Add(service.Key))
                {
                    if (typeof(T).IsAssignableFrom(service.Key))
                    {
                        Trace.TraceInformation($"'{service}' found for {typeof(T).FullName}", TraceLevel.Info.ToString());
                        result.Add(service.Key);
                    }
                }

            return result.OrderByPriority().ToList();

        }

        /// <summary>
        /// Loads abstract loaders from the specified types.
        /// </summary>
        /// <typeparam name="T">The type of the loaders to be loaded.</typeparam>
        /// <param name="types">The list of types to be loaded. Cannot be null.</param>
        /// <param name="initializer">The initializer action to be applied to each loaded instance. Can be null.</param>
        /// <param name="serviceProvider">The service provider used to resolve the instances. Cannot be null.</param>
        /// <returns>A list of loaded instances of type <see cref="T"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="types"/> or <paramref name="serviceProvider"/> is null.</exception>
        /// <remarks>
        /// This method iterates over the provided types, resolves each type using the service provider, and applies the initializer action if provided.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var types = new List&lt;Type&gt; { typeof(MyLoader1), typeof(MyLoader2) };
        /// var serviceProvider = new LocalServiceProvider();
        /// var loaders = InjectionExtensions.LoadAbstractLoaders(types, loader => loader.Initialize(), serviceProvider);
        /// </code>
        /// </example>
        public static List<T> LoadAbstractLoaders<T>(List<Type> types, Action<T> initializer, LocalServiceProvider serviceProvider)
        {

            List<T> instances = new List<T>(types.Count);

            foreach (var type in types)
            {

                T srv = default;

                try
                {
                    srv = (T)serviceProvider.GetService(type);
                    Trace.TraceInformation($"'{type}' loaded for {typeof(T).FullName}", TraceLevel.Info.ToString());
                }
                catch (Exception ex)
                {
                    Trace.TraceError(ex.Message);
                    throw;
                }

                if (initializer != null)
                    initializer(srv);

                instances.Add(srv);

            }

            return instances;

        }

    }


}
