using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// Represents a catch statement in a try-catch block.
    /// </summary>
    /// <remarks>
    /// When getting the value, if the body is null, a new instance of <see cref="SourceCode"/> is created and assigned.
    /// When setting the value, the parent of the body is automatically set if the parent is null.
    /// </remarks>
    /// <example>
    /// <code lang="C#">
    /// var catchStatement = new CatchStatement();
    /// catchStatement.Body = new SourceCode();
    /// Console.WriteLine(catchStatement.Body);
    /// </code>
    /// </example>

    public class CatchStatement : BodyStatement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CatchStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="CatchStatement"/> class with an empty body.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var catchStatement = new CatchStatement();
        /// catchStatement.TypeToCatch = typeof(Exception);
        /// catchStatement.Body = new SourceCode();
        /// </code>
        /// </example>
        public CatchStatement()
            : base()
        {
            TypeToCatch = typeof(Exception);
        }

        /// <summary>
        /// Gets or sets the type of exception to catch.
        /// </summary>
        /// <value>
        /// A <see cref="Type"/> object representing the type of exception to catch.
        /// </value>
        /// <remarks>
        /// This property specifies the type of exception that the catch block is designed to handle.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var catchStatement = new CatchStatement();
        /// catchStatement.TypeToCatch = typeof(ArgumentException);
        /// </code>
        /// </example>
        public Type TypeToCatch { get; set; }

        /// <summary>
        /// Gets or sets the parameter representing the caught exception.
        /// </summary>
        /// <value>
        /// A <see cref="ParameterExpression"/> object representing the caught exception.
        /// </value>
        /// <remarks>
        /// When getting the value, if the parameter is null, a new variable is added to the body for the exception type.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var catchStatement = new CatchStatement();
        /// catchStatement.TypeToCatch = typeof(Exception);
        /// var parameter = catchStatement.Parameter;
        /// Console.WriteLine(parameter.Name);
        /// </code>
        /// </example>
        public ParameterExpression Parameter 
        {
            get
            {
                if (_parameter == null)
                    _parameter = Body.AddVar(TypeToCatch);
                return _parameter;
            }
            set
            {
                _parameter = value;
            }
        }

        /// <summary>
        /// Generates the expression for the catch statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the catch block.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the catch block, including its body and any variables defined within it.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var catchStatement = new CatchStatement();
        /// catchStatement.TypeToCatch = typeof(Exception);
        /// var expression = catchStatement.GetExpression(new HashSet&lt;string&gt;());
        /// Console.WriteLine(expression);
        /// </code>
        /// </example>
        public override Expression GetExpression(HashSet<string> variableParent)
        {
            return Body.GetExpression(new HashSet<string>(variableParent));
        }


        private ParameterExpression? _parameter;

    }

}
