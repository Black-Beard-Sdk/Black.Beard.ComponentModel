using System.Collections.Generic;
using System.ComponentModel;
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
            this.Datas = new Dictionary<CultureInfo, DataTranslation>();
        }

        public TranslatedKeyLabel(string? path, string key, string defaultDisplay, CultureInfo? culture = null)
        {
            this.Datas = new Dictionary<CultureInfo, DataTranslation>();
            this.Path = path;
            this.Key = key;
            this.DefaultDisplay = defaultDisplay;
        }

        public static TranslatedKeyLabel EmptyKey { get; } = new TranslatedKeyLabel(string.Empty, string.Empty, string.Empty);

        public string? Path { get; private set; }

        public string? Key { get; private set; }

        public Dictionary<CultureInfo, DataTranslation> Datas { get; }

        public string? DefaultDisplay { get; private set; }

        public bool IsNotValidKey { get; private set; }

        public override string ToString()
        {

            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(Path))
                list.Add("p:" + Path);

            if (!string.IsNullOrEmpty(Key))
                list.Add("k:" + Key);

            //if (!string.IsNullOrEmpty(DefaultDisplay))
            //    list.Add("d:" + DefaultDisplay);

            //foreach (var item in this.Datas)
            //{
            //    list.Add("");
            //}

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

            TranslatedKeyLabel keyLabel = new TranslatedKeyLabel();
            bool t = false;
            var lexer = new Lexer(key);

            Dictionary<string, DataTranslation> _items = new Dictionary<string, DataTranslation>();

            while (lexer.Next())
            {

                string subKey = lexer.SubKey;

                var index2 = subKey.IndexOf(':');
                if (index2 > -1)
                {

                    t = true;
                    string index = string.Empty;
                    var name = subKey.Trim().Substring(0, index2).ToLower();
                    var value = subKey.Trim().Substring(index2 + 1).Trim();
                    DataTranslation data;

                    if (name.Length > 1)
                    {
                        index = name.Substring(1);
                        name = name.Substring(0, 1);
                    }

                    switch (name)
                    {

                        case "p":
                            keyLabel.Path = value;
                            break;

                        case "k":
                            keyLabel.Key = value;
                            break;

                        case "l":
                            var c = CultureInfo.GetCultureInfo(value);
                            if (!_items.TryGetValue(index, out data))
                                _items.Add(index, (data = new DataTranslation(keyLabel) { Culture = c }));
                            else
                                data.Culture = c;
                            break;

                        case "d":
                            if (!_items.TryGetValue(index, out data))
                                _items.Add(index, (data = new DataTranslation(keyLabel) { Value = value }));
                            else
                                data.Value = value;
                            if (string.IsNullOrEmpty(index))
                                keyLabel.DefaultDisplay = value;
                            break;

                        default:
                            break;
                    }

                }

            }

            foreach (var item in _items)
            {
                var i = item.Value;
                if (i.Culture != CultureInfo.InvariantCulture && !string.IsNullOrEmpty(i.Value))
                    keyLabel.Datas.Add(i.Culture, i);
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
