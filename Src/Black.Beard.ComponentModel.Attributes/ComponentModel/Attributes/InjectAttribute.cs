using System;

namespace Bb.ComponentModel.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class InjectAttribute : Attribute
    {

        // This is a positional argument
        public InjectAttribute()
        {

        }

        public InjectAttribute(Type type)
        {
            this.TypeToInject = type;
        }

        public Type TypeToInject { get; }
    
    }

}
