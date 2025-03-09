using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel.Attributes
{
    /// <summary>
    /// specify this class contains method to create object
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class IocConstructorAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="IocConstructorAttribute"/> class.
        /// </summary>
        public IocConstructorAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IocConstructorAttribute"/> class.
        /// </summary>
        public IocConstructorAttribute(Type type)
        {
            Type = type;
        }

        /// <summary>
        /// Type managed by the constructor
        /// </summary>
        public Type? Type { get; }

        /// <summary>
        /// Return the list of method to create object
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<(Type, MethodInfo)> GetMethods(Type type)
        {
            var methods = type.GetMethods(BindingFlags.Static | BindingFlags.Public);
            foreach (var item in methods)
            {

                var attr = item.GetCustomAttributes(typeof(IocConstructorAttribute), false)
                    .OfType<IocConstructorAttribute>()
                    .FirstOrDefault();

                if (attr != null)
                    yield return (attr.Type ?? type, item);

            }
        }

    }

}
