using System;
using System.Globalization;
using Bb.ComponentModel.Translations;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Translations
{

    public sealed class TestsTranslation1
    {

        [Fact]
        public void Test1()
        {


            TranslatedKeyLabel.ModeDebug = true;
            bool Test = false;

            TranslatedKeyLabel.DebugTrace += (s, r, t) =>
            {
                Test = true;
            };


            string test = "p:menuLanguage,k:French (France),l:en-us, d:French (France)" +
                ", fr-fr:Français de france"
                ;

            TranslatedKeyLabel label = test;


            var c = CultureInfo.GetCultureInfo("fr-fr");
            var l = label.Translations[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "Français de france");
            Assert.Equal(l.Culture, c);

            c = CultureInfo.GetCultureInfo("en-us");
            l = label.Translations[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "French (France)");
            Assert.Equal(l.Culture, c);

            Assert.False(Test);
            Assert.False(label.IsNotValidKey);

        }


        [Fact]
        public void Test2()
        {

            TranslatedKeyLabel.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France),l:en-us, d:French (France)" +
                ", aaaaaa:Français de france"
                ;

            TranslatedKeyLabel label = test;

            var c = CultureInfo.GetCultureInfo("en-us");
            var l = label.Translations[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "French (France)");
            Assert.Equal(l.Culture, c);

        }


        [Fact]
        public void Test3()
        {

            TranslatedKeyLabel.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France),l:aaaaaa, d:French (France)" +
                ", fr-fr:Français de france"
                ;

            TranslatedKeyLabel label = test;

            var c = CultureInfo.GetCultureInfo("fr-fr");
            var l = label.Translations[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "Français de france");
            Assert.Equal(l.Culture, c);

        }


        [Fact]
        public void Test4()
        {

            TranslatedKeyLabel.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France),l:en-us, d:Fr\\,ench (France)" +
                ", fr-fr:Français de france"
                ;

            TranslatedKeyLabel label = test;

            var c = CultureInfo.GetCultureInfo("en-us");
            var l = label.Translations[c];

            Assert.Equal(l.Key, "French (France)");
            Assert.Equal(l.Path, "menuLanguage");
            Assert.Equal(l.Value, "Fr,ench (France)");
            Assert.Equal(l.Culture, c);

        }


        [Fact]
        public void Test5()
        {

            TranslatedKeyLabel.ModeDebug = true;
            bool Test = false;

            TranslatedKeyLabel.DebugTrace += (s, r, t) =>
            {
                Test = true;
            };

            string test = "p:menuLanguage,k:French (France),l:aaaaaa, d:French (France)" +
                ", fr-fr:Français de france"
                ;

            TranslatedKeyLabel label = test;

            Assert.True(Test);

        }

        [Fact]
        public void Test6()
        {

            string test = "p:menuLanguage, k:French (France), l:en-us, d:French (France)" +
                ", fr-fr:Français de france"
                ;

            TranslatedKeyLabel label = test;

            var aaa = label.ToString();

            StringComparer.InvariantCultureIgnoreCase.Equals(aaa, test).Should().BeTrue();

        }



    }

}
