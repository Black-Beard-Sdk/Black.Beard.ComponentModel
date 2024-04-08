using Bb.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;

namespace Bb.ComponentModel.Attributes
{
    public class CultureProviderList : IListProvider
    {

        /// <summary>
        /// Property descriptor
        /// </summary>
        public PropertyDescriptor Property { get; set; }

        /// <summary>
        /// Instance of the object that contains the property
        /// </summary>
        public object Instance { get; set; }

        /// <summary>
        /// Service provider
        /// </summary>
        public IServiceProvider ServiceProvider { get; set; }

        /// <summary>
        /// Get the list of items
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ListItem> GetItems()
        {
            var items = CultureInfo.GetCultures(CultureTypes.FrameworkCultures);
            foreach (var item in items)
                yield return new ListItem() { Display = item.DisplayName, Name = item.EnglishName, Value = item.IetfLanguageTag };

        }

    }

}
