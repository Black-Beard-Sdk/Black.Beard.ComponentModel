using System;

namespace Bb.ComponentModel.Attributes
{

    [Serializable]
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ConfigurationAttribute : Attribute
    {

        public ConfigurationAttribute()
        {



        }

        public string ConfigurationKey { get; set; }

        public string TypeSerialization { get; set; }

        public const string TypeSerializationToJson = "json";
        public const string TypeSerializationToXml = "xml";
        public const string TypeSerializationToYml = "yml";

    }

}
