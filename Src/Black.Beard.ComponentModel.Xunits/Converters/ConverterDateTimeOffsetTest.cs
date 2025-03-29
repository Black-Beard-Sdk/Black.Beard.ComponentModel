using Bb.Converters;
using FluentAssertions;
using System;
using System.Globalization;
using Xunit;

namespace Black.Beard.Converters

{
    public class ConverterDateTimeOffsetTest
    {



        [Fact]
        public void Test1()
        {
            var date = new DateTimeOffset(2020, 1, 3, 10, 00, 00, new TimeSpan(2, 0, 0));
            DateTimeOffset? date2 = (DateTimeOffset)date.ConvertTo(typeof(DateTimeOffset?));
            Assert.Equal(date, date2.Value);
        }


        [Fact]
        public void Test2()
        {
            DateTimeOffset? date = new DateTimeOffset(2020, 1, 3, 10, 00, 00, new TimeSpan(2, 0, 0));
            DateTimeOffset date2 = (DateTimeOffset)date.ConvertTo(typeof(DateTimeOffset));
            Assert.Equal(date.Value, date2);
        }


        [Fact]
        public void Test3()
        {
            DateTimeOffset date = new DateTimeOffset(2020, 1, 3, 10, 00, 00, new TimeSpan(2, 0, 0));
            DateTime date2 = (DateTime)date.ConvertTo(typeof(DateTime));
            Assert.Equal(date, date2);
        }

        [Fact]
        public void Test4()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.Month);

            // 20 240 302 102 536
            ulong expected = 2403;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test5()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.Day);

            // 240 302 102 536
            ulong expected = 240302;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test6()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.Hour);

            // 240 302 102 536
            ulong expected = 24030208;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test7()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.Minute);

            // 240 302 102 536
            ulong expected = 2403020825;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test8()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.Second);

            // 240 302 102 536
            ulong expected = 240302082536;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test9()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, 925, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(true, DateTimeLimit.MilliSecond);

            // 240 302 102 536
            ulong expected = 240302082536925;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test10()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, 925, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex(false, DateTimeLimit.MilliSecond);

            // 240 302 102 536
            ulong expected = 20240302082536925;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test11()
        {

            DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, 925, new TimeSpan(2, 0, 0));

            var i = date.ToLongIndex();

            // 240 302 102 536
            ulong expected = 240302082536925;

            Assert.Equal(expected, i);

        }

        [Fact]
        public void Test20()
        {


            var date = new DateTimeOffset(2020, 1, 3, 10, 00, 00, new TimeSpan(2, 0, 0));
            var txt = date.ToString(CultureInfo.CurrentCulture);

            txt.ConvertTo(typeof(DateTimeOffset)).Should().Be(date);

        }

    }

}
