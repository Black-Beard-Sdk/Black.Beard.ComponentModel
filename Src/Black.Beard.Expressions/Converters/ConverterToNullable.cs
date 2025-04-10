// Ignore Spelling: Nullable

using Bb.Converters;
using System;
using System.Collections;
using System.Globalization;

namespace Bb.Converters
{

    /// <summary>
    /// Represents a set of static methods for converting various types to nullable types.
    /// </summary>
    public static partial class ConverterFromNullable
    {

        #region ToBoolean

        /// <summary>
        /// Converts a non-nullable boolean to a nullable boolean.
        /// </summary>
        /// <param name="value">The non-nullable boolean value to convert.</param>
        /// <returns>
        /// A nullable boolean representing the input value.
        /// </returns>
        /// <remarks>
        /// This method wraps a non-nullable boolean into a nullable boolean.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this bool value)
        {
            return new bool?(value);
        }

        /// <summary>
        /// Converts a signed 8-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The signed 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 8-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this sbyte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a character to a nullable boolean.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a character to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this char value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts an unsigned 8-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The unsigned 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 8-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// byte value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this byte value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a signed 16-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The signed 16-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 16-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this short value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 16-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this ushort value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a signed 32-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The signed 32-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 32-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this int value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts an unsigned 32-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The unsigned 32-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 32-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this uint value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a signed 64-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The signed 64-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 64-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this long value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer to a nullable boolean.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 64-bit integer to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 1;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this ulong value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a single-precision floating-point number to a nullable boolean.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a single-precision floating-point number to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 1.0f;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this float value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a double-precision floating-point number to a nullable boolean.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a double-precision floating-point number to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 1.0;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this double value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a decimal number to a nullable boolean.
        /// </summary>
        /// <param name="value">The decimal number to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a decimal number to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 1.0m;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this decimal value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        /// <summary>
        /// Converts a DateTime value to a nullable boolean.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>
        /// A nullable boolean representing the converted value.
        /// </returns>
        /// <remarks>
        /// This method converts a DateTime value to a nullable boolean using <see cref="Convert.ToBoolean(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = DateTime.Now;
        /// bool? result = value.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// </code>
        /// </example>
        public static bool? ToBoolean(this DateTime value)
        {
            return new bool?(Convert.ToBoolean(value));
        }

        #endregion ToBoolean

        #region TosByte               

        /// <summary>
        /// Converts a non-nullable boolean to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable boolean value to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a boolean value to a signed 8-bit integer, where true is represented as 1 and false as 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 1
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this bool value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a signed 8-bit integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The signed 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method wraps a signed 8-bit integer into a nullable signed 8-bit integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = -42;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: -42
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this sbyte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a character to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the Unicode code point of the character.
        /// </returns>
        /// <remarks>
        /// This method converts a character to its corresponding signed 8-bit integer representation.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the character's Unicode code point exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 65
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this char value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts an unsigned 8-bit integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The unsigned 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 8-bit integer to a signed 8-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// byte value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this byte value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a signed 16-bit integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The signed 16-bit integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 16-bit integer to a signed 8-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this short value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 16-bit integer to a signed 8-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this ushort value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an integer to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this int value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable unsigned integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable unsigned integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned integer to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this uint value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable long integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable long integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a long integer to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this long value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable unsigned long integer to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable unsigned long integer to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned long integer to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 127;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this ulong value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable single-precision floating-point number to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a single-precision floating-point number to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 127.5f;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this float value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable double-precision floating-point number to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a double-precision floating-point number to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 127.5;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this double value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable decimal to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable decimal to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a decimal to a signed 8-bit integer. If the value exceeds the range of a signed 8-bit integer, an exception is thrown.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 127.5m;
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output: 127
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this decimal value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        /// <summary>
        /// Converts a non-nullable <see cref="DateTime"/> to a nullable signed 8-bit integer.
        /// </summary>
        /// <param name="value">The non-nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// A nullable signed 8-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a <see cref="DateTime"/> to a signed 8-bit integer. If the value cannot be converted, an exception is thrown.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = new DateTime(2023, 1, 1);
        /// sbyte? result = value.ToSByte();
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// </code>
        /// </example>
        public static sbyte? ToSByte(this DateTime value)
        {
            return new sbyte?(Convert.ToSByte(value));
        }

        #endregion TosByte

        #region ToChar


