// Ignore Spelling: Existings

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Bb.Converters
{

    /// <summary>
    /// package data for conversion
    /// </summary>
    public class MethodConverter
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="MethodConverter"/> class.
        /// </summary>
        /// <param name="delegate">method to use for convert</param>
        public MethodConverter(Delegate @delegate)
            : this(@delegate.Method)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodConverter"/> class.
        /// </summary>
        /// <param name="method"></param>
        public MethodConverter(ConstructorInfo method)
            : this(method, method.DeclaringType)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodConverter"/> class.
        /// </summary>
        /// <param name="method"></param>
        public MethodConverter(MethodInfo method)
            : this(method, method.ReturnType)
        {
        }

        private MethodConverter(MethodBase method, Type targetType)
        {

            Method = method;
            IsStatic = method.IsStatic;
            TargetType = targetType;
            TypeKey = new TypeKey(targetType);
            Parameters = method.GetParameters();
            var parameterLength = Parameters.Length;

            Type? _genericArgument = null;

            if (TargetType.IsGenericType)
            {
                // System.Collections.Generic.Dictionary`2[[System.String],[System.String]]
                var tt = TargetType.GetGenericTypeDefinition();
                if (!_genericTypeIncludes.Contains(tt))
                    return;

                var genericArguments = TargetType.GetGenericArguments();
                if (genericArguments.Length == 1)
                    _genericArgument = genericArguments[0];
            }

            if (parameterLength == 0 && !IsStatic)
            {
                SourceType = method.DeclaringType;
                if (SourceType != null)
                    ToAdd = !_sourceExcludes.Contains(SourceType);
            }
            else if (parameterLength > 0)
            {

                Parameter0 = Parameters[0];
                SourceType = Parameter0.ParameterType;
                IsGenericConverter = SourceType.IsGenericParameter && SourceType == _genericArgument;
                bool t1 = SourceType != TargetType;

                if (!_sourceExcludes.Contains(SourceType))
                {

                    if (parameterLength == 1 && t1)
                    {
                        ToAdd = true;
                        if (Parameter0.ParameterType == typeof(IFormatProvider))
                        {
                            SourceType = method.DeclaringType;
                            Case = ConvertMethodType.OneParameterManaged;
                        }
                        else if (Parameter0.ParameterType == typeof(Encoding))
                        {
                            SourceType = method.DeclaringType;
                            Case = ConvertMethodType.OneParameterManaged;
                        }
                        else
                            Case = ConvertMethodType.OneParameter;

                    }

                    else if (parameterLength == 2)
                    {

                        Parameter1 = Parameters[1];

                        if (t1 && Parameter1.ParameterType == typeof(IFormatProvider))
                        {
                            ToAdd = true;
                            Case = ConvertMethodType.TwoParameterManaged;
                        }
                        else if (Parameter0.ParameterType == typeof(Encoding))
                        {
                            ToAdd = true;
                            Case = ConvertMethodType.TwoParameterManaged;
                        }
                        else if (Parameter1.Attributes.HasFlag(ParameterAttributes.Out) && TargetType == typeof(bool))
                        {
                            TargetType = Parameter1.ParameterType.GetElementType();
                            if (TargetType != null)
                            {
                                IsGenericConverter = TargetType.IsGenericParameter && TargetType == _genericArgument;
                                ToAdd = true;
                                Case = ConvertMethodType.TwoParameterWithBooleanReturn;
                            }
                        }
                    }

                }

                if (ToAdd && TargetType != null)
                    ToAdd = !_targetExcludes.Contains(TargetType) && TargetType != SourceType;

            }

            this.ReplaceExistings = Method.DeclaringType != SourceType && Method.DeclaringType != TargetType;

        }

        /// <summary>
        /// Gets the method to use.
        /// </summary>
        public MethodBase Method { get; }

        /// <summary>
        /// Gets a value indicating whether this method is static.
        /// </summary>
        public bool IsStatic { get; }

        /// <summary>
        /// Gets a value indicating whether this method is a generic converter.
        /// </summary>
        public bool IsGenericConverter { get; }

        internal TypeKey TypeKey { get; }

        /// <summary>
        /// Managed type to convert
        /// </summary>
        public Type? SourceType { get; }

        /// <summary>
        /// Managed target type to convert.
        /// </summary>
        public Type? TargetType { get; }

        /// <summary>
        /// Gets the parameters of the method.
        /// </summary>
        public ParameterInfo[] Parameters { get; }

        /// <summary>
        /// If true, the converter can be added to the list of converters
        /// </summary>
        public bool ToAdd { get; }

        /// <summary>
        /// Gets the case of the converter.
        /// </summary>
        public ConvertMethodType Case { get; }

        /// <summary>
        /// Parameter 0
        /// </summary>
        public ParameterInfo Parameter0 { get; }

        /// <summary>
        /// Parameter 1
        /// </summary>
        public ParameterInfo Parameter1 { get; }

        /// <summary>
        /// If true, the converter will replace existing converters
        /// </summary>
        public bool ReplaceExistings { get; internal set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{SourceType?.Name} -> {TargetType?.Name} : {Method?.DeclaringType?.Name}.{Method}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if (obj is MethodConverter m)
                return m.Method == this.Method;
            return false;
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Method.GetHashCode();
        }

        /// <summary>
        /// implicit conversion from <see cref="Delegate"/> to <see cref="MethodConverter"/>
        /// </summary>
        /// <param name="delegate"></param>

        public static implicit operator MethodConverter(Delegate @delegate)
        {
            return new MethodConverter(@delegate);
        }

        /// <summary>
        /// Implicit conversion from <see cref="MethodInfo"/> to <see cref="MethodConverter"/>
        /// </summary>
        /// <param name="method"></param>
        public static implicit operator MethodConverter(MethodInfo method)
        {
            return new MethodConverter(method);
        }

        /// <summary>
        /// Implicit conversion from <see cref="ConstructorInfo"/> to <see cref="MethodConverter"/>
        /// </summary>
        /// <param name="method"></param>
        public static implicit operator MethodConverter(ConstructorInfo method)
        {
            return new MethodConverter(method);
        }


        private readonly HashSet<Type> _sourceExcludes = new HashSet<Type>() { typeof(ReadOnlySpan<>), typeof(void) };
        private readonly HashSet<Type> _targetExcludes = new HashSet<Type>() { typeof(void) };

        private readonly HashSet<Type> _genericTypeIncludes = new HashSet<Type>()
        { typeof(Nullable<>), typeof(Dictionary<,>), typeof(IEnumerable<>) };


    }

    /// <summary>
    /// Defines the method type for conversion.
    /// </summary>
    public enum ConvertMethodType
    {

        /// <summary>
        /// By default
        /// </summary>
        Undefined,

        /// <summary>
        /// One parameter
        /// </summary>
        OneParameter,

        /// <summary>
        /// One parameter managed
        /// </summary>
        OneParameterManaged,

        /// <summary>
        /// Two parameter
        /// </summary>
        TwoParameterManaged,

        /// <summary>
        /// Two parameter with boolean return
        /// </summary>
        TwoParameterWithBooleanReturn
    
    }

}
