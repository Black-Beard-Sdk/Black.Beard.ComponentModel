using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Represents metadata for a property.
    /// </summary>
    /// <remarks>
    /// This attribute is used to define additional metadata for properties, fields, events, or parameters.
    /// </remarks>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class MetaPropertyAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="MetaPropertyAttribute"/> class with the specified context, name, and value.
        /// </summary>
        /// <param name="context">The context in which the meta property is used.</param>
        /// <param name="name">The name of the meta property.</param>
        /// <param name="value">The value of the meta property.</param>
        /// <example>
        /// <code lang="C#">
        /// [MetaProperty("UI", "DisplayName", "My Property")]
        /// public string MyProperty { get; set; }
        /// </code>
        /// </example>
        public MetaPropertyAttribute(string context, string name, object value)
        {
            this.Context = context;
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Gets the context in which the meta property is used.
        /// </summary>
        /// <returns>The context of the meta property.</returns>
        public string Context { get; }

        /// <summary>
        /// Gets the name of the meta property.
        /// </summary>
        /// <returns>The name of the meta property.</returns>
        public string Name { get; }

        /// <summary>
        /// Gets the value of the meta property.
        /// </summary>
        /// <returns>The value of the meta property.</returns>
        public object Value { get; }

        /// <summary>
        /// Gets or sets the type of the meta property.
        /// </summary>
        /// <returns>The type of the meta property.</returns>
        public Type Type { get; set; }

    }

}
