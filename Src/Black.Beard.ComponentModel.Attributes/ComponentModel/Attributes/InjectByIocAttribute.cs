// Ignore Spelling: Ioc

using System;

namespace Bb.ComponentModel.Attributes
{
    /// <summary>
    /// Specifies that a property should be injected by an IoC (Inversion of Control) container.
    /// </summary>
    /// <remarks>
    /// This attribute is used to mark properties for dependency injection using an IoC container.
    /// </remarks>
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class InjectByIocAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectByIocAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used when no specific type is specified for injection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// [InjectByIoc]
        /// public IService MyService { get; set; }
        /// </code>
        /// </example>
        public InjectByIocAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InjectByIocAttribute"/> class with the specified type.
        /// </summary>
        /// <param name="type">The type to inject into the property.</param>
        /// <remarks>
        /// This constructor is used when a specific type is required for injection.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// [InjectByIoc(typeof(MyService))]
        /// public IService MyService { get; set; }
        /// </code>
        /// </example>
        public InjectByIocAttribute(Type type)
        {
            this.TypeToInject = type;
        }

        /// <summary>
        /// Gets the type to inject into the property.
        /// </summary>
        /// <returns>The type specified for injection, or <c>null</c> if no type was specified.</returns>
        public Type TypeToInject { get; }
    
    }

}
