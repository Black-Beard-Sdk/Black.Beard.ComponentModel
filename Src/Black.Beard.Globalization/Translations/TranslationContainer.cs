using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bb.Translations
{

    /// <summary>
    /// Represents an implementation of container for storing translations in memory.
    /// </summary>
    /// <remarks>
    /// This class provides methods for adding, retrieving, and managing translations in a structured way.
    /// </remarks>
    public class TranslationContainer : ITranslateContainer
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationContainer"/> class.
        /// </summary>
        public TranslationContainer()
        {

        }

        /// <summary>
        /// Adds a translation key and its associated culture to the container.
        /// </summary>
        /// <param name="key">The translation key to add.</param>
        /// <param name="culture">The culture for the translation.</param>
        /// <returns>The added <see cref="DataTranslation"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> or <paramref name="culture"/> is <c>null</c>.</exception>
        /// <example>
        /// <code lang="C#">
        /// var translation = container.Add(new TranslationKey("greeting", "Hello"), CultureInfo.GetCultureInfo("en-US"));
        /// </code>
        /// </example>
        public DataTranslation? Add(TranslationKey key, CultureInfo culture)
        {

            foreach (var item in key.Translations.Select(c => c))
            {

                EnsureExists(key.Path)
                    .Add(key, item.Culture, item.Value);

            }

            if (Get(key.Path, key.Key, culture, out var result))
                return result;

            return null;

        }

        /// <summary>
        /// Adds a new key to the referential.
        /// </summary>
        /// <param name="path">The context or group for the key.</param>
        /// <param name="key">The key to add.</param>
        /// <param name="culture">The target culture for the translation.</param>
        /// <param name="result">The translation result.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="path"/>, <paramref name="key"/>, <paramref name="culture"/>, or <paramref name="result"/> is <c>null</c> or empty.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// container.Add("path.to.group", "greeting", CultureInfo.GetCultureInfo("en-US"), "Hello");
        /// </code>
        /// </example>
        public virtual DataTranslation? Add(string path, string key, CultureInfo culture, string result)
        {

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            if (string.IsNullOrEmpty(result))
                throw new ArgumentNullException(nameof(result));

            var key1 = new TranslationKey(path, key, result, TranslationKey.CurrentCulture);

            EnsureExists(path)
                .Add(key1, culture, result);

            if (Get(path, key, culture, out var result1))
                return result1;

            return null;

        }

        /// <summary>
        /// Adds a new key to the referential.
        /// </summary>
        /// <param name="key">The key to add.</param>
        /// <param name="culture">The target culture for the translation.</param>
        /// <param name="result">The translation result.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="key"/>, <paramref name="key"/>, <paramref name="culture"/>, or <paramref name="result"/> is <c>null</c> or empty.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// container.Add("path.to.group", "greeting", CultureInfo.GetCultureInfo("en-US"), "Hello");
        /// </code>
        /// </example>
        public virtual DataTranslation? Add(TranslationKey key, CultureInfo culture, string result)
        {

            if (key == null)
                throw new ArgumentNullException(nameof(key));

            EnsureExists(key.Path)
                .Add(key, culture, result);

            if (Get(key, culture, out var result1))
                return result1;

            return null;

        }

        /// <summary>
        /// Retrieves a translation for the specified key and culture.
        /// </summary>
        /// <param name="key">The translation key to retrieve.</param>
        /// <param name="culture">The culture for the translation.</param>
        /// <param name="result">When this method returns, contains the retrieved <see cref="DataTranslation"/> if found; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the translation was found; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="key"/> or <paramref name="culture"/> is <c>null</c>.</exception>
        /// <example>
        /// <code lang="C#">
        /// if (container.Get(new TranslationKey("greeting"), CultureInfo.GetCultureInfo("en-US"), out var translation))
        /// {
        ///     Console.WriteLine(translation.Value);
        /// }
        /// </code>
        /// </example>
        public bool Get(TranslationKey key, CultureInfo culture, out DataTranslation result)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            if (EnsureExists(key.Path)
                .Get(key, culture, out result))
                return true;

            result = null;
            return false;

        }

        /// <summary>
        /// Retrieves a translation for the specified path, key, and culture.
        /// </summary>
        /// <param name="path">The context or group for the key.</param>
        /// <param name="key">The key to retrieve.</param>
        /// <param name="culture">The culture for the translation.</param>
        /// <param name="result">When this method returns, contains the retrieved <see cref="DataTranslation"/> if found; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the translation was found; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="path"/>, <paramref name="key"/>, or <paramref name="culture"/> is <c>null</c>.</exception>
        /// <example>
        /// <code lang="C#">
        /// if (container.Get("path.to.group", "greeting", CultureInfo.GetCultureInfo("en-US"), out var translation))
        /// {
        ///     Console.WriteLine(translation.Value);
        /// }
        /// </code>
        /// </example>
        public bool Get(string path, string key, CultureInfo culture, out DataTranslation result)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            if (EnsureExists(path)
                .Get(key, culture, out result))
                return true;

            result = null;
            return false;

        }

        /// <summary>
        /// Returns all available paths in the container.
        /// </summary>
        /// <returns>An enumerable collection of paths.</returns>
        /// <example>
        /// <code lang="C#">
        /// foreach (var path in container.GetAll())
        /// {
        ///     Console.WriteLine(path);
        /// }
        /// </code>
        /// </example>
        public virtual IEnumerable<string> GetAll()
        {
            return _paths.Keys;
        }

        /// <summary>
        /// Returns all translations available for the specified path.
        /// </summary>
        /// <param name="path">The context or group for the translations.</param>
        /// <returns>An enumerable collection of <see cref="DataTranslation"/> objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="path"/> is <c>null</c> or empty.</exception>
        /// <example>
        /// <code lang="C#">
        /// foreach (var translation in container.GetAll("path.to.group"))
        /// {
        ///     Console.WriteLine(translation.Value);
        /// }
        /// </code>
        /// </example>
        public virtual IEnumerable<DataTranslation> GetAll(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (_paths.TryGetValue(path, out PathContext context))
                context.GetAll();

            return Enumerable.Empty<DataTranslation>();

        }

        /// <summary>
        /// Returns all translations available for the specified path and key.
        /// </summary>
        /// <param name="path">The context or group for the translations.</param>
        /// <param name="key">The key for the translations.</param>
        /// <returns>An enumerable collection of <see cref="DataTranslation"/> objects.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="path"/> or <paramref name="key"/> is <c>null</c> or empty.</exception>
        /// <example>
        /// <code lang="C#">
        /// foreach (var translation in container.GetAll("path.to.group", "greeting"))
        /// {
        ///     Console.WriteLine(translation.Value);
        /// }
        /// </code>
        /// </example>
        public IEnumerable<DataTranslation> GetAll(string path, string key)
        {

            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException(nameof(path));
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            if (_paths.TryGetValue(path, out PathContext context) && context.Get(key, out KeyContext keyResult))
                return keyResult.GetAll();
            return Enumerable.Empty<DataTranslation>();

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private PathContext EnsureExists(string path)
        {
            if (!_paths.TryGetValue(path, out PathContext context))
                lock (_lock)
                    if (!_paths.TryGetValue(path, out context))
                    {
                        context = new PathContext(this, path);
                        _paths.Add(path, context);
                    }
            return context;
        }


        private readonly Dictionary<string, PathContext> _paths = new Dictionary<string, PathContext>();
        private readonly object _lock = new object();

    }

}



