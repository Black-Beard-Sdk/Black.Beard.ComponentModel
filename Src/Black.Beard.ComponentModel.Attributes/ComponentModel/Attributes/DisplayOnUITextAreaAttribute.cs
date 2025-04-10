using System;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Attribute to indicate that a property should be displayed as a text area in the UI.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]

    public sealed class DisplayOnUITextAreaAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayOnUITextAreaAttribute"/> class.
        /// </summary>
        /// <param name="lines"></param>
        public DisplayOnUITextAreaAttribute(int lines = 5)
        {
            this.Lines = lines;
        }

        /// <summary>
        /// Gets the number of lines to display in the text area.
        /// </summary>
        public int Lines { get; }

    }

}
