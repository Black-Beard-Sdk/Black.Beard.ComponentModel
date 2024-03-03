using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Bb.ComponentModel
{

    public static class TypeDiscoveryExtension
    {


        static TypeDiscoveryExtension()
        {
            _systemDirectory = AssemblyDirectoryResolver.SystemDirectory.FullName;
        }

        /// <summary>
        /// Return true if the assembly is an assembly system
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsAssemblySystem(this Assembly self)
        {
            
            if (self.IsDynamic || string.IsNullOrEmpty(self.Location) || self.Location.StartsWith(_systemDirectory))
                return true;

            var name = self.GetName().Name;

            if (name.StartsWith("System.") || name.StartsWith("Microsoft."))
                return true;

            return false;

        }

        /// <summary>
        /// return true if specified type is static
        /// </summary>
        /// <returns></returns>
        public static bool IsStatic(this Type self)
        {
            return self.IsClass && self.IsSealed && self.IsAbstract;
        }


        /// <summary>
        /// return a list of type that contains the specified attribute
        /// </summary>
        /// <param name="self">type to test</param>
        /// <param name="flags">member that match with specified flags</param>
        /// <param name="func"> function to evaluate on the member</param>
        /// <returns></returns>
        public static bool MatchField(this Type self, BindingFlags flags, Func<FieldInfo, bool> func)
        {
            if (self != null)
                foreach (var item in self.GetFields(flags))
                    if (func(item))
                        return true;

            return false;

        }

        /// <summary>
        /// Return true if the type contains the specified property
        /// </summary>
        /// <param name="self">type to test</param>
        /// <param name="flags">member that match with specified flags</param>
        /// <param name="func"> function to evaluate on the member</param>
        /// <returns></returns>
        public static bool MatchProperty(this Type self, BindingFlags flags, Func<PropertyInfo, bool> func)
        {
            if (self != null)
                foreach (var item in self.GetProperties(flags))
                    if (func(item))
                        return true;

            return false;

        }

        /// <summary>
        /// return true if the type contains the specified method
        /// </summary>
        /// <param name="self">type to test</param>
        /// <param name="flags">member that match with specified flags</param>
        /// <param name="func"> function to evaluate on the member</param>
        /// <returns></returns>
        public static bool MatchMethod(this Type self, BindingFlags flags, Func<MethodInfo, bool> func)
        {
            if (self != null)
                foreach (var item in self.GetMethods(flags))
                    if (func(item))
                        return true;

            return false;

        }

        /// <summary>
        /// return true if the type contains the specified event
        /// </summary>
        /// <param name="self">type to test</param>
        /// <param name="flags">member that match with specified flags</param>
        /// <param name="func"> function to evaluate on the member</param>
        /// <returns></returns>
        public static bool MatchEvent(this Type self, BindingFlags flags, Func<EventInfo, bool> func)
        {
            if (self != null)
                foreach (var item in self.GetEvents(flags))
                    if (func(item))
                        return true;

            return false;

        }

        /// <summary>
        /// return true if the type contains the specified constructor
        /// </summary>
        /// <param name="self">type to test</param>
        /// <param name="flags">member that match with specified flags</param>
        /// <param name="func"> function to evaluate on the member</param>
        /// <returns></returns>
        public static bool MatchConstructor(this Type self, BindingFlags flags, Func<ConstructorInfo, bool> func)
        {
            if (self != null)
                foreach (var item in self.GetConstructors(flags))
                    if (func(item))
                        return true;

            return false;

        }

        /// <summary>
        /// return a list file that contains the assembly name
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<FileInfo> ResolveAssemblyFilename(this AssemblyName self)
        {
            var path = TypeDiscovery.Instance.Paths;
            foreach (var item in path.GetPaths())
            {
                var file = self.ResolveAssemblyFilename(item);
                if (file != null)
                    yield return file;
            }
        }

        /// <summary>
        /// return a file that contains the assembly name
        /// </summary>
        /// <param name="self"></param>
        /// <param name="baseDirectory"></param>
        /// <returns></returns>
        public static FileInfo ResolveAssemblyFilename(this AssemblyName self, string baseDirectory)
        {
            var dir = new DirectoryInfo(baseDirectory);
            dir.Refresh();
            return ResolveAssemblyFilename(self, dir);
        }

        /// <summary>
        /// return a file that contains the assembly name
        /// </summary>
        /// <param name="self"></param>
        /// <param name="directory"></param>
        /// <returns></returns>
        public static FileInfo ResolveAssemblyFilename(this AssemblyName self, DirectoryInfo directory)
        {

            if (directory.Exists)
            {

                var filename = directory.GetFiles(self.Name + ".dll", SearchOption.AllDirectories).FirstOrDefault();
                if (filename != null)
                    return filename;

                filename = directory.GetFiles(self.Name + ".exe", SearchOption.AllDirectories).FirstOrDefault();
                if (filename != null)
                    return filename;

            }

            return null;

        }

        /// <summary>
        /// return the assembly file name that contains the specified type
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string GetFileName(this Type self)
        {
            return self.Assembly.Location;
        }

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
        public static IEnumerable<Type> GetTypesWithAttributes<T>(this IEnumerable<Type> self, Type typeBase, Func<T, bool> filterOnAttribute) where T : Attribute
        {

            return self.Where(type =>
            {

                if (typeBase == null || typeBase.IsAssignableFrom(type))
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

        /// <summary>
        /// convert <see cref="AttributeCollection"/> to list of attributes
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static IEnumerable<Attribute> ToList(this AttributeCollection attributes)
        {
            foreach (Attribute attribute in attributes)
                yield return attribute;
        }

        private static string _systemDirectory;

    }

}



