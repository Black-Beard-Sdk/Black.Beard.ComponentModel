using Bb.Converters;
using System;
using System.Globalization;

namespace Bb.Converters
{

    public static partial class ConverterMoreNullable
    {

        #region ToBoolean

        public static bool? ToBoolean(this bool value)
        {
            return new bool?(value);
        }

        public static bool? ToBoolean(this sbyte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this char value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this byte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this short value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this ushort value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this int value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this uint value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this long value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this ulong value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this float value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this double value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this decimal value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        public static bool? ToBoolean(this DateTime value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        #endregion ToBoolean

        #region ToByte               


        public static sbyte? ToSByte(this bool value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this sbyte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this char value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this byte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this short value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this ushort value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this int value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this uint value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this long value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this ulong value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this float value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this double value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this decimal value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        public static sbyte? ToSByte(this DateTime value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        #endregion ToByte

        #region ToChar

        public static char? ToChar(this bool value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this char value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this sbyte value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this byte value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this short value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this ushort value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this int value) => ToChar((uint)value);

        public static char? ToChar(this uint value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this ulong value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this float value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this double value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this decimal value)
        {
            return new char?(Convert.ToChar(value));
        }

        public static char? ToChar(this DateTime value)
        {
            return new char?(Convert.ToChar(value));
        }

        #endregion ToChar

        #region ToInt16

        public static short? ToInt16(this bool value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this char value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this sbyte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this byte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this ushort value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this int value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this uint value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this short value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this long value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this ulong value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this float value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this double value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this decimal value)
        {
            return new short?(Convert.ToInt16(value));
        }

        public static short? ToInt16(this DateTime value)
        {
            return new short?(Convert.ToInt16(value));
        }

        #endregion ToInt16        

        #region ToDateTime

        public static DateTime? ToDateTime(this DateTime value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this sbyte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this byte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this short value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this ushort value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this int value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this uint value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this long value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this ulong value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this bool value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this char value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this float value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this double value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        public static DateTime? ToDateTime(this decimal value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        #endregion ToDateTime

        #region ToDecimal

        public static decimal? ToDecimal(this sbyte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this byte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this char value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this short value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this ushort value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this int value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this uint value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this long value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this ulong value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this float value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this double value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this decimal value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this bool value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        public static decimal? ToDecimal(this DateTime value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        #endregion ToDecimal

        #region ToDouble

        public static double? ToDouble(this sbyte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this byte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this short value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this char value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this ushort value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this int value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this uint value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this long value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this ulong value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this float value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this double value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this decimal value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this bool value)
        {
            return new double?(Convert.ToDouble(value));
        }

        public static double? ToDouble(this DateTime value)
        {
            return new double?(Convert.ToDouble(value));
        }

        #endregion ToDouble

        #region ToInt32

        public static int? ToInt32(this bool value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this char value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this sbyte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this byte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this short value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this ushort value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this uint value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this int value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this long value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this ulong value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this float value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this double value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this decimal value)
        {
            return new int?(Convert.ToInt32(value));
        }

        public static int? ToInt32(this DateTime value)
        {
            return new int?(Convert.ToInt32(value));
        }

        #endregion ToInt32

        #region ToInt64

        public static long? ToInt64(this bool value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this char value)
        {
            return new long?(Convert.ToInt64(value));
        }


        public static long? ToInt64(this sbyte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this byte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this short value)
        {
            return new long?(Convert.ToInt64(value));
        }


        public static long? ToInt64(this ushort value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this int value)
        {
            return new long?(Convert.ToInt64(value));
        }


        public static long? ToInt64(this uint value)
        {
            return new long?(Convert.ToInt64(value));
        }


        public static long? ToInt64(this ulong value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this long value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this float value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this double value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this decimal value)
        {
            return new long?(Convert.ToInt64(value));
        }

        public static long? ToInt64(this DateTime value)
        {
            return new long?(Convert.ToInt64(value));
        }

        #endregion ToInt64

        #region ToByte

        public static byte? ToByte(this bool value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this char value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this sbyte value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this short value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this ushort value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this int value) => ToByte((uint)value);


        public static byte? ToByte(this uint value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this long value) => ToByte((ulong)value);


        public static byte? ToByte(this ulong value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this float value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this double value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this decimal value)
        {
            return new byte?(Convert.ToByte(value));
        }

        public static byte? ToByte(this DateTime value)
        {
            return new byte?(Convert.ToByte(value));
        }

        #endregion ToSByte

        #region ToSingle

        public static float? ToSingle(this sbyte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this byte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this char value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this short value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this ushort value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this int value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this uint value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this long value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this ulong value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this float value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this double value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this decimal value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this bool value)
        {
            return new float?(Convert.ToSingle(value));
        }

        public static float? ToSingle(this DateTime value)
        {
            return new float?(Convert.ToSingle(value));
        }

        #endregion ToSingle

        #region ToUInt16

        public static ushort? ToUInt16(this bool value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this char value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this sbyte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this byte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this short value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this int value) => ToUInt16((uint)value);


        public static ushort? ToUInt16(this ushort value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this uint value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this long value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this ulong value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this float value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this double value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this decimal value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        public static ushort? ToUInt16(this DateTime value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        #endregion ToUInt16

        #region ToUInt32

        public static uint? ToUInt32(this bool value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this char value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this sbyte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this byte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this short value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this ushort value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this int value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this uint value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this long value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this ulong value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this float value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this double value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this decimal value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        public static uint? ToUInt32(this DateTime value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        #endregion ToUInt32

        #region ToUInt64

        public static ulong? ToUInt64(this bool value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this char value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this sbyte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this byte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this short value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this ushort value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this int value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this uint value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this long value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this ulong value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this float value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this double value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this decimal value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        public static ulong? ToUInt64(this DateTime value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        #endregion ToUInt64

        #region ToDateTimeOffset

        /// <summary>
        /// Convert a DateTime to DateTimeOffset
        /// </summary>
        /// <param name="value">DateTime</param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffset(this DateTime value)
        {
            return new DateTimeOffset?(value);
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"><see cref="CultureInfo"/>. By default ConvertMore.CultureInfois used</param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffset(this string value, CultureInfo cultureInfo = null)
        {
            var result = DateTimeOffset.Parse(value, cultureInfo ?? ConverterContext.DefaultCultureInfo ?? CultureInfo.InvariantCulture);
            return result;
        }

        public static DateTimeOffset? ToDateTimeOffset(this sbyte value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this byte value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this short value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this ushort value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this int value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this uint value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this long value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this ulong value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this bool value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this char value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this float value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this double value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        public static DateTimeOffset? ToDateTimeOffset(this decimal value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        #endregion ToDateTimeOffset

        #region ToGuid
        
        public static Guid? ToGuid(this string value)
        {
            Guid? result = Guid.Parse(value);
            return result;
        }


        #endregion ToGuid

    }

}
