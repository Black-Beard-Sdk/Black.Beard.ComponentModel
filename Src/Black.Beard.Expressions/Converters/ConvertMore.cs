using System;

namespace Bb.Converters
{


    public static class ConvertMore
    {

        /// <summary>
        /// Convert a DateTime to ulong for indexation
        /// </summary>
        /// <param name="self">DateTime to convert. Must not be null.</param>
        /// <param name="yearOnTwoDigit">If true, the year is used on two digits (e.g., 24 instead of 2024)</param>
        /// <param name="limit">Specifies the precision of the index, from month to millisecond</param>
        /// <returns>
        /// A <see cref="System.UInt64"/> representation of the date time value, formatted according to the specified parameters.
        /// </returns>
        /// <remarks>
        /// This method converts a DateTime to an unsigned long integer that can be used for indexing or sorting.
        /// The resulting value has a format that depends on the limit parameter:
        /// - Month: YYMM or YYYYMM
        /// - Day: YYMMDD or YYYYMMDD
        /// - Hour: YYMMDDHH or YYYYMMDDHH
        /// - Minute: YYMMDDHHMM or YYYYMMDDHHMM
        /// - Second: YYMMDDHHMMSS or YYYYMMDDHHMMSS
        /// - MilliSecond: YYMMDDHHMMSSMMM or YYYYMMDDHHMMSSMMM
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        ///     DateTime date = new DateTime(2024, 3, 2, 10, 25, 36);
        ///     var i = date.ToLongIndex(true, DateTimeLimit.Second);
        ///     ulong expected = 240302102536;
        ///     Assert.Equal(expected, i);
        /// </code>
        /// </example>   
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
        /// Convert a DateTimeOffset to ulong for indexation
        /// </summary>
        /// <param name="self">DateTimeOffset to convert. Must not be null.</param>
        /// <param name="yearOnTwoDigit">If true, the year is used on two digits (e.g., 24 instead of 2024)</param>
        /// <param name="limit">Specifies the precision of the index, from month to millisecond</param>
        /// <returns>
        /// A <see cref="System.UInt64"/> representation of the date time offset value, formatted according to the specified parameters.
        /// </returns>
        /// <remarks>
        /// This method converts a DateTimeOffset to an unsigned long integer that can be used for indexing or sorting.
        /// The method first converts the DateTimeOffset to UTC before applying the index conversion.
        /// The resulting value has a format that depends on the limit parameter similar to the DateTime version.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, new TimeSpan(2, 0, 0));
        /// var i = date.ToLongIndex(true, DateTimeLimit.Second);
        /// ulong expected = 240302102536;
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
