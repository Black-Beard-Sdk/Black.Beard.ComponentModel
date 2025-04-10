using System;

namespace Bb.Expressions.Statements
{


    /// <summary>
    /// Represents an abstract base class for statements that contain a body of source code.
    /// </summary>
    public abstract class BodyStatement : Statement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BodyStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the abstract class <see cref="BodyStatement"/>.
        /// It is intended to be used as a base class for statements that contain a body of source code.
        /// </remarks>
        protected BodyStatement()
        {
            this._body = new SourceCode();
        }

        /// <summary>
        /// Gets or sets the body of the statement.
        /// </summary>
        /// <value>
        /// A <see cref="SourceCode"/> object representing the body of the statement.
        /// </value>
        /// <remarks>
        /// When getting the value, if the body is null, a new instance of <see cref="SourceCode"/> is created and assigned.
        /// When setting the value, the parent of the body is automatically set if the parent is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var bodyStatement = new CustomBodyStatement();
        /// bodyStatement.Body = new SourceCode();
        /// Console.WriteLine(bodyStatement.Body);
        /// </code>
        /// </example>
        public SourceCode Body
        {
            get
            {
                if (_body == null)
                    _body = new SourceCode();
                return _body;
            }
            set
            {
                _body = value;
                if (this.ParentIsNull)
                    _body.SetParent(GetParent());
            }
        }

        /// <summary>
        /// Sets the parent of the current body statement.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> to set. Must not be null.</param>
        /// <remarks>
        /// This method assigns the specified <see cref="SourceCode"/> as the parent of the body statement.
        /// It ensures that the body is properly linked to its parent source code structure.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceCodes"/> is null.
        /// </exception>
        internal override void SetParent(SourceCode sourceCodes)
        {
            if (_body == null)
                throw new ArgumentNullException(nameof(sourceCodes), "Parent source code cannot be null.");
            _body.SetParent(sourceCodes);
        }

        private SourceCode? _body;

    }
}
