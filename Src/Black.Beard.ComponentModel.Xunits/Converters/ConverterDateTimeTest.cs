using Bb.Expressions;
using FluentAssertions.Equivalency;
using System;
using Xunit;

namespace Black.Beard.Converters
{


    public class ConverterDateTimeTest
    {


        [Fact]
        public void Test12()
        {

            DateTime date = new DateTime(2024, 3, 2, 10, 25, 36, 925);

            var i = date.ToLongIndex();

            // 240 302 102 536
            ulong expected = 240302102536925;

            Assert.Equal(expected, i);

        }

    }

}
