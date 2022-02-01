using System;

namespace Bb.ComponentModel.DataAnnotations
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    public sealed class ListProviderAttribute : Attribute
    {

        /// <summary>
        /// new instance of <see cref="ListProviderAttribute"/>
        /// </summary>
        /// <param name="typeListResolver">the type must implement <see cref="IListProvider"/> </param>
        /// <exception cref="ArgumentException">if the type not implement <see cref="IListProvider"/> </exception>
        public ListProviderAttribute(Type typeListResolver)
        {

            if (!typeof(IListProvider).IsAssignableFrom(typeListResolver))
                throw new ArgumentException($"{typeListResolver} must implement {typeof(IListProvider)}");

            this.EnumerationResolver = typeListResolver;

        }

        public Type EnumerationResolver { get; }

    }

}
