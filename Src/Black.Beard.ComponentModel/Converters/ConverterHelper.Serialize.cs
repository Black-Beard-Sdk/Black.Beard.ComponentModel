using System;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace Bb.Converters
{


    /// <summary>
    /// My Converter
    /// </summary>
    public static partial class ConverterHelper
    {

        /// <summary>
        /// Serializes the specified value in string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Serialize(dynamic value)
        {

            if (value == null)
                return string.Empty;

            switch (value)
            {

                case byte _b1:
                    return _b1.ToString(CultureInfo.CurrentCulture);

                case sbyte _b10:
                    return _b10.ToString(CultureInfo.CurrentCulture);

                case decimal _b4:
                    return _b4.ToString(CultureInfo.CurrentCulture);

                case float _b9:
                    return _b9.ToString(CultureInfo.CurrentCulture);

                case double _b5:
                    return _b5.ToString(CultureInfo.CurrentCulture);

                case ushort _b6:
                    return _b6.ToString(CultureInfo.CurrentCulture);

                case short _b13:
                    return _b13.ToString(CultureInfo.CurrentCulture);

                case uint _b7:
                    return _b7.ToString(CultureInfo.CurrentCulture);

                case int _b11:
                    return _b11.ToString(CultureInfo.CurrentCulture);

                case ulong _b8:
                    return _b8.ToString(CultureInfo.CurrentCulture);

                case long _b12:
                    return _b12.ToString(CultureInfo.CurrentCulture);

                case DateTime _b5:
                case bool _b2:
                    return value.ToString();

                case char _b3:
                    return char.ToString(_b3);

                case string _b11:
                    return _b11;

                default:
                    break;

            }

            Type type = value.GetType();

            if (type.IsEnum)
                return value.ToString();

            if (type == typeof(bool) || type == typeof(bool?))
                return value.ToString();

            if (type == typeof(byte) || type == typeof(byte?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(char) || type == typeof(char?))
                return char.ToString(value);

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return value.ToString();

            if (type == typeof(decimal) || type == typeof(decimal?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(double) || type == typeof(double?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(short) || type == typeof(short?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(int) || type == typeof(int?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(long) || type == typeof(long?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(sbyte) || type == typeof(sbyte?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(float) || type == typeof(float?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(ushort) || type == typeof(ushort?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(uint) || type == typeof(uint?))
                return value.ToString(CultureInfo.CurrentCulture);

            if (type == typeof(ulong) || type == typeof(ulong?))
                return value.ToString(CultureInfo.CurrentCulture);

            IConvertible convertible = value as IConvertible;
            if (convertible != null)
                return convertible.ToString(CultureInfo.CurrentCulture);

            IFormattable formattable = value as IFormattable;
            if (formattable != null)
                return formattable.ToString(null, CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(value.GetType());
            string result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }

        /// <summary>
        /// Deserializes the specified string value in the specified type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        internal static dynamic Unserialize(string value, Type type)
        {

            if (string.IsNullOrEmpty(value))
                return null;

            if (type.IsEnum)
                return Enum.Parse(type, value);

            IConvertible convertible = value as IConvertible;

            if (type == typeof(bool) || type == typeof(bool?))
                return string.IsNullOrWhiteSpace(value) ? (bool?)null : convertible.ToBoolean(CultureInfo.CurrentCulture);

            if (type == typeof(byte) || type == typeof(byte?))
                return string.IsNullOrWhiteSpace(value) ? (byte?)null : convertible.ToByte(CultureInfo.CurrentCulture);

            if (type == typeof(char) || type == typeof(char?))
                return string.IsNullOrWhiteSpace(value) ? (char?)null : convertible.ToChar(CultureInfo.CurrentCulture);

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return string.IsNullOrWhiteSpace(value) ? (DateTime?)null : convertible.ToDateTime(CultureInfo.CurrentCulture);

            if (type == typeof(decimal) || type == typeof(decimal?))
                return string.IsNullOrWhiteSpace(value) ? (decimal?)null : convertible.ToDecimal(CultureInfo.CurrentCulture);

            if (type == typeof(double) || type == typeof(double?))
                return string.IsNullOrWhiteSpace(value) ? (double?)null : convertible.ToDouble(CultureInfo.CurrentCulture);

            if (type == typeof(short) || type == typeof(short?))
                return string.IsNullOrWhiteSpace(value) ? (short?)null : convertible.ToInt16(CultureInfo.CurrentCulture);

            if (type == typeof(int) || type == typeof(int?))
                return string.IsNullOrWhiteSpace(value) ? (int?)null : convertible.ToInt32(CultureInfo.CurrentCulture);

            if (type == typeof(long) || type == typeof(long?))
                return string.IsNullOrWhiteSpace(value) ? (long?)null : convertible.ToInt64(CultureInfo.CurrentCulture);

            if (type == typeof(sbyte) || type == typeof(sbyte?))
                return string.IsNullOrWhiteSpace(value) ? (sbyte?)null : convertible.ToSByte(CultureInfo.CurrentCulture);

            if (type == typeof(float) || type == typeof(float?))
                return string.IsNullOrWhiteSpace(value) ? (float?)null : convertible.ToSingle(CultureInfo.CurrentCulture);

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(ushort) || type == typeof(ushort?))
                return string.IsNullOrWhiteSpace(value) ? (ushort?)null : convertible.ToUInt16(CultureInfo.CurrentCulture);

            if (type == typeof(uint) || type == typeof(uint?))
                return string.IsNullOrWhiteSpace(value) ? (uint?)null : convertible.ToUInt32(CultureInfo.CurrentCulture);

            if (type == typeof(ulong) || type == typeof(ulong?))
                return string.IsNullOrWhiteSpace(value) ? (ulong?)null : convertible.ToUInt64(CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(type);
            if (c.CanConvertTo(typeof(string)))
                return c.ConvertTo(value, typeof(string)) as string;

            return (string)ConverterHelper.ConvertToObject(value, type);

        }

    }


}
