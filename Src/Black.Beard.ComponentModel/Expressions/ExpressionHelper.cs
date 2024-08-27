using System;
using System.Linq.Expressions;
using Bb.Exceptions;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using ICSharpCode.Decompiler.TypeSystem;
using System.Xml.Linq;
using Bb.Converters;
using System.Text;

namespace Bb.Expressions
{

    public static class ExpressionHelper
    {

        /// <summary>
        /// Return the property name of the expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">expression that contains the property member</param>
        /// <returns>return the property name</returns>
        public static string GetPropertyName(this Expression expression)
        {
            return ExpressionMemberVisitor.GetPropertyName(expression);
        }

        /// <summary>
        /// create an expression that assign a value to a target
        /// </summary>
        /// <param name="left">left expression that must be assigned</param>
        /// <param name="right">value expression to assign</param>
        /// <returns></returns>
        public static BinaryExpression AssignFrom(this Expression left, Expression right)
        {
            return Expression.Assign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self">declaring type expression</param>
        /// <param name="propertyName">property name</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        public static MemberExpression Property(this Expression self, string propertyName)
        {
            var properties = self.Type.GetProperties();
            var property = properties.Where(c => c.Name == propertyName).FirstOrDefault();

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);
        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self">declaring type expression</param>
        /// <param name="propertyName">property name</param>
        /// <param name="binding">filter for resolve property</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        public static MemberExpression Property(this Expression self, string propertyName, BindingFlags binding)
        {

            var property = self.Type.GetProperty(propertyName, binding);

            if (property is null)
                throw new MissingMemberException(propertyName);

            return Property(self, property);
        }

        /// <summary>
        /// create a member expression from property
        /// </summary>
        /// <param name="self"></param>
        /// <param name="property">property</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static MemberExpression Property(this Expression self, PropertyInfo property)
        {
            if (property is null)
                throw new NullReferenceException(nameof(property));

            return Expression.Property(self, property);
        }

        /// <summary>
        /// Create a call method expression
        /// </summary>
        /// <param name="self">declaring instance expression</param>
        /// <param name="methodName">method name</param>
        /// <param name="arguments">arguments of the method</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        /// <exception cref="DuplicatedArgumentNameException"></exception>
        public static MethodCallExpression Call(this Expression self, string methodName, params Expression[] arguments)
        {

            var methods = self.Type.GetMethods().ToList();
            methods = methods.Where(c => c.Name == methodName).ToList();

            if (methods.Count == 0)
                throw new MissingMemberException(methodName);

            methods = methods.Where(c => c.GetParameters().Length == arguments.Length).ToList();
            if (methods.Count == 0)
                throw new MissingMemberException($"no method {methodName} match with specified arguments");

            if (methods.Count > 1)
                throw new DuplicatedArgumentNameException(methodName);

            var method = methods[0];

            var parameters = method.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }


            return Expression.Call(self, method, _args.ToArray());

        }

        /// <summary>
        /// Create a call method expression
        /// </summary>
        /// <param name="self">declaring instance expression</param>
        /// <param name="methodTarget">method member</param>
        /// <param name="arguments">arguments of the method</param>
        /// <returns></returns>
        public static MethodCallExpression Call(this Expression self, MethodInfo methodTarget, params Expression[] arguments)
        {

            var parameters = methodTarget.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }

            return Expression.Call(self, methodTarget, _args.ToArray());

        }

