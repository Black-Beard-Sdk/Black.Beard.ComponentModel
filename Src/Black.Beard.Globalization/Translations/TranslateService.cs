using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Bb.Translations
{



    // [ExposeClass(ConstantsCore.Service, ExposedType = typeof(ITranslateService), LifeCycle = IocScopeEnum.Singleton)]
    public abstract class TranslateService : ITranslateService
    {

        public TranslateService()
        {
            _availableCultures = new HashSet<CultureInfo> { CultureInfo.InvariantCulture };
            _container = CreateContainer();
        }

        /// <summary>
        /// Create a container
        /// </summary>
        /// <returns></returns>
        protected abstract ITranslateContainer CreateContainer();

        /// <summary>
        /// Ask to create a new key
        /// </summary>
        /// <param name="label"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected abstract DataTranslation Create(TranslatedKeyLabel label, CultureInfo culture);

        /// <summary>
        /// Failed to create key
        /// </summary>
        /// <param name="label"></param>
        /// <param name="culture"></param>
        protected abstract void FailedToResolve(TranslatedKeyLabel label, CultureInfo culture);


        /// <summary>
        /// Translate the key for th current culture
        /// </summary>
        /// <param name="key"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public string Translate(TranslatedKeyLabel key, params TranslatedKeyLabel[] arguments)
        {
            return Translate(CultureInfo.CurrentUICulture, key, arguments);
        }

        /// <summary>
        /// Translate the key for th current culture
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="label"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public string Translate(CultureInfo culture, TranslatedKeyLabel label, params TranslatedKeyLabel[] arguments)
        {

            DataTranslation result;

            if (!label.IsNotValidKey)
            {

                if (!_container.Get(label, culture, out result))
                    lock (_lock)
                        if (!_container.Get(label, culture, out result))
                            foreach (var item in label.Translations)
                            {
                                var result1 = Create(label, culture);
                                if (result1.Culture.IetfLanguageTag == culture.IetfLanguageTag)
                                    result = result1;
                            }

                if (result != null)
                    return result.Value;

                else
                    FailedToResolve(label, culture);

            }

            var r = label.DefaultDisplay;
            return r;

        }

        /// <summary>
        /// return the available cultures
        /// </summary>
        public CultureInfo[] AvailableCultures => _availableCultures.ToArray();


        ITranslateContainer ITranslateService.Container
        {
            get => _container;
            set { _container = value; }
        }

        private HashSet<CultureInfo> _availableCultures;

        private volatile object _lock = new object();
        private ITranslateContainer _container;

    }


}
