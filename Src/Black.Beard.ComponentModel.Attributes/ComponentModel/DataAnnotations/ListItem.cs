
namespace Bb.ComponentModel.DataAnnotations
{

    /// <summary>
    /// Represents a list item.
    /// </summary>
    public class ListItem
    {

        internal ListItem(IListProvider source, object instance)
        {
            this.Source = source;
            this.Tag = instance;
        }

        #region Properties

        /// <summary>
        /// Gets the source Provider that generated the current item.
        /// </summary>
        public IListProvider Source { get; }

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

        #endregion

        #region Methods

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

            return this.Source.Compare(this, other);

        }

        /// <summary>
        /// return true if the value is equal to the value of the object
        /// </summary>
        /// <param name="right"></param>
        /// <returns></returns>
        public bool Compare(object right)
        {
            return Source.Compare(this, right);
        }

        /// <summary>
        /// Return the new value that can be set in the property
        /// </summary>
        /// <returns></returns>
        public object GetOriginalValue()
        {
            return Source.GetOriginalValue(this);
        }

        /// <summary>
        /// return the hash code of the value
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Value?.GetHashCode() ?? this.GetHashCode();
        }

        #endregion Methods


    }


}
