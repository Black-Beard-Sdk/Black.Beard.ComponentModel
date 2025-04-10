using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Bb.Converters
{


    /// <summary>
    /// My Converter
    /// </summary>
    public static partial class ConverterHelper
    {



        /// <summary>
        /// Converts a value to the specified target type.
        /// </summary>
        /// <typeparam name="T">The target type to convert to.</typeparam>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method uses the default conversion context.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int result = "123".ConvertTo&lt;int&gt;();
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static T? ConvertTo<T>(this object self)
        {
            return (T?)ConvertTo(self, typeof(T), (ConverterContext?)null);
        }

        /// <summary>
        /// Converts a value to the specified target type using a specific culture.
        /// </summary>
        /// <typeparam name="T">The target type to convert to.</typeparam>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <param name="culture">The culture to use for the conversion. Must not be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method allows specifying a culture to assist in the conversion process.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double result = "123.45".ConvertTo&lt;double&gt;(CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: 123.45
        /// </code>
        /// </example>
        public static T? ConvertTo<T>(this object self, CultureInfo culture)
        {
            return (T?)ConvertTo(self, typeof(T), new ConverterContext(culture));
        }

        /// <summary>
        /// Converts a value to the specified target type using a specific text encoding.
        /// </summary>
        /// <typeparam name="T">The target type to convert to.</typeparam>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <param name="encoding">The text encoding to use for the conversion. Must not be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method allows specifying a text encoding to assist in the conversion process.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string result = "Hello".ConvertTo&lt;string&gt;(Encoding.UTF8);
        /// Console.WriteLine(result); // Output: Hello
        /// </code>
        /// </example>
        public static T? ConvertTo<T>(this object self, Encoding encoding)
        {
            return (T?)ConvertTo(self, typeof(T), new ConverterContext(null, encoding));
        }

        /// <summary>
        /// Converts a value to the specified target type using a specific culture and text encoding.
        /// </summary>
        /// <typeparam name="T">The target type to convert to.</typeparam>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <param name="culture">The culture to use for the conversion. Must not be null.</param>
        /// <param name="encoding">The text encoding to use for the conversion. Must not be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method allows specifying both a culture and a text encoding to assist in the conversion process.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string result = "123".ConvertTo&lt;string&gt;(CultureInfo.InvariantCulture, Encoding.UTF8);
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static T? ConvertTo<T>(this object self, CultureInfo culture, Encoding encoding)
        {
            return (T?)ConvertTo(self, typeof(T), new ConverterContext(culture, encoding));
        }

        /// <summary>
        /// Converts a value to the specified target type.
        /// </summary>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <param name="context">The conversion context. Can be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method uses a conversion function specific to the source and target types.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// Thrown if no conversion function is available for the specified types.
        /// </exception>
        public static object? ConvertTo(this object self, Type targetType, ConverterContext? context)
        {

            object? result = null;

            if (self != null)
            {

                var function = GetFunctionForConvert(self.GetType(), targetType);

                if (function != null)
                    result = function(self, context ?? ConverterContext.Default);

            }

            return result;

        }

        /// <summary>
        /// Converts a value to the specified target type.
        /// </summary>
        /// <param name="self">The initial value to convert. Must not be null.</param>
        /// <param name="targetType">The target type to convert to. Must not be null.</param>
        /// <returns>
        /// The converted value.
        /// </returns>
        /// <remarks>
        /// This method uses the default conversion context.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// object result = "123".ConvertTo(typeof(int));
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static object? ConvertTo(this object self, Type targetType)
        {
            return self.ConvertTo(targetType, (ConverterContext?)null);
        }

        /// <summary>
        /// Convert a value to specified target type
        /// </summary>
        /// <param name="self">initial value to convert</param>
        /// <param name="targetType">Target type</param>
        /// <param name="culture">culture for help conversion</param>
        /// <returns></returns>
        public static object? ConvertTo(this object self, Type targetType, CultureInfo culture)
        {
            return self.ConvertTo(targetType, new ConverterContext(culture));
        }

        /// <summary>
        /// Convert a value to specified target type
        /// </summary>
        /// <param name="self">initial value to convert</param>
        /// <param name="targetType">Target type</param>
        /// <param name="encoding">text encoding for help conversion</param>
        /// <returns></returns>
        public static object? ConvertTo(this object self, Type targetType, Encoding encoding)
        {
            return self.ConvertTo(targetType, new ConverterContext(null, encoding));
        }

        /// <summary>
        /// Convert a value to specified target type
        /// </summary>
        /// <param name="self">initial value to convert</param>
        /// <param name="culture">culture for help conversion</param>
        /// <param name="targetType">Target type</param>
        /// <param name="encoding">text encoding for help conversion</param>
        /// <returns></returns>
        public static object? ConvertTo(this object self, Type targetType, CultureInfo culture, Encoding encoding)
        {
            return self.ConvertTo(targetType, new ConverterContext(culture, encoding));
        }


        /// <summary>
        /// Serializes the specified value in string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string? Serialize(dynamic value)
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

                case DateTime:
                case bool:
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

            IConvertible? convertible = value as IConvertible;
            if (convertible != null)
                return convertible.ToString(CultureInfo.CurrentCulture);

            IFormattable? formattable = value as IFormattable;
            if (formattable != null)
                return formattable.ToString(null, CultureInfo.CurrentCulture);

            var c = TypeDescriptor.GetConverter(value.GetType());
            string? result = c.ConvertTo(value, typeof(string)) as string;
            return result;

        }

        /// <summary>
        /// Deserializes the specified string value in the specified type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        internal static dynamic? Unserialize(string value, Type type)
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

            return (string?)ConverterHelper.ConvertTo(value, type);

        }

    }


}
