using Bb.ComponentModel.Translations;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{
    public interface IListProvider
    {

        PropertyDescriptor Property { get; set; }

        IServiceProvider Services { get; set; }

        IEnumerable<ListItem> GetItems();

    }

}
