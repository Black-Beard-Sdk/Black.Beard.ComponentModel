using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{

    public static class TypeDescriptorExtension
    {

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <returns><see cref="IEnumerable<T>"/>List of attrbute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this Type self)
            where T : Attribute
        {

            return TypeDescriptor.GetAttributes(self).OfType<T>();

        }

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <param name="funciton">Type source</param>
        /// <returns><see cref="IEnumerable<T>"/>List of attrbute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this Type self, Func<T, bool> filterFunction)
            where T : Attribute
        {

            return TypeDescriptor.GetAttributes(self)
                .OfType<T>()
                .Where(filterFunction);

        }


        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <param name="funciton">Type source</param>
        /// <returns><see cref="IEnumerable<T>"/>List of attrbute</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IEnumerable<T> GetAttributes<T>(this PropertyInfo self)
            where T : Attribute
        {

            return self.DeclaringType.GetProperties(c => c.Name == self.Name)
                .FirstOrDefault()?.Attributes
                .OfType<T>();

        }

        /// <summary>
        /// Use type descriptor GetAttribute for resolve the list of attribute <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Type of the attributes you must looking for</typeparam>
        /// <param name="self">Type source</param>
        /// <param name="funciton">Type source</param>
        /// <returns><see cref="IEnumerable<T>"/>List of attrbute</returns>
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

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(self.DeclaringType))
                if (funcFilter(property))
                    yield return property;

        }

      
    }



}
