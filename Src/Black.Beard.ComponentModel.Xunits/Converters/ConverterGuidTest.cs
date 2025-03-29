using Bb.Converters;
using Bb.Expressions;
using System;
using Xunit;

namespace Black.Beard.Converters
{


    public class ConverterGuidTest
    {

        [Fact]
        public void TestGuid1()
        {
            var value = Guid.NewGuid().ToString();
            Guid guid1 = value.ConvertTo<Guid>();
            Assert.Equal(value, guid1.ToString());

        }

        [Fact]
        public void TestGuid2()
        {
            var value = Guid.NewGuid().ToString();
            Guid? guid2 = value.ConvertTo<Guid?>();
            Assert.Equal(value, guid2.ToString());
        }

        [Fact]
        public void TestGuid3()
        {
            var value = Guid.NewGuid();
            string guid2 = value.ConvertTo<string>();
            Assert.Equal(value.ToString(), guid2);
        }


        [Fact]
        public void TestGuid4()
        {
            decimal value = 8.3M;
            var guid2 = value.ConvertTo<float>();
            //Assert.Equal(value.ToString(), guid2);
        }



    }



}
