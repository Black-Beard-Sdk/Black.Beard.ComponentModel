using System;

namespace Bb.ComponentModel.Attributes
{
    public class EvaluateValidationAttribute : Attribute
    {

        public EvaluateValidationAttribute(bool toEvaluate)
        {
            this.ToEvaluate = toEvaluate;
        }

        public bool ToEvaluate { get; }
    }

}
