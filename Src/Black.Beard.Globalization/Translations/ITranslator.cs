using System.Globalization;

namespace Bb.Translations
{
    /// <summary>
    /// Defines a translator for converting text between different cultures.
    /// </summary>
    public interface ITranslator
    {

        /// <summary>
        /// Translates the specified text from the source culture to the target culture.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="sourceCulture">The culture of the source text.</param>
        /// <param name="targetCulture">The culture to translate the text into.</param>
        /// <returns>The translated text.</returns>
        /// <remarks>
        /// This method performs a translation of the given text from the specified source culture to the target culture.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ITranslator translator = ...;
        /// string translatedText = translator.Translate("Hello", CultureInfo.GetCultureInfo("en-US"), CultureInfo.GetCultureInfo("fr-FR"));
        /// Console.WriteLine(translatedText); // Output: "Bonjour"
        /// </code>
        /// </example>
        string Translate(string text, CultureInfo sourceCulture, CultureInfo targetCulture);

    }

}



