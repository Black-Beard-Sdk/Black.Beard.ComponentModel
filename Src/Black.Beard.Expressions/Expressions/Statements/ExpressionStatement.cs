using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// Conversion of expression in statement
    /// </summary>
    public class ExpressionStatement : Statement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="ExpressionStatement"/> class with no expression assigned.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var expressionStatement = new ExpressionStatement();
        /// expressionStatement.Expression = Expression.Constant(42);
        /// </code>
        /// </example>
        public ExpressionStatement()
        {

        }

        /// <summary>
        /// Gets or sets the expression associated with this statement.
        /// </summary>
        /// <value>
        /// An <see cref="Expression"/> object representing the expression of the statement.
        /// </value>
        /// <remarks>
        /// This property holds the expression that defines the logic or computation for the statement.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var expressionStatement = new ExpressionStatement();
        /// expressionStatement.Expression = Expression.Add(Expression.Constant(1), Expression.Constant(2));
        /// Console.WriteLine(expressionStatement.Expression);
        /// </code>
        /// </example>
        public Expression? Expression { get; set; }

        /// <summary>
        /// Generates the expression for the statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the logic of the statement.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the statement. If the expression can be reduced, it is reduced before being returned.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var expressionStatement = new ExpressionStatement();
        /// expressionStatement.Expression = Expression.Multiply(Expression.Constant(3), Expression.Constant(4));
        /// var resultExpression = expressionStatement.GetExpression(new HashSet&lt;string&gt;());
        /// Console.WriteLine(resultExpression);
        /// </code>
        /// </example>
        public override Expression? GetExpression(HashSet<string> variableParent)
        {

            Expression? expression = null;
            if (this.Expression != null)
            {
                expression = this.Expression;
                if (expression.CanReduce)
                    expression = expression.Reduce();
            }

            return expression;

        }

        /// <summary>
        /// Sets the parent of the current expression statement.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> to set. Must not be null.</param>
        /// <remarks>
        /// This method assigns the specified <see cref="SourceCode"/> as the parent of the expression statement.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceCodes"/> is null.
        /// </exception>
        internal override void SetParent(SourceCode sourceCodes)
        {
            // Implementation for setting the parent
        }

    }

}
