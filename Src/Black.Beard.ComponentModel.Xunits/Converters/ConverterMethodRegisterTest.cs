using Bb.Converters;
using Bb.Expressions;
using Xunit;

namespace Black.Beard.Converters
{


    public class ConverterMethodRegisterTest
    {

        [Fact]
        public void TestRegister1()
        {
            ConverterHelper.AppendConverter(ConverterMethodRegisterTest.Converter1);
            var result = typeof(type2).CanBeConverted(typeof(type1));
            Assert.True(result > 0);
        }

        [Fact]
        public void TestRegister2()
        {
            ConverterHelper.Register(new MethodConverter(ConverterMethodRegisterTest.Converter2));
            var result = typeof(type2).CanBeConverted(typeof(type1));
            Assert.True(result > 0);
        }


        public static type2 Converter1(type1 source)
        {
            return new type2() { Name = source.Name };
        }


        public static type1 Converter2(type2 source)
        {
            return new type1() { Name = source.Name };
        }

    }


    public class type1
    {

        public string Name { get; set; }

    }

    public class type2
    {

        public string Name { get; set; }

    }

}

