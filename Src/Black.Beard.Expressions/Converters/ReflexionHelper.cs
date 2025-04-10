using System;
using System.Buffers;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;

namespace Bb.Converters
{
    /// <summary>
    /// Provides helper methods for reflection operations on types.
    /// </summary>
    public static class ReflexionHelper
    {

        /// <summary>
        /// Retrieves a static, non-public method by its name.
        /// </summary>
        /// <param name="self">The type to search for the method.</param>
        /// <param name="name">The name of the method to retrieve.</param>
        /// <returns>The <see cref="MethodInfo"/> of the method.</returns>
        /// <exception cref="InvalidOperationException">Thrown if no method or more than one method with the specified name is found.</exception>
        /// <example>
        /// <code lang="C#">
        /// var method = typeof(MyClass).GetMethodByName("MyMethod");
        /// </code>
        /// </example>
        public static MethodInfo GetMethodByName(this Type self, string name)
        {
            return self.GetMethods(_bindings).Single(c => c.Name == name);
        }

        /// <summary>
        /// Retrieves a static, non-public method by its name and parameter types.
        /// </summary>
        /// <param name="self">The type to search for the method.</param>
        /// <param name="name">The name of the method to retrieve.</param>
        /// <param name="parameterTypes">The parameter types of the method.</param>
        /// <returns>The <see cref="MethodInfo"/> of the method.</returns>
        /// <exception cref="AmbiguousMatchException">Thrown if more than one method matches the specified criteria.</exception>
        /// <example>
        /// <code lang="C#">
        /// var method = typeof(MyClass).GetMethodByName("MyMethod", typeof(int), typeof(string));
        /// </code>
        /// </example>
        public static MethodInfo? GetMethodByName(this Type self, string name, params Type[] parameterTypes)
        {
            return self.GetMethod(name, 0, _bindings, null, parameterTypes, null);
        }

        /// <summary>
        /// Retrieves a static, non-public method by its name, generic argument count, and parameter types.
        /// </summary>
        /// <param name="self">The type to search for the method.</param>
        /// <param name="name">The name of the method to retrieve.</param>
        /// <param name="genericCount">The number of generic arguments the method has.</param>
        /// <param name="parameterTypes">The parameter types of the method.</param>
        /// <returns>The <see cref="MethodInfo"/> of the method.</returns>
        /// <exception cref="AmbiguousMatchException">Thrown if more than one method matches the specified criteria.</exception>
        /// <example>
        /// <code lang="C#">
        /// var method = typeof(MyClass).GetMethodByName("MyGenericMethod", 1, typeof(int));
        /// </code>
        /// </example>
        public static MethodInfo? GetMethodByName(this Type self, string name, int genericCount, params Type[] parameterTypes)
        {
            return self.GetMethod(name, genericCount, _bindings, null, parameterTypes, null);
        }

        /// <summary>
        /// Retrieves all static, non-public methods of a type that match a specified filter.
        /// </summary>
        /// <param name="self">The type to search for methods.</param>
        /// <param name="filter">A filter function to apply to the methods.</param>
        /// <returns>An array of <see cref="MethodInfo"/> objects that match the filter.</returns>
        /// <example>
        /// <code lang="C#">
        /// var methods = typeof(MyClass).GetMethods(m => m.Name.StartsWith("Test"));
        /// </code>
        /// </example>
        public static MethodInfo[] GetMethods(this Type self, Func<MethodInfo, bool> filter)
        {
            return self.GetMethods(_bindings).Where(filter).ToArray();
        }

        /// <summary>
        /// Retrieves all static, non-public methods of a type.
        /// </summary>
        /// <param name="self">The type to search for methods.</param>
        /// <returns>An array of <see cref="MethodInfo"/> objects representing the methods.</returns>
        /// <example>
        /// <code lang="C#">
        /// var methods = typeof(MyClass).GetMethodList();
        /// </code>
        /// </example>
        public static MethodInfo[] GetMethodList(this Type self)
        {
            return self.GetMethods(_bindings);
        }


        private const BindingFlags _bindings = BindingFlags.Static | BindingFlags.NonPublic;

    }

}
