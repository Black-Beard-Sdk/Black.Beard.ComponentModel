using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Extension for <see cref="TypeDescriptor"/>
    /// </summary>
    public static class TypeDescriptorExtension
    {

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute 
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <returns><see cref="IEnumerable{T}"/>List of attribute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this Type self)
            where T : Attribute
        {

            return TypeDescriptor.GetAttributes(self).OfType<T>();

        }

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <param name="filterFunction">Type source</param>
        /// <returns><see cref="IEnumerable{T}"/>List of attribute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this Type self, Func<T, bool> filterFunction)
            where T : Attribute
        {

            return TypeDescriptor.GetAttributes(self)
                .OfType<T>()
                .Where(filterFunction);

        }


        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <returns><see cref="IEnumerable{T}"/>List of attribute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo self)
            where T : Attribute
        {

            return self.DeclaringType.GetProperties(c => c.Name == self.Name)
                .FirstOrDefault()?.Attributes
                .OfType<T>();

        }

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <param name="filterFunction">Type source</param>
        /// <returns><see cref="IEnumerable{T}"/>List of attribute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo self, Func<T, bool> filterFunction)
            where T : Attribute
        {

            return self.DeclaringType.GetProperties(c => c.Name == self.Name)
                .FirstOrDefault()?.Attributes
                .OfType<T>()
                .Where(filterFunction);

        }


        /// <summary>
        /// Return the list of propertyDescriptors
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyDescriptor> GetProperties(this Type self)
        {

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(self.DeclaringType))
                yield return property;

        }

        /// <summary>
        /// Return the list of propertyDescriptors
        /// </summary>
        /// <param name="self"></param>
        /// <param name="funcFilter"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyDescriptor> GetProperties(this Type self, Func<PropertyDescriptor, bool> funcFilter)
        {
            return from PropertyDescriptor property in TypeDescriptor.GetProperties(self.DeclaringType)
                   where funcFilter(property)
                   select property;
        }

      
    }



}
