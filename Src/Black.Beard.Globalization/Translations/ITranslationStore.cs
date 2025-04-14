using System;
using System.Globalization;

namespace Bb.Translations
{


    /// <summary>
    /// Defines a store for managing translations.
    /// </summary>
    /// <remarks>
    /// This interface provides methods for reading and writing translations in a storage system.
    /// </remarks>
    public interface ITranslationStore
    {
   

        /// <summary>
        /// Reads a translation from the store.
        /// </summary>
        /// <param name="path">The path where the translation is stored.</param>
        /// <param name="key">The key associated with the translation.</param>
        /// <param name="culture">The culture of the translation.</param>
        /// <param name="result">The translation text if found; otherwise, <c>null</c>.</param>
        /// <returns>
        /// true if the translation was found; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method retrieves a translation for a specific key and culture from the specified path.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore store = ...;
        /// bool success = store.Read("translations", "greeting", CultureInfo.GetCultureInfo("en-US"), out string? translation);
        /// Console.WriteLine(translation); // Output: "Hello"
        /// </code>
        /// </example>
        bool Read(string path, string key, CultureInfo culture, out string? result);


        /// <summary>
        /// Reads all translations from the store and processes them using the specified action.
        /// </summary>
        /// <param name="stream">The action to process each translation. The tuple contains the path, key, culture, and translation data.</param>
        /// <remarks>
        /// This method iterates through all translations in the store and invokes the provided action for each translation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore store = ...;
        /// store.ReadAll(item =>
        /// {
        ///     Console.WriteLine($"Path: {item.path}, Key: {item.key}, Culture: {item.culture}, Data: {item.datas}");
        /// });
        /// </code>
        /// </example>
        void ReadAll(Action<(string path, string key, CultureInfo culture, string datas)> stream);


        /// <summary>
        /// Reads all translations from the store and processes them using the specified action.
        /// </summary>
        /// <param name="stream">The action to process each translation. The tuple contains the path, key, culture, and translation data.</param>
        /// <param name="path">The path where the translation is stored.</param>
        /// <remarks>
        /// This method iterates through all translation files in the directory and invokes the provided action for each translation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// store.ReadAll(item =>
        /// {
        ///     Console.WriteLine($"Path: {item.path}, Key: {item.key}, Culture: {item.culture}, Data: {item.datas}");
        /// });
        /// </code>
        /// </example>
        void ReadAll(Action<(string path, string key, CultureInfo culture, string datas)> stream, string path);


        /// <summary>
        /// Writes a translation to the store.
        /// </summary>
        /// <param name="path">The path where the translation is stored.</param>
        /// <param name="key">The key associated with the translation.</param>
        /// <param name="culture">The culture of the translation.</param>
        /// <param name="result">The translation text to store.</param>
        /// <remarks>
        /// This method saves a translation for a specific key and culture at the specified path.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore store = ...;
        /// store.Write("translations", "greeting", CultureInfo.GetCultureInfo("en-US"), "Hello");
        /// </code>
        /// </example>
        public void Write(string path, string key, CultureInfo culture, string result);


        /// <summary>
        /// Copies all translations from the specified source store to the current store.
        /// </summary>
        /// <param name="sourceStore">The source store to copy translations from.</param>
        /// <remarks>
        /// This method reads all translations from the source store and writes them to the current store.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslationStore sourceStore = ...;
        /// ITranslationStore targetStore = ...;
        /// targetStore.CopyFrom(sourceStore);
        /// </code>
        /// </example>
        void CopyFrom(ITranslationStore sourceStore);


    }

}



