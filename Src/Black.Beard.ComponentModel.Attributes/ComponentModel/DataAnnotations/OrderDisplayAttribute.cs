using System;

namespace Bb.ComponentModel.DataAnnotations
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter, Inherited = false, AllowMultiple = true)]
    public sealed class OrderDisplayAttribute : Attribute
    {
        
        public OrderDisplayAttribute(int position)
        {
            this.Position = position;
        }

        public int Position { get; }

    }

}
