using System;

namespace Bb.ComponentModel.Attributes
{
    /// <summary>
    /// Specifies the display order of a property, field, event, or parameter.
    /// </summary>
    /// <remarks>
    /// This attribute is used to define the position of an element in a display order, such as in a UI or serialization context.
    /// </remarks>
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
    public sealed class OrderDisplayAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDisplayAttribute"/> class with the specified position.
        /// </summary>
        /// <param name="position">The position of the element in the display order.</param>
        /// <example>
        /// <code lang="C#">
        /// [OrderDisplay(1)]
        /// public string Name { get; set; }
        /// </code>
        /// </example>
        public OrderDisplayAttribute(int position)
        {
            this.Position = position;
        }

        /// <summary>
        /// Gets the position of the element in the display order.
        /// </summary>
        /// <returns>The position value.</returns>
        public int Position { get; }

    }

}
