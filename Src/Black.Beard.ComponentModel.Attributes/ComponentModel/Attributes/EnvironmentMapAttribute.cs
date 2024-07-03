using System;

namespace Bb.ComponentModel.Attributes
{


    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class EnvironmentMapAttribute : Attribute
    {

        public EnvironmentMapAttribute(bool map)
        {
            this.Map = map;
        }

        public EnvironmentMapAttribute(string variableName)
        {
            this.VariableName = variableName;
            this.Map = true;
        }

        public string VariableName { get; }

        public bool Map { get; }

    }

}
