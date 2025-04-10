using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Attribute to indicate that a property should be evaluated for validation.
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class EvaluateValidationAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluateValidationAttribute"/> class.
        /// </summary>
        /// <param name="toEvaluate"></param>
        public EvaluateValidationAttribute(bool toEvaluate)
        {
            this.ToEvaluate = toEvaluate;
        }

        /// <summary>
        /// Gets a value indicating whether the property should be evaluated for validation.
        /// </summary>
        public bool ToEvaluate { get; }
    }

}
