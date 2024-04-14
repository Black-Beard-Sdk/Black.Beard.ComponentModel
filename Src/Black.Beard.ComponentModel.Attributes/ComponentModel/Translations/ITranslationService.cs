using Bb.ComponentModel.Attributes;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Bb.ComponentModel.Translations
{

    /// <summary>
    /// Contract for translation service
    /// </summary>
    public interface ITranslateService
    {

        /// <summary>
        /// Translate the key and return the value for the current culture
        /// </summary>
        /// <param name="key">translation key</param>
        /// <returns></returns>
        string Translate(TranslatedKeyLabel key);

        /// <summary>
        /// Translate the key and return the value for the specified culture
        /// </summary>
        /// <param name="culture">culture asked</param>
        /// <param name="key">translation key</param>
        /// <returns></returns>
        string Translate(CultureInfo culture, TranslatedKeyLabel key);

        /// <summary>
        /// return the list of available cultures
        /// </summary>
        CultureInfo[] AvailableCultures { get; }

        /// <summary>
        /// Container for store the keys
        /// </summary>
        public object Container { get; set; }


    }

}



