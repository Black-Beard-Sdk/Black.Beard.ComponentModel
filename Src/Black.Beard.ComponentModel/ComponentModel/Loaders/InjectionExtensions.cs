using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Bb.ComponentModel.Attributes;
using System.Linq;

namespace Bb.ComponentModel.Loaders
{
    public static class InjectionExtensions
    {

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
