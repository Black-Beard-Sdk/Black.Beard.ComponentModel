using Bb.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Provides a base class for implementing list providers with generic support.
    /// </summary>
    /// <typeparam name="T">The type of the items in the list.</typeparam>
    public abstract class ProviderListBase<T> : IListProvider
    {

        /// <summary>
        /// Gets or sets the property descriptor for the associated property.
        /// </summary>
        /// <remarks>
        /// This property represents the metadata for the property that the list provider is associated with.
        /// </remarks>
        public PropertyDescriptor Property { get; set; }

        /// <summary>
        /// Gets or sets the instance of the object that contains the associated property.
        /// </summary>
        /// <remarks>
        /// This property is used to access the object that owns the property being managed by the list provider.
        /// </remarks>
        public object Instance { get; set; }

        /// <summary>
        /// Gets the list of items provided by the list provider.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="ListItem{T}"/> objects.</returns>
        /// <remarks>
        /// This method must be implemented by derived classes to provide the list of items.
        /// </remarks>
        public abstract IEnumerable<ListItem<T>> GetItems();

        /// <summary>
        /// Creates a new list item with the specified parameters.
        /// </summary>
        /// <param name="instance">The instance of the item.</param>
        /// <param name="display">The display text for the item.</param>
        /// <param name="value">The value associated with the item.</param>
        /// <param name="initializer">An optional initializer action to configure the item.</param>
        /// <returns>A new <see cref="ListItem{T}"/> object.</returns>
        /// <remarks>
        /// This method creates a new list item and optionally initializes it using the provided initializer action.
        /// </remarks>
        protected virtual ListItem<T> CreateItem(T instance, string display, object value, Action<ListItem<T>> initializer = null)
        {

            var result = new ListItem<T>(this, instance)
            {
                Display = display,
                Value = value,
            };

            if (initializer != null)
                initializer(result);

            var currentvalue = GetValue();
            if (currentvalue != null)
                result.Selected = Compare(result, currentvalue);

            return result;

        }

        /// <summary>
        /// Gets the current value of the associated property.
        /// </summary>
        /// <returns>The current value of the property, or <c>null</c> if the value is not set.</returns>
        /// <remarks>
        /// This method retrieves the value of the property from the associated object instance.
        /// </remarks>
        protected object GetValue()
        {
            if (_value == null && Instance != null && Property != null)
                _value = Property.GetValue(Instance);
            return _value;
        }

        /// <summary>
        /// Compares a list item with a specified value to determine equality.
        /// </summary>
        /// <param name="left">The list item to compare.</param>
        /// <param name="right">The value to compare against.</param>
        /// <returns><c>true</c> if the list item and value are considered equal; otherwise, <c>false</c>.</returns>
        /// <remarks>
        /// This method performs a comparison between a list item and a value, supporting various types of comparisons.
        /// </remarks>
        public virtual bool Compare(ListItem left, object right)
        {

            if (left == null && right != null)
                return false;

            if (left != null && right == null)
                return false;

            if (right is ListItem item)
                return Compare1(left, item);

            if (right is T a && left.Tag != null && a.Equals(left.Tag))
                return true;

            if (left.Tag.Equals(right))
                return true;

            if (left.Value.Equals(right))
                return true;

            return false;

        }

        private static bool Compare1(ListItem item1, ListItem item2)
        {

            if (item1 == item2)
                return true;

            if (item1.Tag.Equals(item2.Tag))
                return true;

            if (item1.Value.Equals(item2.Value))
                return true;

            return false;

        }

        /// <summary>
        /// Gets the list of items provided by the list provider as non-generic <see cref="ListItem"/> objects.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="ListItem"/> objects.</returns>
        IEnumerable<ListItem> IListProvider.GetItems()
        {
            foreach (var item in GetItems())
                yield return item;
        }

        /// <summary>
        /// Gets the original value for a specified list item.
        /// </summary>
        /// <param name="item">The list item for which to get the original value.</param>
        /// <returns>The original value associated with the list item.</returns>
        object IListProvider.GetOriginalValue(ListItem item)
        {
            return ResolveOriginalValue((ListItem<T>)item);
        }

        /// <summary>
        /// Resolves the original value for a specified list item.
        /// </summary>
        /// <param name="item">The list item for which to resolve the original value.</param>
        /// <returns>The original value associated with the list item.</returns>
        /// <remarks>
        /// This method can be overridden to customize how the original value is resolved for a list item.
        /// </remarks>
        protected virtual object ResolveOriginalValue(ListItem<T> item)
        {
            return item.Tag;
        }

        private object _value;

    }

}
