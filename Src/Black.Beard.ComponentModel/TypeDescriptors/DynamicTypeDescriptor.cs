using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bb.TypeDescriptors
{

    /// <summary>
    /// Dynamic type descriptor
    /// </summary>
    public class DynamicTypeDescriptor : CustomTypeDescriptor, INotifyPropertyChanged
    {


        public DynamicTypeDescriptor(ICustomTypeDescriptor parent, object instance, ConfigurationDescriptorSelector configuration)
            : base(parent)
        {
            _comparer = new DynamicPropertyDescriptorComparer();
            this._instance = instance;
            _configurationSelector = configuration;
        }

        /// <summary>
        /// returns the properties for the instance
        /// </summary>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties()
        {

            var initialList = base.GetProperties();

            if (_configurationSelector != null)
                return BuildNewListOfProperty(BuidExistingProperties(initialList));

            return initialList;

        }

        /// <summary>
        /// returns the properties for the instance
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {

            var initialList = base.GetProperties(attributes);

            if (_configurationSelector != null)
                return BuildNewListOfProperty(BuidExistingProperties(initialList));

            return initialList;

        }


        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Dictionary<string, PropertyDescriptor> BuidExistingProperties(PropertyDescriptorCollection initialList)
        {

            _toExcluded = _configurationSelector.ExcludedProperties;

            var customFields = initialList
                .Cast<PropertyDescriptor>()
                .Where(c => !_toExcluded.Contains(c.Name))
                .ToDictionary(c => c.Name);

            foreach (var configuration in _configurationSelector.Get(_instance))
                foreach (var property in configuration.ExistingProperties.Where(c => !_toExcluded.Contains(c.Key)))
                {

                    DynamicExistingPropertyDescriptor dynamicPropertyDescriptor = null;

                    if (customFields.TryGetValue(property.Key, out var propertyDescriptor))
                    {

                        dynamicPropertyDescriptor = propertyDescriptor as DynamicExistingPropertyDescriptor;

                        if (dynamicPropertyDescriptor == null)
                        {
                            var items = ComponentModel.Accessors.PropertyAccessor.GetProperties(configuration.ComponentType);
                            var accessor = items[property.Key];
                            dynamicPropertyDescriptor = new DynamicExistingPropertyDescriptor(propertyDescriptor, accessor);
                            dynamicPropertyDescriptor.AddValueChanged(this, (s, e) => OnPropertyChanged(propertyDescriptor.Name));
                            customFields[property.Key] = dynamicPropertyDescriptor;
                        }

                        dynamicPropertyDescriptor.Apply(property.Value, configuration.Filter);

                    }

                }

            return customFields;

        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private PropertyDescriptorCollection BuildNewListOfProperty(Dictionary<string, PropertyDescriptor> customFields)
        {

            foreach (var configuration in _configurationSelector.Get(_instance))
                foreach (var property in configuration.NewProperties.Where(c => !_toExcluded.Contains(c.Name)))
                {
                    if (!customFields.ContainsKey(property.Name))
                        customFields.Add(property.Name, property);
                    else
                        customFields[property.Name] = property;
                }

            var list = customFields.Values.ToList();
            list.Sort(_comparer);

            var result = new PropertyDescriptorCollection(list.ToArray());

            return result;

        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private ConfigurationDescriptorSelector _configurationSelector;
        private object _instance;
        private IEnumerable<string> _toExcluded;
        /// <summary>
        /// Comparer to use when sorting a list of dynamic property descriptors.
        /// </summary>
        private readonly IComparer<PropertyDescriptor> _comparer;

    }


}
