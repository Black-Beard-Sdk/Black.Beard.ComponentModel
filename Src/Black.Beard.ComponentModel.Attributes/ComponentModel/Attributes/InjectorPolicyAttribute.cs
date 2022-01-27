using System;

namespace Bb.ComponentModel.Attributes
{
    /// <summary>
    /// Add a policy for the Ioc
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class InjectorPolicyAttribute : Attribute
    {

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="lifeCycle"></param>
        public InjectorPolicyAttribute(Type type, IocScopeEnum lifeCycle)
        {

            Type = type;
            this.LifeCycle = lifeCycle;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        /// <value>
        /// The exposed type.
        /// </value>
        public Type Type { get; }

        /// <summary>
        /// Gets or sets the life cycle if must be use in Ioc.
        /// </summary>
        /// <value>
        /// The life cycle.
        /// </value>
        public IocScopeEnum LifeCycle { get; set; }

    }

}
