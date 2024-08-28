using Bb.Expressions;
using System;
using System.ComponentModel;

namespace Bb.TypeDescriptors
{


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
