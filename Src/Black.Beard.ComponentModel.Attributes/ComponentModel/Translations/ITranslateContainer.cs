using System.Globalization;

namespace Bb.ComponentModel.Translations
{
    public interface ITranslateContainer
    {


        /// <summary>
        /// Return a translation for the key and the culture
        /// </summary>
        /// <param name="key">key translation</param>
        /// <param name="culture">culture target</param>
        /// <returns></returns>
        DataTranslation Get(TranslatedKeyLabel key, CultureInfo culture);

        /// <summary>
        /// Return a translation for the key mapped to the current culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TranslatedKeyLabel Get(TranslatedKeyLabel key);

        /// <summary>
        /// Return a translation for the key mapped with culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TranslatedKeyLabel GetAll(TranslatedKeyLabel key);

        /// <summary>
        /// Add a new key in the referential
        /// </summary>
        /// <param name="key"></param>
        void Add(TranslatedKeyLabel key);

        /// <summary>
        /// Load the translations
        /// </summary>
        void Load();

        /// <summary>
        /// save the translations
        /// </summary>
        void Save();

    }


}



