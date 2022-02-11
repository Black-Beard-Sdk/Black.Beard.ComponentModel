using Bb.ComponentModel.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{
    public interface IListProvider
    {

        object Instance { get; set; }

        PropertyDescriptor Property { get; set; }
                
        IEnumerable<ListItem> GetItems();

    }

}
