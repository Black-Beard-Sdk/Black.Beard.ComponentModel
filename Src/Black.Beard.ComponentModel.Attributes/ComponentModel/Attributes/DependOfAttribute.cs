using System;

namespace Bb.ComponentModel.Attributes
{

    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class DependOfAttribute : Attribute
    {
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="type"></param>
        public DependOfAttribute(Type type)
        {
            this.Type = type;
        }

        public Type Type { get; }
    
    }

}
