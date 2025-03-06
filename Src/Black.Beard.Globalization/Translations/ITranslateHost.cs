namespace Bb.Translations
{
    /// <summary>
    /// Contract for translation service
    /// </summary>
    public interface ITranslateHost
    {

        ITranslateService TranslationService { get; }

    }


}



