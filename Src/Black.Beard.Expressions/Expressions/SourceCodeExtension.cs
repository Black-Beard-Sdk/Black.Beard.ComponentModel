using Bb.Expressions.Statements;
using System;
using System.Linq.Expressions;

namespace Bb.Expressions
{

    /// <summary>
    /// Provides extension methods for the <see cref="SourceCode"/> class.
    /// </summary>
    public static partial class SourceCodeExtension
    {



        /// <summary>
        /// Generates a new unique variable name with the specified prefix.
        /// </summary>
        /// <param name="prefix">The prefix for the new variable name. Must not be null.</param>
        /// <returns>A unique variable name.</returns>
        /// <remarks>
        /// The generated name is based on the provided prefix and an internal index.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the prefix is null.
        /// </exception>
        internal static string GetNewName(string prefix)
        {
            if (prefix == null)
                throw new InvalidOperationException(nameof(prefix));
            else
            {
                var o = $"{prefix}{PrivatesIndex.GetNewIndex()}";
                return o;
            }

        }

        /// <summary>
        /// Generates a ne
        /// w unique variable name based on the specified type.
        /// </summary>
        /// <param name="type">The type to use for generating the variable name. Can be null.</param>
        /// <returns>A unique variable name.</returns>
        /// <remarks>
        /// If the type is null, a generic variable name is generated.
        /// </remarks>
        internal static string GetNewName(Type? type = null)
        {
            if (type == null)
                return $"var_{PrivatesIndex.GetNewIndex()}";
            else
            {
                var o = $"var_{CleanName(type)}{PrivatesIndex.GetNewIndex()}";
                return o;
            }
        }

        /// <summary>
        /// Cleans the name of a type by replacing invalid characters.
        /// </summary>
        /// <param name="type">The type whose name needs to be cleaned. Must not be null.</param>
        /// <returns>A cleaned type name.</returns>
        /// <remarks>
        /// Replaces invalid characters in the type name to make it suitable for use in variable names.
        /// </remarks>
        private static string CleanName(Type type)
        {
            var result = type.Name;
            result = result.Replace("`", "_");
            return result;
        }



        /// <summary>
        /// Assigns the value of the right expression to the left expression.
        /// </summary>
        /// <param name="source">The source code to which the assignment statement is added. Must not be null.</param>
        /// <param name="left">The left-hand side expression of the assignment. Must not be null.</param>
        /// <param name="right">The right-hand side expression of the assignment. Must not be null.</param>
        /// <returns>The updated <see cref="SourceCode"/> instance.</returns>
        /// <remarks>
        /// This method creates an assignment statement and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Assign(Expression.Variable(typeof(int), "x"), Expression.Constant(10));
        /// </code>
        /// </example>
        public static SourceCode Assign(this SourceCode source, Expression left, Expression right)
        {
            source.Add(left.AssignFrom(right));
            return source;
        }

        /// <summary>
        /// Creates an if statement with a test condition and a set of then statements.
        /// </summary>
        /// <param name="source">The source code to which the if statement is added. Must not be null.</param>
        /// <param name="test">The condition to evaluate. Must not be null.</param>
        /// <param name="thenCodes">The statements to execute if the condition is true. Must not be null.</param>
        /// <returns>The created <see cref="ConditionalStatement"/>.</returns>
        /// <remarks>
        /// This method creates an if statement and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.If(Expression.Constant(true), new Statement());
        /// </code>
        /// </example>
        public static ConditionalStatement If(this SourceCode source, Expression test, params Statement[] thenCodes)
        {
            return source.If(test, thenCodes, null);
        }

        /// <summary>
        /// Creates an if-else statement with a test condition, then statements, and else statements.
        /// </summary>
        /// <param name="source">The source code to which the if-else statement is added. Must not be null.</param>
        /// <param name="test">The condition to evaluate. Must not be null.</param>
        /// <param name="then">The source code to execute if the condition is true. Can be null.</param>
        /// <param name="else">The source code to execute if the condition is false. Can be null.</param>
        /// <returns>The created <see cref="ConditionalStatement"/>.</returns>
        /// <remarks>
        /// This method creates an if-else statement and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.If(Expression.Constant(true), new SourceCode(), new SourceCode());
        /// </code>
        /// </example>
        public static ConditionalStatement If(this SourceCode source, Expression test, SourceCode? @then, SourceCode? @else)
        {

            var n = new ConditionalStatement()
            {
                ConditionalExpression = test,
            };

            if (@then != null)
                n.Then.Merge(@then);

            if (@else != null)
                n.Else.Merge(@else);

            source.Add(n);

            return n;

        }

        /// <summary>
        /// Creates a for loop statement with an initial value and an end condition.
        /// </summary>
        /// <param name="source">The source code to which the for loop is added. Must not be null.</param>
        /// <param name="initialValueExpression">The initial value expression for the loop index. Must not be null.</param>
        /// <param name="endValueExpression">The end condition expression for the loop. Must not be null.</param>
        /// <returns>The created <see cref="ForStatement"/>.</returns>
        /// <remarks>
        /// This method creates a for loop statement and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.For(Expression.Constant(0), Expression.Constant(10));
        /// </code>
        /// </example>
        public static ForStatement For(this SourceCode source, Expression initialValueExpression, Expression endValueExpression)
        {

            var Index = source.AddVar(typeof(int), null, initialValueExpression);

            var loop = new ForStatement(initialValueExpression)
            {
                Condition = Expression.LessThan(Index, endValueExpression),
                Index = Index,
                MoveIndex = Index.PostIncrementAssign(),
            };
            source.Add(loop);

            return loop;

        }

        /// <summary>
        /// Creates a while loop statement with a condition.
        /// </summary>
        /// <param name="source">The source code to which the while loop is added. Must not be null.</param>
        /// <param name="conditionExpression">The condition expression for the loop. Must not be null.</param>
        /// <returns>The created <see cref="LoopStatement"/>.</returns>
        /// <remarks>
        /// This method creates a while loop statement and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.While(Expression.Constant(true));
        /// </code>
        /// </example>
        public static LoopStatement While(this SourceCode source, Expression conditionExpression)
        {

            var loop = new LoopStatement()
            {
                Condition = conditionExpression
            };
            source.Add(loop);

            return loop;

        }

    }

}
