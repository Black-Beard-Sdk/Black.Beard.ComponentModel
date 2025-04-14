using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Bb.Translations
{


    [DebuggerDisplay("{Key}")]
    internal class KeyContext
    {


        public KeyContext(PathContext path, string key)
        {
            this.Parent = path;
            this.Key = key;
            this.TranslationKey = new TranslationKey(this.Parent.Path, this.Key, this.Key, TranslationKey.CurrentCulture);
        }


        public PathContext Parent { get; }

        public string Key { get; }

        public TranslationKey TranslationKey { get; private set; }

        internal void Add(TranslationKey key, CultureInfo culture, string result)
        {
            var c = culture.IetfLanguageTag;
            if (!_cultures.TryGetValue(c, out DataByCultureContext context))
                lock (_lock)
                    if (!_cultures.TryGetValue(c, out context))
                    {
                        context = new DataByCultureContext(this, culture, result);
                        _cultures.Add(c, context);
                    }
        }

        public IEnumerable<DataTranslation> GetAll()
        {
            return _cultures.Values.Select(c => c.GetDataTranslation(new TranslationKey(this.Parent.Path, Key)));
        }

        public bool Get(CultureInfo culture, out DataTranslation result)
        {
            if (_cultures.TryGetValue(culture.IetfLanguageTag, out var context))
            {
                result = context.GetDataTranslation(new TranslationKey(Parent.Path, Key));
                return true;
            }

            result = null;
            return false;

        }

        public bool Get(TranslationKey key, CultureInfo culture, out DataTranslation result)
        {
            if (_cultures.TryGetValue(culture.IetfLanguageTag, out DataByCultureContext context))
            {
                result = context.GetDataTranslation(key);
                return true;
            }

            result = null;
            return false;

        }

        private readonly Dictionary<string, DataByCultureContext> _cultures = new Dictionary<string, DataByCultureContext>();
        private readonly object _lock = new object();

    }



}



