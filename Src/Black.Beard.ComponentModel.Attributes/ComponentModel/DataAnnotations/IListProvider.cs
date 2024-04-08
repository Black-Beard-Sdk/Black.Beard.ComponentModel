﻿using Bb.ComponentModel.Translations;
using System;
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
        /// Gets or sets the service provider.
        /// </summary>
        IServiceProvider ServiceProvider { get; set; }

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

    }

}
