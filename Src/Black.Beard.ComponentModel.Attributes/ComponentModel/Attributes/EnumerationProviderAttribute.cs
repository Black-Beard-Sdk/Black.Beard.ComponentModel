using System;

namespace Bb.ComponentModel.Attributes
{


    /// <summary>
    /// Enumeration provider attribute
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = true)]
    sealed class EnumerationProviderAttribute : Attribute
    {

        public EnumerationProviderAttribute(Type typeProvider)
        {
            this.Provider = typeProvider;
        }

        public Type Provider { get; }

    }


}
