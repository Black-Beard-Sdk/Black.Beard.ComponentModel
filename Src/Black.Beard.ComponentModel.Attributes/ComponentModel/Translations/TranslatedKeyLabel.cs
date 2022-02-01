using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Bb.ComponentModel.Translations
{
    /// <summary>
    /// "p:path, k:key, l:en-us, d:default value"
    /// </summary>
    [DebuggerDisplay("{DefaultDisplay}")]
    public class TranslatedKeyLabel
    {

        public TranslatedKeyLabel()
        {
            Culture = CultureInfo.InvariantCulture;
        }

        public TranslatedKeyLabel(string context, string key, string defaultDisplay, CultureInfo? culture = null)
        {
            Culture = culture ?? CultureInfo.InvariantCulture;
            this.Path = context;
            this.Key = key;

            this.DefaultDisplay = defaultDisplay;

        }

        public static TranslatedKeyLabel EmptyKey { get; } = new TranslatedKeyLabel(string.Empty, string.Empty, string.Empty);

        public string? Path { get; private set; }

        public string? Key { get; private set; }

        public CultureInfo Culture { get; private set; }

        public string? DefaultDisplay { get; private set; }

        public bool IsNotValidKey { get; private set; }

        public override string ToString()
        {

            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(Path))
                list.Add("p:" + Path);

            if (!string.IsNullOrEmpty(Key))
                list.Add("k:" + Key);

            if (Culture != CultureInfo.InvariantCulture)
                list.Add("l:" + Culture.IetfLanguageTag);

            if (!string.IsNullOrEmpty(DefaultDisplay))
                list.Add("d:" + DefaultDisplay);

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


        public static TranslatedKeyLabel? Parse(string key)
        {

            if (string.IsNullOrEmpty(key))
                return null;

            if (key.Contains("::"))
            {

            }

            TranslatedKeyLabel keyLabel = new TranslatedKeyLabel();
            bool t = false;
            var lexer = new Lexer(key);

            while (lexer.Next())
            {

                string subKey = lexer.SubKey;

                var index2 = subKey.IndexOf(':');
                if (index2 > -1)
                {

                    t = true;
                    var name = subKey.Substring(0, index2).ToLower();
                    var value = subKey.Substring(index2 + 1).Trim();

                    switch (name)
                    {

                        case "c":
                            keyLabel.Path = value;
                            break;
                        case "k":
                            keyLabel.Key = value;
                            break;
                        case "l":
                            keyLabel.Culture = CultureInfo.GetCultureInfo(value);
                            break;
                        case "d":
                            keyLabel.DefaultDisplay = value;
                            break;
                        default:
                            break;
                    }

                }

            }

            if (t)
            {
                if (string.IsNullOrEmpty(keyLabel.Key) && !string.IsNullOrEmpty(keyLabel.DefaultDisplay))
                    keyLabel.Key = keyLabel.DefaultDisplay;
                return keyLabel;
            }

            if (string.IsNullOrEmpty(keyLabel.DefaultDisplay))
            {
                keyLabel.DefaultDisplay = key;
                keyLabel.IsNotValidKey = true;
            }

            return keyLabel;

        }

        private class Lexer
        {

            public Lexer(string key)
            {
                this._payload = key;
            }

            public bool Next()
            {

                var n = _payload.IndexOf(',', index);
                if (n > -1)
                {
                    SubKey = _payload.Substring(index, n - index).Trim();
                    index = n + 1;
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

            private string _payload;
            int index = 0;


            public string SubKey { get; private set; }

        }

    }

}
