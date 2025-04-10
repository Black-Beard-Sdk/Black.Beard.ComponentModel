using Bb.Exceptions;
using Bb.Expressions.Statements;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Bb.Expressions
{

    public partial class SourceCode
    {


        #region Exceptions

        /// <summary>
        /// Creates a try statement with the specified expressions as its body.
        /// </summary>
        /// <param name="expressions">The expressions to include in the try block. Must not be null.</param>
        /// <returns>The created <see cref="TryStatement"/>.</returns>
        /// <remarks>
        /// This method creates a try statement and adds the specified expressions to its body.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Try(Expression.Constant(1), Expression.Constant(2));
        /// </code>
        /// </example>
        public TryStatement Try(params Expression[] expressions)
        {
            var t = Try();
            foreach (var item in expressions)
                t.Body.Add(item);
            return t;
        }

        /// <summary>
        /// Creates an empty try statement.
        /// </summary>
        /// <returns>The created <see cref="TryStatement"/>.</returns>
        /// <remarks>
        /// This method creates a try statement with an empty body.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// var tryStatement = sourceCode.Try();
        /// </code>
        /// </example>
        public TryStatement Try()
        {
            return Try(new SourceCode());
        }

        /// <summary>
        /// Creates a try statement with the specified source code as its body.
        /// </summary>
        /// <param name="self">The source code to use as the body of the try statement. Must not be null.</param>
        /// <returns>The created <see cref="TryStatement"/>.</returns>
        /// <remarks>
        /// This method creates a try statement and sets the specified source code as its body.
        /// </remarks>
        public TryStatement Try(SourceCode self)
        {

            self._parent = this;

            var tryStatement = new TryStatement()
            {
                Body = self,
            };

            this.Add(tryStatement);

            return tryStatement;

        }

        /// <summary>
        /// Adds a re-throw statement to the source code.
        /// </summary>
        /// <returns>The current <see cref="SourceCode"/> instance.</returns>
        /// <remarks>
        /// This method adds a re throw statement to the source code, which re-throws the current exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Rethrow();
        /// </code>
        /// </example>
        public SourceCode ReThrow()
        {
            this.Add(Expression.Rethrow());
            return this;
        }

        #endregion Exceptions


        #region Goto

        /// <summary>
        /// Adds a break statement to the source code.
        /// </summary>
        /// <returns>The created <see cref="GotoStatement"/> representing the break statement.</returns>
        /// <remarks>
        /// This method adds a break statement to the source code, which exits the current loop or switch statement.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Break();
        /// </code>
        /// </example>
        public GotoStatement Break()
        {
            var label = this.GetLabelImpl(KindLabel.Break);
            var l = new GotoStatement() { Label = label };
            Add(l);
            return l;
        }

        /// <summary>
        /// Adds a continue statement to the source code.
        /// </summary>
        /// <returns>The created <see cref="GotoStatement"/> representing the continue statement.</returns>
        /// <remarks>
        /// This method adds a continue statement to the source code, which skips the remaining loop body and starts the next iteration.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Continue();
        /// </code>
        /// </example>
        public GotoStatement Continue()
        {
            var label = this.GetLabelImpl(KindLabel.Continue);
            var l = new GotoStatement() { Label = label };
            Add(l);
            return l;
        }

        /// <summary>
        /// Adds a return statement with the specified expression to the source code.
        /// </summary>
        /// <param name="return">The expression to return. Must not be null.</param>
        /// <returns>The created <see cref="GotoStatement"/> representing the return statement.</returns>
        /// <remarks>
        /// This method adds a return statement to the source code, which exits the current method or function.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.Return(Expression.Constant(42));
        /// </code>
        /// </example>
        public GotoStatement Return(Expression @return)
        {
            var label = this.GetLabelImpl(KindLabel.Return);
            var l = new GotoStatement() { Label = label, Expression = @return, };
            Add(l);
            return l;

        }

        private Label GetLabelImpl(KindLabel kind)
        {

            Label? label = this._labels.Items.FirstOrDefault(c => c.Kind == kind);

            if (label == null && _parent == null)
                label = _parent.GetLabelImpl(kind);

            if (label == null)
                throw new Exceptions.InvalidArgumentNameException($"no label of {kind.ToString()} defined");

            return label;

        }

        #region Labels 

        /// <summary>
        /// Adds a label to the source code.
        /// </summary>
        /// <param name="name">The name of the label. Can be null.</param>
        /// <param name="kind">The kind of the label. Defaults to <see cref="KindLabel.Default"/>.</param>
        /// <returns>The created <see cref="Label"/>.</returns>
        /// <remarks>
        /// This method creates a label and adds it to the source code.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var sourceCode = new SourceCode();
        /// sourceCode.AddLabel("MyLabel", KindLabel.Break);
        /// </code>
        /// </example>
        public Label AddLabel(string? name = null, KindLabel kind = KindLabel.Default)
        {

            if (string.IsNullOrEmpty(name))
                name = Labels.GetNewName();

            var instance = Expression.Label(name);

            var label = new Label() { Instance = instance, Kind = kind, Name = name };
            this.AddLabel(label);

            return label;
        }

        /// <summary>
        /// Adds an existing label to the source code.
        /// </summary>
        /// <param name="label">The label to add. Must not be null.</param>
        /// <returns>The added <see cref="Label"/>.</returns>
        /// <remarks>
        /// This method adds an existing label to the source code.
        /// </remarks>
        public Label AddLabel(Label label)
        {
            this._labels.Add(label);
            return label;
        }

        #endregion Labels 

        #endregion Goto


        #region variables

        /// <summary>
        /// return a new name for a variable.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static string GetUniqueVariableName(string prefix)
        {
            return SourceCodeExtension.GetNewName(prefix);
        }

        /// <summary>
        /// Adds a variable to the source code if it does not already exist.
        /// </summary>
        /// <param name="parameter">The parameter expression representing the variable. Must not be null.</param>
        /// <returns>The added or existing <see cref="ParameterExpression"/>.</returns>
        /// <remarks>
        /// This method ensures that the variable is added only if it does not already exist in the source code.
        /// </remarks>
        public ParameterExpression AddVarIfNotExists(ParameterExpression parameter)
        {

            if (string.IsNullOrEmpty(parameter.Name))
                throw new InvalidArgumentNameException("parameter.Name");

            var vari = this.GetVar(parameter.Name);
            if (vari == null)
                this.AddVar(parameter);

            return parameter;

        }

        /// <summary>
        /// Adds a variable to the source code if it does not already exist, using the specified type and name.
        /// </summary>
        /// <param name="type">The type of the variable. Must not be null.</param>
        /// <param name="name">The name of the variable. Can be null.</param>
        /// <returns>The added or existing <see cref="ParameterExpression"/>.</returns>
        /// <remarks>
        /// This method ensures that the variable is added only if it does not already exist in the source code.
        /// </remarks>
        public ParameterExpression AddVarIfNotExists(Type type, string name)
        {

            var variable = this.GetVar(name);
            if (variable != null)
                return variable;

            if (string.IsNullOrEmpty(name))
                name = SourceCodeExtension.GetNewName(type);

            var instance = Expression.Parameter(type, name);
            this.AddVar(instance);

            return instance;

        }

        /// <summary>
        /// Adds a variable to the source code with the specified type, name, and optional initialization expression.
        /// </summary>
        /// <param name="type">The type of the variable. Must not be null.</param>
        /// <param name="name">The name of the variable. Can be null.</param>
        /// <param name="initialization">The initialization expression for the variable. Can be null.</param>
        /// <returns>The added <see cref="ParameterExpression"/>.</returns>
        /// <remarks>
        /// This method creates a variable and optionally initializes it with the specified expression.
        /// </remarks>
        public ParameterExpression AddVar(Type type, string? name = null, Expression? initialization = null)
        {

            if (string.IsNullOrEmpty(name))
                name = SourceCodeExtension.GetNewName(type);

            var instance = Expression.Parameter(type, name);
            this.AddVar(instance);

            if (initialization != null)
                this.Assign(instance, initialization);

            return instance;
        }

        /// <summary>
        /// Adds an existing parameter expression as a variable to the source code.
        /// </summary>
        /// <param name="arg">The parameter expression to add. Must not be null.</param>
        /// <returns>The added <see cref="ParameterExpression"/>.</returns>
        /// <remarks>
        /// This method adds an existing parameter expression to the source code as a variable.
        /// </remarks>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown when a variable with the same name but a different instance already exists.
        /// </exception>
        public ParameterExpression AddVar(ParameterExpression arg)
        {

            if (string.IsNullOrEmpty(arg.Name))
                throw new InvalidOperationException("arg.Name");

            var vari = this._variables.GetByName(arg.Name);
            if (vari != null)
            {
                if (vari.Instance != arg)
                    throw new Exceptions.DuplicatedArgumentNameException($"parameter {arg.Name} already exists");
            }
            else
            {
                vari = new Variable() { Name = arg.Name, Instance = arg };
                this._variables.Add(vari);
                this.LastVariable = arg;
            }

            return vari.Instance;

        }

        /// <summary>
        /// Retrieves a variable by its name.
        /// </summary>
        /// <param name="name">The name of the variable to retrieve. Must not be null.</param>
        /// <returns>The <see cref="ParameterExpression"/> representing the variable, or <see langword="null"/> if not found.</returns>
        /// <remarks>
        /// This method searches for a variable by its name in the current and parent source code.
        /// </remarks>
        public virtual ParameterExpression GetVar(string name)
        {

            var variable = _variables.GetByName(name);
            
            if (variable == null && _parent != null)
                return _parent.GetVar(name);

            if (variable == null)
                throw new InvalidOperationException($"variable {name} not found");

            return variable.Instance;

        }

        #endregion variables



    }


}
