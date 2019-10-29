using System;
using System.ComponentModel;
using System.Globalization;

namespace Bb.ComponentModel.Accessors
{
    /// <summary>
    /// My Converter
    /// </summary>
    public class MyConverter
    {

        /// <summary>
        /// The default value
        /// </summary>
        public static string Default = "A5BA2123-213E-4AE9-BD2F-6C13C34EA6FB";

        /// <summary>
        /// Serializes the specified value in string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string Serialize(object value)
        {
            if (value == null)
                return Default;

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

            if (type == typeof(bool?))
            {
                var _b14 = (bool?)value;
                if (_b14.HasValue)
                    return _b14.ToString();
                else
                    return string.Empty;
            }

            if (type == typeof(byte?))
            {
                var _b15 = (byte?)value;
                if (_b15.HasValue)
                    return _b15.ToString();
                else
                    return string.Empty;
            }

            if (type == typeof(char?))
            {
                var _b16 = (char?)value;
                if (_b16.HasValue)
                    return char.ToString(_b16.Value);
                else
                    return string.Empty;
            }

            if (type == typeof(DateTime?))
            {
                var _b17 = (DateTime?)value;
                if (_b17.HasValue)
                    return _b17.Value.ToString();
                else
                    return string.Empty;
            }

            if (type == typeof(decimal?))
            {
                var _b18 = (decimal?)value;
                if (_b18.HasValue)
                    return _b18.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(double?))
            {
                var _b19 = (byte?)value;
                if (_b19.HasValue)
                    return _b19.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(short?))
            {
                var _b20 = (byte?)value;
                if (_b20.HasValue)
                    return _b20.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(int?))
            {
                var _b21 = (byte?)value;
                if (_b21.HasValue)
                    return _b21.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(long?))
            {
                var _b22 = (byte?)value;
                if (_b22.HasValue)
                    return _b22.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(sbyte?))
            {
                var _b23 = (byte?)value;
                if (_b23.HasValue)
                    return _b23.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(float?))
            {
                var _b24 = (byte?)value;
                if (_b24.HasValue)
                    return _b24.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(ushort?))
            {
                var _b25 = (byte?)value;
                if (_b25.HasValue)
                    return _b25.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(uint?))
            {
                var _b26 = (byte?)value;
                if (_b26.HasValue)
                    return _b26.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (type == typeof(ulong?))
            {
                var _b27 = (byte?)value;
                if (_b27.HasValue)
                    return _b27.Value.ToString(CultureInfo.CurrentCulture);
                else
                    return string.Empty;
            }

            if (value is IConvertible convertible)
                return convertible.ToString(CultureInfo.CurrentCulture);

            if (value is IFormattable formattable)
                return formattable.ToString(null, CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(value.GetType());
            string result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }


        /// <summary>
        /// Unserializes the specified string value in the specified type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        internal static object Unserialize(string value, Type type)
        {

            if (value == Default)
                return null;

            if (type.IsEnum)
                return Enum.Parse(type, value);

            IConvertible convertible = value as IConvertible;

            if (type == typeof(bool) || type == typeof(bool?))
                return String.IsNullOrWhiteSpace(value) ? (bool?)null : convertible.ToBoolean(CultureInfo.CurrentCulture);

            if (type == typeof(byte) || type == typeof(byte?))
                return String.IsNullOrWhiteSpace(value) ? (byte?)null : convertible.ToByte(CultureInfo.CurrentCulture);

            if (type == typeof(char) || type == typeof(char?))
                return String.IsNullOrWhiteSpace(value) ? (char?)null : convertible.ToChar(CultureInfo.CurrentCulture);

            if (type == typeof(DateTime) || type == typeof(DateTime?))
                return String.IsNullOrWhiteSpace(value) ? (DateTime?)null : convertible.ToDateTime(CultureInfo.CurrentCulture);

            if (type == typeof(decimal) || type == typeof(decimal?))
                return String.IsNullOrWhiteSpace(value) ? (decimal?)null : convertible.ToDecimal(CultureInfo.CurrentCulture);

            if (type == typeof(double) || type == typeof(double?))
                return String.IsNullOrWhiteSpace(value) ? (double?)null : convertible.ToDouble(CultureInfo.CurrentCulture);

            if (type == typeof(short) || type == typeof(short?))
                return String.IsNullOrWhiteSpace(value) ? (short?)null : convertible.ToInt16(CultureInfo.CurrentCulture);

            if (type == typeof(int) || type == typeof(int?))
                return String.IsNullOrWhiteSpace(value) ? (int?)null : convertible.ToInt32(CultureInfo.CurrentCulture);

            if (type == typeof(long) || type == typeof(long?))
                return String.IsNullOrWhiteSpace(value) ? (long?)null : convertible.ToInt64(CultureInfo.CurrentCulture);

            if (type == typeof(sbyte) || type == typeof(sbyte?))
                return String.IsNullOrWhiteSpace(value) ? (sbyte?)null : convertible.ToSByte(CultureInfo.CurrentCulture);

            if (type == typeof(float) || type == typeof(float?))
                return String.IsNullOrWhiteSpace(value) ? (float?)null : convertible.ToSingle(CultureInfo.CurrentCulture);

            if (type == typeof(string))
                return value.ToString();

            if (type == typeof(ushort) || type == typeof(ushort?))
                return String.IsNullOrWhiteSpace(value) ? (ushort?)null : convertible.ToUInt16(CultureInfo.CurrentCulture);

            if (type == typeof(uint) || type == typeof(uint?))
                return String.IsNullOrWhiteSpace(value) ? (uint?)null : convertible.ToUInt32(CultureInfo.CurrentCulture);

            if (type == typeof(ulong) || type == typeof(ulong?))
                return String.IsNullOrWhiteSpace(value) ? (ulong?)null : convertible.ToUInt64(CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(type);
            string result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }

    }


}
