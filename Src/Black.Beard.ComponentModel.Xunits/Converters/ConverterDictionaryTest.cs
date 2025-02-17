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

    }

}

