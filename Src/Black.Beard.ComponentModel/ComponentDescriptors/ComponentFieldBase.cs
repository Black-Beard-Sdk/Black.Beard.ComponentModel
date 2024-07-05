using Bb.ComponentModel.Translations;


namespace Bb.ComponentDescriptors
{

    public interface IComponentFieldBase
    {

        ITranslateService TranslateService { get; set; }

        PropertyObjectDescriptor? Property { get; set; }

        string StrategyName { get; set; }

    }

    public interface IComponentFieldBase<T> : IComponentFieldBase
    {

    }

}