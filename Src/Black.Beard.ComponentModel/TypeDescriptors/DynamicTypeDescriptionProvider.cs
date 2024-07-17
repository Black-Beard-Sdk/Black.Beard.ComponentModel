using System;
using System.ComponentModel;

namespace Bb.TypeDescriptors
{


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    public class DynamicTypeDescriptionProvider : TypeDescriptionProvider
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        protected DynamicTypeDescriptionProvider(TypeDescriptionProvider defaultTypeProvider)
            : base(defaultTypeProvider)
        {

        }

        /// <summary>
        /// An System.ComponentModel.ICustomTypeDescriptor that can provide metadata for the type.
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {

            ICustomTypeDescriptor parentDescriptor = base.GetTypeDescriptor(objectType, instance);

            return instance == null
                ? parentDescriptor
                : new DynamicTypeDescriptor(parentDescriptor, instance, Configuration.GetTypeDescriptorConfiguration(instance));

        }

        public static void Merge(ConfigurationDescriptorRepository conf)
        {
            Configuration.Merge(conf);
        }

        /// <summary>
        /// Access to global instance of the <see cref="ConfigurationDescriptorRepository"/> class.
        /// </summary>
        /// <example>
        /// <code lang="csharp">
        /// 
        /// var config = DynamicTypeDescriptionProvider.Configuration;
        /// 
        /// // add dynamic configuration for type descriptor
        /// config.Add&lt;Column&gt;(c =>
        /// {
        ///     // add first property
        ///     c.AddProperty("AutoIncrement", typeof(bool), i =>
        ///     {
        ///         i.IsBrowsable(true)
        ///         .Description("Auto increment")
        ///         ;
        ///     })
        ///     // add second property
        ///     .AddProperty("IncrementStart", typeof(int), i =>
        ///     {
        ///     i.IsBrowsable(true)
        ///     .Description("Auto start")
        ///     .DefaultValue(1);
        ///     });
        /// }, d => // the previous bloc is append only if the filter return true
        /// {
        ///     var type = d.GetColumnType();
        ///     if (type != null)
        ///         return type.Category == ColumbTypeCategory.Integer;
        ///     return false;
        /// 
        /// });
        /// 
        /// </code>
        /// </example>
        public static ConfigurationDescriptorRepository Configuration => _configuration;

        private static ConfigurationDescriptorRepository _configuration = new ConfigurationDescriptorRepository();
    }


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    /// <typeparam name="T">type of the model</typeparam>
    /// <example>
    /// Manually
    /// <code lang="csharp">
    /// DynamicTypeDescriptionProvider&lt;Title&gt;.Initialize();
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

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicTypeDescriptionProvider"/> class.
        /// </summary>
        public DynamicTypeDescriptionProvider()
            : base(TypeDescriptor.GetProvider(typeof(T)))
        {

        }

        public static void Initialize()
        {

            if (!registered)
                lock (_lock)
                    if (!registered)
                    {
                        TypeDescriptor.AddProvider(new DynamicTypeDescriptionProvider<T>(), typeof(T));
                        registered = true;
                    }

        }

        private static object _lock = new object();
        private static bool registered = false;

    }

}
