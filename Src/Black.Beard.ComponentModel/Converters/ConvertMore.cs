using System;

namespace Bb.Expressions
{
    public static class ConvertMore
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
        /// <param name="yearOnTwoDigit">if true, the year is used on two digit 
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
