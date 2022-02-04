using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Translations;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Translations
{

    public sealed class TestsTranslation1
    {

        [Fact]
        public void Test1()
        {

            string test = "p:menuLanguage,k:French (France),l:en-us, d:French (France), l1:fr-fr, d1:Français de france";

            TranslatedKeyLabel label = test;


            var c = CultureInfo.GetCultureInfo("fr-fr");
            var l = label.Datas[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "Français de france");
            Assert.Equal(l.Culture, c);

            c = CultureInfo.GetCultureInfo("en-us");
            l = label.Datas[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "French (France)");
            Assert.Equal(l.Culture, c);

        }




    }

}
