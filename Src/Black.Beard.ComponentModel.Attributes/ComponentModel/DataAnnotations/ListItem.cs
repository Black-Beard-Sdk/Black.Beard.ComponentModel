using System;

namespace Bb.ComponentModel.DataAnnotations
{

    /// <summary>
    /// Represents a list item.
    /// </summary>
    public class ListItem
    {

        internal ListItem(Func<ListItem, object, bool> comparer, object instance)
        {
            this._compareListItems = comparer;
            this.Tag = instance;
        }

        /// <summary>
        /// Gets or sets the name. (it is the key)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display.
        /// </summary>
        public string Display { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the item is disabled.
        /// </summary>
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Gets or sets the item is selected.
        /// </summary>
        public bool Selected { get; set; } = false;


        public object Icon { get; set; }


        public virtual object Tag { get; protected set; }

        /// <summary>
        /// Gets or sets the string display
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Display.ToString();
        }

        /// <summary>
        /// return true if the value is equal to the value of the object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {

            var other = o as ListItem;

            if (other == null)
                return false;

            return this._compareListItems(this, other);

        }


        public bool Compare(object right)
        {
            return _compareListItems(this, right);
        }


        private Func<ListItem, object, bool> _compareListItems;

        /// <summary>
        /// return the hash code of the value
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? this.GetHashCode();
        }
                   
    }


}
