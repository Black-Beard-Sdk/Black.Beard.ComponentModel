using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.TypeDescriptors
{

    public static class ConfigurationPropertyDescriptorExtension
    {


   
        /// <summary>
        /// Set the value CanResetValue of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor CanResetValue(this ConfigurationPropertyDescriptor self, bool value)
        {
            self.CanResetValue = value;
            return self;
        }

        /// <summary>
        /// Set the order in the list of propetyDescriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor PropertyOrder(this ConfigurationPropertyDescriptor self, int value)
        {
            self.PropertyOrder = value;
            return self;
        }


        /// <summary>
        /// Set the value IsReadOnly of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor IsReadOnly(this ConfigurationPropertyDescriptor self, bool value)
        {
            self.IsReadOnly = value;
            return self;
        }

        /// <summary>
        /// Set the value ShouldSerializeValue of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor ShouldSerializeValue(this ConfigurationPropertyDescriptor self, bool value)
        {
            self.ShouldSerializeValue = value;
            return self;
        }

        /// <summary>
        /// Set the value Description of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor Description(this ConfigurationPropertyDescriptor self, string value)
        {
            self.Description = value;
            return self;
        }

        /// <summary>
        /// Set the value Category of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor Category(this ConfigurationPropertyDescriptor self, string value)
        {
            self.Category = value;
            return self;
        }

        /// <summary>
        /// Set the value DisplayName of the configuration property descriptor
        /// </summary>
        /// <param name="self"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor DisplayName(this ConfigurationPropertyDescriptor self, string value)
        {
            self.DisplayName = value;
            return self;
        }

        /// <summary>
        /// Make the property browsable in the property grid
        /// </summary>
        /// <param name="self"></param>
        /// <param name="isBrowsable"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor IsBrowsable(this ConfigurationPropertyDescriptor self, bool isBrowsable)
        {
            self.AddAttributes(new BrowsableAttribute(isBrowsable));
            return self;
        }

        /// <summary>
        /// Set the default value of the property
        /// </summary>
        /// <param name="self"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ConfigurationPropertyDescriptor DefaultValue(this ConfigurationPropertyDescriptor self, object defaultValue)
        {
            self.AddAttributes(new DefaultValueAttribute(defaultValue));
            return self;
        }

        public static ConfigurationPropertyDescriptor DisableValidation(this ConfigurationPropertyDescriptor self)
        {
            self.AddAttributes(new EvaluateValidationAttribute(false));
            return self;
        }

        public static ConfigurationPropertyDescriptor DisableBrowsable(this ConfigurationPropertyDescriptor self)
        {
            self.AddAttributes(new BrowsableAttribute(false));
            return self;
        }

        // ConfigurationPropertyDescriptor

        public static object? GetDefaultValue(this PropertyDescriptor self)
        {
            var value = self.Attributes
                .Cast<Attribute>()
                .OfType<DefaultValueAttribute>()
                .FirstOrDefault();

            if (value != null)
                return value.Value;

            return default;

        }

        public static IEnumerable<PropertyDescriptor> AsEnumerable(this PropertyDescriptorCollection self)
        {
            foreach (PropertyDescriptor item in self)
                yield return item;
        }

        public static IEnumerable<PropertyDescriptor> Where(this PropertyDescriptorCollection self, Predicate<PropertyDescriptor> predicate)
        {
            foreach (PropertyDescriptor item in self)
                if (predicate(item))
                    yield return item;
        }

        public static PropertyDescriptor FirstOrDefault(this PropertyDescriptorCollection self, Predicate<PropertyDescriptor> predicate)
        {
            foreach (PropertyDescriptor item in self)
                if (predicate(item))
                    return item;

            return null;

        }

        public static PropertyDescriptor Get(this PropertyDescriptorCollection self, string propertyName)
        {
            foreach (PropertyDescriptor item in self)
                if (item.Name == propertyName)
                    return item;

            return null;

        }

    }

}