        /// <summary>
        /// Create a call method expression
        /// </summary>
        /// <param name="self">method</param>
        /// <param name="arguments">argument of the method</param>
        /// <returns></returns>
        public static MethodCallExpression Call(this MethodInfo self, params Expression[] arguments)
        {

            var parameters = self.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];
                if (argument != null && parameter != null)
                    _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));
                else
                    return null;

            }

            return Expression.Call(null, self, _args.ToArray());

        }

        /// <summary>
        /// Throw an exception
        /// </summary>
        /// <param name="type">type of expression</param>
        /// <param name="args">argument of the constructor</param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static UnaryExpression Throw(this Type type, params Expression[] args)
        {

            if (!typeof(Exception).IsAssignableFrom(type))
                throw new InvalidCastException($"{type.Name} don't inherit from Exception");

            var result = Expression.Throw(type.CreateObject(args), typeof(NullReferenceException));

            return result;

        }

        /// <summary>
        /// Resolve the type of the expression
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Type ResolveType(this Expression self)
        {

            return self.NodeType == ExpressionType.Lambda
                ? (self as LambdaExpression).ReturnType
                : self.Type;

        }

        /// <summary>
        /// return an expression array index
        /// </summary>
        /// <param name="self">array</param>
        /// <param name="index">index of the array</param>
        /// <returns></returns>
        public static IndexExpression ArrayIndex(this Expression self, Expression index)
        {
            return Expression.ArrayAccess(self, index);
        }


        #region Converters

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

            try
            {
                var e = Expression.Convert(Expression.Parameter(sourceType), targetType);
                return 1;
            }
            catch (Exception)
            {
                var result = ConverterHelper.GetMethodToConvert(sourceType, targetType, out var method);
                if (result)
                    return 2;
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

        #endregion Converters

        /// <summary>
        /// return a binary expression that compare the left and right expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <param name="type">right expression</param>
        /// <returns></returns>
        public static TypeBinaryExpression TypeEqual(this Expression left, Type type)
        {
            return Expression.TypeEqual(left, type);
        }

        /// <summary>
        /// Return an expression that evaluate if the left expression is of the type
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static TypeBinaryExpression TypeIs(this Expression left, Type type)
        {
            return Expression.TypeIs(left, type);
        }

        public static LoopExpression TypeIs(this Expression body)
        {
            return Expression.Loop(body);
        }


        #region Binary expressions

        /// <summary>
        /// Return add expression '+'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Add(this Expression left, Expression right)
        {
            return Expression.Add(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// Return add assign expression '+='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression AddAssign(this Expression left, Expression right)
        {
            return Expression.AddAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// Return And expression '&'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression And(this Expression left, Expression right)
        {
            return Expression.And(left, right);
        }

        /// <summary>
        /// return AndAlso expression '&&'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        /// <summary>
        /// return AndAssign expression '&='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression AndAssign(this Expression left, Expression right)
        {
            return Expression.AndAssign(left, right);
        }

        /// <summary>
        /// return Coalesce expression '??'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Coalesce(this Expression left, Expression right)
        {
            return Expression.Coalesce(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return Divide expression '/'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Divide(this Expression left, Expression right)
        {
            return Expression.Divide(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return DivideAssign expression '/='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression DivideAssign(this Expression left, Expression right)
        {
            return Expression.DivideAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return Equal expression '=='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Equal(this Expression left, Expression right)
        {
            return Expression.Equal(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return ExclusiveOr expression '||'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression ExclusiveOr(this Expression left, Expression right)
        {
            return Expression.ExclusiveOr(left, right);
        }

        /// <summary>
        /// return ExclusiveOrAssign expression '||='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression ExclusiveOrAssign(this Expression left, Expression right)
        {
            return Expression.ExclusiveOrAssign(left, right);
        }

        /// <summary>
        /// return GreaterThan expression '>'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return GreaterThanOrEqual expression '>='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression GreaterThanOrEqual(this Expression left, Expression right)
        {
            return Expression.GreaterThanOrEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return LeftShift expression '<<'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LeftShift(this Expression left, Expression right)
        {
            return Expression.LeftShift(left, right);
        }

        /// <summary>
        /// return LeftShiftAssign expression '<<='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LeftShiftAssign(this Expression left, Expression right)
        {
            return Expression.LeftShiftAssign(left, right);
        }

        /// <summary>
        /// return LessThan expression '<'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LessThan(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return LessThanOrEqual expression '<='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LessThanOrEqual(this Expression left, Expression right)
        {
            return Expression.LessThanOrEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return Modulo expression '%'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Modulo(this Expression left, Expression right)
        {
            return Expression.Modulo(left, right);
        }

        /// <summary>
        /// return ModuloAssign expression '%='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression ModuloAssign(this Expression left, Expression right)
        {
            return Expression.ModuloAssign(left, right);
        }

        /// <summary>
        /// return Multiply expression '*'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Multiply(this Expression left, Expression right)
        {
            return Expression.Multiply(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return MultiplyAssign expression '*='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression MultiplyAssign(this Expression left, Expression right)
        {
            return Expression.MultiplyAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return NotEqual expression '!='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression NotEqual(this Expression left, Expression right)
        {
            return Expression.NotEqual(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return Or expression '|'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Or(this Expression left, Expression right)
        {
            return Expression.Or(left, right);
        }

        /// <summary>
        /// return OrAssign expression '|='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression OrAssign(this Expression left, Expression right)
        {
            return Expression.OrAssign(left, right);
        }

        /// <summary>
        /// return OrElse expression '||'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression OrElse(this Expression left, Expression right)
        {
            return Expression.OrElse(left, right);
        }

        /// <summary>
        /// return Power expression '^'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Power(this Expression left, Expression right)
        {
            return Expression.Power(left, right);
        }

        /// <summary>
        /// return PowerAssign expression '^='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression PowerAssign(this Expression left, Expression right)
        {
            return Expression.PowerAssign(left, right);
        }

        /// <summary>
        /// return RightShift expression '>>'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression RightShift(this Expression left, Expression right)
        {
            return Expression.RightShift(left, right);
        }

        /// <summary>
        /// return RightShiftAssign expression '>>='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression RightShiftAssign(this Expression left, Expression right)
        {
            return Expression.RightShiftAssign(left, right);
        }

        /// <summary>
        /// return Subtract expression '-'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression Subtract(this Expression left, Expression right)
        {
            return Expression.Subtract(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return SubtractAssign expression '-='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression SubtractAssign(this Expression left, Expression right)
        {
            return Expression.SubtractAssign(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        #endregion Binary expressions


        #region Unary expression

        /// <summary>
        /// return a unary expression that convert the left expression in the target type
        /// </summary>
        /// <param name="left">left expression</param>
        /// <param name="type"> type to convert</param>
        /// <returns></returns>
        public static UnaryExpression TypeAs(this Expression left, Type type)
        {
            return Expression.TypeAs(left, type);
        }

        /// <summary>
        /// return a unary expression that decrement the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression Decrement(this Expression left)
        {
            return Expression.Decrement(left);
        }

        /// <summary>
        /// return a unary expression that post decrement the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression PostDecrementAssign(this Expression left)
        {
            return Expression.PostDecrementAssign(left);
        }

        /// <summary>
        /// return a unary expression that pre decrement the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression PreDecrementAssign(this Expression left)
        {
            return Expression.PreDecrementAssign(left);
        }

        /// <summary>
        /// return a unary expression that evaluate if the left expression is true
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression IsTrue(this Expression left)
        {
            return Expression.IsTrue(left);
        }

        /// <summary>
        /// return a unary expression that evaluate if the left expression is false
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression IsFalse(this Expression left)
        {
            return Expression.IsFalse(left);
        }

        /// <summary>
        /// return a not unary expression that negate the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression Not(this Expression left)
        {
            return Expression.Not(left);
        }

        /// <summary>
        /// return a unary expression that negate the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression Negate(this Expression left)
        {
            return Expression.Negate(left);
        }

        /// <summary>
        /// return a unary expression that increment the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression Increment(this Expression left)
        {
            return Expression.Increment(left);
        }

        /// <summary>
        /// return a unary expression that post increment the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression PostIncrementAssign(this Expression left)
        {
            return Expression.PostIncrementAssign(left);
        }

        /// <summary>
        /// return a unary expression that pre increment the left expression
        /// </summary>
        /// <param name="left">left expression</param>
        /// <returns></returns>
        public static UnaryExpression PreIncrementAssign(this Expression left)
        {
            return Expression.PreIncrementAssign(left);
        }

        #endregion Unary expression


        /// <summary>
        /// return a new array expression
        /// </summary>
        /// <param name="self"></param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static NewArrayExpression NewArray(this Type self, IEnumerable<Expression> expressions)
        {
            List<Expression> e = new List<Expression>(expressions.Count());
            foreach (var item in expressions)
                e.Add(item.ConvertIfDifferent(self));

            return Expression.NewArrayInit(self, e.ToArray());
        }

        /// <summary>
        /// return a new array expression
        /// </summary>
        /// <param name="self">type of the array</param>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static NewArrayExpression NewArray(this Type self, params Expression[] expressions)
        {
            List<Expression> e = new List<Expression>(expressions.Length);
            foreach (var item in expressions)
                e.Add(item.ConvertIfDifferent(self));

            return Expression.NewArrayInit(self, e.ToArray());
        }

        /// <summary>
        /// return a new object expression
        /// </summary>
        /// <param name="type">type of the array</param>
        /// <param name="args"></param>
        /// <returns></returns>
        /// <exception cref="MissingMethodException"></exception>
        public static NewExpression CreateObject(this Type type, params Expression[] args)
        {

            List<Type> _types = new List<Type>();
            foreach (var arg in args)
                _types.Add(arg.ResolveType());

            var ctor = type.GetConstructor(_types.ToArray());
            if (ctor == null)
                throw new MissingMethodException(string.Join(", ", _types.Select(c => c.Name)));

            var result = Expression.New(ctor, args);

            return result;

        }

        /// <summary>
        /// return a creation of object expression
        /// </summary>
        /// <param name="ctor"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static NewExpression CreateObject(this ConstructorInfo ctor, params Expression[] args)
        {

            if (ctor == null)
                throw new NullReferenceException(nameof(ctor));

            var result = Expression.New(ctor, args);

            return result;

        }



        /// <summary>
        /// return a constant expression
        /// </summary>
        /// <param name="self">object to convert to constant expression</param>
        /// <param name="type">target type of the expression</param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static ConstantExpression AsConstant(this object self, Type type = null)
        {

            if (self is Expression e)
            {
                if (e is ConstantExpression c)
                    return c;
                else
                    throw new InvalidCastException("an expression can't be converted in constant");
            }

            if (type == null)
                return Expression.Constant(self);

            if (self != null && self.GetType() != type && self is IConvertible)
                self = System.Convert.ChangeType(self, type);

            return Expression.Constant(self, type);

        }

        /// <summary>
        /// Make a call to a static method
        /// </summary>
        /// <param name="self">method member info</param>
        /// <param name="arguments">argument of the call expression</param>
        /// <returns></returns>
        public static MethodCallExpression CallStatic(this MethodInfo self, params Expression[] arguments)
        {

            var parameters = self.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);

            for (int i = 0; i < arguments.Length; i++)
            {
                var argument = arguments[i];
                var parameter = parameters[i];

                _args.Add(argument.ConvertIfDifferent(parameter.ParameterType));

            }

            return Expression.Call(self, _args.ToArray());

        }

        /// <summary>
        /// return a default expression
        /// </summary>
        /// <param name="self">target type</param>
        /// <returns></returns>
        public static DefaultExpression DefaultValue(this Type self)
        {
            return Expression.Default(self);
        }


    }


}
