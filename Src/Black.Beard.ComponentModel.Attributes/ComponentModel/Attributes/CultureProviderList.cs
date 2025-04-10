﻿using Bb.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Globalization;

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Provides a list of cultures to use in a list selector
    /// </summary>
    public class CultureProviderList : ProviderListBase<CultureInfo>
    {

        /// <summary>
        /// Get the list of items
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<ListItem<CultureInfo>> GetItems()
        {

            List<ListItem<CultureInfo>> result = new List<ListItem<CultureInfo>>();

            var items = CultureInfo.GetCultures(CultureTypes.AllCultures);

            foreach (var item in items)
                result.Add(CreateItem(item, item.EnglishName, item.IetfLanguageTag , a =>
                {
                    a.Name = item.Name;
                }));

            return result;

        }

    }


}
