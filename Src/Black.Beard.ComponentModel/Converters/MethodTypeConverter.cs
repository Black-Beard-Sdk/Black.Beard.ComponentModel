using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bb.Converters
{

    /// <summary>
    /// Manage the conversion functions for a type
    /// </summary>
    public class MethodTypeConverter : Dictionary<Type, List<MethodConverter>>
    {

        /// <summary>
        /// create a new instance of <see cref="MethodTypeConverter"/>
        /// </summary>
        /// <param name="type">managed source type</param>
        public MethodTypeConverter(Type type)
        {
            SourceType = type;
            _functions = new Dictionary<Type, Func<object, ConverterContext, object>>();
        }


        /// <summary>
        /// Managed source type
        /// </summary>
        public Type SourceType { get; }


        /// <summary>
        /// Try to get the conversion function for the target type
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryGetFunction(Type targetType, out Func<object, ConverterContext, object> result)
        {
            return _functions.TryGetValue(targetType, out result);
        }

        /// <summary>
        /// Add a conversion function
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="func"></param>
        public void AddFunction(Type targetType, Func<object, ConverterContext, object> func)
        {
            _functions.Add(targetType, func);
        }


        /// <summary>
        /// Return the list of generated conversion functions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<KeyValuePair<Type, Type>, Func<object, ConverterContext, object>>> Functions()
        {
            foreach (var item in _functions)
                yield return new KeyValuePair<KeyValuePair<Type, Type>, Func<object, ConverterContext, object>>(new KeyValuePair<Type, Type>(SourceType, item.Key), item.Value);
        }


        public override string ToString()
        {
            return $"{SourceType} : {Count}";
        }

        private Dictionary<Type, Func<object, ConverterContext, object>> _functions;

    }

}
