using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.TypeDescriptors
{

    /// <summary>
    /// configuration descriptor selector
    /// </summary>
    public class ConfigurationDescriptorSelector
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationDescriptorSelector"/> class.
        /// </summary>
        public ConfigurationDescriptorSelector()
        {
            this._list = new List<ConfigurationDescriptor>();
        }

        /// <summary>
        /// Add a new configuration descriptor
        /// </summary>
        /// <param name="configuration"></param>
        public virtual void Add(ConfigurationDescriptor configuration)
        {
            _list.Add(configuration);
        }

        /// <summary>
        /// Get the configuration descriptor for a specific instance
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public virtual IEnumerable<ConfigurationDescriptor> Get(object instance)
        {
            var items = List.Where(c => c.ComponentType.IsInstanceOfType(instance)).ToList();
            return items;
        }

        internal void Merge(ConfigurationDescriptorSelector value)
        {
            foreach (var item in value.List)
                Add(item);
        }

        public IEnumerable<string> ExcludedProperties
        {
            get
            {
                HashSet<string> result = new HashSet<string>();
                foreach (var item in List)
                    foreach (var p in item.ExcludedProperties)
                        result.Add(p);
                return result;
            }
        }


        public ConfigurationDescriptorSelector Clone()
        {
            var result = new ConfigurationDescriptorSelector();
            foreach (var item in _list)
                result.Add(item.Clone());
            return result;
        }


        /// <summary>
        /// List of configuration descriptors
        /// </summary>
        protected IEnumerable<ConfigurationDescriptor> List => _list;

        private readonly List<ConfigurationDescriptor> _list;

    }
}
