using Bb.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;

namespace Bb.ComponentModel.Attributes
{
    [System.AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Struct, Inherited = false, AllowMultiple = true)]
    public sealed class ListProviderAttribute : Attribute
    {

        /// <summary>
        /// new instance of <see cref="ListProviderAttribute"/>
        /// </summary>
        /// <param name="typeListResolver">the type must implement <see cref="IListProvider"/> </param>
        /// <param name="property">property descriptor that decorated with the current attribute</param>
        /// <param name="instance">Instance of the object</param>
        /// <exception cref="ArgumentException">if the type not implement <see cref="IListProvider"/> </exception>
        public ListProviderAttribute(Type typeListResolver)
        {

            if (!typeof(IListProvider).IsAssignableFrom(typeListResolver))
                throw new ArgumentException($"{typeListResolver} must implement {typeof(IListProvider)}");

            this.ProviderListType = typeListResolver;

        }

        /// <summary>
        /// Return the instance of the list provider
        /// </summary>
        /// <returns></returns>
        public IListProvider GetProvider(PropertyDescriptor property = null, object instance = null)
        {
            
            var result = (IListProvider)Activator.CreateInstance(this.ProviderListType);

            result.Property = property;
            result.Instance = instance;

            return result;

        }

        /// <summary>
        /// Return the instance of the list provider
        /// </summary>
        /// <param name="provider">service provider for resolve the type</param>
        /// <param name="property">property descriptor that decorated with the current attribute</param>
        /// <param name="instance">Instance of the object</param>
        /// <returns></returns>
        public IListProvider GetProvider(IServiceProvider provider, PropertyDescriptor property = null, object instance = null)
        {

            var result = (IListProvider)provider.GetService(this.ProviderListType);

            result.Property = property;
            result.Instance = instance;

            return result;

        }

        public Type ProviderListType { get; }

    }

}
