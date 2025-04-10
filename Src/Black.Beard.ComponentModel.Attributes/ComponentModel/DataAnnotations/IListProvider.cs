using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{


    /// <summary>
    /// Provides a list of items for a property.
    /// </summary>
    public interface IListProvider
    {

        /// <summary>
        /// Gets or sets the instance. for th property
        /// </summary>
        object Instance { get; set; }

        /// <summary>
        /// Gets or sets the property descriptor.
        /// </summary>
        PropertyDescriptor Property { get; set; }
                
        /// <summary>
        /// Gets the items list.
        /// </summary>
        /// <returns></returns>
        IEnumerable<ListItem> GetItems();


        /// <summary>
        /// Return the new value that can be set in the property
        /// </summary>
        /// <param name="item">ListItem source</param>
        /// <returns></returns>
        object GetOriginalValue(ListItem item);

        /// <summary>
        /// Compare the value of the list item with the value
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        bool Compare(ListItem left, object right);


    }

}
