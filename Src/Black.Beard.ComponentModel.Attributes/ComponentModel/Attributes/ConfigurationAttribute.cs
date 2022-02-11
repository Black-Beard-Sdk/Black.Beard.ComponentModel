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

        public string TypeSerialisation { get; set; }

        public const string TypeSerialisationToJson = "json";
        public const string TypeSerialisationToXml = "xml";
        public const string TypeSerialisationToYml = "yml";

    }

}
