using System.Globalization;

namespace Bb.Translations
{

    /// <summary>
    /// container for storing the translations
    /// </summary>
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
        /// Try to resolve the key for the specified culture
        /// </summary>
        /// <param name="key">The key to translate</param>
        /// <param name="culture">the target culture</param>
        /// <param name="result">the result of the translation</param>
        /// <returns></returns>
        bool Get(TranslatedKeyLabel key, CultureInfo culture, out DataTranslation result);


        /// <summary>
        /// Return a translation for the key mapped to the current culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TranslatedKeyLabel Get(TranslatedKeyLabel key);


        /// <summary>
        /// Try to resolve the key
        /// </summary>
        /// <param name="key">The key to translate</param>
        /// <param name="result">the result of the translation</param>
        /// <returns></returns>
        bool Get(TranslatedKeyLabel key, out DataTranslation result);

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



