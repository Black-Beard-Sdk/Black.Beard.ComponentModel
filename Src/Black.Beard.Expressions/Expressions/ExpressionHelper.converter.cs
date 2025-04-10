using System;
using System.Linq.Expressions;
using System.Globalization;
using System.Reflection;
using Bb.Converters;
using System.Text;

namespace Bb.Expressions
{

    public static partial class ExpressionHelper
    {


        /// <summary>
        /// Evaluates if the source type can be converted to the target type.
        /// </summary>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <param name="sourceType">The source type to convert from. Must not be null.</param>
        /// <returns>
        /// An integer indicating the conversion possibility:
        /// <list type="bullet">
        /// <item><description>0: The types are the same.</description></item>
        /// <item><description>1: The source type can be directly converted to the target type.</description></item>
        /// <item><description>2: A custom conversion method exists for the source type to the target type.</description></item>
        /// <item><description>-1: Conversion is not possible.</description></item>
        /// </list>
        /// </returns>
        /// <remarks>
        /// This method checks if the source type can be converted to the target type using direct conversion, custom methods, or implicit casting.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int result = typeof(string).CanBeConverted(typeof(int));
        /// Console.WriteLine(result); // Output: -1 (if no conversion exists)
        /// </code>
        /// </example>
        public static int CanBeConverted(this Type targetType, Type sourceType)
        {

            if (sourceType == targetType)
                return 0;

            if (ConverterHelper.ContainsMethodToConvert(sourceType, targetType))
                return 2;

            try
            {
                Expression.Convert(Expression.Parameter(sourceType), targetType);
            }
            catch (Exception)
            {

                return -1;
            }

            return 1;

        }

        /// <summary>
        /// Returns a conversion expression if the source and target types are different.
        /// </summary>
        /// <param name="self">The source expression to convert. Must not be null.</param>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <param name="context">An optional <see cref="ParameterExpression"/> representing the conversion context.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the conversion logic.
        /// </returns>
        /// <remarks>
        /// This method generates a conversion expression if the source and target types differ. If no conversion is possible, an <see cref="InvalidCastException"/> is thrown.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when no method exists to manage the conversion between the source and target types.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var sourceExpression = Expression.Constant(42);
        /// var convertedExpression = sourceExpression.ConvertIfDifferent(typeof(string));
        /// </code>
        /// </example>
        public static Expression ConvertIfDifferent(this Expression self, Type targetType, ParameterExpression context)
        {

            Expression? result = null;
            Type sourceType = self.ResolveType();

            if (sourceType != targetType)
                result = self.Convert(sourceType, targetType, context);

            else
                result = self;

            if (result == null)
                throw new InvalidCastException($"no method for manage conversion of {sourceType} to {targetType}. please use ConverterHelper for register a custom method");

            return result;

        }

        /// <summary>
        /// Returns a conversion expression if the source and target types are different or return the original expression.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static Expression ConvertIfDifferent(this Expression self, Type targetType)
        {

            Expression? result = null;
            Type sourceType = self.ResolveType();

            if (sourceType != targetType)
                result = self.Convert(sourceType, targetType, null);

            else
                result = self;

            if (result == null)
                throw new InvalidCastException($"no method for manage conversion of {sourceType} to {targetType}. please use ConverterHelper for register a custom method");

            return result;

        }

        /// <summary>
        /// Retrieves the type of the given expression.
        /// </summary>
        /// <param name="e">The expression to evaluate. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the type of the given expression.
        /// </returns>
        /// <remarks>
        /// This method determines the type of the provided expression. If the expression type is <c>System.RuntimeType</c>, it is returned directly; otherwise, the <see cref="Type.GetType()"/> method is called.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var expression = Expression.Constant(typeof(string));
        /// var typeExpression = expression.GetTypeExpression();
        /// </code>
        /// </example>
        public static Expression GetTypeExpression(this Expression e)
        {

            if (e.Type.FullName == "System.RuntimeType")
                return e;

            return e.Call(e.Type, nameof(Type.GetType));

        }

        /// <summary>
        /// Converts an enumeration expression to another type.
        /// </summary>
        /// <param name="self">The source enumeration expression to convert. Must not be null.</param>
        /// <param name="sourceType">The source type of the enumeration. Must not be null.</param>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <param name="context">An optional <see cref="ParameterExpression"/> representing the conversion context.</param>
        /// <param name="method">A reference to the <see cref="MethodConverter"/> used for the conversion.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the conversion logic.
        /// </returns>
        /// <remarks>
        /// This method handles conversions from and to enumeration types, including conversions between different enumeration types.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceExpression = Expression.Constant(MyEnum.Value1);
        /// var convertedExpression = sourceExpression.ConvertEnum(typeof(MyEnum), typeof(string), null, ref method);
        /// </code>
        /// </example>
        private static Expression ConvertEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter method)
        {

            if (sourceType.IsEnum && !targetType.IsEnum)
                self = self.ConvertFromEnum(sourceType, targetType, context, ref method);

            else if (!sourceType.IsEnum && targetType.IsEnum)
                self = self.ConvertToEnum(sourceType, targetType, context, ref method);

            else if (sourceType.IsEnum && targetType.IsEnum)
                self = self.ConvertEnumToEnum(sourceType, targetType, context, ref method);

            return self;

        }