        /// <summary>
        /// Converts a non-nullable boolean to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable boolean value to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a boolean value to a character, where true is represented as '1' and false as '0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// char? result = value.ToChar();
        /// Console.WriteLine(result); // Output: '1'
        /// </code>
        /// </example>
        public static char? ToChar(this bool value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable character to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable character to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this char value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable signed byte to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable signed byte to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this sbyte value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable byte to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable byte to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this byte value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable short to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable short to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this short value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable unsigned short to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable unsigned short to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this ushort value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable integer to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable integer to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this int value) => ToChar((uint)value);

        /// <summary>
        /// Converts a non-nullable unsigned integer to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable unsigned integer to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this uint value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable unsigned long to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable unsigned long to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this ulong value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable float to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable float to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this float value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable double to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable double to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this double value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable decimal to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable decimal to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this decimal value)
        {
            return new char?(Convert.ToChar(value));
        }

        /// <summary>
        /// Converts a non-nullable DateTime to a nullable character.
        /// </summary>
        /// <param name="value">The non-nullable DateTime to convert.</param>
        /// <returns>
        /// A nullable character representing the input value.
        /// </returns>
        public static char? ToChar(this DateTime value)
        {
            return new char?(Convert.ToChar(value));
        }

        #endregion ToChar

        #region ToInt16

