using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Bb.Translations
{


    /// <summary>
    /// Translation of a key
    /// </summary>
    [DebuggerDisplay("{Culture} : {Value}")]
    public class DataTranslation
    {

        internal DataTranslation(TranslatedKeyLabel parent)
        {
            this._parent = parent;
        }

        /// <summary>
        /// Contract of the translation key
        /// </summary>
        public string Path { get => _parent.Path; }

        /// <summary>
        /// Translation key
        /// </summary>
        public string Key { get => _parent.Key; }

        /// <summary>
        /// Culture of the translation
        /// </summary>
        public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>
        /// return the default value of the parent
        /// </summary>
        public string DefaultValueValue { get => _parent.DefaultDisplay; }

        /// <summary>
        /// return the default value of the parent
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {

            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(_parent.Path))
                list.Add("p:" + _parent.Path);

            if (!string.IsNullOrEmpty(_parent.Key))
                list.Add("k:" + _parent.Key);

            if (Culture != null)
                list.Add("l:" + Culture.IetfLanguageTag);

            if (!string.IsNullOrEmpty(Value))
                list.Add("d:" + Value);


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

        private readonly TranslatedKeyLabel _parent;


    }

}
