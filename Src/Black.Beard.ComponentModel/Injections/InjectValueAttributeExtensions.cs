using Bb.ComponentModel.Attributes;
using Bb.Converters;
using Bb.Expressions;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bb.Injections
{


    /// <summary>
    /// Provides extension methods for the <see cref="InjectValueByIocAttribute"/> class.
    /// </summary>
    public static class InjectValueAttributeExtensions
    {

        /// <summary>
        /// Retrieves the <see cref="InjectValueByIocAttribute"/> instances defined on the properties of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to retrieve the attributes from.</typeparam>
        /// <param name="type">The type to retrieve the attributes from.</param>
        /// <returns>An enumerable collection of <see cref="InjectValueByIocAttribute"/> instances.</returns>
        /// <remarks>
        /// This method retrieves the <see cref="InjectValueByIocAttribute"/> instances defined on the properties of the specified type.
        /// </remarks>
        public static IEnumerable<InjectValueByIocAttribute> GetKeys<T>(this Type type)
        {

            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var attr = item.GetCustomAttributes(typeof(InjectValueByIocAttribute), true);
                if (attr.Length > 0)
                    yield return (InjectValueByIocAttribute)attr[0];

            }

        }


        /// <summary>
        /// Injects values into the properties of the specified object using the provided value resolver.
        /// </summary>
        /// <typeparam name="T">The type of the object to inject values into.</typeparam>
        /// <param name="self">The object to inject values into.</param>
        /// <param name="valueResolver">The value resolver function used to resolve the values.</param>
        /// <returns>The object with the injected values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="self"/> or <paramref name="valueResolver"/> is null.</exception>
        /// <remarks>
        /// This method injects values into the properties of the specified object using the provided value resolver.
        /// The value resolver function takes a variable name as input and returns the corresponding value.
        /// If a property has the <see cref="InjectValueByIocAttribute"/> applied and the value resolver returns null,
        /// and the attribute's Required property is true, an <see cref="ArgumentNullException"/> is thrown.
        /// The value returned by the value resolver is converted to the property's type using the current culture.
        /// </remarks>
        public static T InjectValue<T>(this T self, Func<string, string> valueResolver)
        {

            if (self == null)
                throw new ArgumentNullException(nameof(self));

            if (valueResolver == null)
                throw new ArgumentNullException(nameof(valueResolver));

            var type = self.GetType();
            var properties = type.GetProperties();
            foreach (var item in properties)
            {
                var attr = item.GetCustomAttributes(typeof(InjectValueByIocAttribute), true);
                if (attr.Length > 0)
                {

                    var attribute = (InjectValueByIocAttribute)attr[0];
                    var value = valueResolver(attribute.VariableName);
                    if (attribute.Required && value == null)
                        throw new ArgumentNullException(item.Name);

                    var convertedValue = value.ConvertTo(item.PropertyType);
                    item.SetValue(self, convertedValue);

                }
            }

            return self;

        }

    }


}
