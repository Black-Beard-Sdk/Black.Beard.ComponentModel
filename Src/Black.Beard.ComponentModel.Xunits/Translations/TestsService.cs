using Bb.Translations;
using Bb.Translations.Stores;
using Bb.Translations.Translators;
using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace ComponentModels.Tests.Translations
{


    public sealed class TestsService
    {

        public TestsService()
        {
            _apiKey = "";
        }

        [Fact]
        public void Test0()
        {

            var cultureSource = new CultureInfo("fr-fr");
            var cultureTarget = new CultureInfo("en-US");
            var datas = "Connexion";


            var srv = new DeeplTranslator(_apiKey);
            var txt = srv.Translate(datas,  cultureSource, cultureTarget);

            Assert.Equal("Connection", txt);

        }

        [Fact]
        public void TestResolveFromStoreKey()
        {

            var path1 = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store = new StoreFile(path1);
            var api = new DeeplTranslator(_apiKey);
            var service = new TranslateService(null, store, api);

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var datas = Guid.NewGuid().ToString();
            var datas2 = Guid.NewGuid().ToString();


            store.Write(path, key, culture, datas2);


            var k = new TranslationKey(path, key, datas, culture);
            var txt = service.Translate(culture, k);

            Assert.Equal(datas2, txt);

        }

        [Fact]
        public void TestResolveFromKey()
        {

            var path1 = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store = new StoreFile(path1);
            var api = new DeeplTranslator(_apiKey);
            var service = new TranslateService(null, store, api);

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var datas = Guid.NewGuid().ToString();

            var k = new TranslationKey(path, key, datas, culture);
            var txt = service.Translate(culture, k);

            Assert.Equal(datas, txt);

        }

        [Fact]
        public void TestResolveFromKey2()
        {

            var path1 = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store = new StoreFile(path1);
            var api = new DeeplTranslator(_apiKey);
            var service = new TranslateService(null, store, api);

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var culture2 = new CultureInfo("en-us");
            var datas = "Connexion";

            var k = new TranslationKey(path, key, datas, culture);
            var txt = service.Translate(culture2, k);

            Assert.Equal("Connection", txt);

        }

        private readonly string _apiKey;

    }

}