        private static Expression ConvertToEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter method)
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
                LocalDebug.Stop();
            }

            return self;

        }

        private static Expression ConvertFromEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter method)
        {

            var typeEnum = targetType == typeof(string)
                ? typeof(string)
                : sourceType.GetFields(BindingFlags.Public | BindingFlags.Instance)[0].FieldType;

            if (ConverterHelper.MethodFromEnum.TryGetValue(typeEnum, out var m))
                method = new MethodConverter(m.MakeGenericMethod(sourceType));

            if (typeEnum != targetType)
            {

                self = self.Convert(typeEnum, method, context);

                if (ConverterHelper.ContainsMethodToConvert(typeEnum, targetType))
                {
                    LocalDebug.Stop();
                }

            }

            return self;

        }

        private static Expression ConvertEnumToEnum(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter method)
        {
            var tt = targetType.GetFields(BindingFlags.Public | BindingFlags.Instance)[0].FieldType;
            self = self.ConvertFromEnum(sourceType, tt, context, ref method);
            self = self.Convert(sourceType, method, context);
            self = self.ConvertToEnum(tt, targetType, context, ref method);
            return self;
        }

        private static Expression ConvertToArray(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter? method)
        {

            var targetElementType = targetType.GetElementType();

            if (targetElementType == null)
                throw new ArgumentException($"target type {targetType} is not an array");

            if (sourceType.IsArray && sourceType.GetArrayRank() == 1)
            {
                var sourceElementType = sourceType.GetElementType();

                if (sourceElementType == null)
                    throw new ArgumentException($"source type {sourceType} is not an array");

                method = new MethodConverter(ConverterHelper.MethodConvertArray.MakeGenericMethod(sourceElementType, targetElementType));
            
            }

            else
            {

                if (sourceType != targetElementType)
                    method = ConverterHelper.GetMethodToConvert(sourceType, targetElementType);

                if (method != null)
                    self = Convert(self, sourceType, method, context);

                method = new MethodConverter(ConverterHelper.MethodToArray.MakeGenericMethod(targetElementType));

            }

            return self;

        }

        private static Expression? ConvertToGeneric(this Expression self, Type sourceType, Type targetType, ParameterExpression? context, ref MethodConverter? method)
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
                        LocalDebug.Stop();
                    }
                }

            }

            return self;

        }

        private static void SetArgument(Expression self, Type initialType, ParameterInfo[] parameters, Expression[] arguments, int index, MethodConverter me, ParameterExpression? context)
        {

            var parameterType = parameters[index].ParameterType;
            var name0 = parameters[index].Name;

            if (parameterType == initialType)    // Take directly the source
                arguments[index] = self;

            else if (typeof(ConverterContext).IsAssignableFrom(parameterType))
            {
                if (context != null)
                    arguments[index] = context;
            }

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
                LocalDebug.Stop();
            }

        }


        /// <summary>
        /// Converts an expression to a target type using a custom conversion method.
        /// </summary>
        /// <param name="self">The source expression to convert. Must not be null.</param>
        /// <param name="sourceType">The source type of the expression. Must not be null.</param>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <param name="context">An optional <see cref="ParameterExpression"/> representing the conversion context.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the conversion logic.
        /// </returns>
        /// <remarks>
        /// This method attempts to convert the source expression to the target type using custom conversion methods, generic type handling, or array conversions.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceExpression = Expression.Constant(42);
        /// var convertedExpression = sourceExpression.Convert(typeof(int), typeof(string), null);
        /// </code>
        /// </example>
        private static Expression Convert(this Expression self, Type sourceType, Type targetType, ParameterExpression? context)
        {

            Expression? result = null;

            if (targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType))
                return Expression.Convert(self, targetType);

            else if (ConverterHelper.TryGetMethodToConvert(sourceType, targetType, out MethodConverter? method))   // Find a registered method to convert
            {                                                                                   // method not found

                if (method == null)
                    throw new TargetInvocationException($"no method for manage conversion of {sourceType} to {targetType}. please use ConverterHelper for register a custom method", null);

                if (targetType.IsConstructedGenericType)                                        // generic
                    self = self.ConvertToGeneric(sourceType, targetType, context, ref method);

                else if (targetType.IsArray && targetType.GetArrayRank() == 1)                  // array of 1 rank
                    self = self.ConvertToArray(sourceType, targetType, context, ref method);

                else if (sourceType.IsEnum || targetType.IsEnum)                                // Target is enum
                    self = self.ConvertEnum(sourceType, targetType, context, ref method);

                if (method != null)
                    result = self.Convert(sourceType, method, context);

            }

            if (result == null)
                throw new TargetInvocationException($"no method for manage conversion of {sourceType} to {targetType}. please use ConverterHelper for register a custom method", null);

            return result;

        }

        private static Expression Convert(this Expression self, Type sourceType, MethodConverter me, ParameterExpression? context)
        {

            Expression result;

            var parameters = me.Method.GetParameters();
            Expression[] arguments = new Expression[parameters.Length];

            for (int index = 0; index < arguments.Length; index++)
                SetArgument(self, sourceType, parameters, arguments, index, me, context);

            if (me.Method is ConstructorInfo ctor)
                result = Expression.New(ctor, arguments);

            else
            {
                var m = (MethodInfo)me.Method;
                result = Expression.Call(m.IsStatic ? null : self, m, arguments);
            }

            return result;

        }

    }


}
