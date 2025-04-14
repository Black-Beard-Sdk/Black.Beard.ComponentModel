using System.Diagnostics;
using System.Globalization;

namespace Bb.Translations
{

    [DebuggerDisplay("{Culture.IetfLanguageTag}")]
    internal class DataByCultureContext
    {

        public DataByCultureContext(KeyContext parent, CultureInfo culture, string result)
        {
            this.Parent = parent;
            this.Culture = culture;
            this.Value = result;
        }


        public KeyContext Parent { get; }

        public CultureInfo Culture { get; }

        public string Value { get; set; }



        public DataTranslation GetDataTranslation(TranslationKey key)
        {
            return key.AddTranslation(Culture, Value);
        }


    }



}



