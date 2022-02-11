using System;

namespace Bb.ComponentModel.Attributes
{


    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class MetaPropertyAttribute : Attribute
    {

        public MetaPropertyAttribute(string context, string name, string value)
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

    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class EnumerationProviderAttribute : Attribute
    {

        public EnumerationProviderAttribute(Type typeProvider)
        {

        }

    }


}
