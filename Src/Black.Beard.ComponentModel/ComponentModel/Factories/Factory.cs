using System;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{




    [System.Diagnostics.DebuggerDisplay("{Name}")]
    public abstract class Factory
    {

        public Factory(MethodBase method, ParameterInfo[] paramsInfo, MethodDescription description, Type type)
        {
            this.ExposedType = type;
            this.MethodSource = method;
            IsStatic = method.IsStatic;
            IsCtor = method is ConstructorInfo;
            this.Parameters = paramsInfo;
            this.MethodInfos = description;

        }

        public Type ExposedType { get; }

        public MethodBase MethodSource { get; }

        public ParameterInfo[] MethodParameters { get; protected set; }

        public bool IsStatic { get; }

        public bool IsCtor { get; }

        public Type[] Types { get; protected set; }

        public ParameterInfo[] Parameters { get; }

        public MethodInfo MethodCall { get; internal set; }

        public MethodInfo MethodReset { get; internal set; }

        public abstract bool IsEmpty { get; }

        public MethodDescription MethodInfos { get; }

        public string Name { get; set; }

        /// <summary>
        /// Creates a new instance of T with the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        public abstract object CallInstance(params dynamic[] args);

    }
}
