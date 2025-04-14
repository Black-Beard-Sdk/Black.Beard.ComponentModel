using System.Collections.Generic;
using System.Globalization;

namespace Bb.Translations
{


    /// <summary>
    /// container for storing translations in memory
    /// </summary>
    public interface ITranslateContainer
    {

        /// <summary>
        /// Try to resolve the key for the specified culture
        /// </summary>
        /// <param name="path">The key to translate</param>
        /// <param name="key">The key to translate</param>
        /// <param name="culture">the target culture</param>
        /// <param name="result">the result of the translation</param>
        /// <returns></returns>
        bool Get(string path, string key, CultureInfo culture, out DataTranslation result);


        /// <summary>
        /// Try to resolve the key for the specified culture
        /// </summary>
        /// <param name="key">The key to translate</param>
        /// <param name="culture">the target culture</param>
        /// <param name="result">the result of the translation</param>
        /// <returns></returns>
        bool Get(TranslationKey key, CultureInfo culture, out DataTranslation result);


        /// <summary>
        /// Return all paths context available in the container
        /// </summary>
        /// <returns></returns>
        IEnumerable<string> GetAll();


        /// <summary>
        /// Return all translation available for the key mapped with culture
        /// </summary>
        /// <param name="path">specify the context</param>
        /// <returns></returns>
        IEnumerable<DataTranslation> GetAll(string path);

        /// <summary>
        /// Return all translation available for the key mapped with culture
        /// </summary>
        /// <param name="path">specify the context</param>
        /// <param name="key">specify the key</param>
        /// <returns></returns>
        IEnumerable<DataTranslation> GetAll(string path, string key);

        /// <summary>
        /// Add a new key in the referential
        /// </summary>
        /// <param name="path">specify the context</param>
        /// <param name="key">specify the key</param>
        /// <param name="culture">the target culture</param>
        /// <param name="result">the result of the translation</param>
        DataTranslation? Add(string path, string key, CultureInfo culture, string result);

        /// <summary>
        /// Add a new key in the referential
        /// </summary>
        /// <param name="key">specify the key</param>
        /// <param name="culture">the target culture</param>
        DataTranslation? Add(TranslationKey key, CultureInfo culture);

        /// <summary>
        /// Add a new key in the referential
        /// </summary>
        /// <param name="key">specify the key</param>
        /// <param name="culture">the target culture</param>
        /// <param name="result">translation</param>
        DataTranslation? Add(TranslationKey key, CultureInfo culture, string result);


    }


}



