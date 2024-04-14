using Bb.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Bb.ComponentModel.Attributes
{

    public abstract class ProviderListBase<T> : IListProvider
    {

        /// <summary>
        /// Property descriptor
        /// </summary>
        public PropertyDescriptor Property { get; set; }


        /// <summary>
        /// Instance of the object that contains the property
        /// </summary>
        public object Instance { get; set; }
   
        /// <summary>
        /// Gets the items list.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<ListItem<T>> GetItems();

        /// <summary>
        /// Create new item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
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

        protected object GetValue()
        {
            if (_value == null && Instance != null && Property != null)
                _value = Property.GetValue(Instance);
            return _value;
        }

        public virtual bool Compare(ListItem left, object right)
        {

            if (left == null && right != null)
                return false;

            if (left != null && right == null)
                return false;

            if (right is ListItem item)
                return Compare1(left, item);

            if (right is T a)
                if (left.Tag != null && a.Equals(left.Tag))
                    return true;

            if (left.Tag.Equals(right))
                return true;

            if (left.Value.Equals(right))
                return true;

            return false;

        }

        private bool Compare1(ListItem item1, ListItem item2)
        {

            if (item1 == item2)
                return true;

            if (item1.Tag.Equals(item2.Tag))
                return true;

            if (item1.Value.Equals(item2.Value))
                return true;

            return false;

        }

        IEnumerable<ListItem> IListProvider.GetItems()
        {
            foreach (var item in GetItems())
                yield return item;
        }

        object IListProvider.GetOriginalValue(ListItem item)
        {
            return ResolveOriginalValue((ListItem<T>)item);
        }

        /// <summary>
        /// Return the new value that must to be set in the property
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected virtual object ResolveOriginalValue(ListItem<T> item)
        {
            return item.Tag;
        }

        private object _value;


    }

}
