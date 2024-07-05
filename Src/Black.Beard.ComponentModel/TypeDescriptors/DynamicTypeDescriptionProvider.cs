using System;
using System.ComponentModel;

namespace Bb.TypeDescriptors
{


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    /// <typeparam name="T">type of the model</typeparam>
    /// <example>
    /// <code lang="csharp">
    /// DynamicTypeDescriptionProvider<Title>.Initialize();
    /// </code>
    /// </example>
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

        public static ConfigurationDescriptorRepository Configuration => _configuration;

        private static ConfigurationDescriptorRepository _configuration = new ConfigurationDescriptorRepository();
    }


    /// <summary>
    /// Provides supplemental metadata to the System.ComponentModel.TypeDescriptor.
    /// </summary>
    /// <typeparam name="T">type of the model</typeparam>
    /// <example>
    /// <code lang="csharp">
    /// TypeDescriptor.AddProvider(new DynamicTypeDescriptionProvider<Title>(conf), title);
    /// </code>
    /// </example>
    /// <example>
    /// <code lang="csharp">
    /// [TypeDescriptionProvider(typeof(DynamicTypeDescriptionProvider<Title>))]
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
