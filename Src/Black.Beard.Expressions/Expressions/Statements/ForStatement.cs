using Bb.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{
    /// <summary>
    /// for statement.
    /// </summary>
    public class ForStatement : LoopStatement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ForStatement"/> class.
        /// </summary>
        /// <param name="InitialExpression">The initial expression to execute before the loop starts. Must not be null.</param>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="ForStatement"/> class with the specified initial expression.
        /// The initial expression is executed once before the loop begins.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var initialExpression = Expression.Assign(Expression.Variable(typeof(int), "i"), Expression.Constant(0));
        /// var forStatement = new ForStatement(initialExpression);
        /// forStatement.Index = Expression.Variable(typeof(int), "i");
        /// forStatement.MoveIndex = Expression.PostIncrementAssign(forStatement.Index);
        /// </code>
        /// </example>
        public ForStatement(Expression InitialExpression)
        {
        }

        /// <summary>
        /// Gets or sets the index variable used in the loop.
        /// </summary>
        /// <value>
        /// A <see cref="ParameterExpression"/> representing the index variable of the loop.
        /// </value>
        /// <remarks>
        /// This property specifies the variable that is used as the index in the loop.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var forStatement = new ForStatement(initialExpression);
        /// forStatement.Index = Expression.Variable(typeof(int), "i");
        /// </code>
        /// </example>
        public ParameterExpression? Index { get; set; }

        /// <summary>
        /// Gets or sets the expression that updates the index variable in each iteration of the loop.
        /// </summary>
        /// <value>
        /// An <see cref="Expression"/> representing the logic to update the index variable.
        /// </value>
        /// <remarks>
        /// This property specifies the expression that is executed at the end of each loop iteration to update the index variable.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var forStatement = new ForStatement(initialExpression);
        /// forStatement.MoveIndex = Expression.PostIncrementAssign(forStatement.Index);
        /// </code>
        /// </example>
        public Expression? MoveIndex { get; set; }

        /// <summary>
        /// Generates the expression for the "for" loop statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the "for" loop statement.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the "for" loop, including the initial expression, the loop body, and the index update expression.
        /// </remarks>
        /// <exception cref="NotSettedExpressionException">
        /// Thrown when <see cref="MoveIndex"/> is null.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var initialExpression = Expression.Assign(Expression.Variable(typeof(int), "i"), Expression.Constant(0));
        /// var forStatement = new ForStatement(initialExpression);
        /// forStatement.Index = Expression.Variable(typeof(int), "i");
        /// forStatement.MoveIndex = Expression.PostIncrementAssign(forStatement.Index);
        /// var loopExpression = forStatement.GetExpression(new HashSet&lt;string&gt;());
        /// </code>
        /// </example>
        public override Expression GetExpression(HashSet<string> variableParent)
        {
            if (MoveIndex == null)
                throw new NotSettedExpressionException(nameof(MoveIndex));

            Body.Add(MoveIndex);

            return base.GetExpression(variableParent);
        }

    }

}
