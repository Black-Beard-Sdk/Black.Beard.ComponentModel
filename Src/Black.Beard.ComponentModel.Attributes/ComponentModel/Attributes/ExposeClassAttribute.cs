using System;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// specify this class contains method to expose
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    [System.Diagnostics.DebuggerDisplay("{Context} : {LifeCycle}")]
    public sealed class ExposeClassAttribute : Attribute
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeClassAttribute"/> class.
        /// </summary>
        public ExposeClassAttribute()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeClassAttribute"/> class.
        /// </summary>
        /// <param name="context">key for matching context</param>
        public ExposeClassAttribute(string context)
        {
            Context = context;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExposeClassAttribute"/> class.
        /// </summary>
        /// <param name="context">key for matching context</param>
        /// <param name="display">The display.</param>
        public ExposeClassAttribute(string context, string display)
        {
            Context = context;
            this.Name = display;
        }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the context of the class exposed by this attribute.
        /// </summary>
        /// <value>
        /// The context.
        /// </value>
        public string Context { get; set; }              

        /// <summary>
        /// Gets or sets the life cycle if must be use in Ioc.
        /// </summary>
        /// <value>
        /// The life cycle.
        /// </value>
        public IocScopeEnum LifeCycle { get; set; }

        /// <summary>
        /// Gets or sets the exposition type.
        /// </summary>
        /// <value>
        /// The type of the exposed.
        /// </value>
        public Type ExposedType { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {

            if (obj == null)
                return false;

            if (obj is ExposeClassAttribute)
                return this.GetHashCode() == obj.GetHashCode();

            return false;

        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {

            if (!string.IsNullOrEmpty(Context))
            {
                if (!string.IsNullOrEmpty(Name))
                    return Context.GetHashCode() ^ Name.GetHashCode();

                return Context.GetHashCode();
            }

            return base.GetHashCode();

        }

        public override object TypeId => base.TypeId;

    }

}
