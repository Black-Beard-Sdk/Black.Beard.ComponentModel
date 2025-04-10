using System;
using System.Collections.Generic;

namespace Bb.Expressions
{

    /// <summary>
    /// Represents a collection of variables used in expression trees.
    /// </summary>
    public class Variables
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Variables"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes an empty dictionary to store variables.
        /// </remarks>
        public Variables()
        {
            this._variables = new Dictionary<string, Variable>();
        }

        /// <summary>
        /// Adds a variable to the collection.
        /// </summary>
        /// <param name="variable">The variable to add. Must not be null.</param>
        /// <returns>The added variable.</returns>
        /// <remarks>
        /// If the variable already exists, it checks for conflicts and throws an exception if necessary.
        /// </remarks>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown when a variable with the same name but a different instance already exists.
        /// </exception>
        internal Variable Add(Variable variable)
        {

            if (variable.Type == null)
                variable.Type = variable.Instance.Type;

            var variable2 = GetByName(variable.Name);

            if (variable2 == null)
                this._variables.Add(variable.Name, variable);

            else if (variable.Instance != variable2.Instance)
                throw new Exceptions.DuplicatedArgumentNameException($"{variable.Name} already existing");

            return variable;

        }

        /// <summary>
        /// Retrieves a variable by its name.
        /// </summary>
        /// <param name="name">The name of the variable to retrieve. Must not be null.</param>
        /// <returns>The variable if found; otherwise, <see langword="null"/>.</returns>
        /// <remarks>
        /// Searches the current collection and its parent for the specified variable.
        /// </remarks>
        internal Variable? GetByName(string name)
        {

            if (this._variables.TryGetValue(name, out Variable? variable))
            {
                if (variable.Type == null && variable.Instance != null)
                    variable.Type = variable.Instance.Type;

                return variable;

            }

            if (_parent != null)
                return _parent.GetByName(name);

            return null;

        }

        /// <summary>
        /// Gets all variables in the collection, including those from the parent collection.
        /// </summary>
        /// <returns>An enumerable collection of variables.</returns>
        /// <remarks>
        /// This method combines variables from the current collection and its parent.
        /// </remarks>
        public IEnumerable<Variable> GetVariables()
        {

            foreach (var item in this._variables)
                yield return item.Value;

            if (_parent != null)
                foreach (var item in _parent.GetVariables())
                    yield return item;

        }

        /// <summary>
        /// Removes a variable by its name.
        /// </summary>
        /// <param name="name">The name of the variable to remove. Must not be null.</param>
        /// <remarks>
        /// This method removes the variable from the current collection and its parent, if applicable.
        /// </remarks>
        internal void RemoveByName(string name)
        {
            if (this._variables.ContainsKey(name))
                this._variables.Remove(name);

            if (_parent != null)
                _parent.RemoveByName(name);

        }

        /// <summary>
        /// Gets the collection of variables in the current scope.
        /// </summary>
        /// <remarks>
        /// This property provides access to the variables stored in the current collection.
        /// </remarks>
        internal IEnumerable<Variable> Items { get => this._variables.Values; }

        /// <summary>
        /// Merges the specified variables into the current collection.
        /// </summary>
        /// <param name="variables">The variables to merge. Must not be null.</param>
        /// <remarks>
        /// Adds all variables from the specified collection to the current collection.
        /// </remarks>
        internal void Merge(Variables variables)
        {
            if (variables != this)
                foreach (var item in variables.Items)
                    this.Add(item);
        }

        /// <summary>
        /// Sets the parent collection for the current variables.
        /// </summary>
        /// <param name="variables">The parent variables collection. Must not be null.</param>
        /// <remarks>
        /// Ensures that there are no conflicts between the current collection and the parent collection.
        /// </remarks>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown when a variable with the same name but a different instance exists in the parent collection.
        /// </exception>
        internal void SetParent(Variables variables)
        {

            this._parent = null;

            foreach (var item in variables.GetVariables())
            {
                var item2 = this.GetByName(item.Name);
                if (item2 != null)
                {
                    if (item2.Instance == item.Instance)
                        RemoveByName(item.Name);
                    else
                        throw new Exceptions.DuplicatedArgumentNameException($"{item.Name} already existings");
                }
            }

            this._parent = variables;

        }

        private readonly Dictionary<string, Variable> _variables;
        private Variables? _parent;

    }

}
