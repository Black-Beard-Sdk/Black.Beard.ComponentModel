using Bb.Expressions.Statements;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{

    /// <summary>
    /// Represents a collection of source code statements.
    /// </summary>
    public partial class SourceCode : ICollection<Statement>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceCode"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the variables and labels collections.
        /// </remarks>
        public SourceCode()
        {
            _variables = new Variables();
            _labels = new Labels();
        }

        /// <summary>
        /// Adds one or more statements to the source code.
        /// </summary>
        /// <param name="statements">The statements to add. Must not be null.</param>
        /// <returns>The current <see cref="SourceCode"/> instance.</returns>
        /// <remarks>
        /// This method appends the provided statements to the internal collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Add(new Statement(), new Statement());
        /// </code>
        /// </example>
        public SourceCode Add(params Statement[] statements)
        {
            foreach (var statement in statements)
                Add(statement);

            return this;
        }

        /// <summary>
        /// Gets the expression tree for the current source code.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>An <see cref="Expression"/> representing the source code.</returns>
        /// <remarks>
        /// This method generates an expression tree based on the statements in the source code.
        /// </remarks>
        internal Expression? GetExpression(HashSet<string> variableParent)
        {
            Expression? expression = null;

            if (this._statements.Count == 1)
                expression = this._statements[0].GetExpression(variableParent);
            else
                expression = GetBlock(variableParent);

            if (expression != null && expression.CanReduce)
                expression = expression.Reduce();

            return expression;
        }

        /// <summary>
        /// Gets the collection of variables in the source code.
        /// </summary>
        /// <value>An enumerable collection of <see cref="ParameterExpression"/> objects.</value>
        /// <remarks>
        /// This property provides access to all variables defined in the source code.
        /// </remarks>
        public IEnumerable<ParameterExpression> Variables { get => this._variables.Items.Select(c => c.Instance); }

        /// <summary>
        /// Gets the last statement added to the source code.
        /// </summary>
        /// <value>The last <see cref="Statement"/> added.</value>
        /// <remarks>
        /// This property keeps track of the most recently added statement.
        /// </remarks>
        public Statement? LastStatement { get; private set; }

        /// <summary>
        /// Gets the last variable added to the source code.
        /// </summary>
        /// <value>The last <see cref="ParameterExpression"/> added.</value>
        /// <remarks>
        /// This property keeps track of the most recently added variable.
        /// </remarks>
        public ParameterExpression? LastVariable { get; private set; }

        /// <summary>
        /// Generates a block expression from the current statements.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>A <see cref="BlockExpression"/> representing the statements.</returns>
        /// <remarks>
        /// This method creates a block expression that includes all statements and variables in the current scope.
        /// </remarks>
        private BlockExpression GetBlock(HashSet<string> variableParent)
        {
            ParameterExpression[] __variables = CleanVariables(variableParent);

            var __list = new List<Expression>(this._statements.Count + 10);
            foreach (Statement statement in this._statements)
            {
                var e = statement.GetExpression(variableParent);
                if (e != null)
                    __list.Add(e);
            }
            return Expression.Block(__variables, __list.ToArray());
        }

        /// <summary>
        /// Sets the parent source code for the current instance.
        /// </summary>
        /// <param name="sourceCodes">The parent <see cref="SourceCode"/> instance. Must not be null.</param>
        /// <remarks>
        /// This method establishes a parent-child relationship between source code instances.
        /// </remarks>
        internal void SetParent(SourceCode sourceCodes)
        {
            this._parent = sourceCodes;
            _variables.SetParent(sourceCodes._variables);
            _labels.SetParent(sourceCodes._labels);
        }

        /// <summary>
        /// Merges the specified source code into the current instance.
        /// </summary>
        /// <param name="source">The source code to merge. Must not be null.</param>
        /// <remarks>
        /// This method combines variables, labels, and statements from the specified source code into the current instance.
        /// </remarks>
        public void Merge(SourceCode source)
        {
            this._variables.Merge(source._variables);
            this._labels.Merge(source._labels);

            foreach (var item in source._statements)
                this.Add(item);
        }

        /// <summary>
        /// Cleans the variables by removing duplicates based on the parent scope.
        /// </summary>
        /// <param name="variableParent">A set of variable names from the parent scope. Must not be null.</param>
        /// <returns>An array of <see cref="ParameterExpression"/> objects representing the cleaned variables.</returns>
        /// <remarks>
        /// This method ensures that variables in the current scope do not conflict with those in the parent scope.
        /// </remarks>
        protected ParameterExpression[] CleanVariables(HashSet<string> variableParent)
        {
            var v = this._variables.Items.ToList();
            foreach (var item in v.Select(c => c.Name))
                if (!(variableParent.Add(item)))
                    this._variables.RemoveByName(item);

            var __variables = this._variables.Items.Select(c => c.Instance).ToArray();

            return __variables;
        }

        /// <summary>
        /// Adds a statement to the source code.
        /// </summary>
        /// <param name="statement">The statement to add. Must not be null.</param>
        /// <remarks>
        /// This method appends the provided statement to the internal collection and sets it as the last statement.
        /// </remarks>
        public void Add(Statement statement)
        {
            statement.SetParent(this);
            _statements.Add(statement);
            this.LastStatement = statement;
        }

        /// <summary>
        /// Clears all statements from the source code.
        /// </summary>
        /// <remarks>
        /// This method removes all statements from the internal collection.
        /// </remarks>
        public void Clear()
        {
            _statements.Clear();
        }

        /// <summary>
        /// Determines whether the source code contains the specified statement.
        /// </summary>
        /// <param name="item">The statement to locate. Must not be null.</param>
        /// <returns><see langword="true"/> if the statement is found; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method checks whether the specified statement exists in the internal collection.
        /// </remarks>
        public bool Contains(Statement item)
        {
            return _statements.Contains(item);
        }

        /// <summary>
        /// Copies the statements to an array, starting at the specified index.
        /// </summary>
        /// <param name="array">The destination array. Must not be null.</param>
        /// <param name="arrayIndex">The zero-based index in the array at which copying begins.</param>
        /// <remarks>
        /// This method copies the statements from the internal collection to the specified array.
        /// </remarks>
        public void CopyTo(Statement[] array, int arrayIndex)
        {
            _statements.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified statement from the source code.
        /// </summary>
        /// <param name="item">The statement to remove. Must not be null.</param>
        /// <returns><see langword="true"/> if the statement was successfully removed; otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method removes the specified statement from the internal collection.
        /// </remarks>
        public bool Remove(Statement item)
        {
            return _statements.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the statements in the source code.
        /// </summary>
        /// <returns>An enumerator for the statements.</returns>
        /// <remarks>
        /// This method provides an enumerator for iterating through the internal collection of statements.
        /// </remarks>
        public IEnumerator<Statement> GetEnumerator()
        {
            return _statements.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the statements in the source code.
        /// </summary>
        /// <returns>An enumerator for the statements.</returns>
        /// <remarks>
        /// This method provides a non-generic enumerator for iterating through the internal collection of statements.
        /// </remarks>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _statements.GetEnumerator();
        }

        /// <summary>
        /// Gets the number of statements in the source code.
        /// </summary>
        /// <value>The number of statements.</value>
        /// <remarks>
        /// This property returns the count of statements in the internal collection.
        /// </remarks>
        public int Count => _statements.Count;

        /// <summary>
        /// Gets a value indicating whether the source code is read-only.
        /// </summary>
        /// <value>Always returns <see langword="false"/>.</value>
        /// <remarks>
        /// This property indicates that the source code is not read-only.
        /// </remarks>
        public bool IsReadOnly => false;

        /// <summary>
        /// Implicitly converts an <see cref="Expression"/> to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="expression">The expression to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the expression.</returns>
        public static implicit operator SourceCode(Expression expression)
        {
            var src = new SourceCode();
            src.Add(expression);
            return src;
        }

        /// <summary>
        /// Implicitly converts an array of <see cref="Expression"/> objects to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="expressions">The expressions to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the expressions.</returns>
        public static implicit operator SourceCode(Expression[] expressions)
        {
            var src = new SourceCode();
            foreach (var item in expressions)
                src.Add(item);
            return src;
        }

        /// <summary>
        /// Implicitly converts a list of <see cref="Expression"/> objects to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="expressions">The expressions to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the expressions.</returns>
        public static implicit operator SourceCode(List<Expression> expressions)
        {
            var src = new SourceCode();
            foreach (var item in expressions)
                src.Add(item);
            return src;
        }

        /// <summary>
        /// Implicitly converts a <see cref="Statement"/> to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="expression">The statement to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the statement.</returns>
        public static implicit operator SourceCode(Statement expression)
        {
            var src = new SourceCode();
            src.Add(expression);
            return src;
        }

        /// <summary>
        /// Implicitly converts an array of <see cref="Statement"/> objects to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="statements">The statements to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the statements.</returns>
        public static implicit operator SourceCode(Statement[] statements)
        {
            var src = new SourceCode();
            foreach (var item in statements)
                src.Add(item);
            return src;
        }

        /// <summary>
        /// Implicitly converts a list of <see cref="Statement"/> objects to a <see cref="SourceCode"/>.
        /// </summary>
        /// <param name="statements">The statements to convert.</param>
        /// <returns>A new <see cref="SourceCode"/> instance containing the statements.</returns>
        public static implicit operator SourceCode(List<Statement> statements)
        {
            var src = new SourceCode();
            foreach (var item in statements)
                src.Add(item);
            return src;
        }

        /// <summary>
        /// Gets the variables and labels used in the expression tree.
        /// </summary>
        protected Variables _variables;

        /// <summary>
        /// Gets the labels used in the expression tree.
        /// </summary>
        protected Labels _labels;

        private SourceCode? _parent;
        private List<Statement> _statements = new List<Statement>();

    }

}
