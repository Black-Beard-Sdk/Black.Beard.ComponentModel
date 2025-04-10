// Ignore Spelling: Accessor

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Bb.Accessors
{

    /// <summary>
    /// Extension methods for <see cref="AccessorItem"/>
    /// </summary>
    public static class AccessorExtensions
    {

        /// <summary>
        /// Returns a <see cref="AccessorList"/> for the specified type.
        /// </summary>
        /// <param name="type">The type to evaluate. Must not be null.</param>
        /// <param name="strategy">The strategy to determine which members to include (e.g., properties, fields, static, instance).</param>
        /// <param name="filter">A filter function to select declaring types. Can be null.</param>
        /// <param name="memberFilter">A filter function to select members. Can be null.</param>
        /// <returns>
        /// A <see cref="AccessorList"/> containing member accessors for the specified type.
        /// </returns>
        /// <remarks>
        /// This method retrieves a list of accessors for the members of the specified type based on the provided strategy and filters.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var accessors = typeof(MyClass).GetAccessors(
        ///     MemberStrategy.Properties | MemberStrategy.Fields,
        ///     type => type.Namespace == "MyNamespace",
        ///     member => member.Name.StartsWith("Get"));
        /// foreach (var accessor in accessors)
        /// {
        ///     Console.WriteLine(accessor.Name);
        /// }
        /// </code>
        /// </example>
        public static AccessorList GetAccessors(this Type type, MemberStrategys strategy =
            MemberStrategys.Direct
          | MemberStrategys.Properties
          | MemberStrategys.Fields
          | MemberStrategys.Instance
          | MemberStrategys.Static
            , Func<Type, bool>? filter = null
            , Func<MemberInfo, bool>? memberFilter = null)
        {
            return AccessorItem.GetPropertiesImpl(type, strategy, filter, memberFilter);
        }

        /// <summary>
        /// Returns a <see cref="AccessorList"/> for the specified type.
        /// </summary>
        /// <param name="type">The type to evaluate. Must not be null.</param>
        /// <param name="filter">A filter function to select declaring types. Must not be null.</param>
        /// <param name="memberFilter">A filter function to select members. Can be null.</param>
        /// <returns>
        /// A <see cref="AccessorList"/> containing member accessors for the specified type.
        /// </returns>
        /// <remarks>
        /// This method retrieves a list of accessors for the members of the specified type using default strategies and the provided filters.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var accessors = typeof(MyClass).GetAccessors(
        ///     type => type.Namespace == "MyNamespace",
        ///     member => member.Name.Contains("Data"));
        /// foreach (var accessor in accessors)
        /// {
        ///     Console.WriteLine(accessor.Name);
        /// }
        /// </code>
        /// </example>
        public static AccessorList GetAccessors(this Type type
            , Func<Type, bool> filter
            , Func<MemberInfo, bool>? memberFilter = null)
        {
            MemberStrategys strategy = MemberStrategys.Direct 
                | MemberStrategys.Properties | MemberStrategys.Fields
                | MemberStrategys.Instance | MemberStrategys.Static;

            return AccessorItem.GetPropertiesImpl(type, strategy, filter, memberFilter);
        }

        /// <summary>
        /// Converts an <see cref="AttributeCollection"/> to a list of attributes.
        /// </summary>
        /// <param name="attributes">The attribute collection to convert. Must not be null.</param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="Attribute"/> objects.
        /// </returns>
        /// <remarks>
        /// This method enumerates through the provided <see cref="AttributeCollection"/> and yields each attribute as an individual item.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// AttributeCollection attributes = TypeDescriptor.GetAttributes(typeof(MyClass));
        /// var attributeList = attributes.ToList();
        /// foreach (var attribute in attributeList)
        /// {
        ///     Console.WriteLine(attribute.GetType().Name);
        /// }
        /// </code>
        /// </example>
        internal static IEnumerable<Attribute> ToList(this AttributeCollection attributes)
        {
            foreach (Attribute attribute in attributes)
                yield return attribute;
        }

    }

}
