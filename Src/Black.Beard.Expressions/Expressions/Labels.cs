using System.Collections.Generic;
using System.Linq;

namespace Bb.Expressions
{

    /// <summary>
    /// This class manages the labels used in the expression tree.
    /// </summary>
    public class Labels
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Labels"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes an empty collection of labels.
        /// </remarks>
        public Labels()
        {
            this._labels = new Dictionary<string, Label>();
        }

        /// <summary>
        /// Adds a label to the collection.
        /// </summary>
        /// <param name="label">The label to add.</param>
        /// <remarks>
        /// If the label's kind is not <see cref="KindLabel.Default"/> and a label of the same kind already exists, an exception is thrown.
        /// If the label's name is null or empty, a new name is generated.
        /// </remarks>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown if a label of the same kind already exists in the collection.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var labels = new Labels();
        /// labels.Add(new Label { Name = "Label1", Kind = KindLabel.Default });
        /// </code>
        /// </example>
        public void Add(Label label)
        {

            if (label.Kind != KindLabel.Default && this._labels.Values.Any(c => c.Kind == label.Kind))
                throw new Exceptions.DuplicatedArgumentNameException($"the bloc contains already label of type {label.Kind.ToString()}");

            if (string.IsNullOrEmpty(label.Name))
                label.Name = GetNewName();

            this._labels.Add(label.Name, label);

        }

        /// <summary>
        /// Retrieves a label by its name.
        /// </summary>
        /// <param name="name">The name of the label to retrieve.</param>
        /// <returns>The label with the specified name, or <c>null</c> if not found.</returns>
        /// <remarks>
        /// If the label is not found in the current collection, the method searches in the parent collection, if available.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var label = labels.GetByName("Label1");
        /// </code>
        /// </example>
        public Label? GetByName(string name)
        {

            if (!this._labels.TryGetValue(name, out Label? label) && _parent != null)
                label = _parent.GetByName(name);

            return label;
        }

        /// <summary>
        /// Generates a new unique name for a label.
        /// </summary>
        /// <returns>A new unique label name.</returns>
        /// <remarks>
        /// The generated name is in the format "label_{index}" where {index} is a unique number.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string newName = Labels.GetNewName();
        /// Console.WriteLine(newName); // Output: "label_1"
        /// </code>
        /// </example>
        public static string GetNewName()
        {
            return $"label_{PrivatesIndex.GetNewIndex()}";
        }

        /// <summary>
        /// Removes a label by its name.
        /// </summary>
        /// <param name="name">The name of the label to remove.</param>
        /// <remarks>
        /// If the label exists in the current collection, it is removed. If not, the method attempts to remove it from the parent collection, if available.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// labels.RemoveByName("Label1");
        /// </code>
        /// </example>
        public void RemoveByName(string name)
        {

            if (this._labels.ContainsKey(name))
                this._labels.Remove(name);

            if (_parent != null)
                _parent.RemoveByName(name);

        }

        /// <summary>
        /// Gets all labels in the current collection.
        /// </summary>
        /// <returns>An enumerable collection of labels.</returns>
        /// <example>
        /// <code lang="C#">
        /// foreach (var label in labels.Items)
        /// {
        ///     Console.WriteLine(label.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<Label> Items { get => this._labels.Values; }

        /// <summary>
        /// Merges another <see cref="Labels"/> collection into the current collection.
        /// </summary>
        /// <param name="labels">The collection of labels to merge.</param>
        /// <remarks>
        /// This method adds all labels from the specified collection to the current collection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// labels.Merge(otherLabels);
        /// </code>
        /// </example>
        public void Merge(Labels labels)
        {
            foreach (var item in labels.Items)
                this.Add(item);
        }

        /// <summary>
        /// Retrieves all labels in the current collection and its parent collection.
        /// </summary>
        /// <returns>An enumerable collection of labels.</returns>
        /// <remarks>
        /// This method combines labels from the current collection and its parent collection, if available.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// foreach (var label in labels.GetLabels())
        /// {
        ///     Console.WriteLine(label.Name);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<Label> GetLabels()
        {

            foreach (var item in this._labels)
                yield return item.Value;

            if (_parent != null)
                foreach (var item in _parent.GetLabels())
                    yield return item;

        }

        /// <summary>
        /// Sets the parent collection for the current <see cref="Labels"/> instance.
        /// </summary>
        /// <param name="labels">The parent collection to set.</param>
        /// <remarks>
        /// This method validates the labels in the parent collection to ensure no duplicates exist in the current collection.
        /// </remarks>
        /// <exception cref="Exceptions.DuplicatedArgumentNameException">
        /// Thrown if a label with the same name but a different instance already exists in the current collection.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// labels.SetParent(parentLabels);
        /// </code>
        /// </example>
        public void SetParent(Labels labels)
        {

            this._parent = null;

            foreach (var item in labels.GetLabels())
            {

                if (string.IsNullOrEmpty(item.Name))
                    item.Name = GetNewName();

                var item2 = this.GetByName(item.Name);
                if (item2 != null)
                {
                    if (item2.Instance == item.Instance)
                        RemoveByName(item.Name);
                    else
                        throw new Exceptions.DuplicatedArgumentNameException($"{item.Name} already existing");
                }

            }

            this._parent = labels;

        }

        private readonly Dictionary<string, Label> _labels;
        private Labels? _parent;

    }

}
