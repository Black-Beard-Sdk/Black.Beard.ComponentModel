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
            {

                methods = methods.OrderMethods(type);
                if (methods.Count > 1)
                {
                    var m = GetBestMethod(arguments, methods);
                    if (m != null)
                        return Call(self, m, arguments);
                    throw new DuplicatedArgumentNameException(methodName);
                }

            }

            return Call(self, methods[0], arguments);

        }

        /// <summary>
        /// Sort the best method that match withe parameters 
        /// </summary>
        /// <param name="arguments">expression to passes</param>
        /// <param name="methods">methods to evaluate</param>
        /// <returns></returns>
        public static List<MethodInfo> SortBestMethod(Expression[] arguments, List<MethodInfo> methods)
        {
            var types = arguments.Select(c => c.Type).ToArray();
            return SortBestMethod(types, methods);
        }

        /// <summary>
        /// Sort the best method that match withe parameters
        /// </summary>
        /// <param name="types">type to match</param>
        /// <param name="methods">methods to evaluate</param>
        /// <returns></returns>
        public static List<MethodInfo> SortBestMethod(Type[] types, List<MethodInfo> methods)
        {

            var s = new List<(int, MethodInfo)>(methods.Count);

            foreach (var method in methods)
            {
                var score = Evaluate(types, method);
                if (score > 0)
                    s.Add((score, method));
            }

            return s.OrderBy(c => c.Item1).Select(c => c.Item2).ToList();

        }

        /// <summary>
        /// Return the best method that match withe parameters
        /// </summary>
        /// <param name="arguments">expression to passes</param>
        /// <param name="methods">methods to evaluate</param>
        /// <returns></returns>
        public static MethodInfo GetBestMethod(Expression[] arguments, List<MethodInfo> methods)
        {
            var types = arguments.Select(c => c.Type).ToArray();
            return GetBestMethod(types, methods);
        }

        /// <summary>
        /// Return the best method that match withe parameters
        /// </summary>
        /// <param name="types">type to match</param>
        /// <param name="methods">methods to evaluate</param>
        /// <returns></returns>
        public static MethodInfo GetBestMethod(Type[] types, List<MethodInfo> methods)
        {

            var s = new List<(int, MethodInfo)>(methods.Count);

            foreach (var method in methods)
            {
                var score = Evaluate(types, method);
                if (score == 0)
                    return method;
                if (score > 0)
                    s.Add((score, method));
            }

            return s.OrderBy(c => c.Item1).First().Item2;

        }

        private static int Evaluate(Type[] arguments, MethodInfo method)
        {

            var parameters = method.GetParameters();
            int[] ints = new int[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i].ParameterType;
                var argument = arguments[i];

                if (parameter == argument)
                    ints[i] = 0;

                else if (parameter.IsAssignableFrom(argument))
                    ints[i] = 100;

                else if (parameter != argument)
                    return -1;

            }

            return ints.Sum();

        }

        /// <summary>
        /// Order methods by declaring type
        /// </summary>
        /// <param name="methods">method to sort</param>
        /// <param name="type">first type</param>
        /// <returns></returns>
        public static List<MethodInfo> OrderMethods(this List<MethodInfo> methods, Type type)
        {

            var currentType = type;
            while (currentType != null)
            {
                var _methods = methods.Where(c => c.DeclaringType == currentType).ToList();
                if (_methods.Count == 1)
                {
                    return _methods;
                    break;
                }
                currentType = currentType.BaseType;
            }

            return methods;

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
