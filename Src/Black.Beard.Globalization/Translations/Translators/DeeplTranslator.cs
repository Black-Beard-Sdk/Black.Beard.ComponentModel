// Ignore Spelling: Deepl api

using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Globalization;
using Bb.Exceptions;

namespace Bb.Translations.Translators
{

    /// <summary>
    /// Translator using Deepl API
    /// </summary>
    public class DeeplTranslator : ITranslator
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="DeeplTranslator"/> class with the specified API key.
        /// </summary>
        /// <param name="apiKey"></param>
        public DeeplTranslator(string apiKey)
        {
            _apiKey = apiKey;
        }

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
        public string Translate(string text, CultureInfo sourceCulture, CultureInfo targetCulture)
        {
            var selectedLanguage = sourceCulture.TwoLetterISOLanguageName.ToUpper();
            var targetLanguage = targetCulture.TwoLetterISOLanguageName.ToUpper();
            if (Deepl(selectedLanguage, targetLanguage, text, out string result))
                return result;
            else
                throw new TranslatorException("Error during translation");
        }


        private bool Deepl(string selectedLanguage, string targetLanguage, string text, out string result)
        {

            result = string.Empty;
            var requestBody = new StringContent(
                $"auth_key={_apiKey}&text={Uri.EscapeDataString(text)}&source_lang={selectedLanguage}&target_lang={targetLanguage}",
                Encoding.UTF8,
                "application/x-www-form-urlencoded"
            );

            var response = _client.PostAsync(_deeplApiUrl, requestBody).Result;
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                var jsonDocument = JsonDocument.Parse(jsonResponse);
                result = jsonDocument
                    .RootElement
                    .GetProperty("translations")[0]
                    .GetProperty("text")
                    .GetString();

                return true;
            }

            return false;

        }


        private static readonly HttpClient _client = new HttpClient();
        private static readonly string _deeplApiUrl = "https://" + "api-free.deepl.com" + "/v2/translate";
        private readonly string _apiKey;

    }
}
