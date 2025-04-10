using System;
using System.Linq.Expressions;

namespace Bb.Expressions
{
    public class Variable
    {

        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        /// <remarks>
        /// This property represents the unique identifier for the variable.
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type of the variable.
        /// </summary>
        /// <remarks>
        /// This property specifies the data type of the variable.
        /// </remarks>
        public Type Type { get; set; }

        /// <summary>
        /// Gets the <see cref="ParameterExpression"/> instance associated with the variable.
        /// </summary>
        /// <remarks>
        /// This property provides access to the underlying expression tree representation of the variable.
        /// </remarks>
        public ParameterExpression Instance { get; internal set; }

    }

}
