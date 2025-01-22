﻿using Bb.ComponentModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;

namespace Bb.Diagnostics
{


    public static class DiagnosticProviderExtensions
    {


        /// <summary>
        /// return a collection of activity tags
        /// </summary>
        /// <param name="tags">list of key values</param>
        /// <returns></returns>
        public static ActivityTagsCollection GetTagCollection(this (string key, string value)[] tags)
        {
            var _tags = new ActivityTagsCollection();
            if (tags.Length > 0)
                foreach (var item in tags)
                    _tags.Add(item.key, item.value);
            return _tags;

        }

        ///// <summary>
        ///// return all name of activities are loaded
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public static IEnumerable<(Type, string)> GetActivityNames(string name = "Source")
        //{

        //    var types = GetTypes("Source", typeof(ActivitySource));

        //    foreach (var type in types)
        //        yield return (type, GetActivityName(type));

        //}


        ///// <summary>
        ///// return all name of meters are loaded
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public static IEnumerable<(Type, string)> GetMeterNames(string name = "Source")
        //{

        //    var types = GetTypes("Source", typeof(Meter));

        //    foreach (var type in types)
        //        yield return (type, GetMeterName(type));

        //}


        ///// <summary>
        ///// return the name of the meter
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string GetMeterName(Type type)
        //{
        //    var n = type.GetField("Name");
        //    var constantName = n.GetValue(null);
        //    return constantName?.ToString();
        //}


        ///// <summary>
        ///// Return all types that contains a static field with specified name and type
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static IEnumerable<Type> GetTypes(string name, Type type)
        //{

        //    var types = TypeDiscovery.Instance.GetStaticTypes(
        //        d => !d.IsAssemblySystem(),
        //        c => c.MatchField(BindingFlags.NonPublic | BindingFlags.Static, e => e.Name == name && e.FieldType == type)
        //        ).ToList();

        //    return types;

        //}


        public static string GetActivityName(this Type type)
        {
            return type.Assembly.GetName().Name;
            //var name = type.Name;
            //if (name.EndsWith("Provider"))
            //    name = name.Substring(0, name.Length - "Provider".Length);
            //return name;
        }


        public static Version GetActivityVersion(this Type type)
        {
            return type.Assembly.GetName().Version ?? new Version("1.0.0");
        }


    }


}
