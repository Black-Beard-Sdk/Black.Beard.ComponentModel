using System;

namespace Bb.ComponentModel.DataAnnotations
{

    /// <summary>
    /// Represents an item of list.
    /// </summary>
    public sealed class ListItem<T> : ListItem
    {

        internal ListItem(IListProvider source, object instance) 
            : base(source, instance)
        {
            
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public new T Tag
        {
            get => (T)base.Tag;
            set => base.Tag = value;
        }


    }
    

}
