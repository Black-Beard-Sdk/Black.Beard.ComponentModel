// Ignore Spelling: Catchs

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Bb.Expressions.Statements
{

    /// <summary>
    /// represents a try statement in a programming language.
    /// </summary>
    public class TryStatement : BodyStatement
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TryStatement"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new instance of the <see cref="TryStatement"/> class with an empty list of catch statements.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// tryStatement.Body = new SourceCode();
        /// tryStatement.Finally = new SourceCode();
        /// </code>
        /// </example>
        public TryStatement()
        {
            this._catchs = new List<CatchStatement>();
        }

        /// <summary>
        /// Adds a catch block to the try statement for the default exception type (<see cref="Exception"/>).
        /// </summary>
        /// <returns>
        /// A <see cref="CatchStatement"/> representing the newly added catch block.
        /// </returns>
        /// <remarks>
        /// This method creates a catch block that handles exceptions of type <see cref="Exception"/> and adds it to the try statement.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// var catchBlock = tryStatement.Catch();
        /// catchBlock.Body = new SourceCode();
        /// </code>
        /// </example>
        public CatchStatement Catch()
        {
            return Catch(typeof(Exception));
        }

        /// <summary>
        /// Adds a catch block to the try statement for a specific exception type.
        /// </summary>
        /// <param name="self">The type of exception to catch. Must not be null.</param>
        /// <returns>
        /// A <see cref="CatchStatement"/> representing the newly added catch block.
        /// </returns>
        /// <remarks>
        /// This method creates a catch block that handles exceptions of the specified type and adds it to the try statement.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="self"/> is null.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// var catchBlock = tryStatement.Catch(typeof(ArgumentException));
        /// catchBlock.Body = new SourceCode();
        /// </code>
        /// </example>
        public CatchStatement Catch(Type self)
        {
            var result = new CatchStatement()
            {
                TypeToCatch = self,
            };

            this._catchs.Add(result);

            if (this.ParentIsNull)
                result.SetParent(this.GetParent());

            return result;
        }

        /// <summary>
        /// Gets the collection of catch blocks associated with the try statement.
        /// </summary>
        /// <value>
        /// An <see cref="IEnumerable{CatchStatement}"/> containing all the catch blocks in the try statement.
        /// </value>
        /// <remarks>
        /// This property provides access to the list of catch blocks defined for the try statement.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// foreach (var catchBlock in tryStatement.Catchs)
        /// {
        ///     Console.WriteLine(catchBlock.TypeToCatch);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<CatchStatement> Catchs { get => _catchs; }

        /// <summary>
        /// Gets or sets the "Finally" block of the try statement.
        /// </summary>
        /// <value>
        /// A <see cref="SourceCode"/> object representing the body of the "Finally" block.
        /// </value>
        /// <remarks>
        /// When getting the value, if the "Finally" block is null, a new instance of <see cref="SourceCode"/> is created and assigned.
        /// When setting the value, the parent of the "Finally" block is automatically set if the parent is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// tryStatement.Finally = new SourceCode();
        /// </code>
        /// </example>
        public SourceCode Finally
        {
            get
            {
                if (_finally == null)
                    _finally = new SourceCode();
                return _finally;
            }
            set
            {
                _finally = value;
                if (this.ParentIsNull)
                    _finally.SetParent(this.GetParent());
            }
        }

        /// <summary>
        /// Generates the expression for the try statement.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>
        /// An <see cref="Expression"/> representing the try statement, including its body, catch blocks, and finally block if defined.
        /// </returns>
        /// <remarks>
        /// This method generates the expression tree for the try statement. It includes the try block, all associated catch blocks, and the finally block if it is defined.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var tryStatement = new TryStatement();
        /// tryStatement.Body = new SourceCode();
        /// tryStatement.Finally = new SourceCode();
        /// var expression = tryStatement.GetExpression(new HashSet&lt;string&gt;());
        /// </code>
        /// </example>
        public override Expression GetExpression(HashSet<string> variableParent)
        {
            List<CatchBlock> _catchs1 = new List<CatchBlock>();
            Expression resultExpression;
            Expression? expressionFinaly = null;

            Expression? expressionTry = Body.GetExpression(new HashSet<string>(variableParent));

            if (expressionTry == null)
                throw new Exceptions.InvalidArgumentNameException($"the bloc must contains a boby");

            foreach (CatchStatement @catch in Catchs)
            {
                CatchBlock c;
                if (@catch.Parameter != null)
                {

                    if (!string.IsNullOrEmpty(@catch.Parameter.Name))
                        variableParent.Add(@catch.Parameter.Name);

                    @catch.Body.AddVarIfNotExists(@catch.Parameter);
                    var body = @catch.GetExpression(variableParent);

                    if (body  == null)
                        throw new Exceptions.InvalidArgumentNameException($"the bloc must contains a bobt");

                    c = Expression.Catch(@catch.Parameter, body);

                    if (!string.IsNullOrEmpty(@catch.Parameter.Name))
                        variableParent.Remove(@catch.Parameter.Name);
                }
                else
                {
                    var body = @catch.GetExpression(variableParent);

                    if (body == null)
                        throw new Exceptions.InvalidArgumentNameException($"the bloc must contains a bobt");

                    c = Expression.Catch(@catch.TypeToCatch, body);

                }
                _catchs1.Add(c);
            }

            if (_finally != null)
                expressionFinaly = _finally.GetExpression(new HashSet<string>(variableParent));

            if (expressionFinaly != null)
            {
                if (_catchs1.Count > 0)
                    resultExpression = Expression.TryCatchFinally(expressionTry, expressionFinaly, _catchs1.ToArray());
                else
                    resultExpression = Expression.TryFinally(expressionTry, expressionFinaly);
            }
            else
                resultExpression = Expression.TryCatch(expressionTry, _catchs1.ToArray());

            if (resultExpression.CanReduce)
                resultExpression = resultExpression.Reduce();

            return resultExpression;
        }

        /// <summary>
        /// Sets the parent of the current try statement.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> to set. Must not be null.</param>
        /// <remarks>
        /// This method assigns the specified <see cref="SourceCode"/> as the parent of the try statement, including its body, catch blocks, and finally block.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="sourceCodes"/> is null.
        /// </exception>
        internal override void SetParent(SourceCode sourceCodes)
        {
            base.SetParent(sourceCodes);
            _finally?.SetParent(sourceCodes);
            foreach (var item in Catchs)
                item.SetParent(sourceCodes);
        }

        private SourceCode? _finally;
        private readonly List<CatchStatement> _catchs;
    }

}
