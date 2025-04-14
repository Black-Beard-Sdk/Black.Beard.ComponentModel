using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Bb.Translations
{

    [DebuggerDisplay("{Path}")]
    internal class PathContext
    {

        public PathContext(TranslationContainer parent, string context)
        {
            this.Parent = parent;
            this.Path = context;
        }

        public virtual void Add(TranslationKey key, CultureInfo culture, string result)
        {
            EnsureExists(key.Key)
                .Add(key, culture, result);
        }
    
        internal IEnumerable<DataTranslation> GetAll()
        {
            foreach (var item in _keys)
                foreach (DataTranslation item2 in item.Value.GetAll())
                    yield return item2;
        }

        internal bool Get(string key, out KeyContext keyResult)
        {
            return _keys.TryGetValue(key, out keyResult);
        }


        internal bool Get(TranslationKey key, CultureInfo culture, out DataTranslation result)
        {
            
            if (EnsureExists(key.Key)
                .Get(key, culture, out result))
                return true;

            result = null;
            return false;

        }

        internal bool Get(string key, CultureInfo culture, out DataTranslation result)
        {
            
            if (EnsureExists(key)
                .Get(culture, out result))
                return true;

            result = null;
            return false;

        }

        public TranslationContainer Parent { get; }
        public string Path { get; }

        private KeyContext EnsureExists(string key)
        {
            if (!_keys.TryGetValue(key, out KeyContext context))
                lock (_lock)
                    if (!_keys.TryGetValue(key, out context))
                    {
                        context = new KeyContext(this, key);
                        _keys.Add(key, context);
                    }

            return context;
        }

        private readonly Dictionary<string, KeyContext> _keys = new Dictionary<string, KeyContext>();
        private readonly object _lock = new object();

    }



}



