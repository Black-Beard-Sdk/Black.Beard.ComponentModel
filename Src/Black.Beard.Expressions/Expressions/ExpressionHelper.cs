using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bb.Expressions
{

    public static partial class ExpressionHelper
    {
            

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

            if (self.NodeType == ExpressionType.Lambda && self is LambdaExpression lambda)
                return lambda.ReturnType;
            
            return  self.Type;

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

        /// <summary>
        /// Create a loop with bloc
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static LoopExpression Loop(this Expression body)
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
        /// Return And expression '&amp;'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression And(this Expression left, Expression right)
        {
            return Expression.And(left, right);
        }

        /// <summary>
        /// return AndAlso expression '&amp;&amp;'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        /// <summary>
        /// return AndAssign expression '&amp;='
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
        /// return LeftShift expression '&lt;&lt;'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LeftShift(this Expression left, Expression right)
        {
            return Expression.LeftShift(left, right);
        }

        /// <summary>
        /// return LeftShiftAssign expression '&lt;&lt;='
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LeftShiftAssign(this Expression left, Expression right)
        {
            return Expression.LeftShiftAssign(left, right);
        }

        /// <summary>
        /// return LessThan expression '&lt;'
        /// </summary>
        /// <param name="left">Left expression</param>
        /// <param name="right">right expression</param>
        /// <returns><see cref="BinaryExpression"/></returns>
        public static BinaryExpression LessThan(this Expression left, Expression right)
        {
            return Expression.LessThan(left, right.ConvertIfDifferent(left.ResolveType()));
        }

        /// <summary>
        /// return LessThanOrEqual expression '&lt;='
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
                throw new ArgumentNullException(nameof(ctor));

            var result = Expression.New(ctor, args);

            return result;

        }





        /// <summary>
        /// Return a constant expression with type
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static ConstantExpression TypeAsConstant(this Type self)
        {
            return Expression.Constant(self);
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
