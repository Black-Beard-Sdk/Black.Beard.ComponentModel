using System;
using System.Globalization;
using System.Linq;
using Bb.Translations;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Translations
{


    public sealed class TestsTranslationKeys
    {

        [Fact]
        public void Test1()
        {


            TranslationKey.ModeDebug = true;
            bool Test = false;

            TranslationKey.DebugTrace += (s, r, t) =>
            {
                Test = true;
            };


            string test = "p:menuLanguage,k:French (France),d:en-us, en-us:French (France), fr-fr:Français de france";

            TranslationKey label = test.ToTranslation();


            var c = CultureInfo.GetCultureInfo("fr-fr");
            var l = label[c];

            Assert.Equal("French (France)", l.Key);
            Assert.Equal("menuLanguage", l.Path);
            Assert.Equal("French (France)", l.Value);
            Assert.Equal(l.Culture, c);

            c = CultureInfo.GetCultureInfo("en-us");
            l = label[c];

            Assert.Equal("French (France)", l.Key);
            Assert.Equal("menuLanguage", l.Path);
            Assert.Equal("French (France)", l.Value);
            Assert.Equal(l.Culture, c);

            Assert.False(Test);
            Assert.False(label.IsNotValidKey);

        }


        [Fact]
        public void Test2()
        {

            TranslationKey.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France),d:en-us, en-us:French (France), aaaaaa:Français de france";

            TranslationKey label = test.ToTranslation();

            var c = CultureInfo.GetCultureInfo("en-us");
            var l = label[c];

            Assert.Equal("French (France)", l.Key);
            Assert.Equal("menuLanguage", l.Path);
            Assert.Equal("French (France)", l.Value);
            Assert.Equal(l.Culture, c);
            Assert.Single(label.Translations);
            Assert.True(label.IsNotValidKey);
        }


        [Fact]
        public void Test3()
        {

            TranslationKey.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France), en-us:French (France), fr-fr:Français de france";

            TranslationKey label = test.ToTranslation();

            var c = CultureInfo.GetCultureInfo("fr-fr");
            var l = label[c];

            Assert.Equal("French (France)", l.Key);
            Assert.Equal("menuLanguage", l.Path);
            Assert.Equal("French (France)", l.Value);
            Assert.Equal(l.Culture, c);
            Assert.Equal(2, label.Translations.Count());

        }


        [Fact]
        public void Test4()
        {

            TranslationKey.ModeDebug = false;

            string test = "p:menuLanguage,k:French (France),d:en-us, fr-fr:Français de france"
                ;

            TranslationKey label = test.ToTranslation();

            var c = CultureInfo.GetCultureInfo("en-us");
            var l = label[c];

            Assert.Equal("French (France)", l.Key);
            Assert.Equal("menuLanguage", l.Path);
            Assert.Equal(string.Empty, l.Value);
            Assert.Equal(l.Culture, c);

        }


        [Fact]
        public void Test5()
        {

            TranslationKey.ModeDebug = true;
            bool Test = false;

            TranslationKey.DebugTrace += (s, r, t) =>
            {
                Test = true;
            };

            string test = "p:menuLanguage,k:French (France),l:aaaaaa, en-us:French (France), fr-fr:Français de france";

            test.ToTranslation();

            Assert.True(Test);

        }


        [Fact]
        public void Test6()
        {

            string test = "p:menuLanguage, k:French (France), d:en-us, en-us:French (France), fr-fr:Français de france";
            //             p:menuLanguage, k:French (France), d:en-US, en-us:French (France), fr-fr:Français de france
            TranslationKey label = test.ToTranslation();

            var aaa = label.ToString();

            StringComparer.InvariantCultureIgnoreCase.Equals(aaa, test).Should().BeTrue();

        }



    }

}
