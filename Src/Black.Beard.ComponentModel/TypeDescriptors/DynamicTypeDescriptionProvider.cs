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
        /// <param name="filter">filter to apply the configuration</param>
        /// <returns></returns>
        /// <example>
        /// <code lang="csharp">
        /// var provider = DynamicTypeDescriptionProvider.Configure(instance, c =>
        /// {
        ///     c.AddProperty("Index", typeof(int), p =>
        ///     {
        ///         p.DefaultValue(3);
        ///     });
        /// };
        /// </code>
        /// </example>
        public static DynamicTypeDescriptionProvider<T> Configure<T>(T instance, Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)
        {
            return DynamicTypeDescriptionProvider<T>.InstanceType.Configure(instance, configure, filter);
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


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    /// <typeparam name="T">type of the model</typeparam>
    /// <example>
    /// Manually
    /// <code lang="csharp">
    /// DynamicTypeDescriptionProvider&lt;Title&gt;.Instance();
    /// </code>
    /// </example>
    /// <example>
    /// <code lang="csharp">
    /// TypeDescriptor.AddProvider(new DynamicTypeDescriptionProvider&lt;Title&gt;(conf), title);
    /// </code>
    /// </example>
    /// <example>
    /// <code lang="csharp">
    /// [TypeDescriptionProvider(typeof(DynamicTypeDescriptionProvider&lt;Title&gt;))]
    /// </code>
    /// </example>
    public class DynamicTypeDescriptionProvider<T> : DynamicTypeDescriptionProvider
    {

        #region ctors 

        internal DynamicTypeDescriptionProvider(T instance, ConfigurationDescriptorSelector? configuration = null)
            : base(instance, TypeDescriptor.GetProvider(instance), configuration ?? new ConfigurationDescriptorSelector())
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        /// <param name="defaultTypeProvider"></param>
        /// <param name="configuration"></param>
        internal DynamicTypeDescriptionProvider(TypeDescriptionProvider defaultTypeProvider, ConfigurationDescriptorSelector configuration)
            : base(typeof(T), defaultTypeProvider ?? TypeDescriptor.GetProvider(typeof(T)), configuration ?? new ConfigurationDescriptorSelector())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        internal DynamicTypeDescriptionProvider(TypeDescriptionProvider? defaultTypeProvider = null)
            : base(typeof(T), defaultTypeProvider ?? TypeDescriptor.GetProvider(typeof(T)), new ConfigurationDescriptorSelector())
        {


        }

        #endregion ctors

        #region life cycle 

        /// <summary>
        /// Access to global instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        public static DynamicTypeDescriptionProvider<T> InstanceType
        {
            get
            {
                if (_instanceTypeProvider == null)
                    lock (_lock)
                        if (_instanceTypeProvider == null)
                        {
                            var i = new DynamicTypeDescriptionProvider<T>();
                            TypeDescriptor.AddProvider(i, typeof(T));
                            _instanceTypeProvider = i;
                        }

                return _instanceTypeProvider;

            }
        }

        /// <summary>
        /// Remove the TypeDescriptorProvider for type.
        /// </summary>
        /// <returns></returns>
        public static DynamicTypeDescriptionProvider<T> RemoveType()
        {

            if (_instanceTypeProvider != null)
                lock (_lock)
                    if (_instanceTypeProvider != null)
                    {
                        TypeDescriptor.RemoveProvider(_instanceTypeProvider, typeof(T));
                        _instanceTypeProvider = null;
                    }

            return _instanceTypeProvider;

        }

        #endregion life cycle

        /// <summary>
        /// Add a configuration for a specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configure"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DynamicTypeDescriptionProvider<T> Configure(T instance, Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)
        {
            var i = new DynamicTypeDescriptionProvider<T>(instance);
            i.Configure(configure, filter);
            TypeDescriptor.AddProviderTransparent(i, instance);
            return i;
        }

        /// <summary>
        /// Add a configuration for a specific type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configure"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public DynamicTypeDescriptionProvider<T> Configure(Action<ConfigurationDescriptor<T>> configure, Func<T, bool> filter = null)
        {

            Func<object, bool> filterTarget = null;
            if (filter != null)
                filterTarget = o => filter((T)o);

            var configuration = new ConfigurationDescriptor<T>() { Filter = filterTarget };
            configure(configuration);
            Configuration.Add(configuration);

            return this;

        }



        private static object _lock = new object();
        private static DynamicTypeDescriptionProvider<T> _instanceTypeProvider;

    }

}
