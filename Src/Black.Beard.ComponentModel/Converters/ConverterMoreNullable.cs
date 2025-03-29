using System;

namespace Bb.Converters
{

    public static partial class ConverterMoreNullable
    {

        #region ToBoolean

        public static bool ToBoolean(this bool? value)
        {
            return value.HasValue ? value.Value : false;
        }


        public static bool ToBoolean(this sbyte? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this char? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        public static bool ToBoolean(this byte? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this short? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }


        public static bool ToBoolean(this ushort? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this int? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }


        public static bool ToBoolean(this uint? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this long? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }


        public static bool ToBoolean(this ulong? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this float? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this double? value)
        {
            return value != 0;
        }

        public static bool ToBoolean(this decimal? value)
        {
            return value.HasValue ? value.Value != 0 : false;
        }

        public static bool ToBoolean(this DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        #endregion ToBoolean

        #region ToByte               


        public static sbyte ToSByte(this bool? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this sbyte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this char? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this byte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this short? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this ushort? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this int? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this uint? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this long? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this ulong? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this float? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this double? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this decimal? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        public static sbyte ToSByte(this DateTime? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        #endregion ToByte

        #region ToChar

        public static char ToChar(this bool? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(this char? value)
        {
            return value.HasValue ? value.Value : '\0';
        }

        public static char ToChar(this sbyte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this byte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this short? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this ushort? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this int? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        public static char ToChar(this uint? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this long? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        public static char ToChar(this ulong? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        public static char ToChar(this float? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(this double? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);

            return '\0';
        }

        public static char ToChar(this decimal? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        public static char ToChar(this DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        #endregion ToChar

        #region ToInt16

        public static short ToInt16(this bool? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this char? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this byte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this int? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this uint? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this short? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this long? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this float? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this double? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        public static short ToInt16(this DateTime? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        #endregion ToInt16        

        #region ToDateTime

        public static DateTime ToDateTime(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this byte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this short? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this ushort? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this int? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this uint? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this long? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this ulong? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this bool? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this char? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this float? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this double? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        public static DateTime ToDateTime(this decimal? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
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

        /// <summary>
        /// Convert a DateTime to a DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this DateTimeOffset? value)
        {

            if (!value.HasValue)
                return DateTime.MinValue;

            var value2 = value.Value.ToUniversalTime();
            return value2.UtcDateTime;

        }

        #endregion ToDateTime

        #region ToDecimal

        public static decimal ToDecimal(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this byte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this char? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this short? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this ushort? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this int? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this uint? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this long? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this ulong? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this float? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this double? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this decimal? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this bool? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        public static decimal ToDecimal(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        #endregion ToDecimal

        #region ToDouble

        public static double ToDouble(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this byte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this short? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this char? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this ushort? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this int? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this uint? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this long? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this ulong? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this float? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this double? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this decimal? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this bool? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        public static double ToDouble(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        #endregion ToDouble

        #region ToInt32

        public static int ToInt32(this bool? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this char? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this byte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this short? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this uint? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this int? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this long? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this float? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this double? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        public static int ToInt32(this DateTime? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        #endregion ToInt32

        #region ToInt64

        public static long ToInt64(this bool? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this char? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this byte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this short? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this int? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this uint? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this long? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this float? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this double? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static long ToInt64(this DateTime? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        public static ulong ToUInt64(bool? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        public static ulong ToUInt64(char? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        #endregion ToInt64

        #region ToByte

        public static byte ToByte(this bool? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this char? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this sbyte? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this short? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this ushort? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this int? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        public static byte ToByte(this uint? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this long? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        public static byte ToByte(this ulong? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this float? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this double? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this decimal? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        public static byte ToByte(this DateTime? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        #endregion ToSByte

        #region ToSingle


        public static float ToSingle(sbyte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(byte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(char? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(short? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }


        public static float ToSingle(ushort? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(int? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }


        public static float ToSingle(uint? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(long? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }


        public static float ToSingle(ulong? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(float? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(double? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(decimal? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(bool? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        public static float ToSingle(DateTime? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        #endregion ToSingle

        #region ToString          

        public static string ToString(bool? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(bool? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;

        }

        public static string ToString(char? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(char? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(sbyte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(sbyte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(byte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(byte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(short? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(short? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(ushort? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(ushort? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(int? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(int? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(uint? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(uint? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(long? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(long? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(ulong? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }


        public static string ToString(ulong? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(float? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(float? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(double? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(double? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(decimal? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(decimal? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(DateTime? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        public static string ToString(DateTime? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        #endregion ToString

        #region ToUInt16


        public static ushort ToUInt16(bool? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(char? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(byte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(short? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(int? value) => value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;


        public static ushort ToUInt16(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(uint? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(long? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(float? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(double? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }


        public static ushort ToUInt16(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        #endregion ToUInt16

        #region ToUInt32


        public static uint ToUInt32(bool? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(char? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(byte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(short? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(int? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(uint? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(long? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(float? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(double? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }


        public static uint ToUInt32(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        #endregion ToUInt32

        #region ToUInt64

        public static ulong ToUInt64(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(byte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(short? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(int? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(uint? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(long? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(float? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(double? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        public static ulong ToUInt64(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        #endregion ToUInt64

        #region ToDateTimeOffset

        public static DateTimeOffset ToDateTimeOffset(this DateTime? value)
        {
            return value.HasValue ? new DateTimeOffset(value.Value) : DateTimeOffset.MinValue;
        }
        public static DateTimeOffset ToDateTimeOffset(this sbyte? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this byte? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this short? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this ushort? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this int? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this uint? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this long? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this ulong? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this bool? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this char? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this float? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this double? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        public static DateTimeOffset ToDateTimeOffset(this decimal? value)
        {
            return value.HasValue ? new  DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        #endregion ToDateTimeOffset


    }

}
