using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;


namespace Bb.Translations
{

    /// <summary>
    /// Represents a translation key with associated translations and metadata.
    /// </summary>
    /// <remarks>
    /// A translation key is defined by its path, key, default display value, and associated translations for different cultures.
    /// </remarks>
    [DebuggerDisplay("{Path}:{Key}")]
    public class TranslationKey
    {

        #region ctor

        /// <summary>
        /// Initializes static members of the <see cref="TranslationKey"/> class.
        /// </summary>
        /// <remarks>
        /// This static constructor populates culture mappings for efficient lookup by name or LCID.
        /// </remarks>
        static TranslationKey()
        {

            foreach (var item in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                if (!culturesByNames.ContainsKey(item.Name)) culturesByNames.Add(item.Name, item);
                string lcid = item.LCID.ToString();
                if (!culturesByLcid.ContainsKey(lcid)) culturesByLcid.Add(lcid, item);
            }

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationKey"/> class.
        /// </summary>
        private TranslationKey()
        {
            this._translations = new Dictionary<CultureInfo, DataTranslation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationKey"/> class with a path and key.
        /// </summary>
        /// <param name="path">The context or group for the translation key.</param>
        /// <param name="key">The key of the translation.</param>
        /// <example>
        /// <code lang="C#">
        /// var key = new TranslationKey("path.to.group", "greeting");
        /// </code>
        /// </example>
        public TranslationKey(string path, string key)
            : this(path, key, null, null)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationKey"/> class with a key, default display value, and culture.
        /// </summary>
        /// <param name="key">The key of the translation.</param>
        /// <param name="defaultDisplay">The default display value for the translation key.</param>
        /// <param name="culture">The default culture for the translation key.</param>
        /// <example>
        /// <code lang="C#">
        /// var key = new TranslationKey("greeting", "Hello", CultureInfo.GetCultureInfo("en-US"));
        /// </code>
        /// </example>
        public TranslationKey(string key, string? defaultDisplay, CultureInfo culture)
            : this(string.Empty, key, defaultDisplay, culture)
        {


        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslationKey"/> class with a path, key, default display value, and culture.
        /// </summary>
        /// <param name="path">The context or group for the translation key.</param>
        /// <param name="key">The key of the translation.</param>
        /// <param name="defaultDisplay">The default display value for the translation key.</param>
        /// <param name="culture">The default culture for the translation key. Can be <c>null</c>.</param>
        /// <example>
        /// <code lang="C#">
        /// var key = new TranslationKey("path.to.group", "greeting", "Hello", CultureInfo.GetCultureInfo("en-US"));
        /// </code>
        /// </example>
        public TranslationKey(string path, string key, string? defaultDisplay, CultureInfo? culture)
            : this()
        {

            this.Path = path;
            this.Key = key;

            if (!string.IsNullOrEmpty(defaultDisplay) && culture != null)
            {
                this.DefaultCulture = culture;
                var trad = new DataTranslation(this) { Culture = this.DefaultCulture, Value = defaultDisplay };
                this._translations.Add(this.DefaultCulture, trad);
            }
            else
            {
                this.DefaultCulture = culture ?? CultureInfo.InvariantCulture;
            }

            if (ModeDebug && string.IsNullOrEmpty(key))
            {
                this.IsNotValidKey = true;
                Trace(this, key);
            }

        }

        #endregion

        /// <summary>
        /// Gets or sets the current culture for translations.
        /// </summary>
        /// <returns>The current <see cref="CultureInfo"/>.</returns>
        public static CultureInfo CurrentCulture { get => _currentCulture; set => _currentCulture = value ?? CultureInfo.CurrentCulture; } 

        [ThreadStatic]
        private static CultureInfo _currentCulture;

        /// <summary>
        /// Translates the current key using the specified translation host.
        /// </summary>
        /// <param name="service">The translation host to use for translation.</param>
        /// <returns>The translated string.</returns>
        /// <example>
        /// <code lang="C#">
        /// string translation = key.Translate(translationHost);
        /// </code>
        /// </example>
        public string Translate(ITranslateHost service)
        {
            return service.TranslationService.Translate(this);
        }

        /// <summary>
        /// Translates the current key using the specified translation service.
        /// </summary>
        /// <param name="service">The translation service to use for translation.</param>
        /// <returns>The translated string.</returns>
        /// <example>
        /// <code lang="C#">
        /// string translation = key.Translate(translationService);
        /// </code>
        /// </example>
        public string Translate(ITranslateService service)
        {
            return service.Translate(this);
        }

        /// <summary>
        /// Default key
        /// </summary>
        public static TranslationKey EmptyKey { get; } = new TranslationKey();

        /// <summary>
        /// Contract of the translation key
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        /// Translation key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Gets the default display value for the translation key.
        /// </summary>
        /// <returns>The default display value.</returns>
        public string DefaultDisplay => this._translations.Where(t => t.Key == this.DefaultCulture).Select(t => t.Value.Value).FirstOrDefault() ?? string.Empty;

        /// <summary>
        /// Default culture
        /// </summary>
        public CultureInfo DefaultCulture { get; set; }

        /// <summary>
        /// Return true if the key is not valid
        /// </summary>
        public bool IsNotValidKey { get; private set; }

        /// <summary>
        /// Convert a string to a TranslatedKeyLabel
        /// </summary>
        /// <param name="key">string key</param>
        public static implicit operator TranslationKey(string key)
        {
            return TranslationKey.Parse(key) ?? TranslationKey.EmptyKey;
        }

        /// <summary>
        /// Convert a TranslatedKeyLabel to a string
        /// </summary>
        /// <param name="key">Translated key label</param>
        public static implicit operator string(TranslationKey key)
        {
            return key.ToString();
        }

        /// <summary>
        /// Evaluate if the key is valid
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool IsValid(string key)
        {

            if (!string.IsNullOrEmpty(key))
            {
                var keyLabel = Parse(key);
                return !keyLabel.IsNotValidKey;
            }

            return false;

        }

        /// <summary>
        /// Attempts to convert a string into a <see cref="TranslationKey"/>.
        /// </summary>
        /// <param name="key">The string to convert.</param>
        /// <param name="keyLabel">When this method returns, contains the converted <see cref="TranslationKey"/> if the conversion succeeded; otherwise, <c>null</c>.</param>
        /// <returns><c>true</c> if the conversion succeeded; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code lang="C#">
        /// if (TranslationKey.TryConvert("p:path, k:key", out var key))
        /// {
        ///     Console.WriteLine(key);
        /// }
        /// </code>
        /// </example>
        public static bool TryConvert(string key, out TranslationKey keyLabel)
        {

            if (!string.IsNullOrEmpty(key))
            {
                keyLabel = Parse(key);
                return !keyLabel.IsNotValidKey;
            }

            keyLabel = null;
            return false;

        }
     
        /// <summary>
        /// Determines whether this instance and a specified object, which must also be a System.String object, have the same value
        /// </summary>
        /// <param name="obj">The string to compare to this instance.</param>
        /// <returns>true if obj is a System.String and its value is the same as this instance; otherwise, false. If obj is null, the method returns false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is TranslationKey key)
                return this.ToString().Equals(key.ToString());
            return false;
        }

        /// <summary>
        /// Returns the hash code for the current <see cref="TranslationKey"/>.
        /// </summary>
        /// <returns>The hash code for the current <see cref="TranslationKey"/>.</returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// return a valid translation key for the current instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(Path))
                list.Add("p:" + Path);

            if (!string.IsNullOrEmpty(Key))
                list.Add("k:" + Key);

            if (DefaultCulture != null)
                list.Add("d:" + DefaultCulture.IetfLanguageTag);

            foreach (var item in _translations)
                list.Add(item.Key.IetfLanguageTag.ToLower() + ":" + item.Value.Value);

            StringBuilder sb = new StringBuilder();
            string comma = string.Empty;
            foreach (var item in list)
            {
                sb.Append(comma);
                sb.Append(item);
                comma = ", ";
            }

            return sb.ToString();
        }

        /// <summary>
        /// If true the invalid keys can be intercepted with DebugTrace method
        /// </summary>
        public static bool ModeDebug { get; set; } = false;

        /// <summary>
        /// Intercept failed parsing of key
        /// </summary>
        public static Action<TranslationKey, string, string> DebugTrace { get; set; }



        #region translations

        /// <summary>
        /// return a translation for a culture
        /// </summary>
        /// <param name="culture">asked culture</param>
        /// <returns><see cref="DataTranslation"/></returns>
        public DataTranslation this[CultureInfo culture]
        {
            get
            {
                if (this._translations.TryGetValue(culture, out DataTranslation translation))
                    return translation;

                return new DataTranslation(this) { Culture = culture, Value = this.DefaultDisplay };
            }
        }

        /// <summary>
        /// Gets the translations for the current key.
        /// </summary>
        public IEnumerable<DataTranslation> Translations => _translations.Values;

        /// <summary>
        /// Adds a translation for the specified culture.
        /// </summary>
        /// <param name="culture">The culture for the translation.</param>
        /// <param name="value">The translation value.</param>
        /// <returns>The added <see cref="DataTranslation"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="culture"/> or <paramref name="value"/> is <c>null</c>.</exception>
        /// <example>
        /// <code lang="C#">
        /// key.AddTranslation(CultureInfo.GetCultureInfo("en-US"), "Hello");
        /// </code>
        /// </example>
        public DataTranslation AddTranslation(CultureInfo culture, string value)
        {
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            if (_translations.TryGetValue(culture, out var t))
            {
                if (t.Value != value)
                    t.Value = value;
            }
            else
            {
                t = new DataTranslation(this) { Value = value, Culture = culture };
                _translations.Add(culture, t);
            }

            return t;

        }

        #endregion translations




        #region parse

        /// <summary>
        /// Parses a string into a <see cref="TranslationKey"/>.
        /// </summary>
        /// <param name="key">The string to parse.</param>
        /// <returns>A <see cref="TranslationKey"/> instance.</returns>
        /// <example>
        /// <code lang="C#">
        /// var key = TranslationKey.Parse("p:path, k:key, l:en-us, d:default value");
        /// </code>
        /// </example>
        public static TranslationKey Parse(string key)
        {

            if (string.IsNullOrEmpty(key))
                return null;

            bool isValid = false;
            TranslationKey keyLabel = new TranslationKey();
            var lexer = new Lexer(key);

            while (lexer.Next(out string name, out string value))
                isValid = MapSwitch(keyLabel, name, value);

            Closure(key, isValid, keyLabel);

            return keyLabel;

        }

        private static bool MapSwitch(TranslationKey keyLabel, string name, string value)
        {
            bool isValid;
            switch (name)
            {
                case "p":
                case "path":
                    keyLabel.Path = value;
                    isValid = true;
                    break;

                case "k":
                case "key":
                    keyLabel.Key = value;
                    isValid = true;
                    break;

                case "d":
                case "default":
                    MapDefault(keyLabel, value);
                    isValid = true;
                    break;

                default:
                    MapLanguage(keyLabel, name, value);
                    isValid = !keyLabel.IsNotValidKey;
                    break;

            }

            return isValid;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void MapDefault(TranslationKey keyLabel, string value)
        {
            if (TryGetCulture(value, out var culture))
                keyLabel.DefaultCulture = culture;

            else
                keyLabel.IsNotValidKey = true;

        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void MapLanguage(TranslationKey keyLabel, string name, string value)
        {
            if (TryGetCulture(name, out var culture))
            {
                var translation = new DataTranslation(keyLabel) { Value = value, Culture = culture };
                if (!keyLabel._translations.ContainsKey(culture))
                    keyLabel._translations.Add(culture, translation);
                else
                    keyLabel._translations[culture] = translation;

            }
            else
            {
                keyLabel.IsNotValidKey = true;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Closure(string key, bool isValid, TranslationKey keyLabel)
        {
            if (!isValid)
                keyLabel.IsNotValidKey = true;

            else if (string.IsNullOrEmpty(keyLabel.Key) && !string.IsNullOrEmpty(keyLabel.DefaultDisplay))
                keyLabel.Key = keyLabel.DefaultDisplay;

            if (keyLabel.DefaultCulture != null && !keyLabel._translations.ContainsKey(keyLabel.DefaultCulture))
                keyLabel._translations.Add(keyLabel.DefaultCulture, new DataTranslation(keyLabel) { Value = keyLabel.DefaultDisplay, Culture = keyLabel.DefaultCulture });

            if (keyLabel.IsNotValidKey && ModeDebug)
            {
                Trace(keyLabel, key);

            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryGetCulture(string cultureName, out CultureInfo culture)
        {

            if (culturesByNames.TryGetValue(cultureName, out culture))
                return true;

            if (culturesByLcid.TryGetValue(cultureName, out culture))
                return true;

            culture = CultureInfo.InvariantCulture;
            return false;

        }

        private sealed class Lexer
        {

            public Lexer(string key)
            {
                this._payload = key;
            }

            public bool Next(out string name, out string value)
            {

                name = null;
                value = null;

                var n = GetNextComma(out bool escape);

                if (n > -1)
                {
                    SubKey = _payload.Substring(index, n - index).Trim();
                    index = n + 1;

                    if (escape)
                    {
                        SubKey = SubKey.Replace(@"\,", @",");
                        SubKey = SubKey.Replace(@"\\", @"\");
                    }

                    ReadValues(ref name, ref value);
                    return true;

                }
                else if (index > 0 && _payload.IndexOf(':', index) > -1)
                {
                    SubKey = _payload.Substring(index, _payload.Length - index).Trim();
                    index = _payload.Length;

                    ReadValues(ref name, ref value);
                    return true;

                }

                return false;

            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private bool ReadValues(ref string name, ref string value)
            {
                var index2 = SubKey.IndexOf(':');
                if (index2 > -1)
                {
                    name = SubKey.Trim().Substring(0, index2).ToLower();
                    value = SubKey.Trim().Substring(index2 + 1).TrimStart();
                    return true;
                }
                return false;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            private int GetNextComma(out bool escape)
            {

                escape = false;

                for (int i = index; i < _payload.Length; i++)
                {

                    var c2 = _payload[i];
                    if (',' == c2 && !escape)
                        return i;

                    else if (!escape && c2 == '\\')
                        escape = true;

                    else if (escape)
                        escape = false;

                }

                return -1;

            }

            private readonly string _payload;
            int index = 0;


            public string SubKey { get; private set; }

        }

        #endregion parse

        private static void Trace(TranslationKey key, string raw)
        {

            if (DebugTrace != null)
            {

                var trace = new StackTrace();
                for (int i = 0; i < trace.FrameCount; i++)
                {

                    var frame = trace.GetFrame(i);
                    var m = frame.GetMethod();
                    if (m?.DeclaringType != typeof(TranslationKey))
                    {
                        DebugTrace(key, raw, m.ToString());
                        return;
                    }

                }

            }

        }

        private readonly static Dictionary<string, CultureInfo> culturesByNames = new Dictionary<string, CultureInfo>(StringComparer.OrdinalIgnoreCase);
        private readonly static Dictionary<string, CultureInfo> culturesByLcid = new Dictionary<string, CultureInfo>(StringComparer.OrdinalIgnoreCase);
        private readonly Dictionary<CultureInfo, DataTranslation> _translations;

    }

}
