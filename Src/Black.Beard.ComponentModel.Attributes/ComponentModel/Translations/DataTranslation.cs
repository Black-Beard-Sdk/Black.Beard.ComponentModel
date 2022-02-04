using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Bb.ComponentModel.Translations
{
    [DebuggerDisplay("{Culture} : {Value}")]
    public class DataTranslation
    {

        public DataTranslation(TranslatedKeyLabel parent)
        {
            this._parent = parent;
        }

        public string Path { get => _parent.Path; }

        public string Key { get => _parent.Key; }

        public CultureInfo Culture { get; set; } = CultureInfo.InvariantCulture;

        public string Value { get; set; } = string.Empty;

        public string DefaultValueValue { get => _parent.DefaultDisplay; }

        private readonly TranslatedKeyLabel _parent;

        public override string ToString()
        {

            List<string> list = new List<string>();

            if (!string.IsNullOrEmpty(_parent.Path))
                list.Add("p:" + _parent.Path);

            if (!string.IsNullOrEmpty(_parent.Key))
                list.Add("k:" + _parent.Key);

            if (Culture != null)
                list.Add("c:" + Value);

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

    }

}
