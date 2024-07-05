using Bb.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bb.TypeDescriptors
{

    [JsonConverter(typeof(DynamicDescriptorInstanceJsonConverter))]
    public class DynamicDescriptorInstanceContainer : IDynamicDescriptorInstance
    {

        public DynamicDescriptorInstanceContainer(object parent)
        {
            this._instance = parent;
            _properties = new Dictionary<string, object>();
        }

        public string GetPropertyToString(string name)
        {

            var value = GetProperty(name);

            if (value == null)
                return null;

            if (value is string s)
                return s;

            return value.Serialize(false);
        }

        public object GetProperty(string name)
        {
            if (_properties.TryGetValue(name, out object value))
                return value;

            var property = DynamicProperties().Where(c => c.Name == name).FirstOrDefault();
            if (property != null)
                return property.GetDefaultValue();

            return null;
        }

        public void SetProperty(string name, object value)
        {

            if (_properties.TryGetValue(name, out object v))
            {
                if (v == value)
                    _properties.Remove(name);
                else
                    _properties[name] = value;
            }
            else
                _properties.Add(name, value);
        }

        public IEnumerable<PropertyDescriptor> Properties()
        {
            var properties = TypeDescriptor.GetProperties(Instance).OfType<PropertyDescriptor>().ToList();
            return properties;
        }

        public IEnumerable<PropertyDescriptor> DynamicProperties()
        {
            var properties = TypeDescriptor.GetProperties(Instance).OfType<DynamicPropertyDescriptor>().ToList();
            return properties;
        }

        public object Instance => _instance;

        private readonly object _instance;
        private readonly Dictionary<string, object> _properties;

    }

    public static class DynamicDescriptorInstanceExtension
    {

        public static void Map(this PropertyDescriptor self, object instance, bool exists, string serializedData)
        {

            var options = new JsonSerializerOptions
            {
                Converters = { new DynamicDescriptorInstanceJsonConverter() },
                // Other options as required
                IncludeFields = true,  // You must set this if MyClass.Id and MyClass.Data are really fields not properties.
                WriteIndented = true
            };

            object value = null;
            if (string.IsNullOrEmpty(serializedData))
            {
                if (!exists)
                    value = self.GetDefaultValue();
            }
            else
                value = serializedData.Deserialize(self.PropertyType, options);

            if (!string.IsNullOrEmpty(serializedData))
                self.SetValue(instance, value);

        }

    }

}


