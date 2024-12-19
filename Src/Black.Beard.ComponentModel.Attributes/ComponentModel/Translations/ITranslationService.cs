using System.Globalization;

namespace Bb.ComponentModel.Translations
{

    /// <summary>
    /// Contract for translation service
    /// </summary>
    public interface ITranslateHost
    {

        ITranslateService TranslationService { get; }

    }

    /// <summary>
    /// Contract for translation service
    /// </summary>
    public interface ITranslateService
    {

        /// <summary>
        /// Translate the key and return the value for the current culture
        /// </summary>
        /// <param name="key">translation key</param>
        /// <param name="arguments">translation keys arguments. (if the result of the translation contains "{\d}", a String.Format is apply with specified arguments</param>
        /// <example>"Do you want to delete item {0}"</example>
        /// <returns></returns>
        string Translate(TranslatedKeyLabel key, params TranslatedKeyLabel[] arguments);

        /// <summary>
        /// Translate the key and return the value for the specified culture
        /// </summary>
        /// <param name="culture">culture asked</param>
        /// <param name="key">translation key</param>
        /// <param name="arguments">translation keys arguments. (if the result of the translation contains "{\d}" a String.Format is apply with specified arguments</param>
        /// <example>"Do you want to delete item {0}"</example>
        /// <returns></returns>
        string Translate(CultureInfo culture, TranslatedKeyLabel key, params TranslatedKeyLabel[] arguments);

        /// <summary>
        /// return the list of available cultures
        /// </summary>
        CultureInfo[] AvailableCultures { get; }

        /// <summary>
        /// Container for store the keys
        /// </summary>
        public ITranslateContainer Container { get; set; }

    }


}



