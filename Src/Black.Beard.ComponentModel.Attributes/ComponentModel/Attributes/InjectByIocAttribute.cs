using System;

namespace Bb.ComponentModel.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class InjectByIocAttribute : Attribute
    {

        // This is a positional argument
        public InjectByIocAttribute()
        {

        }

        public InjectByIocAttribute(Type type)
        {
            this.TypeToInject = type;
        }

        public Type TypeToInject { get; }
    
    }

}
