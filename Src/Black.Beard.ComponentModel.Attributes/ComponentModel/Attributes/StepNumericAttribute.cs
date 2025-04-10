using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Specifies a numeric step value for a property.
    /// </summary>
    /// <remarks>
    /// This attribute is used to define a step increment for numeric properties, typically for UI or validation purposes.
    /// </remarks>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class StepNumericAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="StepNumericAttribute"/> class with the specified step value.
        /// </summary>
        /// <param name="step">The step increment value for the property.</param>
        /// <example>
        /// <code lang="C#">
        /// [StepNumeric(0.5f)]
        /// public float Increment { get; set; }
        /// </code>
        /// </example>
        public StepNumericAttribute(float step)
        {
            this.Step = step;
        }

        /// <summary>
        /// Gets the step increment value for the property.
        /// </summary>
        /// <returns>The step increment value.</returns>
        public float Step { get; }

    }

}
