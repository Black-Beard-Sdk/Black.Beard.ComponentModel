using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bb.Exceptions;

namespace Bb.Expressions
{


    /// <summary>
    /// Helper class for creating and manipulating expression trees.
    /// </summary>
    public static partial class ExpressionHelper
    {


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
        /// Sorts the methods to find the best match based on the provided argument types.
        /// </summary>
        /// <param name="types">An array of argument types to match against the method signatures. Must not be null.</param>
        /// <param name="methods">A list of <see cref="MethodInfo"/> objects to evaluate. Must not be null.</param>
        /// <returns>
        /// A sorted <see cref="List{MethodInfo}"/> containing the methods ordered by their match score.
        /// </returns>
        /// <remarks>
        /// This method evaluates each method in the provided list against the argument types and assigns a score based on compatibility.
        /// Methods with higher compatibility are ranked higher in the returned list.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var methods = typeof(MyClass).GetMethods().ToList();
        /// var argumentTypes = new[] { typeof(int), typeof(string) };
        /// var sortedMethods = ExpressionHelper.SortBestMethod(argumentTypes, methods);
        /// </code>
        /// </example>
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
        /// Orders methods by their declaring type, prioritizing methods declared in the specified type.
        /// </summary>
        /// <param name="methods">A list of <see cref="MethodInfo"/> objects to sort. Must not be null.</param>
        /// <param name="type">The type to prioritize when ordering methods. Must not be null.</param>
        /// <returns>
        /// A <see cref="List{MethodInfo}"/> containing the methods ordered by their declaring type.
        /// </returns>
        /// <remarks>
        /// This method prioritizes methods declared in the specified type over methods declared in base types.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var methods = typeof(MyClass).GetMethods().ToList();
        /// var orderedMethods = methods.OrderMethods(typeof(MyClass));
        /// </code>
        /// </example>
        public static List<MethodInfo> OrderMethods(this List<MethodInfo> methods, Type type)
        {

            var currentType = type;
            while (currentType != null)
            {
                var _methods = methods.Where(c => c.DeclaringType == currentType).ToList();
                if (_methods.Count == 1)
                    return _methods;
                currentType = currentType.BaseType;
            }

            return methods;

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
        /// Builds the parameters for a method call expression by converting arguments to match the method's parameter types.
        /// </summary>
        /// <param name="arguments">An array of <see cref="Expression"/> objects representing the arguments to pass to the method. Must not be null.</param>
        /// <param name="method">The <see cref="MethodInfo"/> object representing the method to call. Must not be null.</param>
        /// <returns>
        /// An array of <see cref="Expression"/> objects representing the converted arguments.
        /// </returns>
        /// <remarks>
        /// This method ensures that the provided arguments are converted to match the parameter types of the specified method.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var method = typeof(MyClass).GetMethod("MyMethod");
        /// var arguments = new Expression[] { Expression.Constant(42), Expression.Constant("test") };
        /// var convertedArguments = ExpressionHelper.BuildParameters(arguments, method);
        /// </code>
        /// </example>
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
                    argument = argument.ConvertIfDifferent(parameter.ParameterType);
                else
                    return Array.Empty<Expression>();

                _args.Add(argument);
            }

            return _args.ToArray();

        }



        /// <summary>
        /// Evaluates whether the left expression can be assigned from the right expression.
        /// </summary>
        /// <param name="left">The left type expression. Must not be null.</param>
        /// <param name="right">The right type expression. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> that evaluates whether the left type can be assigned from the right type.
        /// </returns>
        /// <remarks>
        /// This method generates an expression that checks if the type represented by the left expression can be assigned from the type represented by the right expression.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when either the left or right expression has a type of <c>void</c>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var left = typeof(string).TypeAsConstant();
        /// var right = Expression.Constant(typeof(object));
        /// var result = left.CallIsAssignableFrom(right);
        /// </code>
        /// </example>
        public static Expression CallIsAssignableFrom(this Expression left, Expression right)
        {

            if (left.Type == typeof(void))
                throw new InvalidOperationException("void type is not assignable");
            if (right.Type == typeof(void))
                throw new InvalidOperationException("void type is not assignable");

            if (left.Type != typeof(Type))
                left = left.GetTypeExpression();

            if (right.Type != typeof(Type))
                right = right.GetTypeExpression();

            return left.Call(typeof(Type), nameof(Type.IsAssignableFrom), right);
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
        /// Evaluates whether the left expression can be assigned to the right expression.
        /// </summary>
        /// <param name="left">The left type expression. Must not be null.</param>
        /// <param name="right">The right type expression. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> that evaluates whether the left type can be assigned to the right type.
        /// </returns>
        /// <remarks>
        /// This method generates an expression that checks if the type represented by the left expression can be assigned to the type represented by the right expression.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var left = typeof(object).TypeAsConstant();
        /// var right = Expression.Constant(typeof(string));
        /// var result = left.CallIsAssignableTo(right);
        /// </code>
        /// </example>
        public static Expression CallIsAssignableTo(this Expression left, Expression right)
        {
            return left.GetTypeExpression().Call(typeof(Type), nameof(Type.IsAssignableTo), right);
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


    }


}
