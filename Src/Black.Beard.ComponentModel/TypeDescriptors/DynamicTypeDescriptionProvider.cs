using Bb.Expressions;
using System;
using System.ComponentModel;

namespace Bb.TypeDescriptors
{


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    public class DynamicTypeDescriptionProvider : TypeDescriptionProvider, IDisposable
    {
        private bool disposedValue;


        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        /// <param name="defaultTypeProvider"></param>
        /// <param name="configuration"></param>
        protected DynamicTypeDescriptionProvider(object key, TypeDescriptionProvider defaultTypeProvider, ConfigurationDescriptorSelector configuration)
            : base(defaultTypeProvider)
        {
            this._key = key;
            Configuration = configuration;
        }

        /// <summary>
        /// Configure the TypeDescriptor for specific instance with the configuration.
        /// </summary>
        /// <typeparam name="T">type of the instance</typeparam>
        /// <param name="instance">instance to configure</param>
        /// <param name="configure">method to configure</param>
        /// <param name="filter">filter to apply the configuration if result is true</param>
        /// <returns></returns>
        /// <example>
        /// <code lang="csharp">
        /// var provider = DynamicTypeDescriptionProvider.Configure(instance, c =>
        /// {
        ///     c.AddProperty("Index", typeof(int), p =>
        ///     {
        ///         p.DefaultValue(3);
        ///     });
        /// }, f => true);
        /// </code>
        /// </example>
        public static DynamicTypeDescriptionProvider<T> Configure<T>(T instance, Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)
        {
            return DynamicTypeDescriptionProvider<T>.InstanceType.Configure(instance, configure, filter);
        }

        /// <summary>
        /// Configure the TypeDescriptor for specified type with the configuration.
        /// </summary>
        /// <typeparam name="T">type of the instance</typeparam>
        /// <param name="configure">method to configure</param>
        /// <param name="filter">filter to apply the configuration if result is true</param>
        /// <returns></returns>
        /// <example>
        /// <code lang="csharp">
        /// var provider = DynamicTypeDescriptionProvider.Configure&lt;Column&gt;(c =>
        /// {
        ///     c.AddProperty("Index", typeof(int), p =>
        ///     {
        ///         p.DefaultValue(3);
        ///     });
        /// }, f => true);
        /// </code>
        /// </example>
        public static DynamicTypeDescriptionProvider<T> Configure<T>(Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)
        {
            return DynamicTypeDescriptionProvider<T>.InstanceType.Configure(configure, filter);
        }

        /// <summary>
        /// An <see cref="System.ComponentModel.ICustomTypeDescriptor"/> that can provide metadata for the type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return new DynamicTypeDescriptor(base.GetTypeDescriptor(objectType, instance), instance, Configuration);
        }

        public override ICustomTypeDescriptor GetExtendedTypeDescriptor(object instance)
        {

            return base.GetExtendedTypeDescriptor(instance);

            //return new DynamicTypeDescriptor(base.GetTypeDescriptor(instance.GetType(), instance), instance, Configuration);
        }

        /// <summary>
        /// Merge the configuration descriptor selector with the current instance.
        /// </summary>
        /// <param name="configuration"></param>
        public void Merge(ConfigurationDescriptorSelector configuration)
        {
            Configuration.Merge(configuration);
        }


        ///// <summary>
        ///// Access to global configuration instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        ///// </summary>
        ///// <example>
        ///// <code lang="csharp">
        ///// 
        ///// // add dynamic configuration for type descriptor
        ///// DynamicTypeDescriptionProvider&lt;Column&gt;.Instance.Configure(c =>
        ///// {
        /////     // add first property
        /////     c.AddProperty("AutoIncrement", typeof(bool), i =>
        /////     {
        /////         i.IsBrowsable(true)
        /////         .Description("Auto increment")
        /////         ;
        /////     })
        /////     // add second property
        /////     .AddProperty("IncrementStart", typeof(int), i =>
        /////     {
        /////     i.IsBrowsable(true)
        /////     .Description("Auto start")
        /////     .DefaultValue(1);
        /////     });
        ///// }, d => // the previous bloc is append only if the filter return true
        ///// {
        /////     var type = d.GetColumnType();
        /////     if (type != null)
        /////         return type.Category == ColumbTypeCategory.Integer;
        /////     return false;
        ///// 
        ///// });
        ///// 
        ///// </code>
        ///// </example>
        public ConfigurationDescriptorSelector Configuration { get; }

        /// <summary>
        /// Dispose the instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_key is Type t)
                        TypeDescriptor.RemoveProvider(this, t);
                    else
                        TypeDescriptor.RemoveProviderTransparent(this, _key);

                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Dispose the instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        private readonly object _key;

    }

}
