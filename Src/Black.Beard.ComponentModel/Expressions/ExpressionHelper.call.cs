﻿using System;
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
            var type = self.Type;
            return Call(self, type, methodName, arguments);
        }

        /// <summary>
        /// Create a call method expression
        /// </summary>
        /// <param name="self">declaring instance expression</param>
        /// <param name="type">type that contains the method</param>
        /// <param name="methodName">method name</param>
        /// <param name="arguments">arguments of the method</param>
        /// <returns></returns>
        /// <exception cref="MissingMemberException"></exception>
        /// <exception cref="DuplicatedArgumentNameException"></exception>
        public static MethodCallExpression Call(this Expression self, Type type, string methodName, params Expression[] arguments)
        {

            var methods = type.GetMethods().ToList();
            methods = methods.Where(c => c.Name == methodName).ToList();

            if (methods.Count == 0)
                throw new MissingMemberException(methodName);

            methods = methods.Where(c => c.GetParameters().Length == arguments.Length).ToList();
            if (methods.Count == 0)
                throw new MissingMemberException($"no method {methodName} match with specified arguments");

            if (methods.Count > 1)
                throw new DuplicatedArgumentNameException(methodName);

            return Call(self, methods[0], arguments);

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
            Expression[] _args = BuildParameters(arguments, methodTarget);
            return Expression.Call(self, methodTarget, _args);
        }

        /// <summary>
        /// Create a call for static method
        /// </summary>
        /// <param name="self">method</param>
        /// <param name="arguments">argument of the method</param>
        /// <returns></returns>
        public static MethodCallExpression Call(this MethodInfo self, params Expression[] arguments)
        {
            Expression[] _args = BuildParameters(arguments, self);
            return Expression.Call(self, _args.ToArray());

        }

        /// <summary>
        /// Make a call to a static method
        /// </summary>
        /// <param name="self">method member info</param>
        /// <param name="arguments">argument of the call expression</param>
        /// <returns></returns>
        public static MethodCallExpression CallStatic(this MethodInfo self, params Expression[] arguments)
        {
            Expression[] _args = BuildParameters(arguments, self);
            return Expression.Call(self, _args.ToArray());
        }



        private static Expression[] BuildParameters(Expression[] arguments, MethodInfo method)
        {

            var parameters = method.GetParameters()
              .ToArray();

            List<Expression> _args = new List<Expression>(arguments.Length);
            for (int i = 0; i < arguments.Length; i++)
            {

                var argument = arguments[i];
                var parameter = parameters[i];

                if (argument != null && parameter != null)
                {

                    if (parameter.ParameterType == typeof(Type))
                        argument = argument.GetTypeExpression();
                    
                    else 
                        argument = argument.ConvertIfDifferent(parameter.ParameterType);

                }
                else
                    return null;

                _args.Add(argument);
            }

            return _args.ToArray();

        }



        /// <summary>
        /// Evaluate the left expression can be assigned from right expression
        /// </summary>
        /// <param name="left">left type expression</param>
        /// <param name="right">right type expression</param>
        /// <returns></returns>
        public static Expression CallIsAssignableFrom(this Type left, Expression right)
        {
            return left.TypeAsConstant().CallIsAssignableFrom(right);
        }

        /// <summary>
        /// Evaluate the left expression can be assigned from right expression
        /// </summary>
        /// <param name="left">left type expression</param>
        /// <param name="right">right type expression</param>
        /// <returns></returns>
        public static Expression CallIsAssignableFrom(this Expression left, Expression right)
        {
            return left.GetTypeExpression().Call(typeof(Type), nameof(Type.IsAssignableFrom), right);
        }

        /// <summary>
        /// Evaluate the left expression can be assigned to right expression
        /// </summary>
        /// <param name="left">left type expression</param>
        /// <param name="right">right type expression</param>
        /// <returns></returns>
        public static Expression CallIsAssignableTo(this Type left, Expression right)
        {
            return left.TypeAsConstant().CallIsAssignableTo(right);
        }

        /// <summary>
        /// Evaluate the left expression can be assigned to right expression
        /// </summary>
        /// <param name="left">left type expression</param>
        /// <param name="right">right type expression</param>
        /// <returns></returns>
        public static Expression CallIsAssignableTo(this Expression left, Expression right)
        {
            return left.GetTypeExpression().Call(typeof(Type), nameof(Type.IsAssignableTo), right);
        }


    }


}