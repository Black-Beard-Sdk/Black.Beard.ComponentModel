using System;

namespace Bb.ComponentModel.Attributes
{

    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = true)]
    public class ExposeMethodAttribute : Attribute
    {

        public ExposeMethodAttribute()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayName">key for matching ruless</param>
        public ExposeMethodAttribute(string displayName)
        {
            DisplayName = displayName;
        }

        public ExposeMethodAttribute(string context, string displayName)
            : this(displayName)
        {
            Context = context;
        }

        public ExposeMethodAttribute(string context, MethodType kind, string displayName)
            : this(context, displayName)
        {
            Kind = kind;
        }

        public string DisplayName { get; }

        public string Context { get; }

        public MethodType Kind { get; }

    }

    public enum MethodType
    {
        Other,
        Add,
        Del,
        New,
    }


}
