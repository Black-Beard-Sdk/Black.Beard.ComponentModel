namespace Bb.ComponentModel.DataAnnotations
{

    /// <summary>
    /// Represents a list item.
    /// </summary>
    public class ListItem
    {

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
        /// Gets or sets the string display
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Display.ToString();
        }

        /// <summary>
        /// retur true if the value is equal to the value of the object
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            var other = o as ListItem;
            return other?.Value == Value;
        }

        /// <summary>
        /// return the hash code of the value
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

    }

}
