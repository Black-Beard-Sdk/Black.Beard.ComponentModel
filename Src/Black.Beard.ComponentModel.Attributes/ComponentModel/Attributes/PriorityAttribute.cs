using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.ComponentModel.Attributes
{


    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class PriorityAttribute : Attribute, IComparable<PriorityAttribute>
    {

        // This is a positional argument
        public PriorityAttribute(int priority)
        {
            this.Priority = priority;
        }


        public int Priority { get; }


        public int CompareTo(PriorityAttribute other)
        {

            if (other == null)
                return 1;

            return this.Priority.CompareTo(other.Priority);

        }


        public static int ResolvePriority(Type type)
        {

            int result = 10000;

            var attribute = type.GetCustomAttributes(typeof(PriorityAttribute), true).FirstOrDefault();
            
            if (attribute != null)
                result = ((PriorityAttribute)attribute).Priority;

            return result;

        }


    }

    public static class PriorityHelper
    {

        /// <summary>
        /// sort the list of type by priority
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<Type> OrderByPriority(this IEnumerable<Type> types)
        {

            List<KeyValuePair<int, Type>> result = new List<KeyValuePair<int, Type>>(types.Count());

            foreach (var type in types)
                result.Add(new KeyValuePair<int, Type>(PriorityAttribute.ResolvePriority(type), type));

            return result.OrderBy(c => c.Key).Select(c => c.Value);

        }

    }

}
