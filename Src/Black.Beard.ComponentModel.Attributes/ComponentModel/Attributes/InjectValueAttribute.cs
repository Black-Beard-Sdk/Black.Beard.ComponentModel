using System;

namespace Bb.ComponentModel
{


    /// <summary>
    /// Attribute to inject a value into a property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class InjectValueAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectValueAttribute"/> class.
        /// </summary>
        /// <param name="variableName">The name of the variable to inject.</param>
        /// <param name="required">Indicates whether the variable is required.</param>
        /// <remarks>
        /// This attribute is used to inject a value into a property.
        /// The <paramref name="variableName"/> specifies the name of the variable to inject.
        /// The <paramref name="required"/> parameter indicates whether the variable is required or not.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="variableName"/> is null or empty.</exception>

        public InjectValueAttribute(string variableName, bool required = false)
        {

            if (string.IsNullOrEmpty(variableName))
                throw new ArgumentNullException(nameof(variableName));

            this.VariableName = variableName;
            this.Required = required;

        }

        /// <summary>
        /// Variable name to inject.
        /// </summary>
        public string VariableName { get; }

        /// <summary>
        /// Indicates whether the variable is required.
        /// </summary>
        public bool Required { get; }

    }

}
