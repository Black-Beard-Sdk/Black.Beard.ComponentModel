using System;
using System.Reflection;

namespace Bb.ComponentModel.Accessors
{

    public static class AccessorExtensions
    {


        /// <summary>
        /// Returns a <see cref="AccessorList"/> for the specified type.
        /// </summary>
        /// <param name="type">type to evaluate</param>
        /// <param name="strategy"></param>
        /// <param name="filter">filter to select declaring types</param>
        /// <param name="memberFilter">filter to select members</param>
        /// <returns><see cref="AccessorList"/> with member accessors</returns>
        public static AccessorList GetAccessors(this Type type, MemberStrategy strategy =
            MemberStrategy.Direct
          | MemberStrategy.Properties
          | MemberStrategy.Fields
          | MemberStrategy.Instance
          | MemberStrategy.Static
            , Func<Type, bool> filter = null
            , Func<MemberInfo, bool> memberFilter = null)
        {

            return AccessorItem.GetPropertiesImpl(type, strategy, filter, memberFilter);

        }

        /// <summary>
        /// Returns a <see cref="AccessorList"/> for the specified type.
        /// </summary>
        /// <param name="type">type to evaluate</param>
        /// <param name="filter">filter to select declaring types</param>
        /// <param name="memberFilter">filter to select members</param>
        /// <returns><see cref="AccessorList"/> with member accessors</returns>
        public static AccessorList GetAccessors(this Type type
            , Func<Type, bool> filter
            , Func<MemberInfo, bool> memberFilter = null)
        {

            MemberStrategy strategy = MemberStrategy.Direct 
                | MemberStrategy.Properties | MemberStrategy.Fields
                | MemberStrategy.Instance | MemberStrategy.Static;

            return AccessorItem.GetPropertiesImpl(type, strategy, filter, memberFilter);

        }

    }

}