        /// <summary>
        /// Converts a boolean value to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The boolean value to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a boolean value to a 16-bit integer, where true is represented as 1 and false as 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 1
        /// </code>
        /// </example>
        public static short? ToInt16(this bool value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a character to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the Unicode code point of the character.
        /// </returns>
        /// <remarks>
        /// This method converts a character to its corresponding 16-bit integer representation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 65
        /// </code>
        /// </example>
        public static short? ToInt16(this char value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a signed 8-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The signed 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 8-bit integer to a 16-bit integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = -42;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: -42
        /// </code>
        /// </example>
        public static short? ToInt16(this sbyte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts an unsigned 8-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The unsigned 8-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 8-bit integer to a 16-bit integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte value = 255;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 255
        /// </code>
        /// </example>
        public static short? ToInt16(this byte value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts an unsigned 16-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 16-bit integer to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 32767;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 32767
        /// </code>
        /// </example>
        public static short? ToInt16(this ushort value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a signed 32-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The signed 32-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 32-bit integer to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 12345;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 12345
        /// </code>
        /// </example>
        public static short? ToInt16(this int value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a signed 64-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The signed 64-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a signed 64-bit integer to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 12345;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 12345
        /// </code>
        /// </example>
        public static short? ToInt16(this long value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts an unsigned 64-bit integer to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts an unsigned 64-bit integer to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 12345;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 12345
        /// </code>
        /// </example>
        public static short? ToInt16(this ulong value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a single-precision floating-point number to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The single-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a single-precision floating-point number to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 123.45f;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static short? ToInt16(this float value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a double-precision floating-point number to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The double-precision floating-point number to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a double-precision floating-point number to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 123.45;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static short? ToInt16(this double value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a decimal to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The decimal to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a decimal to a signed 16-bit integer.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 123.45m;
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output: 123
        /// </code>
        /// </example>
        public static short? ToInt16(this decimal value)
        {
            return new short?(Convert.ToInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> to a nullable 16-bit integer.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// A nullable 16-bit integer representing the input value.
        /// </returns>
        /// <remarks>
        /// This method converts a <see cref="DateTime"/> to a signed 16-bit integer. The conversion logic depends on the implementation of <see cref="Convert.ToInt16(object)"/>.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = new DateTime(2023, 1, 1);
        /// short? result = value.ToInt16();
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// </code>
        /// </example>
        public static short? ToInt16(this DateTime value)
        {
            return new short?(Convert.ToInt16(value));
        }

        #endregion ToInt16        

        #region ToDateTime

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// DateTime date = DateTime.Now;
        /// DateTime? nullableDate = date.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this DateTime value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="sbyte"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this sbyte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="byte"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// byte value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this byte value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="short"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this short value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="ushort"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this ushort value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="int"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this int value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an <see cref="uint"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="uint"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this uint value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="long"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this long value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="ulong"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 1;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this ulong value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="bool"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this bool value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this char value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="float"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 1.0f;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this float value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="double"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 1.0;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this double value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="DateTime"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTime"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="decimal"/> value cannot be converted to a <see cref="DateTime"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 1.0m;
        /// DateTime? nullableDate = value.ToDateTime();
        /// </code>
        /// </example>
        public static DateTime? ToDateTime(this decimal value)
        {
            return new DateTime?(Convert.ToDateTime(value));
        }


        #endregion ToDateTime

        #region ToDecimal

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="sbyte"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this sbyte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this byte value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this char value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="short"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this short value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this ushort value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="int"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 1000;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this int value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts an <see cref="uint"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1000;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this uint value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="long"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 10000;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this long value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 10000;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this ulong value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="float"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 10.5f;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this float value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="double"/> value is outside the range of a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 10.5;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this double value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 10.5m;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this decimal value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the <see cref="bool"/> value cannot be converted to a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this bool value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="decimal"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="decimal"/> containing the converted value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the <see cref="DateTime"/> value cannot be converted to a <see cref="decimal"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = DateTime.Now;
        /// decimal? nullableDecimal = value.ToDecimal();
        /// </code>
        /// </example>
        public static decimal? ToDecimal(this DateTime value)
        {
            return new decimal?(Convert.ToDecimal(value));
        }


        #endregion ToDecimal

        #region ToDouble

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this sbyte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this byte value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this short value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="double"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this char value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this ushort value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// int value = 1000;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this int value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts an <see cref="uint"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1000;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this uint value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// long value = 10000;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this long value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 10000;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this ulong value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// float value = 10.5f;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this float value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// double value = 10.5;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this double value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 10.5m;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this decimal value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this bool value)
        {
            return new double?(Convert.ToDouble(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="double"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="double"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = DateTime.Now;
        /// double? nullableDouble = value.ToDouble();
        /// </code>
        /// </example>
        public static double? ToDouble(this DateTime value)
        {
            return new double?(Convert.ToDouble(value));
        }

        #endregion ToDouble

        #region ToInt32

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this bool value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to an <see cref="int"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this char value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this sbyte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this byte value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this short value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this ushort value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="uint"/> value is outside the range of an <see cref="int"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1000;
        /// int? nullableInt = value.ToInt32();
        /// </code>
        /// </example>
        public static int? ToInt32(this uint value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this int value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this long value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this ulong value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this float value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this double value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this decimal value)
        {
            return new int?(Convert.ToInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="int"/> containing the converted value.</returns>
        public static int? ToInt32(this DateTime value)
        {
            return new int?(Convert.ToInt32(value));
        }

        #endregion ToInt32

        #region ToInt64

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this bool value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this char value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this sbyte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this byte value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this short value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this ushort value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// int value = 1000;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this int value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="uint"/> value is outside the range of a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1000;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this uint value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ulong"/> value is outside the range of a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 1000;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this ulong value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// long value = 1000;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this long value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="float"/> value is outside the range of a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 1000.5f;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this float value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="double"/> value is outside the range of a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 1000.5;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this double value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="decimal"/> value is outside the range of a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 1000.5m;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this decimal value)
        {
            return new long?(Convert.ToInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="long"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="long"/> containing the converted value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the <see cref="DateTime"/> value cannot be converted to a <see cref="long"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = DateTime.Now;
        /// long? nullableLong = value.ToInt64();
        /// </code>
        /// </example>
        public static long? ToInt64(this DateTime value)
        {
            return new long?(Convert.ToInt64(value));
        }

        #endregion ToInt64

        #region ToByte

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this bool value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this char value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="sbyte"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this sbyte value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="short"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this short value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ushort"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this ushort value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="int"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 255;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this int value) => ToByte((uint)value);

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="uint"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 255;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this uint value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="long"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 255;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this long value) => ToByte((ulong)value);

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ulong"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 255;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this ulong value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="float"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 255.0f;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this float value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="double"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 255.0;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this double value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="decimal"/> value is outside the range of a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 255.0m;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this decimal value)
        {
            return new byte?(Convert.ToByte(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="byte"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="byte"/> containing the converted value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the <see cref="DateTime"/> value cannot be converted to a <see cref="byte"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime value = DateTime.Now;
        /// byte? nullableByte = value.ToByte();
        /// </code>
        /// </example>
        public static byte? ToByte(this DateTime value)
        {
            return new byte?(Convert.ToByte(value));
        }

        #endregion ToSByte

        #region ToSingle

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this sbyte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this byte value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="float"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this char value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this short value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this ushort value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// int value = 1000;
        /// float? nullableFloat = value.ToSingle();
        /// </code>
        /// </example>
        public static float? ToSingle(this int value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this uint value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this long value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this ulong value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this float value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this double value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this decimal value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this bool value)
        {
            return new float?(Convert.ToSingle(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="float"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="float"/> containing the converted value.</returns>
        public static float? ToSingle(this DateTime value)
        {
            return new float?(Convert.ToSingle(value));
        }




        #endregion ToSingle

        #region ToUInt16

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this bool value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="char"/> value is outside the range of a <see cref="ushort"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this char value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="sbyte"/> value is outside the range of a <see cref="ushort"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this sbyte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this byte value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="short"/> value is outside the range of a <see cref="ushort"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this short value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="int"/> value to a nullable <see cref="int"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ushort"/> value is outside the range of a <see cref="ushort"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// ushort? nullableUShort = value.ToUInt16();
        /// </code>
        /// </example>
        public static ushort? ToUInt16(this int value) => ToUInt16((uint)value);

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        public static ushort? ToUInt16(this ushort value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        public static ushort? ToUInt16(this uint value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="long"/> value is outside the range of a <see cref="ushort"/>.</exception>
        public static ushort? ToUInt16(this long value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ulong"/> value is outside the range of a <see cref="ushort"/>.</exception>
        public static ushort? ToUInt16(this ulong value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="float"/> value is outside the range of a <see cref="ushort"/>.</exception>
        public static ushort? ToUInt16(this float value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="double"/> value is outside the range of a <see cref="ushort"/>.</exception>
        public static ushort? ToUInt16(this double value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="decimal"/> value is outside the range of a <see cref="ushort"/>.</exception>
        public static ushort? ToUInt16(this decimal value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="ushort"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="ushort"/> containing the converted value.</returns>
        public static ushort? ToUInt16(this DateTime value)
        {
            return new ushort?(Convert.ToUInt16(value));
        }


        #endregion ToUInt16

        #region ToUInt32

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// uint? nullableUInt = value.ToUInt32();
        /// </code>
        /// </example>
        public static uint? ToUInt32(this bool value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="char"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// uint? nullableUInt = value.ToUInt32();
        /// </code>
        /// </example>
        public static uint? ToUInt32(this char value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="sbyte"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// uint? nullableUInt = value.ToUInt32();
        /// </code>
        /// </example>
        public static uint? ToUInt32(this sbyte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// uint? nullableUInt = value.ToUInt32();
        /// </code>
        /// </example>
        public static uint? ToUInt32(this byte value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="short"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// uint? nullableUInt = value.ToUInt32();
        /// </code>
        /// </example>
        public static uint? ToUInt32(this short value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        public static uint? ToUInt32(this ushort value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="int"/> value is outside the range of a <see cref="uint"/>.</exception>
        public static uint? ToUInt32(this int value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        public static uint? ToUInt32(this uint value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="long"/> value is outside the range of a <see cref="uint"/>.</exception>
        public static uint? ToUInt32(this long value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="ulong"/> value is outside the range of a <see cref="uint"/>.</exception>
        public static uint? ToUInt32(this ulong value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="float"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <exception cref="FormatException">Thrown if the <see cref="float"/> value is not in a recognizable format.</exception>
        public static uint? ToUInt32(this float value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="double"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <exception cref="FormatException">Thrown if the <see cref="double"/> value is not in a recognizable format.</exception>
        public static uint? ToUInt32(this double value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="decimal"/> value is outside the range of a <see cref="uint"/>.</exception>
        /// <exception cref="FormatException">Thrown if the <see cref="decimal"/> value is not in a recognizable format.</exception>
        public static uint? ToUInt32(this decimal value)
        {
            return new uint?(Convert.ToUInt32(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="uint"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="uint"/> containing the converted value.</returns>
        /// <exception cref="InvalidCastException">Thrown if the <see cref="DateTime"/> value cannot be converted to a <see cref="uint"/>.</exception>
        public static uint? ToUInt32(this DateTime value)
        {
            return new uint?(Convert.ToUInt32(value));
        }


        #endregion ToUInt32

        #region ToUInt64

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// ulong? nullableULong = value.ToUInt64();
        /// </code>
        /// </example>
        public static ulong? ToUInt64(this bool value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="char"/> value is outside the range of a <see cref="ulong"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = '5';
        /// ulong? nullableULong = value.ToUInt64();
        /// </code>
        /// </example>
        public static ulong? ToUInt64(this char value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="sbyte"/> value is outside the range of a <see cref="ulong"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// ulong? nullableULong = value.ToUInt64();
        /// </code>
        /// </example>
        public static ulong? ToUInt64(this sbyte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// ulong? nullableULong = value.ToUInt64();
        /// </code>
        /// </example>
        public static ulong? ToUInt64(this byte value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        /// <exception cref="OverflowException">Thrown if the <see cref="short"/> value is outside the range of a <see cref="ulong"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// ulong? nullableULong = value.ToUInt64();
        /// </code>
        /// </example>
        public static ulong? ToUInt64(this short value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this ushort value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this int value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this uint value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this long value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this ulong value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this float value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this double value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
        public static ulong? ToUInt64(this decimal value)
        {
            return new ulong?(Convert.ToUInt64(value));
        }

        /// <summary>
        /// Converts a <see cref="DateTime"/> value to a nullable <see cref="ulong"/>.
        /// </summary>
        /// <param name="value">The <see cref="DateTime"/> value to convert.</param>
        /// <returns>A nullable <see cref="ulong"/> containing the converted value.</returns>
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
        public static DateTimeOffset? ToDateTimeOffset(this string value, CultureInfo? cultureInfo = null)
        {
            var result = DateTimeOffset.Parse(value, cultureInfo ?? ConverterContext.DefaultCultureInfo ?? CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>
        /// Converts an <see cref="sbyte"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="sbyte"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="sbyte"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this sbyte value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="byte"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="byte"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="byte"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// byte value = 10;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this byte value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="short"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="short"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="short"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// short value = 100;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this short value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="ushort"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="ushort"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="ushort"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 100;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this ushort value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an <see cref="int"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="int"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="int"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// int value = 1000;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this int value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="uint"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="uint"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="uint"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// uint value = 1000;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this uint value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="long"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="long"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="long"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// long value = 1000;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this long value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="ulong"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="ulong"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="ulong"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 1000;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this ulong value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="bool"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="bool"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="bool"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this bool value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="char"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="char"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="char"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this char value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="float"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="float"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="float"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// float value = 10.5f;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this float value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="double"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="double"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="double"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// double value = 10.5;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this double value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a <see cref="decimal"/> value to a nullable <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to convert.</param>
        /// <returns>A nullable <see cref="DateTimeOffset"/> containing the converted value.</returns>
        /// <exception cref="FormatException">Thrown if the <see cref="decimal"/> value cannot be converted to a <see cref="DateTimeOffset"/>.</exception>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 10.5m;
        /// DateTimeOffset? nullableDateTimeOffset = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset? ToDateTimeOffset(this decimal value)
        {
            return new DateTimeOffset?(Convert.ToDateTime(value));
        }

        #endregion ToDateTimeOffset

        #region ToGuid

        /// <summary>
        /// Converts a <see cref="string"/> value to a nullable <see cref="Guid"/>.
        /// </summary>
        /// <remarks>
        /// Parses the string representation of a GUID to create a nullable <see cref="Guid"/>.
        /// </remarks>
        /// <param name="value">The string representation of the GUID to convert.</param>
        /// <returns>A nullable <see cref="Guid"/> containing the parsed value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="FormatException">Thrown if <paramref name="value"/> is not in a recognized GUID format.</exception>
        /// <example>
        /// <code lang="C#">
        /// string guidString = "d3c4a1b2-3e4f-5678-9abc-def012345678";
        /// Guid? nullableGuid = guidString.ToGuid();
        /// </code>
        /// </example>
        public static Guid? ToGuid(this string value)
        {
            Guid? result = Guid.Parse(value);
            return result;
        }

        /// <summary>
        /// Converts a byte array to a nullable <see cref="Guid"/>.
        /// </summary>
        /// <remarks>
        /// Creates a nullable <see cref="Guid"/> from a byte array.
        /// </remarks>
        /// <param name="values">The byte array to convert.</param>
        /// <returns>A nullable <see cref="Guid"/> containing the converted value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="values"/> is not 16 bytes long.</exception>
        /// <example>
        /// <code lang="C#">
        /// byte[] guidBytes = new byte[16];
        /// Guid? nullableGuid = guidBytes.ToGuid();
        /// </code>
        /// </example>
        public static Guid? ToGuid(this byte[] values)
        {
            Guid? result = new Guid(new ReadOnlySpan<byte>(values));
            return result;
        }

        #endregion ToGuid

    }

}
