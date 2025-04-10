using Bb.ComponentModel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bb.ComponentModel
{
    /// <summary>
    /// Provides helper methods for working with priority attributes.
    /// </summary>
    public static class PriorityHelper
    {

        /// <summary>
        /// Sorts a list of types by their priority values.
        /// </summary>
        /// <param name="types">The list of types to sort.</param>
        /// <returns>An enumerable collection of types sorted by priority.</returns>
        /// <remarks>
        /// This method uses the <see cref="PriorityAttribute"/> to determine the priority of each type.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sortedTypes = types.OrderByPriority();
        /// </code>
        /// </example>
        public static IEnumerable<Type> OrderByPriority(this IEnumerable<Type> types)
        {

            List<KeyValuePair<int, Type>> result = new List<KeyValuePair<int, Type>>(types.Count());

            foreach (var type in types)
                result.Add(new KeyValuePair<int, Type>(PriorityAttribute.ResolvePriority(type), type));

            return result.OrderBy(c => c.Key).Select(c => c.Value);

        }

    }

}
