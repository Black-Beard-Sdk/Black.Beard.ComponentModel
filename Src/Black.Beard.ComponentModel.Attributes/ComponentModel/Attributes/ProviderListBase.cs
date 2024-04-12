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

            var result = new ListItem<T>(Compare, instance)
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

        IEnumerable<ListItem> IListProvider.GetItems()
        {
            foreach (var item in GetItems())
                yield return item;
        }

        protected object GetValue()
        {
            if (_value == null && Instance != null && Property != null)
                _value = Property.GetValue(Instance);
            return _value;
        }

        protected virtual bool Compare(ListItem item1, object item2)
        {

            if (item1 == null && item2 != null)
                return false;

            if (item1 != null && item2 == null)
                return false;

            if (item2 is ListItem item)
                return Compare1(item1, item);

            if (item2 is T a)
                if (item1.Tag != null && a.Equals(item1.Tag))
                    return true;

            return false;

        }

        private bool Compare1(ListItem item1, ListItem item2)
        {

            if (item1.Tag.Equals(item2.Tag))
                return true;

            if (item1.Value.Equals(item2.Value))
                return true;

            return false;

        }

        private object _value;


    }

}
