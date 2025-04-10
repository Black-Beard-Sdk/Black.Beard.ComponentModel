using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// Represents an abstract statement in a programming language.
    /// </summary>
    public abstract class Statement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Statement"/> class.
        /// </summary>
        public Statement()
        {

        }

        /// <summary>
        /// Gets or sets the expression associated with this statement.
        /// </summary>
        /// <param name="variableParent"></param>
        /// <returns></returns>
        public abstract Expression? GetExpression(HashSet<string> variableParent);

        /// <summary>
        /// Implicitly converts an <see cref="Expression"/> to a <see cref="Statement"/>.
        /// </summary>
        /// <param name="expression"></param>
        public static implicit operator Statement(Expression expression)
        {
            return new ExpressionStatement() { Expression = expression };
        }

        /// <summary>
        /// Sets the parent of the current statement.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> to set. Must not be null.</param>
        /// <remarks>
        /// This method assigns the specified <see cref="SourceCode"/> as the parent of the current statement.
        /// It is used to establish a hierarchical relationship between statements and their parent source code.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceCodes"/> is null.
        /// </exception>
        internal virtual void SetParent(SourceCode sourceCodes)
        {

            if (sourceCodes == null)
                throw new ArgumentNullException(nameof(sourceCodes), "The parent source code cannot be null.");

            _parent = sourceCodes;
        
        }

        /// <summary>
        /// Gets the parent of the current statement.
        /// </summary>
        /// <returns>
        /// The <see cref="SourceCode"/> object representing the parent of the current statement.
        /// </returns>
        /// <remarks>
        /// This method retrieves the parent source code associated with the current statement.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var statement = new CustomStatement();
        /// statement.SetParent(new SourceCode());
        /// var parent = statement.GetParent();
        /// Console.WriteLine(parent);
        /// </code>
        /// </example>
        internal SourceCode GetParent()
        {
            return _parent;
        }

        /// <summary>
        /// Gets a value indicating whether the parent of the current statement is null.
        /// </summary>
        /// <value>
        /// <c>true</c> if the parent is not null; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// This property checks whether the current statement has a parent source code assigned.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var statement = new CustomStatement();
        /// Console.WriteLine(statement.ParentIsNull); // Output: false (if no parent is set)
        /// </code>
        /// </example>
        internal bool ParentIsNull { get => _parent != null; }

        private SourceCode? _parent;

    }


}
