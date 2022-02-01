using System;

namespace Bb.ComponentModel.DataAnnotations
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class StepNumericAttribute : Attribute
    {

        public StepNumericAttribute(float step)
        {
            this.Step = step;
        }

        public float Step { get; }

    }

}
