using System;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Meta property attribute
    /// </summary>
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    public sealed class MetaPropertyAttribute : Attribute
    {

        /// <summary>
        /// Constructor that create a new <see cref="MetaPropertyAttribute"/>
        /// </summary>
        /// <param name="context">context using</param>
        /// <param name="name">name of the property</param>
        /// <param name="value">Value property</param>
        public MetaPropertyAttribute(string context, string name, object value)
        {
            this.Context = context;
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// Context of the property
        /// </summary>
        public string Context { get; }

        /// <summary>
        /// Name of the meta property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Value of the meta property
        /// </summary>
        public object Value { get; }

        /// <summary>
        /// Type of the meta property
        /// </summary>
        public Type Type { get; set; }


    }


}
