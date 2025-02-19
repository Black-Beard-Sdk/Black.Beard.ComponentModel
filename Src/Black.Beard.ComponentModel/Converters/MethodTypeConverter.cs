using System;
using System.Collections.Generic;

namespace Bb.Converters
{

    /// <summary>
    /// Manage the conversion functions for a type
    /// </summary>
    public class MethodTypeConverter
    {

        /// <summary>
        /// create a new instance of <see cref="MethodTypeConverter"/>
        /// </summary>
        /// <param name="type">managed source type</param>
        public MethodTypeConverter(Type type)
        {
            this.TypeKey = new TypeKey(type);
            SourceType = type;
            _dic = new Dictionary<TypeKey, List<MethodConverter>>();
            _functions = new Dictionary<TypeKey, Func<object, ConverterContext, object>>();
        }

        internal TypeKey TypeKey { get; }

        /// <summary>
        /// Managed source type
        /// </summary>
        public Type SourceType { get; }

        /// <summary>
        /// Get the list of conversion functions for the target type
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<MethodConverter> this[Type key] => _dic[new TypeKey(key)];

        /// <summary>
        /// Add a conversion function
        /// </summary>
        /// <param name="newMethod"></param>
        public void Add(MethodConverter newMethod)
        {
            _dic.Add(newMethod.TypeKey, new List<MethodConverter>() { newMethod });
        }

        /// <summary>
        /// Try to get the list of conversion functions for the target type
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(Type key, out List<MethodConverter> value)
        {
            return _dic.TryGetValue(new TypeKey(key), out value);
        }

        /// <summary>
        /// Try to get the conversion function for the target type
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public bool TryGetFunction(Type targetType, out Func<object, ConverterContext, object> result)
        {
            return _functions.TryGetValue(new TypeKey(targetType), out result);
        }

        /// <summary>
        /// Add a conversion function
        /// </summary>
        /// <param name="targetType"></param>
        /// <param name="func"></param>
        public void AddFunction(Type targetType, Func<object, ConverterContext, object> func)
        {
            _functions.Add(new TypeKey(targetType), func);
        }


        /// <summary>
        /// Return the list of generated conversion functions
        /// </summary>
        /// <returns></returns>
        public IEnumerable<KeyValuePair<KeyValuePair<Type, Type>, Func<object, ConverterContext, object>>> Functions()
        {
            foreach (var item in _functions)
                yield return
                    new KeyValuePair<KeyValuePair<Type, Type>,
                    Func<object, ConverterContext, object>>(new KeyValuePair<Type, Type>(SourceType, item.Key.Type), item.Value);
        }


        public override string ToString()
        {
            return $"{SourceType} : {_dic.Count}";
        }

        private Dictionary<TypeKey, Func<object, ConverterContext, object>> _functions;
        private readonly Dictionary<TypeKey, List<MethodConverter>> _dic;

    }


    internal class ConverterIndex
    {

        public ConverterIndex()
        {
            _dic = new Dictionary<TypeKey, MethodTypeConverter>();
        }

        public void Add(Type type, MethodTypeConverter converter)
        {
            _dic.Add(converter.TypeKey, converter);
        }

        public bool TryGetValue(Type key, out MethodTypeConverter value)
        {
            return _dic.TryGetValue(new TypeKey(key), out value);
        }

        public IEnumerable<MethodTypeConverter> Items()
        {
            foreach (var item in _dic)
                yield return item.Value;
        }

        private readonly Dictionary<TypeKey, MethodTypeConverter> _dic;

    }


    internal class TypeKey
    {

        public TypeKey(Type type)
        {
            this.Type = type;
        }

        public Type Type { get; }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }

        override public bool Equals(object obj)
        {
            if (obj != null && obj is TypeKey o)
                return o.Type.GetHashCode() == this.Type.GetHashCode();
            return false;
        }

    }

}
