using System;
using System.Linq.Expressions;
using Bb.Exceptions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Bb.Converters;
using System.Text;

namespace Bb.Expressions
{

    public static partial class ExpressionHelper
    {


        /// <summary>
        /// evaluate if the types can be converted.
        /// 0 if the types are the same
        /// 1 if the source type can be converted in target type
        /// 2 if a method for convert the source type in target type exists
        /// </summary>
        /// <param name="targetType">target type</param>
        /// <param name="sourceType">source type</param>
        /// <returns></returns>
        public static int CanBeConverted(this Type targetType, Type sourceType)
        {

            if (sourceType == targetType)
                return 0;

            var result = ConverterHelper.GetMethodToConvert(sourceType, targetType, out var method);
            if (result)
                return 2;

            try
            {
                var e = Expression.Convert(Expression.Parameter(sourceType), targetType);
                return 1;
            }
            catch (Exception)
            {
                //var result = ConverterHelper.GetMethodToConvert(sourceType, targetType, out var method);
                //if (result)
                //    return 2;
            }

            return -1;

        }

        /// <summary>
        /// return an expression of conversion if target type are different
        /// </summary>
        /// <param name="self">source expression to convert</param>
        /// <param name="targetType">target type</param>
        /// <returns></returns>
        public static Expression ConvertIfDifferent(this Expression self, Type targetType, ParameterExpression? context = null)
        {

            Expression result = null;
            Type sourceType = self.ResolveType();

            if (sourceType != targetType)
                result = self.Convert(sourceType, targetType, context);

            else
                result = self;

            if (result == null)
                throw new InvalidCastException($"no method for manage conversion of {sourceType} to {targetType}. please use ConverterHelper for register a custom method");

            return result;

        }
    
        public static Expression GetTypeExpression(this Expression e)
        {

            if (e.Type == typeof(Type))
                return e;

            return e.Call(typeof(Type), nameof(Type.GetType));

        }

        private static Expression Convert(this Expression self, Type sourceType, Type targetType, ParameterExpression context)
        {

            Expression result = null;
            MethodConverter method = null;

            if (targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType))
                result = Expression.Convert(self, targetType);

            else if (!ConverterHelper.GetMethodToConvert(sourceType, targetType, out method))   // Find a registered method to convert
            {                                                                                   // method not found

                if (targetType.IsConstructedGenericType)                                        // generic
                    self.ConvertToGeneric(sourceType, targetType, context, ref method);

                else if (targetType.IsArray && targetType.GetArrayRank() == 1)                  // array of 1 rank
                    self = self.ConvertToArray(sourceType, targetType, context, ref method);

                else if (sourceType.IsEnum || targetType.IsEnum)                                // Target is enum
                    self = self.ConvertEnum(sourceType, targetType, context, ref method);

                else
                {

                }

            }

            if (method != null)
                result = self.Convert(sourceType, method, context);

            return result;

        }

        private static Expression ConvertEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {

            if (sourceType.IsEnum && !targetType.IsEnum)
                self = self.ConvertFromEnum(sourceType, targetType, context, ref method);

            else if (!sourceType.IsEnum && targetType.IsEnum)
                self = self.ConvertToEnum(sourceType, targetType, context, ref method);

            else if (sourceType.IsEnum && targetType.IsEnum)
                self = self.ConvertEnumToEnum(sourceType, targetType, context, ref method);

            return self;

        }

        private static Expression ConvertToEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {

            var typeEnum = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance)[0].FieldType;
            if (typeEnum != sourceType && sourceType != typeof(string))
                self = self.Convert(sourceType, typeEnum, context);
            else
                typeEnum = sourceType;

            if (ConverterHelper.MethodToEnum.TryGetValue(typeEnum, out var m))
                method = new MethodConverter(m.MakeGenericMethod(targetType));

            else
            {

            }

