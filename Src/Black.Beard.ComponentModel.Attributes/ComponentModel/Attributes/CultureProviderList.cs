using Bb.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Bb.ComponentModel.Attributes
{
    public class CultureProviderList : IListProvider
    {


        public PropertyDescriptor Property { get; set; }


        public object Instance { get; set; }


        public IEnumerable<ListItem> GetItems()
        {
            var items = CultureInfo.GetCultures(CultureTypes.FrameworkCultures);
            foreach (var item in items)
                yield return new ListItem() { Display = item.DisplayName, Name = item.EnglishName, Value = item.IetfLanguageTag };

        }

    }

}
