using Bb.Translations;
using Bb.Translations.Stores;
using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace ComponentModels.Tests.Translations
{


    public sealed class TestsContainer
    {

        [Fact]
        public void Test1()
        {

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var datas = "Français de france";

            var c = new TranslationContainer();
            c.Add(path, key, culture, datas);


            if (c.Get(path, key, culture, out DataTranslation? data))
            {
                Assert.Equal(data.Key, key);
                Assert.Equal(data.Path, path);
                Assert.Equal(data.Value, datas);
                Assert.Equal(data.Culture, culture);
            }
            else
            {
                Assert.Fail("Data not found");
            }

        }

        [Fact]
        public void Test2()
        {

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var datas = "Français de france";

            var c = new TranslationContainer();
            c.Add(path, key, culture, datas);


            var k = new TranslationKey(path, key);

            if (c.Get(k, culture, out DataTranslation? data))
            {
                Assert.Equal(data.Key, key);
                Assert.Equal(data.Path, path);
                Assert.Equal(data.Value, datas);
                Assert.Equal(data.Culture, culture);
            }
            else
            {
                Assert.Fail("Data not found");
            }


        }

        [Fact]
        public void Test3()
        {

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var datas = "Français de france";
            var k = new TranslationKey(path, key);
            k.AddTranslation(culture, datas);

            var c = new TranslationContainer();
            c.Add(k, culture);

            if (c.Get(k, culture, out DataTranslation? data))
            {
                Assert.Equal(data.Key, key);
                Assert.Equal(data.Path, path);
                Assert.Equal(data.Value, datas);
                Assert.Equal(data.Culture, culture);
            }
            else
                Assert.Fail("Data not found");

        }

        [Fact]
        public void Test4()
        {

            var path = "menuLanguage";
            var key = "French (France)";
            var culture = new CultureInfo("fr-fr");
            var culture2 = new CultureInfo("en-us");
            var datas = "Français de france";
            var k = new TranslationKey(path, key);
            k.AddTranslation(culture, datas);

            var c = new TranslationContainer();
            c.Add(k, culture2);

            if (c.Get(k, culture2, out DataTranslation? data))
                Assert.Fail("Data found");

        }

        [Fact]
        public void Test5()
        {

            string pathStr = "myContext";
            string key = Guid.NewGuid().ToString();

            var path = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store = new StoreFile(path);

            string expectedFr = Guid.NewGuid().ToString();
            string expectedEn = Guid.NewGuid().ToString();
            store.Write(pathStr, key, new CultureInfo("fr-fr"), expectedFr);
            store.Write(pathStr, key, new CultureInfo("en-us"), expectedEn);


            expectedFr = Guid.NewGuid().ToString();
            store.Write(pathStr, key, new CultureInfo("fr-fr"), expectedFr);

            if (store.Read(pathStr, key, new CultureInfo("fr-fr"), out var txt))
                Assert.Equal(expectedFr, txt);
            else
                Assert.Fail("Data not found");


            if (store.Read(pathStr, key, new CultureInfo("en-us"), out txt))
                Assert.Equal(expectedEn, txt);
            else
                Assert.Fail("Data not found");

        }

        [Fact]
        public void Test6()
        {

            string pathStr = "myContext";
            string key = Guid.NewGuid().ToString();
            var culture = new CultureInfo("fr-fr");
            string expectedFr = Guid.NewGuid().ToString();

            var container = new TranslationContainer();


            var k = new TranslationKey(pathStr, key);
            k.AddTranslation(culture, expectedFr);
            container.Add(k, culture);

            if (container.Get(k, culture, out var k2))
                Assert.Equal(expectedFr, k2.Value);
            else
                Assert.Fail("key not found");

        }
      

    }

}
