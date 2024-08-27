using Bb.Helpers;
using System.ComponentModel;
using System.Text.Json;

namespace Bb.TypeDescriptors
{
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


