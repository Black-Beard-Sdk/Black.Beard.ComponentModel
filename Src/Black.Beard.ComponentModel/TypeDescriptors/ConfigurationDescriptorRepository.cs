using System;
using System.Collections.Generic;

namespace Bb.TypeDescriptors
{

    /// <summary>
    /// Configuration descriptor repository.
    /// </summary>
    public class ConfigurationDescriptorRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDescriptorRepository"/> class.
        /// </summary>
        /// <example>
        /// <code lang="csharp">
        /// var conf = new ConfigurationDescriptorProvider()
        ///     .Add<Title>(c =>
        ///     {
        ///         c.AddProperty("Director", typeof(string))
        ///          .AddProperty("Year", typeof(int), i =>
        ///          {
        ///             i.IsBrowsable(true)
        ///              .CanResetValue(true);
        ///          });
        ///     });</code>
        /// </example>
        public ConfigurationDescriptorRepository()
        {
            _configurations = new Dictionary<Type, ConfigurationDescriptorSelector>();
        }

        /// <summary>
        /// Add a configuration for a specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configure"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ConfigurationDescriptorRepository Add<T>(Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)            
        {

            Func<object, bool> filterTarget = null;
            if (filter != null)
                filterTarget = o => filter((T)o);

            var configuration = new ConfigurationDescriptor<T>() { Filter = filterTarget };
            configure(configuration);

            this.Add(configuration);

            var method = typeof(DynamicTypeDescriptionProvider<>).MakeGenericType(typeof(T)).GetMethod("Initialize");
            method.Invoke(null, new object[] { });

            return this;

        }

        /// <summary>
        /// Add a configuration for a specific type.
        /// </summary>
        /// <param name="componentType"></param>
        /// <param name="configure"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public ConfigurationDescriptorRepository Add(Type componentType, Action<ConfigurationDescriptor> configure, Func<object, bool> filter = null)
        {

            var configuration = new ConfigurationDescriptor(componentType) { Filter = filter };
            configure(configuration);
            this.Add(configuration);

            var method = typeof(DynamicTypeDescriptionProvider<>).MakeGenericType(componentType).GetMethod("Initialize");
            method.Invoke(null, new object[] { });

            return this;
        }

        /// <summary>
        /// Append the configuration to the list of configurations.
        /// </summary>
        /// <param name="configuration"></param>
        public void Add(ConfigurationDescriptor configuration)
        {            
            if (!_configurations.TryGetValue(configuration.ComponentType, out var selector))
                this._configurations.Add(configuration.ComponentType, selector = new ConfigurationDescriptorSelector());
            selector.Add(configuration);
        }

        /// <summary>
        /// Get the configuration for a specific instance.
        /// </summary>
        /// <param name="instance">instance to map</param>
        /// <returns></returns>
        public virtual ConfigurationDescriptorSelector GetTypeDescriptorConfiguration(object instance)
        {
            var selector = GetTypeDescriptorConfiguration(instance.GetType());
            return selector;
        }

        /// <summary>
        /// Get the configuration for a specific type.
        /// </summary>
        /// <param name="objectType">type to resolve</param>
        /// <returns></returns>
        public ConfigurationDescriptorSelector GetTypeDescriptorConfiguration(Type objectType)
        {
            return _configurations.TryGetValue(objectType, out var configuration)
                ? configuration
                : null
                ;
        }

        internal void Merge(ConfigurationDescriptorRepository conf)
        {

            foreach (var item in conf._configurations)
            {
                if (!_configurations.TryGetValue(item.Key, out var selector))
                    this._configurations.Add(item.Key, selector = new ConfigurationDescriptorSelector());
                selector.Merge(item.Value);
            }

        }


        private Dictionary<Type, ConfigurationDescriptorSelector> _configurations;

    }
}
