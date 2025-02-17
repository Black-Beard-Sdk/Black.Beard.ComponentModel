using Bb.ComponentModel.Converters;
using Bb.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Expressions
{

    public static partial class ConverterHelper
    {


        #region ToBoolean

        /// <summary>
        /// Convert a string to dictionary
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ToDictionary(string self)
        {
            return self.GetKeyValues();
        }

        #endregion ToBoolean


        #region ToBoolean

        /// <summary>
        /// Convert a string to boolean
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool ToBoolean(string self)
        {
            var v1 = self.Trim().ToLower();
            var value = v1.Equals("true") || v1.Equals("1") || v1.Equals("vrai");
            return value;
        }

        /// <summary>
        /// Convert a string to boolean
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool ToBoolean(int self)
        {
            var value = self !> 0;
            return value;
        }
        
        #endregion ToBoolean


        #region Array

        internal static T[] ToArray<T>(T item)
        {
            return new T[] { item };
        }

        internal static U[] ConvertArray<T, U>(T[] self, ConverterContext ctx)
        {

            var source = self.ToArray();
            U[] target = new U[source.Length];
            var function = GetFunctionForConvert(typeof(T), typeof(U));

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

        /// <summary>
        /// Convert a string to Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Guid ToGuid(this char[] value)
        {
            var result = Guid.Parse(value);
            return result;
        }

        #endregion ToGuid


        #region ToByte

        /// <summary>
        /// Convert a string to byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (byte)value[0];
        }

        /// <summary>
        /// Convert a string to byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte ToByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return value[0];
        }

        /// <summary>
        /// Convert a string to byte
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static byte ToByte(this Single self)
        {
            return (byte)((int)self);
        }

        #endregion ToByte


        #region ToSByte

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static sbyte ToSByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static sbyte ToSByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static sbyte ToSByte(this sbyte[] value)
        {
            if (value.Length == 0)
                return 0;
            return value[0];

        }

        #endregion ToByte


        #region ToByteArray

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Byte[] ToByteArray(this string value)
        {
            if (value == null)
                return null;
            return ConverterContext.DefaultEncoding.GetBytes(value, 0, value.Length);
        }

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this char[] value)
        {
            string.Concat(value).ToByteArray();
            var r = new byte[value.Length];
            for (int i = 0; i < value.Length; i++)
                r[i] = (byte)value[i];
            return r;
        }

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this char value)
        {
            return new byte[] { (byte)value };
        }

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this Int32 value)
        {
            return new byte[] { (byte)value };
        }
     

        #endregion ToByteArray


        #region ToCharArray

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char[] ToCharArray(this Int32 value)
        {
            return new char[] { (char)value };
        }

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char[] ToCharArray(this Guid value)
        {
            return value.ToString().ToCharArray();
        }

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static char ToChar(this Single self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static char ToChar(this double self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static char ToChar(this Boolean self)
        {
            return self ? '1' : '0';
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static char ToChar(this decimal self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static char ToChar(this Int32 self)
        {
            return (char)self;
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char ToChar(this Byte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char ToChar(this sbyte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        /// <summary>
        /// Convert a string to char
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static char ToChar(this char[] value)
        {
            if (value.Length == 0)
                return '\0';
            return value[0];
        }

        #endregion ToChar


        #region ToDateTimeOffset

        /// <summary>
        /// Convert a string to DateTimeOffset
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this sbyte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this byte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this short value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this ushort value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this int value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this uint value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this long value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this ulong value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this bool value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this char value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this float value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this double value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Convert a DateTimeOffset to a DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Convert a DateTime to TimeSpan
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this DateTime value)
        {
            return value.TimeOfDay;
        }

        /// <summary>
        /// Convert a DateTimeOffset to TimeSpan
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TimeSpan ToTimeSpan(this DateTimeOffset value)
        {
            return value.TimeOfDay;
        }

        #endregion


        #region ToString

        public static string ToString(this Dictionary<string, string> value)
        {

            if (value == null)
                return null;

            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (var item in value)
            {

                if (first)
                    first = false;
                else
                    sb.Append(';');

                sb.Append(item.Key);
                sb.Append('=');

                var valueItem = item.Value;

                if (valueItem.Contains("\\"))
                    valueItem = valueItem.Replace("\\", "\\\\");

                if (valueItem.Contains(";"))
                    valueItem = valueItem.Replace(";", "\\;");

                if (valueItem.Contains("="))
                    valueItem = valueItem.Replace("=", "\\=");

                sb.Append(valueItem);

            }

            var result = sb.ToString();
            return result;

        }

        public static string ToString(this Dictionary<string, object> value)
        {

            if (value == null)
                return null;

            bool first = true;
            StringBuilder sb = new StringBuilder();
            foreach (var item in value)
            {

                if (first)
                    first = false;
                else
                    sb.Append(';');

                sb.Append(item.Key);
                sb.Append('=');

                string valueItem;
                if (item.Value is string str)
                    valueItem = str;
                
                else
                    valueItem = (string)item.Value.ConvertToObject(typeof(string));
                
                if (valueItem.Contains("\\"))
                    valueItem = valueItem.Replace("\\", "\\\\");

                if (valueItem.Contains(";"))
                    valueItem = valueItem.Replace(";", "\\;");

                if (valueItem.Contains("="))
                    valueItem = valueItem.Replace("=", "\\=");

                sb.Append(valueItem);

            }

            var result = sb.ToString();
            return result;

        }

        /// <summary>
        /// Convert a DateTime to string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToString(this Guid value)
        {
            var result = value.ToString();
            return result;
        }

        /// <summary>
        /// Convert a DateTime to string
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToString(this char[] self)
        {
            return string.Concat(self);
        }

        /// <summary>
        /// Convert a DateTime to string
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static string ToString(this Byte[] self)
        {
            var e = ConverterContext.DefaultEncoding ?? Encoding.UTF8;
            return e.GetString(self, 0, self.Length);
        }

        #endregion ToString


        #region ToInt16

        /// <summary>
        /// Convert a string to Int16
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this float value)
        {
            return (Int16)value;
        }

        /// <summary>
        /// Convert a string to Int16
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this double value)
        {
            return (Int16)value;
        }

        /// <summary>
        /// Convert a string to Int16
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int16 ToInt16(this char value)
        {
            return (Int16)(int)value;
        }

        #endregion ToInt16


        #region ToInt32

        /// <summary>
        /// Convert a string to Int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this float value)
        {
            return (Int32)value; 
        }

        /// <summary>
        /// Convert a string to Int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this double value)
        {
            return (Int32)value; 
        }

        /// <summary>
        /// Convert a string to Int32
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this char value)
        {
            return (Int32)(int)value;
        }

        #endregion ToInt32


        #region ToInt64

        /// <summary>
        /// Convert a string to Int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this float value)
        {
            return (Int64)value;
        }

        /// <summary>
        /// Convert a string to Int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this double value)
        {
            return (Int64)value;
        }

        /// <summary>
        /// Convert a string to Int64
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this char value)
        {
            return (Int64)(int)value;
        }

        #endregion ToInt32


        #region ToSingle

        /// <summary>
        /// Convert a string to Single
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Single ToSingle(this char value)
        {
            return (Single)(int)value;
        }

        #endregion ToSingle


        #region ToDouble

        /// <summary>
        /// Convert a string to Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Double ToDouble(this char value)
        {
            return (Double)(int)value;
        }

        #endregion ToDouble


        #region ToDecimal

        /// <summary>
        /// Convert a string to Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this char value)
        {
            return (decimal)(int)value;
        }

        #endregion ToDecimal

    }


}
