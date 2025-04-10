using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// Represents a loop statement in a programming language.
    /// </summary>
    public class LoopStatement : BodyStatement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="LoopStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="LoopStatement"/> class with a body and labels for break and continue operations.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loopStatement = new LoopStatement();
        /// loopStatement.Condition = Expression.Constant(true);
        /// loopStatement.Body = new SourceCode();
        /// </code>
        /// </example>
        public LoopStatement()
        {
            this.Body = new SourceCode();
            this._breakLabel = this.Body.AddLabel(Labels.GetNewName(), KindLabel.Break);
            this._continueLabel = this.Body.AddLabel(Labels.GetNewName(), KindLabel.Continue);
            Condition = Expression.Constant(true);

        }

        /// <summary>
        /// Gets or sets the condition for the loop.
        /// </summary>
        /// <value>
        /// An <see cref="Expression"/> representing the condition to evaluate for each iteration of the loop.
        /// </value>
        /// <remarks>
        /// This property specifies the condition that determines whether the loop continues or exits.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loopStatement = new LoopStatement();
        /// loopStatement.Condition = Expression.LessThan(Expression.Variable(typeof(int), "i"), Expression.Constant(10));
        /// </code>
        /// </example>
        public Expression Condition { get; set; }

        /// <summary>
        /// Generates the expression for the loop statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the loop statement.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the loop, including the body and the condition.
        /// The loop continues as long as the condition evaluates to true.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loopStatement = new LoopStatement();
        /// loopStatement.Condition = Expression.Constant(true);
        /// var loopExpression = loopStatement.GetExpression(new HashSet&lt;string&gt;());
        /// </code>
        /// </example>
        public override Expression GetExpression(HashSet<string> variableParent)
        {
            Expression? b1 = Body.GetExpression(new HashSet<string>(variableParent));
            if (b1.CanReduce)
                b1 = b1.Reduce();
            if (Condition == null)
                Condition = Expression.Constant(true);
            var @if = Expression.IfThenElse(Condition, b1, GenerateBreak());
            var expression = Expression.Loop(@if, this._breakLabel.Instance, this._continueLabel.Instance);
            return expression;
        }

        /// <summary>
        /// Generates a break expression for the loop.
        /// </summary>
        /// <returns>
        /// A <see cref="GotoExpression"/> that represents the break operation for the loop.
        /// </returns>
        /// <remarks>
        /// This method creates a break expression that exits the loop when executed.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loopStatement = new LoopStatement();
        /// var breakExpression = loopStatement.GenerateBreak();
        /// </code>
        /// </example>
        public GotoExpression GenerateBreak()
        {

            if (this._breakLabel.Instance == null)
                throw new Exceptions.DuplicatedArgumentNameException("the bloc does not contain a break label");

            return Expression.Break(_breakLabel.Instance);
        }

        /// <summary>
        /// Generates a continue expression for the loop.
        /// </summary>
        /// <returns>
        /// A <see cref="GotoExpression"/> that represents the continue operation for the loop.
        /// </returns>
        /// <remarks>
        /// This method creates a continue expression that skips the remaining body of the loop and starts the next iteration.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var loopStatement = new LoopStatement();
        /// var continueExpression = loopStatement.GenerateContinue();
        /// </code>
        /// </example>
        public GotoExpression GenerateContinue()
        {

            if (_continueLabel.Instance == null)
                throw new Exceptions.DuplicatedArgumentNameException("the bloc does not contain a continue label");

            return Expression.Break(_continueLabel.Instance);

        }

        private readonly Label _breakLabel;
        private readonly Label _continueLabel;

    }

}
