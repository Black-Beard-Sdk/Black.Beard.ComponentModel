using Bb.Converters;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.Expressions
{

    public static partial class ConverterHelper
    {


        #region Array

        internal static T[] ToArray<T>(T item)
        {
            return new T[] { item };
        }

        internal static U[] ConvertArray<T, U>(T[] self, ConverterContext ctx)
        {

            var source = self.ToArray();
            U[] target = new U[source.Length];
            var function = GetFunction(typeof(T), typeof(U));

            if (function == null)
                throw new InvalidCastException($"Cannot convert {typeof(T).Name} to {typeof(U).Name}");

            for (int i = 0; i < source.Length; i++)
                target[i] = (U)function(source[i], ctx);

            return target;

        }

        #endregion Array


        #region Enum

        internal static T ToEnum<T>(ushort item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(short item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(uint item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(int item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(ulong item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(long item)
            where T : Enum
        {
            return (T)(object)item;
        }

        internal static T ToEnum<T>(string item)
            where T : Enum
        {
            return (T)Enum.Parse(typeof(T), item);
        }

        internal static ushort EnumToUShort<T>(T item)
            where T : Enum
        {
            return (ushort)(object)item;
        }

        internal static short EnumToShort<T>(T item)
            where T : Enum
        {
            return (short)(object)item;
        }

        internal static uint EnumToUInt<T>(T item)
            where T : Enum
        {
            return (uint)(object)item;
        }

        internal static int EnumToInt<T>(T item)
            where T : Enum
        {
            return (int)(object)item;
        }

        internal static ulong EnumToULong<T>(T item)
            where T : Enum
        {
            return (ulong)(object)item;
        }

        internal static long EnumToLong<T>(T item)
            where T : Enum
        {
            return (long)(object)item;
        }

        internal static string EnumToString<T>(T item)
            where T : Enum
        {
            return item.ToString();
        }

        #endregion Enum


        #region ToGuid

        //public static Guid ToGuid(this string value)
        //{
        //    var result = Guid.Parse(value);
        //    return result;
        //}

        public static Guid ToGuid(this char[] value)
        {
            var result = Guid.Parse(value);
            return result;
        }

        #endregion ToGuid


        #region ToByte

        public static byte ToByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (byte)value[0];
        }

        public static byte ToByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return value[0];
        }

        public static byte ToByte(this Single self)
        {
            return (byte)((int)self);
        }

        #endregion ToByte


        #region ToSByte

        public static sbyte ToSByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        public static sbyte ToSByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        public static sbyte ToSByte(this sbyte[] value)
        {
            if (value.Length == 0)
                return 0;
            return value[0];

        }

        #endregion ToByte


        #region ToByteArray

        public static Byte[] ToByteArray(this string value)
        {
            if (value == null)
                return null;
            return ConverterContext.DefaultEncoding.GetBytes(value, 0, value.Length);
        }

        public static byte[] ToByteArray(this char[] value)
        {
            string.Concat(value).ToByteArray();
            var r = new byte[value.Length];
            for (int i = 0; i < value.Length; i++)
                r[i] = (byte)value[i];
            return r;
        }

        public static byte[] ToByteArray(this char value)
        {
            return new byte[] { (byte)value };
        }

        public static byte[] ToByteArray(this Int32 value)
        {
            return new byte[] { (byte)value };
        }

        //public static byte[] ToByteArray(this sbyte value)
        //{
        //    return new byte[] { (byte)value };
        //}

        //public static byte[] ToByteArray(this Single self)
        //{
        //    return new byte[] { (byte)((int)self) };
        //}

        #endregion ToByteArray


        #region ToCharArray

        //public static char[] ToCharArray(this char value)
        //{
        //    return new char[] { value };
        //}

        public static char[] ToCharArray(this Int32 value)
        {
            return new char[] { (char)value };
        }

        public static char[] ToCharArray(this Guid value)
        {
            return value.ToString().ToCharArray();
        }

        public static char[] ToCharArray(this Byte[] value)
        {
            string.Concat(value).ToByteArray();
            var r = new char[value.Length];
            for (int i = 0; i < value.Length; i++)
                r[i] = (char)value[i];
            return r;
        }

        //public static char[] ToCharArray(this sbyte value)
        //{
        //    return new char[] { (char)value };
        //}

        //public static char[] ToCharArray(this Single self)
        //{
        //    return new char[] { (char)((int)self) };
        //}

        #endregion ToCharArray


        #region ToChar

        public static char ToChar(this Single self)
        {
            return (char)((int)self);
        }

        public static char ToChar(this double self)
        {
            return (char)((int)self);
        }

        public static char ToChar(this Boolean self)
        {
            return self ? '1' : '0';
        }

        public static char ToChar(this decimal self)
        {
            return (char)((int)self);
        }

        public static char ToChar(this Int32 self)
        {
            return (char)self;
        }

        public static char ToChar(this Byte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        public static char ToChar(this sbyte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        public static char ToChar(this char[] value)
        {
            if (value.Length == 0)
                return '\0';
            return value[0];
        }

        #endregion ToChar


        #region ToDateTimeOffset

        public static DateTimeOffset ToDateTimeOffser(this TimeSpan value)
        {
            return new DateTimeOffset(new DateTime(0, 0, 0, value.Hours, value.Minutes, value.Seconds, value.Milliseconds));
        }

        /// <summary>
        /// Convert a string to DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"><see cref="CultureInfo"/>. By default ConvertMore.CultureInfois used</param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this string value, CultureInfo cultureInfo = null)
        {
            var result = DateTimeOffset.Parse(value, cultureInfo ?? ConverterContext.DefaultCultureInfo ?? CultureInfo.InvariantCulture);
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

        #endregion ToDateTimeOffset


        #region ToDateTime

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

        //public static DateTime ToDateTime(this TimeSpan value)
        //{
        //    return new DateTime(0, 1, 1, value.Hours, value.Minutes, value.Seconds, value.Milliseconds);
        //}

        #endregion ToDateTime


        #region ToTimeSpan

        public static TimeSpan ToTimeSpan(this DateTime value)
        {
            return value.TimeOfDay;
        }

        public static TimeSpan ToTimeSpan(this DateTimeOffset value)
        {
            return value.TimeOfDay;
        }

        #endregion


        #region ToString

        public static string ToString(this Guid value)
        {
            var result = value.ToString();
            return result;
        }

        public static string ToString(this char[] self)
        {
            return string.Concat(self);
        }

        public static string ToString(this Byte[] self)
        {
            var e = ConverterContext.DefaultEncoding ?? Encoding.UTF8;
            return e.GetString(self, 0, self.Length);
        }

        #endregion ToString


        #region ToInt16

        public static Int16 ToInt16(this float value)
        {
            return (Int16)value;
        }

        public static Int16 ToInt16(this double value)
        {
            return (Int16)value;
        }

        public static Int16 ToInt16(this char value)
        {
            return (Int16)(int)value;
        }

        #endregion ToInt16


        #region ToInt32

        public static Int32 ToInt32(this float value)
        {
            return (Int32)value; 
        }

        public static Int32 ToInt32(this double value)
        {
            return (Int32)value; 
        }

        public static Int32 ToInt32(this char value)
        {
            return (Int32)(int)value;
        }

        #endregion ToInt32


        #region ToInt64

        public static Int64 ToInt64(this float value)
        {
            return (Int64)value;
        }

        public static Int64 ToInt64(this double value)
        {
            return (Int64)value;
        }

        public static Int64 ToInt64(this char value)
        {
            return (Int64)(int)value;
        }

        #endregion ToInt32


        #region ToSingle

        public static Single ToSingle(this char value)
        {
            return (Single)(int)value;
        }

        #endregion ToSingle


        #region ToDouble

        public static Double ToDouble(this char value)
        {
            return (Double)(int)value;
        }

        #endregion ToDouble


        #region ToDecimal

        public static decimal ToDecimal(this char value)
        {
            return (decimal)(int)value;
        }

        #endregion ToDecimal

    }

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
