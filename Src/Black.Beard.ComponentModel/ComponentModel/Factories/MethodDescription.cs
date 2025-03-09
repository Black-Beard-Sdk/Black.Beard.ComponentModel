using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{


    [DebuggerDisplay("{Name}")]
    public class MethodDescription
    {

        public MethodDescription(string name, MethodBase method, Type typeReturn)
        {

            if (method == null)
                throw new NullReferenceException(nameof(Method));

            Method = method;
            this.Name = name;
            var parameters = method.GetParameters();
            this.Parameters = new List<ArgumentDescription>(parameters.Length);
            foreach (var item in parameters)
            {
                var p = new ArgumentDescription(item.Name, item)
                {
                    Name = item.Name,
                    Parameter = item,
                };
                this.Parameters.Add(p);
            }
            
            if (typeReturn != null)
                this.Type = typeReturn;

            else if (method is ConstructorInfo ctor)
                this.Type = ctor.DeclaringType;

            else if (method is MethodInfo method1)
                this.Type =  method1.ReturnType;

        }

        public string Name { get; }

        public string Description { get; set; }

        
        public List<ArgumentDescription> Parameters { get; }
        
        public MethodBase Method { get; set; }

        public string Content { get; set; }

        public Type Type { get; }
    }
}
