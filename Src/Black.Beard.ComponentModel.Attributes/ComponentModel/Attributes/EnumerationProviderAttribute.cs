using System;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Enumeration provider attribute
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class EnumerationProviderAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerationProviderAttribute"/> class.
        /// </summary>
        /// <param name="typeProvider"></param>
        public EnumerationProviderAttribute(Type typeProvider)
        {
            this.Provider = typeProvider;
        }

        /// <summary>
        /// Gets the type to use like provider.
        /// </summary>
        public Type Provider { get; }

    }


}
