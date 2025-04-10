namespace Bb.Translations
{

    /// <summary>
    /// Contract for translation service
    /// </summary>
    public interface ITranslateHost
    {

        /// <summary>
        /// return the translation service
        /// </summary>
        ITranslateService TranslationService { get; }

    }


}



