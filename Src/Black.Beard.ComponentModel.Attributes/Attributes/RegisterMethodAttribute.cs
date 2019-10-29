using System;

namespace Bb.ComponentModel.Attributes
{

    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
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
            this.DisplayName = displayName;
        }

        public string DisplayName { get; set; }

        public string Context { get; set; }

    }

}
