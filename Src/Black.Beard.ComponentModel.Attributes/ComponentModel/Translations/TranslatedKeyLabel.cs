using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Transactions;
using System.Xml.Linq;

namespace Bb.ComponentModel.Translations
{


    /// <summary>
    /// "p:path, k:key, l:en-us, d:default value"
    /// </summary>
    [DebuggerDisplay("{DefaultDisplay}")]
    public class TranslatedKeyLabel
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedKeyLabel"/> class.
        /// </summary>
        private TranslatedKeyLabel()
        {
            this.Translations = new Dictionary<CultureInfo, DataTranslation>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedKeyLabel"/> class.
        /// </summary>
        /// <param name="defaultDisplay">use for create key</param>
        public TranslatedKeyLabel(string defaultDisplay)
            : this(null, defaultDisplay, defaultDisplay)
        {

            if (ModeDebug)
                Trace(this, string.Empty);


        }

        /// <summary>
        /// Translate the current key
        /// </summary>
        /// <param name="service">service that translate keys</param>
        /// <returns></returns>
        public string Translate(ITranslateHost service)
        {
            return service.TranslationService.Translate(this);
        }

        /// <summary>
        /// Translate the current key
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public string Translate(ITranslateService service)
        {
            return service.Translate(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedKeyLabel"/> class.
        /// </summary>
        /// <param name="path">group of translation key</param>
        /// <param name="defaultDisplay">default display</param>
        public TranslatedKeyLabel(string path, string defaultDisplay)
            : this(path, defaultDisplay, defaultDisplay)
        {

            if (ModeDebug)
                Trace(this, string.Empty);

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatedKeyLabel"/> class.
        /// </summary>
        /// <param name="path">context for group key</param>
        /// <param name="defaultDisplay">default display</param>
        /// <param name="key">key of translation</param>
        /// <param name="culture">default culture</param>
        public TranslatedKeyLabel(string? path, string defaultDisplay, string key, CultureInfo? culture = null)
        {
            this.Path = path;
            this.DefaultDisplay = defaultDisplay;
            this.Key = key ?? defaultDisplay;
            this.DefaultCulture = culture ?? CultureInfo.InvariantCulture;

            this.Translations = new Dictionary<CultureInfo, DataTranslation>
            {
                { this.DefaultCulture, new DataTranslation(this) { Culture = this.DefaultCulture, Value = defaultDisplay } }
            };

            if (defaultDisplay == null)
            {
                IsNotValidKey = true;
                if (ModeDebug)
                    Trace(this, string.Empty);
            }

        }

        /// <summary>
        /// Default key
        /// </summary>
        public static TranslatedKeyLabel EmptyKey { get; } = new TranslatedKeyLabel();

        /// <summary>
        /// Contract of the translation key
        /// </summary>
        public string? Path { get; private set; }

        /// <summary>
        /// Translation key
        /// </summary>
        public string? Key { get; private set; }

        /// <summary>
        /// Other translation
        /// </summary>
        public Dictionary<CultureInfo, DataTranslation> Translations { get; }

        /// <summary>
        /// return a translation for a culture
        /// </summary>
        /// <param name="culture">asked culture</param>
        /// <returns><see cref="DataTranslation"/></returns>
        public DataTranslation this[CultureInfo culture]
        {
            get
            {
                if (this.Translations.TryGetValue(culture, out DataTranslation translation))
                    return translation;

                return new DataTranslation(this) { Culture = culture, Value = this.DefaultDisplay };
            }
        }

        /// <summary>
        /// Default display
        /// </summary>
        public string? DefaultDisplay { get; set; }

        /// <summary>
        /// Default culture
        /// </summary>
        public CultureInfo DefaultCulture { get; set; }

        /// <summary>
        /// Return true if the key is not valid
        /// </summary>
        public bool IsNotValidKey { get; private set; }

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
                list.Add("l:" + DefaultCulture.IetfLanguageTag);

            if (!string.IsNullOrEmpty(DefaultDisplay))
                list.Add("d:" + DefaultDisplay);

            foreach (var item in Translations)
                if (item.Key != DefaultCulture)
                    list.Add(item.Key.IetfLanguageTag + ":" + item.Value.Value);

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


        public static implicit operator TranslatedKeyLabel(string key)
        {
            return TranslatedKeyLabel.Parse(key) ?? TranslatedKeyLabel.EmptyKey;
        }

        public static implicit operator string(TranslatedKeyLabel key)
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
        /// Try to convert text in translation key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="keyLabel"></param>
        /// <returns></returns>
        public static bool TryConvert(string key, out TranslatedKeyLabel keyLabel)
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
        /// Evaluate to key
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {

            if (obj is TranslatedKeyLabel key)
                return key.ToString() == this.ToString();

            return false;

        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// If true the invalid keys can be intercepted with DebugTrace method
        /// </summary>
        public static bool ModeDebug { get; set; } = false;

        /// <summary>
        /// Intercept failed parsing of key
        /// </summary>
        public static Action<TranslatedKeyLabel, string, string> DebugTrace { get; set; }


        /// <summary>
        /// Parse a key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TranslatedKeyLabel? Parse(string key)
        {

            if (string.IsNullOrEmpty(key))
                return null;

            CultureInfo culture;
            bool isValid = false;
            TranslatedKeyLabel keyLabel = new TranslatedKeyLabel();
            var lexer = new Lexer(key);

            while (lexer.Next())
            {

                string subKey = lexer.SubKey;

                var index2 = subKey.IndexOf(':');
                if (index2 > -1)
                {

                    var name = subKey.Trim().Substring(0, index2).ToLower();
                    var value = subKey.Trim().Substring(index2 + 1).TrimStart();

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

                        case "l":
                        case "language":
                            if (TryGetCulture(value, out culture))
                            {
                                keyLabel.DefaultCulture = culture;
                                isValid = true;
                            }
                            else
                            {
                                keyLabel.IsNotValidKey = true;
                            }
                            break;

                        case "d":
                        case "display":
                        case "defaultdisplay":
                            keyLabel.DefaultDisplay = value;
                            isValid = true;
                            break;

                        default:
                            if (TryGetCulture(name, out culture))
                            {
                                isValid = true;
                                var translation = new DataTranslation(keyLabel) { Value = value, Culture = culture };
                                if (!keyLabel.Translations.ContainsKey(culture))
                                    keyLabel.Translations.Add(culture, translation);
                                else
                                    keyLabel.Translations[culture] = translation;

                                if (culture == keyLabel.DefaultCulture)
                                    keyLabel.DefaultDisplay = value;
                            }
                            else
                            {
                                keyLabel.IsNotValidKey = true;
                            }
                            break;

                    }
                }

            }

            if (!isValid)
            {
                keyLabel.DefaultDisplay = keyLabel.Key = key;
                keyLabel.IsNotValidKey = true;
            }

            else if (string.IsNullOrEmpty(keyLabel.Key) && !string.IsNullOrEmpty(keyLabel.DefaultDisplay))
                keyLabel.Key = keyLabel.DefaultDisplay;

            else if (!string.IsNullOrEmpty(keyLabel.Key) && string.IsNullOrEmpty(keyLabel.DefaultDisplay))
                keyLabel.DefaultDisplay = keyLabel.Key;

            if (keyLabel.DefaultCulture != null && !keyLabel.Translations.ContainsKey(keyLabel.DefaultCulture))
                keyLabel.Translations.Add(keyLabel.DefaultCulture, new DataTranslation(keyLabel) { Value = keyLabel.DefaultDisplay, Culture = keyLabel.DefaultCulture });

            if (keyLabel.IsNotValidKey && ModeDebug)
            {
                Trace(keyLabel, key);

            }

            return keyLabel;

        }


        private static bool TryGetCulture(string cultureName, out CultureInfo culture)
        {
            culture = CultureInfo.InvariantCulture;
            try
            {
                culture = CultureInfo.GetCultureInfo(cultureName);
                return true;
            }
            catch (Exception)
            {
            }

            return false;

        }

        private class Lexer
        {

            public Lexer(string key)
            {
                this._payload = key;
            }

            public bool Next()
            {

                var n = GetNext(out bool escape);

                if (n > -1)
                {
                    SubKey = _payload.Substring(index, n - index).Trim();
                    index = n + 1;
                    if (escape)
                    {
                        SubKey = SubKey.Replace(@"\,", @",");
                        SubKey = SubKey.Replace(@"\\", @"\");
                    }
                    return true;
                }
                else if (index > 0 && _payload.IndexOf(':', index) > -1)
                {
                    SubKey = _payload.Substring(index, _payload.Length - index).Trim();
                    index = _payload.Length;
                    return true;
                }

                return false;

            }

            private int GetNext(out bool escape)
            {

                escape = false;
                bool escaped = false;

                for (int i = index; i < _payload.Length; i++)
                    if (_payload[i] == ',' && !escaped)
                        return i;

                    else if (escaped = _payload[i] == '\\')
                    {
                        escape = true;
                    }

                return -1;

            }

            private string _payload;
            int index = 0;


            public string SubKey { get; private set; }

        }

        private static void Trace(TranslatedKeyLabel key, string raw)
        {

            if (DebugTrace != null)
            {

                var trace = new StackTrace();
                for (int i = 0; i < trace.FrameCount; i++)
                {

                    var frame = trace.GetFrame(i);
                    var m = frame.GetMethod();
                    if (m?.DeclaringType != typeof(TranslatedKeyLabel))
                    {
                        DebugTrace(key, raw, m.ToString());
                        return;
                    }

                }

            }


        }


    }

}
