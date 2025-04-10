using System;

namespace Bb.Converters
{

    /// <summary>
    /// Provides extension methods for converting <see cref="DateTime"/> and <see cref="DateTimeOffset"/> to unsigned long indices.
    /// </summary>
    public static class ConvertMore
    {

        /// <summary>
        /// Converts a <see cref="DateTime"/> to an unsigned long for indexing or sorting.
        /// </summary>
        /// <param name="self">The <see cref="DateTime"/> to convert. Must not be null.</param>
        /// <param name="yearOnTwoDigit">If <c>true</c>, the year is represented with two digits (e.g., 24 instead of 2024).</param>
        /// <param name="limit">Specifies the precision of the index, from month to millisecond.</param>
        /// <returns>
        /// A <see cref="ulong"/> representation of the <see cref="DateTime"/> value, formatted according to the specified parameters.
        /// </returns>
        /// <remarks>
        /// This method converts a <see cref="DateTime"/> to an unsigned long integer that can be used for indexing or sorting.
        /// The resulting value's format depends on the <paramref name="limit"/> parameter:
        /// <list type="bullet">
        /// <item><term>Month</term>: YYMM or YYYYMM</item>
        /// <item><term>Day</term>: YYMMDD or YYYYMMDD</item>
        /// <item><term>Hour</term>: YYMMDDHH or YYYYMMDDHH</item>
        /// <item><term>Minute</term>: YYMMDDHHMM or YYYYMMDDHHMM</item>
        /// <item><term>Second</term>: YYMMDDHHMMSS or YYYYMMDDHHMMSS</item>
        /// <item><term>Millisecond</term>: YYMMDDHHMMSSMMM or YYYYMMDDHHMMSSMMM</item>
        /// </list>
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime date = new DateTime(2024, 3, 2, 10, 25, 36);
        /// ulong index = date.ToLongIndex(true, DateTimeLimit.Second);
        /// Console.WriteLine(index); // Output: 240302102536
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
        /// Converts a <see cref="DateTimeOffset"/> to an unsigned long for indexing or sorting.
        /// </summary>
        /// <param name="self">The <see cref="DateTimeOffset"/> to convert. Must not be null.</param>
        /// <param name="yearOnTwoDigit">If <c>true</c>, the year is represented with two digits (e.g., 24 instead of 2024).</param>
        /// <param name="limit">Specifies the precision of the index, from month to millisecond.</param>
        /// <returns>
        /// A <see cref="ulong"/> representation of the <see cref="DateTimeOffset"/> value, formatted according to the specified parameters.
        /// </returns>
        /// <remarks>
        /// This method converts a <see cref="DateTimeOffset"/> to an unsigned long integer that can be used for indexing or sorting.
        /// The method first converts the <see cref="DateTimeOffset"/> to UTC before applying the index conversion.
        /// The resulting value's format depends on the <paramref name="limit"/> parameter, similar to the <see cref="DateTime"/> version.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTimeOffset date = new DateTimeOffset(2024, 3, 2, 10, 25, 36, TimeSpan.FromHours(2));
        /// ulong index = date.ToLongIndex(true, DateTimeLimit.Second);
        /// Console.WriteLine(index); // Output: 240302102536
        /// </code>
        /// </example>
        public static ulong ToLongIndex(this DateTimeOffset self, bool yearOnTwoDigit = true, DateTimeLimit limit = DateTimeLimit.None)
        {
            return self.UtcDateTime.ToLongIndex(yearOnTwoDigit, limit);
        }

    }

    /// <summary>
    /// Specifies the precision level for converting <see cref="DateTime"/> or <see cref="DateTimeOffset"/> to an unsigned long index.
    /// </summary>
    public enum DateTimeLimit
    {
        /// <summary>
        /// No specific precision is applied.
        /// </summary>
        None = 5,

        /// <summary>
        /// Precision up to the month (e.g., YYMM or YYYYMM).
        /// </summary>
        Month = 0,

        /// <summary>
        /// Precision up to the day (e.g., YYMMDD or YYYYMMDD).
        /// </summary>
        Day = 1,

        /// <summary>
        /// Precision up to the hour (e.g., YYMMDDHH or YYYYMMDDHH).
        /// </summary>
        Hour = 2,

        /// <summary>
        /// Precision up to the minute (e.g., YYMMDDHHMM or YYYYMMDDHHMM).
        /// </summary>
        Minute = 3,

        /// <summary>
        /// Precision up to the second (e.g., YYMMDDHHMMSS or YYYYMMDDHHMMSS).
        /// </summary>
        Second = 4,

        /// <summary>
        /// Precision up to the millisecond (e.g., YYMMDDHHMMSSMMM or YYYYMMDDHHMMSSMMM).
        /// </summary>
        MilliSecond = 5,
    }

}
