using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace Bb.ComponentModel.Factories
{

    /// <summary>
    /// Object mapper extension
    /// </summary>
    public static class ObjectMapperExtension
    {

        /// <summary>
        /// Resolve the properties to map. If your property is not in the list, you must add an attribute <see cref="T:InjectAttribute"/>
        /// </summary>
        /// <param name="source">Item to evaluate</param>
        /// <returns>List of property with <see cref="T:InjectAttribute"/></returns>
        public static IEnumerable<PropertyDescriptor> GetPropertiesToMap(this object source)
        {

            var type = source.GetType();

            var properties = TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor property in properties)
                if (ObjectCreatorByIoc.EvaluateToAdd(property, out Type typeToInject))
                    yield return property;

        }

        /// <summary>
        /// Map the method with attribute
        /// </summary>
        /// <typeparam name="T">Type of the source to map</typeparam>
        /// <param name="source">source to map</param>
        /// <param name="serviceProvider">Provider of service</param>
        /// <param name="lastChanceFunction">if the provider has not the Type, you can help to resolve</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static T MapInjectProperties<T>(this T source, IServiceProvider serviceProvider, Func<T, PropertyDescriptor, object> lastChanceFunction = null)
        {

            if (source == null)
                throw new ArgumentNullException("source");

            if (serviceProvider == null)
                throw new ArgumentNullException("serviceProvider");

            foreach (PropertyDescriptor property in GetPropertiesToMap(source))
                MapProperty(source, serviceProvider, property, lastChanceFunction);

            return source;

        }

        /// <summary>
        /// Map the property
        /// </summary>
        /// <typeparam name="T">Type of the source to map</typeparam>
        /// <param name="source">source to map</param>
        /// <param name="serviceProvider">Provider of service</param>
        /// <param name="lastChanceFunction">if the provider has not the Type, you can help to resolve</param>
        /// <returns></returns>
        public static void MapProperty<T>(T source, IServiceProvider serviceProvider, PropertyDescriptor property, Func<T, PropertyDescriptor, object> lastChanceFunction = null)
        {

            var propertyValue = property.GetValue(source);
            if (propertyValue == null)
            {
                
                bool failed = false;
                try
                {
                    propertyValue = serviceProvider.GetService(property.PropertyType);
                }
                catch (Exception)
                {
                    failed = true;
                }


                if (failed && lastChanceFunction != null)
                {
                    propertyValue = lastChanceFunction(source, property);
                }


                if (propertyValue != null)
                    property.SetValue(source, propertyValue);

            }
        }
    
    }

}