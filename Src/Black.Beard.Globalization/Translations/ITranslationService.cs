using System.Globalization;

namespace Bb.Translations
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
        /// <example>"Do you want to delete item {0}"</example>
        /// <returns></returns>
        string Translate(TranslationKey key);

        /// <summary>
        /// Translate the key and return the value for the specified culture
        /// </summary>
        /// <param name="culture">culture asked</param>
        /// <param name="key">translation key</param>
        /// <example>"Do you want to delete item {0}"</example>
        /// <returns></returns>
        string Translate(CultureInfo culture, TranslationKey key);

        /// <summary>
        /// return the list of available cultures
        /// </summary>
        CultureInfo[] AvailableCultures { get; }

    }


}



