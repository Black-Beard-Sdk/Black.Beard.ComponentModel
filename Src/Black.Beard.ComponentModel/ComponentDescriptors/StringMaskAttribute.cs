using System;

namespace Bb.ComponentDescriptors
{


    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class StringMaskAttribute : Attribute
    {

        public StringMaskAttribute(StringType mask)
        {
            this.Mask = mask;
        }

        public StringType Mask { get; }
    }


}
