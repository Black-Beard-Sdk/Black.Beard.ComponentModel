﻿using Bb.Converters;
using Xunit;

namespace Black.Beard.Converters
{
    public class ConverterTest
    {

        [Fact]
        public void TestByte()
        {
            
            byte value = 1;
            var p = ConverterHelper.GetMethodToConvert(value.GetType(), typeof(string));


        }

        //[Fact]
        //public void TestGuid2()
        //{
        //    var value = Guid.NewGuid().ToString();
        //    Guid? guid2 = value.ToObject<Guid?>();
        //    Assert.Equal(value, guid2.ToString());
        //}

        //[Fact]
        //public void TestGuid3()
        //{
        //    var value = Guid.NewGuid();
        //    string guid2 = value.ToObject<string>();
        //    Assert.Equal(value.ToString(), guid2);
        //}


        //[Fact]
        //public void TestGuid4()
        //{
        //    decimal value = 8.3M;
        //    var guid2 = value.ToObject<float>();
        //    //Assert.Equal(value.ToString(), guid2);


        //}



    }



}
