using Bb.Translations;
using Bb.Translations.Stores;
using System;
using System.Globalization;
using System.IO;
using Xunit;

namespace ComponentModels.Tests.Translations
{
    public sealed class StoreService
    {

        [Fact]
        public void Test0()
        {

            string pathStr = "myContext";
            string key = Guid.NewGuid().ToString();
            var culture = new CultureInfo("fr-fr");
            string expectedFr = Guid.NewGuid().ToString();

            var path = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store = new StoreFile(path);
            store.Write(pathStr, key, culture, expectedFr);


            var k = new TranslationKey(pathStr, key);
            k.AddTranslation(culture, expectedFr);

            if (store.Read(pathStr, key, culture, out var txt))
                Assert.Equal(expectedFr, txt);
            else
                Assert.Fail("Data not found");


        }

        [Fact]
        public void Test1()
        {

            string pathStr = "myContext";
            string key = Guid.NewGuid().ToString();
            var culture = new CultureInfo("fr-fr");
            string expectedFr = Guid.NewGuid().ToString();

            var path1 = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store1 = new StoreFile(path1);
            store1.Write(pathStr, key, culture, expectedFr);


            if (store1.Read(pathStr, key, new CultureInfo("fr-fr"), out var txt))
                Assert.Equal(expectedFr, txt);


            var path2 = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Path.GetFileNameWithoutExtension(Path.GetRandomFileName())));
            var store2 = new StoreFile(path2);
            store2.CopyFrom(store1);

            if (store2.Read(pathStr, key, new CultureInfo("fr-fr"), out txt))
                Assert.Equal(expectedFr, txt);

        }

    }

}
