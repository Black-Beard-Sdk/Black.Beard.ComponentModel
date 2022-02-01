using System;

namespace Bb.ComponentModel.DataAnnotations
{

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]

    public sealed class DisplayOnUITextAreaAttribute : Attribute
    {

        public DisplayOnUITextAreaAttribute()
        {

        }

    }

}
