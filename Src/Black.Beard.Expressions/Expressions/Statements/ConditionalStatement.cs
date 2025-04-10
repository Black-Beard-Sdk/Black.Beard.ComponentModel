using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// Represents a conditional statement with "Then" and "Else" blocks.
    /// </summary>
    public class ConditionalStatement : Statement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="ConditionalStatement"/> class with no conditional expression or body.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var conditionalStatement = new ConditionalStatement();
        /// conditionalStatement.ConditionalExpression = Expression.Constant(true);
        /// conditionalStatement.Then = new SourceCode();
        /// conditionalStatement.Else = new SourceCode();
        /// </code>
        /// </example>
        public ConditionalStatement()
        {
            ConditionalExpression = Expression.Constant(true);
        }

        /// <summary>
        /// Gets or sets the conditional expression for the statement.
        /// </summary>
        /// <value>
        /// An <see cref="Expression"/> representing the condition to evaluate.
        /// </value>
        /// <remarks>
        /// This property specifies the condition that determines whether the "Then" or "Else" block is executed.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var conditionalStatement = new ConditionalStatement();
        /// conditionalStatement.ConditionalExpression = Expression.Equal(Expression.Constant(1), Expression.Constant(1));
        /// </code>
        /// </example>
        public Expression ConditionalExpression { get; set; }

        /// <summary>
        /// Gets or sets the "Then" block of the conditional statement.
        /// </summary>
        /// <value>
        /// A <see cref="SourceCode"/> object representing the body of the "Then" block.
        /// </value>
        /// <remarks>
        /// When getting the value, if the "Then" block is null, a new instance of <see cref="SourceCode"/> is created and assigned.
        /// When setting the value, the parent of the "Then" block is automatically set if the parent is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var conditionalStatement = new ConditionalStatement();
        /// conditionalStatement.Then = new SourceCode();
        /// </code>
        /// </example>
        public SourceCode Then
        {
            get
            {
                if (_then == null)
                    _then = new SourceCode();
                return _then;
            }
            set
            {
                _then = value;
                if (this.ParentIsNull)
                    _then?.SetParent(this.GetParent());
            }
        }

        /// <summary>
        /// Gets or sets the "Else" block of the conditional statement.
        /// </summary>
        /// <value>
        /// A <see cref="SourceCode"/> object representing the body of the "Else" block.
        /// </value>
        /// <remarks>
        /// When getting the value, if the "Else" block is null, a new instance of <see cref="SourceCode"/> is created and assigned.
        /// When setting the value, the parent of the "Else" block is automatically set if the parent is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var conditionalStatement = new ConditionalStatement();
        /// conditionalStatement.Else = new SourceCode();
        /// </code>
        /// </example>
        public SourceCode Else
        {
            get
            {
                _else ??= new SourceCode();
                return _else;
            }
            set
            {
                _else = value;
                if (this.ParentIsNull)
                    _else.SetParent(this.GetParent());
            }
        }

        /// <summary>
        /// Generates the expression for the conditional statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the conditional statement.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the conditional statement, including its "Then" and "Else" blocks.
        /// If the "Else" block is null, the generated expression will be an "IfThen" expression; otherwise, it will be an "IfThenElse" expression.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var conditionalStatement = new ConditionalStatement();
        /// conditionalStatement.ConditionalExpression = Expression.Constant(true);
        /// conditionalStatement.Then = new SourceCode();
        /// var expression = conditionalStatement.GetExpression(new HashSet&lt;string&gt;());
        /// Console.WriteLine(expression);
        /// </code>
        /// </example>
        public override Expression? GetExpression(HashSet<string> variableParent)
        {

            ConditionalExpression? expression = null;
            Expression? b1 = _then != null ? _then.GetExpression(new HashSet<string>(variableParent)) : null;
            Expression? b2 = _else != null ? _else.GetExpression(new HashSet<string>(variableParent)) : null;

            if (b1 == null && b2 == null)
                return null;

            else if (b1 != null && b2 == null)
                expression = Expression.IfThen(ConditionalExpression, b1);

            else if (b1 == null && b2 != null)
                expression = Expression.IfThen(ConditionalExpression.Not(), b2);

            else
            {
                if (b1 == null) b1 = Expression.Empty();
                if (b2 == null) b2 = Expression.Empty();
                expression = Expression.IfThenElse(ConditionalExpression, b1, b2);
            }
            if (expression.CanReduce)
                return expression.Reduce();


            return expression;
        }

        /// <summary>
        /// Sets the parent of the current conditional statement.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> to set. Must not be null.</param>
        /// <remarks>
        /// This method assigns the specified <see cref="SourceCode"/> as the parent of the "Then" and "Else" blocks of the conditional statement.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceCodes"/> is null.
        /// </exception>
        internal override void SetParent(SourceCode sourceCodes)
        {
            _then?.SetParent(sourceCodes);
            if (_else != null)
                _else.SetParent(sourceCodes);
        }

        private SourceCode? _then;
        private SourceCode? _else;

    }

}
