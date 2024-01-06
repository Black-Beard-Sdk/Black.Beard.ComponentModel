using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace Bb.ComponentModel
{

    public static class TypeDiscoveryExtension
    {


        /// <summary>
        /// return a list of type that assignable from the specified type
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithAttributes(this IEnumerable<Type> self, Type baseType, Type typeFilter)
        {

            if (baseType == null)
                baseType = typeof(object);

            if (typeFilter == null)
                typeFilter = typeof(Attribute);

            return self.Where(type =>
            {
                return baseType.IsAssignableFrom(type)
                        && TypeDescriptor.GetAttributes(type).ToList().Any(c => c.GetType() == typeFilter);
                        
            });

        }

        /// <summary>
        /// return a list of type that contains specified attribute
        /// </summary>
        /// <param name="attributeTypeFilter"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithAttributes(this IEnumerable<Type> self, Type attributeTypeFilter)
        {

            if (attributeTypeFilter == null)
                attributeTypeFilter = typeof(Attribute);

            return self.Where(type =>
            {
                return TypeDescriptor.GetAttributes(type).ToList().Any(c => c.GetType() == attributeTypeFilter);
            });

        }


        /// <summary>
        /// return a list of type that contains specified attribute and the filter must be valid
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filterOnAttribute">filter to apply on the attributes</param>
        /// <returns></returns>
        public static IEnumerable<Type> GetTypesWithAttributes<T>(this IEnumerable<Type> self, Type typebase, Func<T, bool> filterOnAttribute) where T : Attribute
        {

            return self.Where(type =>
            {

                if (typebase == null || typebase.IsAssignableFrom(type))
                {

                    var attributes = TypeDescriptor.GetAttributes(type).OfType<T>().ToArray();

                    if (attributes.Length == 0)
                        return false;

                    foreach (T attribute in attributes)
                        if (filterOnAttribute(attribute))
                            return true;

                }

                return false;

            });

        }

        public static IEnumerable<Attribute> ToList(this AttributeCollection attributes)
        {
            foreach (Attribute attribute in attributes)
                yield return attribute;
        }

    }

}



