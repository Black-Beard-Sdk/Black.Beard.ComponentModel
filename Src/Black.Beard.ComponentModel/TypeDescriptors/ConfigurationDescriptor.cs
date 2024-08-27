using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.TypeDescriptors
{


    public class ConfigurationDescriptor<T> : ConfigurationDescriptor
    {

        public ConfigurationDescriptor() : base(typeof(T))
        {


        }

        public ConfigurationDescriptor<T> Property(Expression<Func<T, object>> name, Action<ConfigurationPropertyDescriptor> initializer = null)
        {
            var n = Bb.Expressions.ExpressionMemberVisitor.GetPropertyName(name);
            Property(n, initializer);
            return this;
        }

    }


    /// <summary>
    /// Configuration descriptor
    /// </summary>
    public class ConfigurationDescriptor
    {

        /// <summary>
        /// initializes a new instance of the <see cref="ConfigurationDescriptor"/> class.
        /// </summary>
        public ConfigurationDescriptor(Type componentType)
        {
            ComponentType = componentType;
            this._customs = new List<PropertyDescriptor>();
            this._excludedProperties = new HashSet<string>();
            this._existings = new List<ConfigurationPropertyDescriptor>();
        }

        /// <summary>
        /// Add a property to the configuration descriptor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public ConfigurationDescriptor Property(string name, Action<ConfigurationPropertyDescriptor> initializer = null)
        {

            var property = new ConfigurationPropertyDescriptor()
            {
                Name = name,
                ComponentType = ComponentType,
                AddedProperty = false
            };

            initializer?.Invoke(property);

            AddProperties(property);

            return this;
        }

        /// <summary>
        /// Add a property to the configuration descriptor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="initializer"></param>
        /// <returns></returns>
        public ConfigurationDescriptor AddProperty(string name, Type type, Action<ConfigurationPropertyDescriptor> initializer = null)
        {

            var property = new ConfigurationPropertyDescriptor()
            {
                Name = name,
                Type = type,
                ComponentType = ComponentType,
                AddedProperty = true,
            };

            initializer?.Invoke(property);

            AddProperties(property);

            return this;
        }

        /// <summary>
        /// add properties to the configuration descriptor
        /// </summary>
        /// <param name="customs"></param>
        /// <returns></returns>
        public ConfigurationDescriptor AddProperties(params ConfigurationPropertyDescriptor[] customs)
        {

            foreach (var item in customs)
                if (_excludedProperties.Contains(item.Name))
                    _excludedProperties.Remove(item.Name);

            foreach (var property in customs)
            {
                if (property.AddedProperty)
                    this._customs.Add(new DynamicPropertyDescriptor(property)
                    {
                        _filter = Filter
                    });
                else
                {
                    var e = this._existings.FirstOrDefault(c => c.Name == property.Name);
                    if (e != null)
                        e.Merge(property);

                    else
                        this._existings.Add(property);
                }
            }

            return this;
        }

        /// <summary>
        /// remove properties from the configuration descriptor and mark the property as excluded
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public ConfigurationDescriptor RemoveProperties(params string[] names)
        {

            foreach (var item in names)
            {
                _excludedProperties.Add(item);
                this._customs.Where(c => c.Name == item).ToList().ForEach(c => this._customs.Remove(c));
            }

            return this;

        }


        public IEnumerable<string> ExcludedProperties => _excludedProperties;


        public PropertyDescriptor[] NewProperties => _customsArray ??= _customs.ToArray();

        public IDictionary<string, ConfigurationPropertyDescriptor> ExistingProperties => _customsArray2 ??= _existings.ToDictionary(c => c.Name);

        public Type ComponentType { get; }

        public Func<object, bool> Filter { get; internal set; }


        public ConfigurationDescriptor Clone()
        {

            var result = new ConfigurationDescriptor(ComponentType)
            {
                Filter = Filter,
            };

            foreach (var item in _existings)
                result.AddProperties(item);

            foreach (DynamicPropertyDescriptor item in _customs)
                result.AddProperties(item._configuration.Clone());

            return result;
        }


        private readonly List<PropertyDescriptor> _customs;
        private readonly List<ConfigurationPropertyDescriptor> _existings;
        private readonly HashSet<string> _excludedProperties;
        private PropertyDescriptor[] _customsArray;
        private IDictionary<string, ConfigurationPropertyDescriptor> _customsArray2;

    }

}
