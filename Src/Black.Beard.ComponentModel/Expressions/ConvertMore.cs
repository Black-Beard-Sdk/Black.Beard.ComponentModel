using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Expressions
{


    public static class ConvertMore
    {

        /// <summary>
        /// Culture used by default if the parameter is not specified
        /// </summary>
        public static CultureInfo CultureInfo { get; set; } = CultureInfo.InvariantCulture;


        /// <summary>
        /// Convert a string to DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"><see cref="CultureInfo"/>. By default ConvertMore.CultureInfois used</param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this string value, CultureInfo cultureInfo = null)
        {
            var result = DateTimeOffset.Parse(value, cultureInfo ?? ConvertMore.CultureInfo ?? CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this DateTime value)
        {
            return new DateTimeOffset(value);
        }

        public static DateTimeOffset ToDateTimeOffset(this sbyte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this byte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this short value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this ushort value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this int value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this uint value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this long value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this ulong value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this bool value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this char value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this float value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this double value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        public static DateTimeOffset ToDateTimeOffset(this decimal value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }


        /// <summary>
        /// Convert a DateTime to a DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeOffset value)
        {
            var value2 = value.ToUniversalTime();
            return value2.UtcDateTime;
        }


    }

    public static class ConvertMore2
    {

        /// <summary>
        /// Convert a DateTime to ulong for indexation
        /// </summary>
        /// <param name="value">DateTime to convert</param>
        /// <param name="yearOnTwoDigit">if true, the year is use on two digit 
        ///     if false : 2024-03-02 
        ///     if true  :   24-03-02
        /// </param>
        /// <param name="limit">specify the limit of the index</param>
        /// <example>
        /// <code lang="csharp>
        ///     DateTime date = new DateTime(2024, 3, 2, 10, 25, 36);
        ///     var i = date.ToLongIndex(true, Bb.Expressions.DateTimeKind.Second);
        ///     ulong expected = 240302082536;
        ///     Assert.Equal(expected, i);
        /// </code>
        /// </example>   
        /// <returns></returns>
        public static ulong ToLongIndex(this DateTime self, bool yearOnTwoDigit = true, DateTimeLimit limit = DateTimeLimit.None)
        {

            ulong v = (ulong)self.Year;                     // 2024
            if (yearOnTwoDigit)
                v -= 2000;                                  // 24

            v *= 100;                                       // 2400                        
            v += (ulong)self.Month;                         // 2403

            if (limit > DateTimeLimit.Month)
            {

                v *= 100;                                   // 240300
                v += (ulong)self.Day;                       // 240302

                if (limit > DateTimeLimit.Day)
                {

                    v *= 100;                               // 24030200
                    v += (ulong)self.Hour;                  // 24030208

                    if (limit > DateTimeLimit.Hour)
                    {

                        v *= 100;                               // 2403020800
                        v += (ulong)self.Minute;                // 2403020825

                        if (limit > DateTimeLimit.Minute)
                        {

                            v *= 100;                           // 240302082500
                            v += (uint)self.Second;             // 240302082536

                            if (limit > DateTimeLimit.Second)
                            {
                                v *= 1000;                      // 240302082500000
                                v += (uint)self.Millisecond;    // 240302082536925
                            }

                        }

                    }
                }

            }

            return v;

        }

        /// <summary>
        /// Convert a DateTime to ulong for indexation
        /// </summary>
        /// <param name="value">DateTime offset to convert</param>
        /// <param name="yearOnTwoDigit">if true, the year is use on two digit 
        ///     if false : 2024-03-02 
        ///     if true  :   24-03-02
        /// </param>
        /// <param name="limit">specify the limit of the index</param>
        /// <returns></returns>
        /// <example>
        /// <code lang="csharp>
        /// DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));
        /// var i = date.ToLongIndex(true, Bb.Expressions.DateTimeKind.Second);
        /// ulong expected = 240302082536;
        /// Assert.Equal(expected, i);
        /// </code>
        /// </example>        
        public static ulong ToLongIndex(this DateTimeOffset self, bool yearOnTwoDigit = true, DateTimeLimit limit = DateTimeLimit.None)
        {
            return self.UtcDateTime.ToLongIndex(yearOnTwoDigit, limit);
        }


    }

    public enum DateTimeLimit
    {
        None = 5,
        Month = 0,
        Day = 1,
        Hour = 2,
        Minute = 3,
        Second = 4,
        MilliSecond = 5,
    }


}
