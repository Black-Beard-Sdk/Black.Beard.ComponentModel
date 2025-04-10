using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Specifies that a method should be exposed with additional metadata.
    /// </summary>
    /// <remarks>
    /// This attribute is used to mark methods for exposure with optional context, type, and display name metadata.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ExposeMethodAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeMethodAttribute"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor is used when no additional metadata is required.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// [ExposeMethod]
        /// public void MyMethod() { }
        /// </code>
        /// </example>
        public ExposeMethodAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeMethodAttribute"/> class with a display name.
        /// </summary>
        /// <param name="displayName">The display name for the method, used as a key for matching rules.</param>
        /// <example>
        /// <code lang="C#">
        /// [ExposeMethod("MyMethod")]
        /// public void MyMethod() { }
        /// </code>
        /// </example>
        public ExposeMethodAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeMethodAttribute"/> class with a context and display name.
        /// </summary>
        /// <param name="context">The context in which the method is exposed.</param>
        /// <param name="displayName">The display name for the method, used as a key for matching rules.</param>
        /// <example>
        /// <code lang="C#">
        /// [ExposeMethod("Admin", "MyMethod")]
        /// public void MyMethod() { }
        /// </code>
        /// </example>
        public ExposeMethodAttribute(string context, string displayName)
            : this(displayName)
        {
            Context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeMethodAttribute"/> class with a context, method type, and display name.
        /// </summary>
        /// <param name="context">The context in which the method is exposed.</param>
        /// <param name="kind">The type of the method, indicating its purpose.</param>
        /// <param name="displayName">The display name for the method, used as a key for matching rules.</param>
        /// <example>
        /// <code lang="C#">
        /// [ExposeMethod("Admin", MethodType.Add, "AddUser")]
        /// public void AddUser() { }
        /// </code>
        /// </example>
        public ExposeMethodAttribute(string context, MethodType kind, string displayName)
            : this(context, displayName)
        {
            Kind = kind;
        }

        /// <summary>
        /// Gets the display name for the method.
        /// </summary>
        /// <remarks>
        /// The display name is used as a key for matching rules.
        /// </remarks>
        public string DisplayName { get; }

        /// <summary>
        /// Gets the context in which the method is exposed.
        /// </summary>
        /// <remarks>
        /// The context can be used to group or categorize exposed methods.
        /// </remarks>
        public string Context { get; }

        /// <summary>
        /// Gets the type of the method, indicating its purpose.
        /// </summary>
        /// <remarks>
        /// The method type can be used to specify the role of the method, such as adding, deleting, or creating new items.
        /// </remarks>
        public MethodType Kind { get; }

    }

    /// <summary>
    /// Specifies the type of a method, indicating its purpose.
    /// </summary>
    public enum MethodType
    {
        /// <summary>
        /// Represents a method with an unspecified or other purpose.
        /// </summary>
        Other,

        /// <summary>
        /// Represents a method used for adding items.
        /// </summary>
        Add,

        /// <summary>
        /// Represents a method used for deleting items.
        /// </summary>
        Del,

        /// <summary>
        /// Represents a method used for creating new items.
        /// </summary>
        New,
    }

}
