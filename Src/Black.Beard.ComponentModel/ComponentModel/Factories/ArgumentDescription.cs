using System.Diagnostics;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    [DebuggerDisplay("{ParameterType} {Name}")]
    public class ArgumentDescription
    {

        public ArgumentDescription(string   name, ParameterInfo parameter)
        {
            this.Name = name;
            this.Parameter = parameter;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public ParameterInfo Parameter { get; set; }

    }
}