            return self;

        }

        private static Expression ConvertFromEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {

            var typeEnum = targetType == typeof(string)
                ? typeof(string)
                : sourceType.GetFields(BindingFlags.Public | BindingFlags.Instance)[0].FieldType;

            if (ConverterHelper.MethodFromEnum.TryGetValue(typeEnum, out var m))
                method = new MethodConverter(m.MakeGenericMethod(sourceType));

            if (typeEnum != targetType)
            {

                self = self.Convert(typeEnum, method, context);

                if (!ConverterHelper.GetMethodToConvert(typeEnum, targetType, out method))
                {

                }

            }

            return self;

        }

        private static Expression ConvertEnumToEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {
            var tt = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance)[0].FieldType;
            self = self.ConvertFromEnum(sourceType, tt, context, ref method);
            self = self.Convert(sourceType, method, context);
            self = self.ConvertToEnum(tt, targetType, context, ref method);
            return self;
        }

        private static Expression Convert(this Expression self, Type sourceType, MethodConverter me, ParameterExpression? context)
        {

            Expression result = null;

            var parameters = me.Method.GetParameters();
            Expression[] arguments = new Expression[parameters.Length];

            for (int index = 0; index < arguments.Length; index++)
                SetArgument(self, sourceType, parameters, arguments, index, me, context);

            if (me.Method is MethodInfo m)
                result = Expression.Call(m.IsStatic ? null : self, m, arguments);

            else if (me.Method is ConstructorInfo ctor)
                result = Expression.New(ctor, arguments);

            return result;
        }

        private static Expression ConvertToArray(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {

            var targetElementType = targetType.GetElementType();

            if (sourceType.IsArray && sourceType.GetArrayRank() == 1)
            {
                var sourceElementType = sourceType.GetElementType();
                method = new MethodConverter(ConverterHelper.MethodConvertArray.MakeGenericMethod(sourceElementType, targetElementType));
            }

            else
            {

                method = sourceType != targetElementType
                ? ConverterHelper.GetMethodToConvert(sourceType, targetElementType)
                : null;

                if (method != null)
                    self = Convert(self, sourceType, method, context);

                method = new MethodConverter(ConverterHelper.MethodToArray.MakeGenericMethod(targetElementType));

            }

            return self;

        }

        private static Expression ConvertToGeneric(this Expression self, Type sourceType, Type targetType, ParameterExpression context, ref MethodConverter method)
        {

            var p = targetType.GetGenericArguments();
            if (p.Length == 1)
            {
                Type elementType = p[0];
                method = ConverterHelper.GetMethodToConvert(sourceType, elementType);
                if (method != null)
                {
                    self = self.Convert(sourceType, method, context);
                    method = ConverterHelper.GetMethodToConvert(elementType, targetType);
                    if (method == null)
                    {

                    }
                }
                return self;

            }
            else
            {

            }

            return null;

        }

        private static void SetArgument(Expression self, Type initialType, ParameterInfo[] parameters, Expression[] arguments, int index, MethodConverter me, ParameterExpression? context)
        {

            var parameterType = parameters[index].ParameterType;
            var name0 = parameters[index].Name;

            if (parameterType == initialType)    // Take directly the source
                arguments[index] = self;

            else if (typeof(ConverterContext).IsAssignableFrom(parameterType))
                arguments[index] = context;

            else if (typeof(IFormatProvider).IsAssignableFrom(parameterType))
            {

                if (context != null)
                    arguments[index] = context.Property("Culture");

                else
                    arguments[index] = Expression.Constant(ConverterContext.DefaultCultureInfo ?? CultureInfo.InvariantCulture);

            }

            else if (typeof(Encoding).IsAssignableFrom(parameterType))
            {

                if (context != null)
                    arguments[index] = context.Property("Encoding");

                else
                    arguments[index] = Expression.Constant(ConverterContext.DefaultEncoding ?? Encoding.UTF8);

            }

            else if (parameterType.IsAssignableFrom(me.SourceType))     // use converter for assign the initial value
                arguments[index] = ConvertIfDifferent(self, parameterType);

            else if (parameterType == typeof(Type))
                arguments[index] = Expression.Constant(me.TargetType);

            else if (parameterType == typeof(Int32) && name0 == "toBase")
                arguments[1] = Expression.Constant(10);

            else
            {

            }

        }

    }


}
