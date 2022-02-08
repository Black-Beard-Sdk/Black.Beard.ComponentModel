using System;

namespace Bb.ComponentModel.DataAnnotations
{


    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]

    public sealed class DisplayOnUITextAreaAttribute : Attribute
    {

        public DisplayOnUITextAreaAttribute(int lines = 5)
        {
            this.Lines = lines;
        }

        public int Lines { get; }

    }

}
