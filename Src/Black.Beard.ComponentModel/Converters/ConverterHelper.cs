using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Bb.Converters;

namespace Bb.Expressions
{


    /// <summary>
    /// Referential of method for conversion between types
    /// </summary>
    public static partial class ConverterHelper
    {    

        private static MethodInfo[] GetMethod()
        {
            return typeof(ConverterHelper).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        static ConverterHelper()
        {


            ConverterHelper.MethodToArray = typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToArray));
            ConverterHelper.MethodConvertArray = typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ConvertArray));

            MethodToEnum = new Dictionary<Type, MethodInfo>();
            ConverterHelper.MethodToEnum.Add(typeof(UInt16), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(UInt16)));
            ConverterHelper.MethodToEnum.Add(typeof(Int16), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(Int16)));
            ConverterHelper.MethodToEnum.Add(typeof(UInt32), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(UInt32)));
            ConverterHelper.MethodToEnum.Add(typeof(Int32), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(Int32)));
            ConverterHelper.MethodToEnum.Add(typeof(UInt64), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(UInt64)));
            ConverterHelper.MethodToEnum.Add(typeof(Int64), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(Int64)));
            ConverterHelper.MethodToEnum.Add(typeof(string), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.ToEnum), 1, typeof(string)));

            MethodFromEnum = new Dictionary<Type, MethodInfo>();
            ConverterHelper.MethodFromEnum.Add(typeof(UInt16), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToUShort)));
            ConverterHelper.MethodFromEnum.Add(typeof(Int16), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToShort)));
            ConverterHelper.MethodFromEnum.Add(typeof(UInt32), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToUInt)));
            ConverterHelper.MethodFromEnum.Add(typeof(Int32), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToInt)));
            ConverterHelper.MethodFromEnum.Add(typeof(UInt64), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToULong)));
            ConverterHelper.MethodFromEnum.Add(typeof(Int64), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToLong)));
            ConverterHelper.MethodFromEnum.Add(typeof(string), typeof(ConverterHelper).GetMethodByName(nameof(ConverterHelper.EnumToString)));

            AppendConverters(typeof(Convert), true, BindingFlags.Static | BindingFlags.Public, c => _names.Contains(c.Name));
            AppendConverters(typeof(ConverterHelper), true, BindingFlags.Static | BindingFlags.Public);
            AppendConverters(typeof(ConverterHelperNullable), true, BindingFlags.Static | BindingFlags.Public);

        }

        /// <summary>
        /// Convert a value to specified target type
        /// </summary>
        /// <typeparam name="T">Target type</typeparam>
        /// <param name="self">initial value to convert</param>
        /// <returns></returns>
        public static T ToObject<T>(this object self)
        {
            return (T)ToObject(self, typeof(T));
        }

        /// <summary>
        /// Convert a value to specified target type
        /// </summary>
        /// <param name="self">initial value to convert</param>
        /// <param name="targetType">Target type</param>
        /// <returns></returns>
        public static object ToObject(this object self, Type targetType, ConverterContext? context = null)
        {

            object result = null;

            if (self != null)
            {

                var function = GetFunctionForConvert(self.GetType(), targetType);

                if (function != null)
                {

                    if (context == null)
                        context = ConverterContext.Default;

                    result = function(self, context);
                }

            }

            return result;

        }

        /// <summary>
        /// Get the function to convert sourceType to targetType
        /// </summary>
        /// <param name="sourceType">Source type</param>
        /// <param name="targetType">Target type</param>
        /// <returns></returns>
        public static Func<object, ConverterContext, object> GetFunctionForConvert(this Type sourceType, Type targetType)
        {

            if (!_dicConverters.TryGetValue(sourceType, out var dic2))
                lock (_lock)
                    if (!_dicConverters.TryGetValue(sourceType, out dic2))
                        _dicConverters.Add(sourceType, dic2 = new MethodTypeConverter(sourceType));

            if (!dic2.TryGetFunction(targetType, out var function))
                lock (_lock)
                    if (!dic2.TryGetFunction(targetType, out function))
                    {
                        var sourceValue = Expression.Parameter(typeof(object));
                        var sourceContext = Expression.Parameter(typeof(ConverterContext));
                        var e = sourceValue.ConvertIfDifferent(sourceType, sourceContext);
                        e = e.ConvertIfDifferent(targetType, sourceContext);
                        e = e.ConvertIfDifferent(typeof(object), sourceContext);
                        var lbd = Expression.Lambda<Func<object, ConverterContext, object>>(e, sourceValue, sourceContext);

                        dic2.AddFunction(targetType, function = lbd.Compile());

                    }

            return function;

        }

        /// <summary>
        /// Return all source types that can be converted to targetType
        /// </summary>
        /// <param name="filter">filter for bypass items</param>
        /// <returns></returns>
        public static IEnumerable<MethodTypeConverter> Methods(Predicate<MethodTypeConverter> filter = null)
        {
            foreach (var item in _dicConverters)
                if (filter == null || filter(item.Value))
                    yield return item.Value;
        }

        /// <summary>
        /// Try to resolve the method to convert sourceType to targetType
        /// </summary>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static bool GetMethodToConvert(Type sourceType, Type targetType, out MethodConverter method)
        {
            method = GetMethodToConvert(sourceType, targetType);
            return method != null;
        }

        /// <summary>
        /// Get the method to convert sourceType to targetType
        /// </summary>
        /// <param name="sourceType">Source type</param>
        /// <param name="targetType">Target type</param>
        /// <returns></returns>
        public static MethodConverter GetMethodToConvert(Type sourceType, Type targetType)
        {

            #region append

            if (!_initialized.Contains(sourceType))
                lock (_lock)
                    if (!_initialized.Contains(sourceType))
                        Discover(sourceType, false);

            if (!_initialized.Contains(targetType))
                lock (_lock)
                    if (!_initialized.Contains(targetType))
                    {
                        Discover(targetType, false);
                        if (targetType.IsConstructedGenericType)
                        {
                            var p = targetType.GetGenericArguments();
                            if (p.Length == 1)
                            {
                                registerCtors(p[0]);
                                RegisterOperators(p[0], false);
                            }
                        }
                    }

            #endregion append

            MethodConverter method = null;

            if (_dicConverters.TryGetValue(sourceType, out var typeSource))
                if (typeSource.TryGetValue(targetType, out var list))
                    method = list[0];

            return method;

        }

        /// <summary>
        /// Append new method to register
        /// </summary>
        /// <param name="method"></param>
        /// <param name="replaceExisting"></param>
        public static void AppendConverter(this Delegate method, bool replaceExisting = true)
        {
            AppendConverters(replaceExisting, method.Method);
        }

        /// <summary>
        /// /// Add methods in the list of method to be used for conversion
        /// </summary>
        /// <param name="type">type where the method can be found</param>
        /// <param name="replaceExisting">if true, replace existing methods</param>
        /// <param name="bindings"></param>
        public static void AppendConverters(this Type type, bool? replaceExisting, BindingFlags bindings, Func<MethodInfo, bool> filter = null)
        {

            var c = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            AppendConverters(c);

            var m = type.GetMethods(bindings);
            if (filter != null)
                m = m.Where(filter).ToArray();
            AppendConverters(replaceExisting, m);
        }

        /// <summary>
        /// Add methods to the list of methods to be used for conversion
        /// </summary>
        /// <param name="replaceExisting">if true, replace existing methods</param>
        /// <param name="ms"></param>
        public static void AppendConverters(bool? replaceExisting, params MethodInfo[] ms)
        {
            foreach (var item in ms)
            {
                var m = new MethodConverter(item);

                if (replaceExisting.HasValue)
                    m.ReplaceExistings = replaceExisting.Value;

                if (m.ToAdd)
                    Register(m);
            }
        }

        /// <summary>
        /// Add methods to the list of methods to be used for conversion
        /// </summary>
        /// <param name="ms"></param>
        public static void AppendConverters(params ConstructorInfo[] ms)
        {
            foreach (var item in ms)
            {
                var m = new MethodConverter(item);
                if (m.ToAdd)
                    Register(m);
            }
        }

        /// <summary>
        /// Register a new method to convert sourceType to targetType
        /// </summary>
        /// <param name="newMethod"></param>
        /// <exception cref="Exception">Method not allowed if the Property ToAdd is false</exception>
        /// <remarks>If a method already existing in the referential and the property ReplaceExisting is false, the method is not append</remarks>
        public static void Register(MethodConverter newMethod)
        {

            bool replace = false;

            //if (newMethod.SourceType == typeof(Single))
            //    if (newMethod.TargetType == typeof(char))
            //    {
            //    }

            if (newMethod.ToAdd == false)
                throw new Exception("Method not allowed");

            // Debug.WriteLine($"Register {newMethod}");

            if (!_dicConverters.TryGetValue(newMethod.SourceType, out var dicSource))
                _dicConverters.Add(newMethod.SourceType, dicSource = new MethodTypeConverter(newMethod.SourceType));

            if (!dicSource.TryGetValue(newMethod.TargetType, out List<MethodConverter> list))
                dicSource.Add(newMethod.TargetType, new List<MethodConverter>() { newMethod });

            else if (newMethod.ReplaceExistings)
                replace = true;

            var list1 = dicSource[newMethod.TargetType];

            if (replace)
                list1.Insert(0, newMethod);
            else
                list1.Add(newMethod);

        }

        /// <summary>
        /// Remove specified type
        /// </summary>
        /// <param name="type">specified type to remove</param>
        public static void Reset(Type type)
        {
            if (_initialized.Contains(type))
                lock (_lock)
                    if (_initialized.Contains(type))
                        _initialized.Remove(type);
        }

        #region private

        private static void Discover(Type targetType, bool? replaceExistings)
        {
            registerCtors(targetType);
            RegisterOperators(targetType, replaceExistings);
            RegisterIConvertible(targetType, replaceExistings);
            _initialized.Add(targetType);
        }

        private static void registerCtors(Type type)
        {
            var c = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            AppendConverters(c);
        }

        private static void RegisterOperators(Type type, bool? ReplaceExisting)
        {
            AppendConverters(ReplaceExisting, type.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(c => _names.Contains(c.Name)).ToArray());
            AppendConverters(ReplaceExisting, type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(c => _names.Contains(c.Name)).ToArray());
        }

        private static void RegisterIConvertible(Type type, bool? ReplaceExistings)
        {
            if (typeof(IConvertible).IsAssignableFrom(type))
                AppendConverters(ReplaceExistings, type.GetInterfaceMap(typeof(IConvertible)).TargetMethods);
        }

        private static Dictionary<Type, MethodTypeConverter> _dicConverters = new Dictionary<Type, MethodTypeConverter>();
        private static HashSet<string> _names = new HashSet<string>() { "ToByteArray", "ToString", "Concat", "Parse", "ToCharArray", "op_Implicit", "op_Explicit", "ToBoolean", "ToByte", "ToChar", "ToDateTime", "ToDecimal", "ToDouble", "ToInt16", "ToInt32", "ToInt64", "ToSByte", "ToSingle", "ToString", "ToUInt16", "ToUInt32", "ToUInt64", "ChangeType", "ToDateTimeOffset", };
        private static object _lock = new object();
        private static HashSet<Type> _initialized = new HashSet<Type>();

        internal static MethodInfo MethodToArray { get; }

        internal static MethodInfo MethodConvertArray { get; }

        internal static Dictionary<Type, MethodInfo> MethodToEnum { get; }
        internal static Dictionary<Type, MethodInfo> MethodFromEnum { get; }

        #endregion private

    }

}
