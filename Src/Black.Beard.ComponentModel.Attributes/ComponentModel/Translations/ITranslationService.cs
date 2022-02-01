using Bb.ComponentModel.Attributes;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Bb.ComponentModel.Translations
{


    public interface ITranslateService
    {

        string Translate(TranslatedKeyLabel key);


        string Translate(CultureInfo culture, TranslatedKeyLabel key);


        CultureInfo[] AvailableCultures { get; }

    }

}



