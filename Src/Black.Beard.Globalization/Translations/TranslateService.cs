using Bb.Translations.Stores;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bb.Translations
{

    /// <summary>
    /// Service to translate the keys
    /// </summary>
    public class TranslateService : ITranslateService
    {

        #region ctor

        /// <summary>
        /// Initialize the service
        /// </summary>
        public TranslateService() 
            : this(null, null, null)
        {
            
        }

        /// <summary>
        /// Initialize the service
        /// </summary>        
        /// <param name="translationStore">service for manage IO interactions</param>
        /// <param name="translator">service for resolve translations</param>
        public TranslateService(ITranslationStore? translationStore, ITranslator? translator = null)
            : this(null, translationStore, translator)
        {

        }

        /// <summary>
        /// Initialize the service
        /// </summary>
        /// <param name="container">container for storing translation in memory</param>
        /// <param name="translationStore">service for manage IO interactions</param>
        /// <param name="translator">service for resolve translations</param>
        public TranslateService(ITranslateContainer? container, ITranslationStore? translationStore = null, ITranslator? translator = null)
        {
            _availableCultures = new HashSet<CultureInfo> { CultureInfo.InvariantCulture };
            _container = container ?? new TranslationContainer();
            _store = translationStore ?? new StoreFile();
            _translator = translator;
        }

        #endregion ctor


        /// <summary>
        /// Failed to resolve the key
        /// </summary>
        /// <param name="path">path context</param>
        /// <param name="key">key that fails</param>
        /// <param name="culture">culture should be resolved</param>
        protected virtual void FailedToResolve(string path, string key, CultureInfo culture)
        {

        }

        /// <summary>
        /// Translate the key for th current culture
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Translate(TranslationKey key)
        {
            return Translate(CultureInfo.CurrentUICulture, key);
        }

        /// <summary>
        /// Translate the key for th current culture
        /// </summary>
        /// <param name="culture">target culture</param>
        /// <param name="key">key to translate</param>
        /// <returns></returns>
        public string Translate(CultureInfo culture, TranslationKey key)
        {

            DataTranslation result;

            if (!key.IsNotValidKey)
            {

                if (!_container.Get(key, culture, out result) && !TryRead(key, culture, out result))
                    FailedToResolve(key.Path, key.Key, culture);

                if (result != null)
                    return result.Value;

            }

            return  key.DefaultDisplay ?? key.Key;

        }


        /// <summary>
        /// return the available cultures
        /// </summary>
        public CultureInfo[] AvailableCultures
        {
            get
            {
                CultureInfo[] cultures = new CultureInfo[_availableCultures.Count];
                _availableCultures.CopyTo(cultures.ToArray(), 0);
                return cultures;
            }
        }


        private bool TryRead(TranslationKey key, CultureInfo culture, out DataTranslation result)
        {

            // Search in store
            if (_store != null && _store.Read(key.Path, key.Key, culture, out string? resultTxt))
            {
                result = _container.Add(key, culture, resultTxt);
                return true;
            }

            // Search in the key
            if (TryReadFromKey(key, culture, out result))
                return true;

            var items = _container.GetAll(key.Path, key.Key);
            if (items != null && items.Any())
            {

                var pp = items.FirstOrDefault(items => items.Culture.TwoLetterISOLanguageName.ToLower() == "en");

                if (pp == null)
                    pp = items.FirstOrDefault();

                var datas = _translator.Translate(pp.Value, pp.Culture, culture);
                if (!string.IsNullOrEmpty(datas))
                {
                    Write(key.Path, key.Key, culture, datas);
                    result = _container.Add(key, culture, datas);
                    return true;
                }

            }

            result = null;
            return false;

        }

        private bool TryReadFromKey(TranslationKey key, CultureInfo culture, out DataTranslation result)
        {
            result = _container.Add(key, culture);
            if (result != null)
            {
                Write(key.Path, key.Key, result.Culture, result.Value);
                return true;
            }

            result = null;
            return false;
        }

        private void Write(string path, string key, CultureInfo culture, string result)
        {
            if (_store != null)
                _store.Write(path, key, culture, result);
        }


        private readonly HashSet<CultureInfo> _availableCultures;
        private readonly ITranslateContainer _container;
        private readonly ITranslator? _translator; 
        private readonly ITranslationStore _store;


    }


}
