using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Indicates that a class depends on another class.
    /// </summary>
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

        /// <summary>
        /// Gets the type that this class depends on.
        /// </summary>
        public Type Type { get; }
    
    }

}
