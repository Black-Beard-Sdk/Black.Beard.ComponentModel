using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Bb.TypeDescriptors
{


    /// <summary>
    /// Type descriptors extension
    /// </summary>
    public static class TypeDescriptorExtension
    {



        /// <summary>
        /// Return the list of properties that match with the specified names
        /// </summary>
        /// <param name="type">type that contains events</param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IEnumerable<EventDescriptor> GetEventDescriptors(this Type type, params string[] names)
        {
            return type.GetEventDescriptors(c => names.Contains(c.Name));
        }

        /// <summary>
        /// Return the list of properties that match with the specified names
        /// </summary>
        /// <param name="type">type that contains the events</param>
        /// <param name="filter">filter for select event to return</param>
        /// <returns></returns>
        public static IEnumerable<EventDescriptor> GetEventDescriptors(this Type type, Predicate<EventDescriptor> filter)
        {

            var @event = TypeDescriptor.GetEvents(type);
            foreach (EventDescriptor item in @event)
                if (filter == null || filter(item))
                    yield return item;

        }

        /// <summary>
        /// Return the list of properties for specified names
        /// </summary>
        /// <param name="type">/// <param name="type">type that contains properties</param></param>
        /// <param name="names"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyDescriptor> GetPropertyDescriptors(this Type type, params string[] names)
        {
            return type.GetPropertyDescriptors(c => names.Contains(c.Name));
        }

        /// <summary>
        /// Return the list of properties
        /// </summary>
        /// <param name="type">type that contains the properties</param>
        /// <param name="filter">filter for select property to return</param>
        /// <returns></returns>
        public static IEnumerable<PropertyDescriptor> GetPropertyDescriptors(this Type type, Predicate<PropertyDescriptor> filter)
        {

            var properties = TypeDescriptor.GetProperties(type);
            foreach (PropertyDescriptor item in properties)
                if (filter == null || filter(item))
                        yield return item;

        }

        /// <summary>
        /// Return the list of attributes that match with the specified type
        /// </summary>
        /// <typeparam name="T">Attribute to find</typeparam>
        /// <param name="property">property that contains attributes</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributes<T>(this PropertyDescriptor property)
                    where T : Attribute
        {

            foreach (Attribute attribute in property.Attributes)
                if (typeof(T).IsAssignableFrom(attribute.GetType()))
                    yield return (T)attribute;

        }

        /// <summary>
        /// Return the first attribute that match with the specified type
        /// </summary>
        /// <typeparam name="T">Attribute to find</typeparam>
        /// <param name="property">property that contains attribute</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this PropertyDescriptor property)
            where T : Attribute
        {

            foreach (Attribute attribute in property.Attributes)
                if (typeof(T).IsAssignableFrom(attribute.GetType()))
                    return (T)attribute;

            return default;

        }
        
        /// <summary>
        /// Return the list of attributes that match with the specified type
        /// </summary>
        /// <typeparam name="T">attribute to find</typeparam>
        /// <param name="event">event that contains attribute</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributes<T>(this EventDescriptor @event)
                    where T : Attribute
        {

            foreach (Attribute attribute in @event.Attributes)
                if (typeof(T).IsAssignableFrom(attribute.GetType()))
                    yield return (T)attribute;

        }

        /// <summary>
        /// Return the first attribute that match with the specified type
        /// </summary>
        /// <typeparam name="T">attribute to find</typeparam>
        /// <param name="event">event that contains attribute</param>
        /// <returns></returns>
        public static T GetAttribute<T>(this EventDescriptor @event)
            where T : Attribute
        {

            foreach (Attribute attribute in @event.Attributes)
                if (typeof(T).IsAssignableFrom(attribute.GetType()))
                    return (T)attribute;

            return default;

        }


    }


}
