using Bb.ComponentModel.Translations;
using System.Collections.Generic;
using System.ComponentModel;

namespace Bb.ComponentModel.DataAnnotations
{
    public interface IListProvider
    {

        PropertyDescriptor Property { get; set; }

        ITranslateService TranslateService { get; set; }

        IEnumerable<ListItem> GetItems();

    }

}
