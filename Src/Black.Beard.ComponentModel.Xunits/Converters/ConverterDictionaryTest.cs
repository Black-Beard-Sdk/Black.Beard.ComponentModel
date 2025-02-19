using Bb.Expressions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Black.Beard.Converters
{
    public class ConverterDictionaryTest
    {

        [Fact]
        public void Teststring1()
        {

            string expectedValue = "Key1=Value1;Key2=Value2";

            var dic = new Dictionary<string, string>()
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" }
            };


            var result = ConverterHelper.ToObject<string>(dic);

            Assert.Equal(expectedValue, result);

        }

        [Fact]
        public void Teststring2()
        {

            string expectedValue = "Key1=Val\\=ue1;Key2=Value2";

            var dic = new Dictionary<string, string>()
            {
                { "Key1", "Val=ue1" },
                { "Key2", "Value2" }
            };


            var result = ConverterHelper.ToObject<string>(dic);

            Assert.Equal(expectedValue, result);


        }

        [Fact]
        public void Teststring3()
        {

            string expectedValue = "Key1=Value1;Key2=12";

            var dic = new Dictionary<string, object>()
            {
                { "Key1", "Value1" },
                { "Key2", 12 }
            };


            var result = ConverterHelper.ToObject<string>(dic);

            Assert.Equal(expectedValue, result);

        }

        [Fact]
        public void Teststring4()
        {

            string value = "Key1=Value1;Key2=12";

            var expectedResult = new Dictionary<string, string>()
            {
                { "key1", "Value1" },
                { "key2", "12" }
            };


            var result = ConverterHelper.ToObject<Dictionary<string, string>>(value);

            Assert.Equal(expectedResult["key1"], result["key1"]);
            Assert.Equal(expectedResult["key2"], result["key2"]);

        }

        [Fact]
        public void Teststring5()
        {

            string value = "Key1=Value1;Key2=12";

            var expectedResult = new Dictionary<string, object>()
            {
                { "key1", "Value1" },
                { "key2", "12" }
            };


            var result = ConverterHelper.ToObject<Dictionary<string, object>>(value);

            Assert.Equal(expectedResult["key1"], result["key1"]);
            Assert.Equal(expectedResult["key2"], result["key2"]);

        }

    }

}

