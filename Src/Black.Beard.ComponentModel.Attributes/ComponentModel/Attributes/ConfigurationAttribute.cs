using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Specifies configuration metadata for a class.
    /// </summary>
    /// <remarks>
    /// This attribute is used to define configuration-related properties for a class, such as the configuration key and serialization type.
    /// </remarks>
    [Serializable]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ConfigurationAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationAttribute"/> class.
        /// </summary>
        public ConfigurationAttribute()
        {

        }

        /// <summary>
        /// Gets or sets the configuration key associated with the class.
        /// </summary>
        /// <remarks>
        /// The configuration key is used to identify the configuration section or entry for the class.
        /// </remarks>
        public string ConfigurationKey { get; set; }

        /// <summary>
        /// Gets or sets the serialization type for the configuration.
        /// </summary>
        /// <remarks>
        /// Supported serialization types include JSON, XML, and YAML.
        /// </remarks>
        public string TypeSerialization { get; set; }

        /// <summary>
        /// Represents the JSON serialization type.
        /// </summary>
        public const string TypeSerializationToJson = "json";

        /// <summary>
        /// Represents the XML serialization type.
        /// </summary>
        public const string TypeSerializationToXml = "xml";

        /// <summary>
        /// Represents the YAML serialization type.
        /// </summary>
        public const string TypeSerializationToYml = "yml";

    }

}
