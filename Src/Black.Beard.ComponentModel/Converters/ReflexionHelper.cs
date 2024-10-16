using System;
using System.Buffers;
using System.Linq;
using System.Reflection;

namespace Bb.Expressions
{
    public static class ReflexionHelper
    {

        public static MethodInfo GetMethodByName(this Type self, string name)
        {
            return self.GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Single(c => c.Name == name);
        }

        public static MethodInfo GetMethodByName(this Type self, string name, params Type[] parameterTypes)
        {
            return self.GetMethod(name, 0, BindingFlags.Static | BindingFlags.NonPublic, null, parameterTypes, null);
        }

        public static MethodInfo GetMethodByName(this Type self, string name, int genericCount, params Type[] parameterTypes)
        {
            return self.GetMethod(name, genericCount, BindingFlags.Static | BindingFlags.NonPublic, null, parameterTypes, null);
        }

        /// <summary>
        /// Return method list
        /// </summary>
        /// <param name="self"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethods(this Type self, Func<MethodInfo, bool> filter)
        {
            return self.GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Where(filter).ToArray();
        }

        /// <summary>
        /// return methods
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static MethodInfo[] GetMethodList(this Type self)
        {
            return self.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
        }

    }

}
