// Ignore Spelling: Nullable

using System;

namespace Bb.Converters
{

    /// <summary>
    /// Helper class for converting nullable types to non-nullable types.
    /// </summary>
    public static partial class ConverterMoreNullable
    {


        #region ToBoolean

        /// <summary>
        /// Converts a nullable boolean to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// The boolean value if it has a value; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to a non-nullable boolean.
        /// If the input value is null, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// bool? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this bool? value)
        {
            return value ?? false;
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 10;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// sbyte? zeroValue = 0;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// sbyte? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this sbyte? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable character value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and can be converted to true; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to a non-nullable boolean using the IConvertible interface.
        /// If the input value is null, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = '1';
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// char? nullValue = null;
        /// bool resultForNull = nullableValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this char? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 10;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// byte? zeroValue = 0;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// byte? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this byte? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable short integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 10;
        /// bool result = ConverterMoreNullable.ToBoolean(nullableValue);
        /// Console.WriteLine(result); // Output: True
        /// 
        /// short? zeroValue = 0;
        /// bool resultForZero = ConverterMoreNullable.ToBoolean(zeroValue);
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// short? nullValue = null;
        /// bool resultForNull = ConverterMoreNullable.ToBoolean(nullValue);
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this short? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 10;
        /// bool result = ConverterMoreNullable.ToBoolean(nullableValue);
        /// Console.WriteLine(result); // Output: True
        /// 
        /// ushort? zeroValue = 0;
        /// bool resultForZero = ConverterMoreNullable.ToBoolean(zeroValue);
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// ushort? nullValue = null;
        /// bool resultForNull = ConverterMoreNullable.ToBoolean(nullValue);
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this ushort? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 10;
        /// bool result = ConverterMoreNullable.ToBoolean(nullableValue);
        /// Console.WriteLine(result); // Output: True
        /// 
        /// int? zeroValue = 0;
        /// bool resultForZero = ConverterMoreNullable.ToBoolean(zeroValue);
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// int? nullValue = null;
        /// bool resultForNull = ConverterMoreNullable.ToBoolean(nullValue);
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this int? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 10;
        /// bool result = ConverterMoreNullable.ToBoolean(nullableValue);
        /// Console.WriteLine(result); // Output: True
        /// 
        /// uint? zeroValue = 0;
        /// bool resultForZero = ConverterMoreNullable.ToBoolean(zeroValue);
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// uint? nullValue = null;
        /// bool resultForNull = ConverterMoreNullable.ToBoolean(nullValue);
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this uint? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable long integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable long integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 10;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// long? zeroValue = 0;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// long? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this long? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 10;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// ulong? zeroValue = 0;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// ulong? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this ulong? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable float value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable float to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 10.5f;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// float? zeroValue = 0f;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// float? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this float? value)
        {
            return value.HasValue && Math.Abs(value.Value) > double.Epsilon;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable double value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double to a non-nullable boolean.
        /// Note that unlike most other ToBoolean methods, this implementation doesn't check HasValue
        /// but still handles null properly through the null-conditional operator.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 10.5;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// double? zeroValue = 0;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// double? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this double? value)
        {
            return value.HasValue && Math.Abs(value.Value) > double.Epsilon;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a non-nullable boolean.
        /// If the input value is null or zero, the method returns false.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 10.5m;
        /// bool result = nullableValue.ToBoolean();
        /// Console.WriteLine(result); // Output: True
        /// 
        /// decimal? zeroValue = 0m;
        /// bool resultForZero = zeroValue.ToBoolean();
        /// Console.WriteLine(resultForZero); // Output: False
        /// 
        /// decimal? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this decimal? value)
        {
            return value.HasValue && value.Value != 0;
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable boolean value.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert.</param>
        /// <returns>
        /// <c>true</c> if the value has a value and can be converted to true; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable DateTime to a non-nullable boolean using the 
        /// IConvertible interface. If the input value is null, the method returns false.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the conversion from DateTime to boolean is not supported, which is typically 
        /// the case with standard DateTime implementations.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = DateTime.Now;
        /// bool result;
        /// try {
        ///     result = nullableValue.ToBoolean();
        /// } catch (InvalidCastException) {
        ///     Console.WriteLine("DateTime cannot be directly converted to boolean");
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// bool resultForNull = nullValue.ToBoolean();
        /// Console.WriteLine(resultForNull); // Output: False
        /// </code>
        /// </example>
        public static bool ToBoolean(this DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToBoolean(null);
            return false;
        }

        #endregion ToBoolean

        #region ToByte               

        /// <summary>
        /// Converts a nullable boolean to a non-nullable signed byte value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// 1 if the value has a value and is true; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to a non-nullable signed byte.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// sbyte result = nullableValue.ToSByte();
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// sbyte resultForFalse = falseValue.ToSByte();
        /// Console.WriteLine(resultForFalse); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// sbyte resultForNull = nullValue.ToSByte();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this bool? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// ulong? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this ulong? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 127.5f;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// float? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this float? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 127.5;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// double? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this double? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable decimal to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 127.5m;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// decimal? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this decimal? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// sbyte result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToSByte(value);
        ///     Console.WriteLine(result);
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// DateTime? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this DateTime? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable signed 8-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 8-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 8-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = -42;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: -42
        /// 
        /// sbyte? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this sbyte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }


        /// <summary>
        /// Converts a nullable character to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the character's Unicode code point is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char? value = 'A';
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 65
        /// 
        /// char? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this char? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 8-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 8-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 8-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// byte? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this byte? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable signed 16-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 16-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 16-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// short? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this short? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 16-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 16-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 16-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// ushort? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this ushort? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable signed 32-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 32-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 32-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// int? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this int? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 32-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 32-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 32-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// uint? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this uint? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        /// <summary>
        /// Converts a nullable signed 64-bit integer to a signed 8-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 64-bit integer to convert.</param>
        /// <returns>
        /// The <see cref="sbyte"/> representation of the value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 64-bit integer to a signed 8-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the value is outside the range of a signed 8-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? value = 127;
        /// sbyte result = ConverterMoreNullable2.ToSByte(value);
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// long? nullValue = null;
        /// sbyte resultForNull = ConverterMoreNullable2.ToSByte(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static sbyte ToSByte(this long? value)
        {
            return value.HasValue ? Convert.ToSByte(value.Value) : (sbyte)0;
        }

        #endregion ToByte

        #region ToChar

        /// <summary>
        /// Converts a nullable boolean to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// A character representing the boolean value if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to a non-nullable character using the IConvertible interface.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output usually depends on the IConvertible implementation
        /// 
        /// bool? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this bool? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable character value to convert.</param>
        /// <returns>
        /// The character value if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output: A
        /// 
        /// char? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this char? value)
        {
            return value.HasValue ? value.Value : '\0';
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert.</param>
        /// <returns>
        /// The signed byte converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than 0 or greater than 255.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// sbyte? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this sbyte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>
        /// The byte converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// byte? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this byte? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable short integer value to convert.</param>
        /// <returns>
        /// The short integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than 0 or greater than 65535.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// short? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this short? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer value to convert.</param>
        /// <returns>
        /// The unsigned short integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// ushort? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this ushort? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable integer value to convert.</param>
        /// <returns>
        /// The integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than 0 or greater than 65535.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output: A
        /// 
        /// int? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this int? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer value to convert.</param>
        /// <returns>
        /// The unsigned integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is greater than 65535.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// uint? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this uint? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable long integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable long integer value to convert.</param>
        /// <returns>
        /// The long integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than 0 or greater than 65535.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output: A
        /// 
        /// long? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this long? value) => value.HasValue ? Convert.ToChar(value.Value) : (char)0;

        /// <summary>
        /// Converts a nullable unsigned long integer to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer value to convert.</param>
        /// <returns>
        /// The unsigned long integer converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a non-nullable character.
        /// If the input value is null, the method returns the null character '\0'.
        /// Note: The method has a bug where it doesn't return the result of the Convert.ToChar call.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is greater than 65535.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 65;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Should be 'A' but may return '\0' due to implementation issue
        /// 
        /// ulong? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this ulong? value)
        {
            if (value.HasValue)
                Convert.ToChar(value.Value);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable float value to convert.</param>
        /// <returns>
        /// The float converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable float to a non-nullable character using the IConvertible interface.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion through IConvertible is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 65.0f;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output depends on IConvertible implementation
        /// 
        /// float? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this float? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable double value to convert.</param>
        /// <returns>
        /// The double converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double to a non-nullable character using the IConvertible interface.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion through IConvertible is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 65.0;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output depends on IConvertible implementation
        /// 
        /// double? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this double? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);

            return '\0';
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <returns>
        /// The decimal converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a non-nullable character using the IConvertible interface.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the conversion through IConvertible is not supported.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 65.0m;
        /// char result = nullableValue.ToChar();
        /// Console.WriteLine(result); // Output depends on IConvertible implementation
        /// 
        /// decimal? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this decimal? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable character value.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert.</param>
        /// <returns>
        /// The DateTime converted to a character if it has a value; otherwise, the null character ('\0').
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable DateTime to a non-nullable character using the IConvertible interface.
        /// If the input value is null, the method returns the null character '\0'.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the conversion from DateTime to character is not supported, which is typically 
        /// the case with standard DateTime implementations.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = DateTime.Now;
        /// char result;
        /// try {
        ///     result = nullableValue.ToChar();
        /// } catch (InvalidCastException) {
        ///     Console.WriteLine("DateTime cannot be directly converted to char");
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// char resultForNull = nullValue.ToChar();
        /// Console.WriteLine(resultForNull == '\0'); // Output: True
        /// </code>
        /// </example>
        public static char ToChar(this DateTime? value)
        {
            if (value.HasValue)
                return ((IConvertible)value.Value).ToChar(null);
            return '\0';
        }

        #endregion ToChar

        #region ToInt16


        /// <summary>
        /// Converts a nullable boolean to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// The boolean value converted to <see cref="short"/>: 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? value = true;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this bool? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable character to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The character's Unicode code point as a <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? value = 'A';
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 65
        /// 
        /// char? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this char? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable signed 8-bit integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 8-bit integer to convert.</param>
        /// <returns>
        /// The signed 8-bit integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 8-bit integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = -42;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: -42
        /// 
        /// sbyte? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 8-bit integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 8-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 8-bit integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 8-bit integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this byte? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 16-bit integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 16-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 16-bit integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 16-bit integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned 16-bit integer value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 32767;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 32767
        /// 
        /// ushort? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }


        /// <summary>
        /// Converts a nullable integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the integer value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? value = 12345;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// int? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this int? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned integer value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 12345;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// uint? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this uint? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable short integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? value = 123;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// short? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this short? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable long integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// The long integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the long integer value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? value = 12345;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// long? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this long? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// The unsigned long integer value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned long integer value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 12345;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ulong? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// The single-precision floating-point number converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// float? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this float? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// The double-precision floating-point number converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.45;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// double? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this double? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable decimal to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the decimal value exceeds the range of a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// short result = ConverterMoreNullable2.ToInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// decimal? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a signed 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// The <see cref="DateTime"/> value converted to <see cref="short"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to a signed 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to a signed 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// short result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToInt16(value);
        ///     Console.WriteLine(result);
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// short resultForNull = ConverterMoreNullable2.ToInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static short ToInt16(this DateTime? value)
        {
            return value.HasValue ? Convert.ToInt16(value.Value) : (short)0;
        }

        #endregion ToInt16        

        #region ToDateTime

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert.</param>
        /// <returns>
        /// The DateTime value if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable DateTime to a non-nullable DateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = new DateTime(2023, 1, 1);
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output: 1/1/2023 12:00:00 AM
        /// 
        /// DateTime? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable sbyte to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable sbyte value to convert.</param>
        /// <returns>
        /// The sbyte value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable sbyte to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the sbyte value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 1;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// sbyte? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>
        /// The byte value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the byte value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 1;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// byte? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this byte? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable short to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable short value to convert.</param>
        /// <returns>
        /// The short value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the short value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 2023;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// short? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this short? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable ushort to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable ushort value to convert.</param>
        /// <returns>
        /// The ushort value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable ushort to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the ushort value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 2023;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// ushort? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this ushort? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable int to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable int value to convert.</param>
        /// <returns>
        /// The int value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable int to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the int value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 20230101;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// int? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this int? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable uint to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable uint value to convert.</param>
        /// <returns>
        /// The uint value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable uint to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the uint value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 20230101;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// uint? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this uint? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable long to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable long value to convert.</param>
        /// <returns>
        /// The long value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the long value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 20230101123045;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// long? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this long? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable ulong to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable ulong value to convert.</param>
        /// <returns>
        /// The ulong value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable ulong to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the ulong value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 20230101123045;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output depends on culture-specific DateTime conversion
        /// 
        /// ulong? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this ulong? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable bool to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable bool value to convert.</param>
        /// <returns>
        /// The bool value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable bool to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// For bool values, true typically converts to a DateTime of 1/1/0001 1:00:00 AM and
        /// false typically converts to a DateTime of 1/1/0001 12:00:00 AM.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the bool value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output: 1/1/0001 1:00:00 AM (for true)
        /// 
        /// bool? falseValue = false;
        /// DateTime falseResult = falseValue.ToDateTime();
        /// Console.WriteLine(falseResult); // Output: 1/1/0001 12:00:00 AM (for false)
        /// 
        /// bool? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this bool? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable char to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable char value to convert.</param>
        /// <returns>
        /// The char value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable char to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the char value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = '1';
        /// DateTime result;
        /// try {
        ///     result = nullableValue.ToDateTime();
        ///     Console.WriteLine(result);
        /// } catch (InvalidCastException ex) {
        ///     Console.WriteLine("Cannot convert the char to DateTime: " + ex.Message);
        /// }
        /// 
        /// char? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this char? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable float value to convert.</param>
        /// <returns>
        /// The float value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable float to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the float value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 44197.5f; // Approximately Jan 1, 2021 12:00 PM (OLE Automation date)
        /// DateTime result;
        /// try {
        ///     result = nullableValue.ToDateTime();
        ///     Console.WriteLine(result); 
        /// } catch (InvalidCastException ex) {
        ///     Console.WriteLine("Cannot convert the float to DateTime: " + ex.Message);
        /// }
        /// 
        /// float? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this float? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable double value to convert.</param>
        /// <returns>
        /// The double value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime, which treats the double
        /// as an OLE Automation date (days since December 30, 1899).
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the double value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 44197.5; // Jan 1, 2021 12:00 PM (OLE Automation date)
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output: 1/1/2021 12:00:00 PM
        /// 
        /// double? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this double? value)
        {
            return value.HasValue ? Convert.ToDateTime(value.Value) : DateTime.MinValue;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <returns>
        /// The decimal value converted to DateTime if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a non-nullable DateTime.
        /// The conversion is performed using System.Convert.ToDateTime.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the decimal value cannot be converted to a valid DateTime.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 44197.5m; // Jan 1, 2021 12:00 PM (OLE Automation date)
        /// DateTime result;
        /// try {
        ///     result = nullableValue.ToDateTime();
        ///     Console.WriteLine(result);
        /// } catch (InvalidCastException ex) {
        ///     Console.WriteLine("Cannot convert the decimal to DateTime: " + ex.Message);
        /// }
        /// 
        /// decimal? nullValue = null;
        /// DateTime resultForNull = nullValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
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
        /// Converts a nullable DateTimeOffset to a non-nullable DateTime value.
        /// </summary>
        /// <param name="value">The nullable DateTimeOffset value to convert.</param>
        /// <returns>
        /// The UTC DateTime value if it has a value; otherwise, <see cref="DateTime.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable DateTimeOffset to a non-nullable DateTime.
        /// The DateTimeOffset is first converted to Universal Coordinated Time (UTC) before extracting the DateTime value.
        /// If the input value is null, the method returns DateTime.MinValue.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTimeOffset? nullableValue = new DateTimeOffset(2023, 1, 1, 12, 0, 0, TimeSpan.FromHours(2));
        /// DateTime result = nullableValue.ToDateTime();
        /// Console.WriteLine(result); // Output: 1/1/2023 10:00:00 AM (UTC time)
        /// 
        /// DateTimeOffset? nullValue = null;
        /// DateTime resultForNull = nullableValue.ToDateTime();
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM (DateTime.MinValue)
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this DateTimeOffset? value)
        {

            if (!value.HasValue)
                return DateTime.MinValue;

            var value2 = value.Value.ToUniversalTime();
            return value2.UtcDateTime;

        }

        #endregion ToDateTime

        #region ToDecimal

        /// <summary>
        /// Converts a nullable sbyte to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable sbyte value to convert.</param>
        /// <returns>
        /// The sbyte value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable sbyte to a non-nullable decimal.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>
        /// The byte value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a non-nullable decimal.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// byte? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this byte? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable char to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable char value to convert.</param>
        /// <returns>
        /// The char value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable char to a non-nullable decimal.
        /// The numeric value of the character (its Unicode code point) is used for the conversion.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 65 (Unicode value of 'A')
        /// 
        /// char? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this char? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable short value to convert.</param>
        /// <returns>
        /// The short value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short to a non-nullable decimal.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// short? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this short? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable ushort to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable ushort value to convert.</param>
        /// <returns>
        /// The ushort value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable ushort to a non-nullable decimal.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// ushort? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this ushort? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable int to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable int value to convert.</param>
        /// <returns>
        /// The int value converted to decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable int to a non-nullable decimal.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// int? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this int? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 42;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// uint? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this uint? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable long integer to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// The long integer value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable long integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 9223372036854775807; // Max long value
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 9223372036854775807
        /// 
        /// long? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this long? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// The unsigned long integer value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned long integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is too large to represent as a decimal.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 18446744073709551615; // Max ulong value
        /// decimal result;
        /// try {
        ///     result = nullableValue.ToDecimal();
        ///     Console.WriteLine(result);
        /// }
        /// catch (OverflowException) {
        ///     Console.WriteLine("Value is too large for decimal type");
        /// }
        /// 
        /// ulong? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this ulong? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable float to convert.</param>
        /// <returns>
        /// The float value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable floats, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is too large or small to represent as a decimal.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 123.456f;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 123.456 (may have small precision differences)
        /// 
        /// float? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this float? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable double to convert.</param>
        /// <returns>
        /// The double value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable doubles, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is too large or small to represent as a decimal, or if it is NaN or Infinity.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 123.456789;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 123.456789
        /// 
        /// double? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this double? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable decimals, returning a default value of 0
        /// when the input is null instead of throwing an exception. Since the input is already
        /// a decimal, no actual type conversion takes place.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 123.456789m;
        /// decimal result = nullableValue.ToDecimal();
        /// Console.WriteLine(result); // Output: 123.456789
        /// 
        /// decimal? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this decimal? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable boolean to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable booleans, converting true to 1,
        /// and both false and null to 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// decimal resultTrue = trueValue.ToDecimal();
        /// Console.WriteLine(resultTrue); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// decimal resultFalse = falseValue.ToDecimal();
        /// Console.WriteLine(resultFalse); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// decimal resultNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this bool? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable decimal value.
        /// </summary>
        /// <param name="value">The nullable DateTime to convert.</param>
        /// <returns>
        /// The DateTime value as a decimal if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable DateTimes, returning a default value of 0
        /// when the input is null. The conversion from DateTime to decimal uses the OLE Automation
        /// date format, where the integer portion represents the date and the fractional part
        /// represents the time of day.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// May be thrown when converting DateTime to decimal if not supported in the current implementation.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = new DateTime(2023, 1, 1);
        /// decimal result;
        /// try {
        ///     result = nullableValue.ToDecimal();
        ///     Console.WriteLine(result); // Output depends on implementation
        /// }
        /// catch (InvalidCastException) {
        ///     Console.WriteLine("Cannot convert DateTime to decimal directly");
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// decimal resultForNull = nullValue.ToDecimal();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static decimal ToDecimal(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDecimal(value.Value) : 0;
        }


        #endregion ToDecimal

        #region ToDouble

        /// <summary>
        /// Converts a nullable sbyte to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable sbyte value to convert.</param>
        /// <returns>
        /// The sbyte value converted to double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable sbyte to a non-nullable double.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 42;
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this sbyte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable byte value to convert.</param>
        /// <returns>
        /// The byte value converted to double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a non-nullable double.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 42;
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// byte? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this byte? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable short value to convert.</param>
        /// <returns>
        /// The short value converted to double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short to a non-nullable double.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 42;
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// short? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this short? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable char to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable char value to convert.</param>
        /// <returns>
        /// The char value converted to double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable char to a non-nullable double.
        /// The numeric value of the character (its Unicode code point) is used for the conversion.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 65 (Unicode value of 'A')
        /// 
        /// char? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this char? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable unsigned short to convert.</param>
        /// <returns>
        /// The unsigned short value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned shorts, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 65535; // max ushort value
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 65535
        /// 
        /// ushort? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this ushort? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 2147483647; // max int value
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 2147483647
        /// 
        /// int? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this int? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 4294967295; // max uint value
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 4294967295
        /// 
        /// uint? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this uint? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable long to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable long to convert.</param>
        /// <returns>
        /// The long value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable longs, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// Note that very large long values may lose precision when converted to double.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 9223372036854775807; // max long value
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 9.223372036854776E+18 (may lose precision)
        /// 
        /// long? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this long? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable unsigned long to convert.</param>
        /// <returns>
        /// The unsigned long value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned longs, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// Note that very large ulong values may lose precision when converted to double.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 18446744073709551615; // max ulong value
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 1.8446744073709552E+19 (may lose precision)
        /// 
        /// ulong? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this ulong? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable float to convert.</param>
        /// <returns>
        /// The float value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable floats, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// The conversion from float to double does not lose precision.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 123.456f;
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 123.456
        /// 
        /// float? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this float? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable double to convert.</param>
        /// <returns>
        /// The double value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable doubles, returning a default value of 0
        /// when the input is null instead of throwing an exception. Since the input is already
        /// a double, no actual type conversion takes place.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 123.456789;
        /// double result = nullableValue.ToDouble();
        /// Console.WriteLine(result); // Output: 123.456789
        /// 
        /// double? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this double? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable boolean to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// 1.0 for true, 0.0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable booleans, converting true to 1.0,
        /// and both false and null to 0.0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// double resultTrue = trueValue.ToDouble();
        /// Console.WriteLine(resultTrue); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// double resultFalse = falseValue.ToDouble();
        /// Console.WriteLine(resultFalse); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// double resultNull = nullValue.ToDouble();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this bool? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable double value.
        /// </summary>
        /// <param name="value">The nullable DateTime to convert.</param>
        /// <returns>
        /// The DateTime value as a double if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable DateTimes, returning a default value of 0
        /// when the input is null. The conversion from DateTime to double uses the OLE Automation
        /// date format, where the integer portion represents the date and the fractional part
        /// represents the time of day.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// May be thrown when converting DateTime to double if not supported in the current implementation.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = new DateTime(2023, 1, 1);
        /// double result;
        /// try {
        ///     result = nullableValue.ToDouble();
        ///     Console.WriteLine(result); // Output depends on implementation
        /// }
        /// catch (InvalidCastException) {
        ///     Console.WriteLine("Cannot convert DateTime to double directly");
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// double resultForNull = nullValue.ToDouble();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static double ToDouble(this DateTime? value)
        {
            return value.HasValue ? Convert.ToDouble(value.Value) : 0;
        }

        #endregion ToDouble

        #region ToInt32

        /// <summary>
        /// Converts a nullable bool to a non-nullable int value.
        /// </summary>
        /// <param name="value">The nullable bool value to convert.</param>
        /// <returns>
        /// The bool value converted to int if it has a value; otherwise, 0.
        /// For <c>true</c> the value is 1, for <c>false</c> the value is 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable bool to a non-nullable int.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// int resultForFalse = falseValue.ToInt32();
        /// Console.WriteLine(resultForFalse); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this bool? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable char to a non-nullable int value.
        /// </summary>
        /// <param name="value">The nullable char value to convert.</param>
        /// <returns>
        /// The char's Unicode code point converted to int if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable char to a non-nullable int.
        /// The numeric value of the character (its Unicode code point) is used for the conversion.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 65 (Unicode value of 'A')
        /// 
        /// char? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this char? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable sbyte to a non-nullable int value.
        /// </summary>
        /// <param name="value">The nullable sbyte value to convert.</param>
        /// <returns>
        /// The sbyte value converted to int if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable sbyte to a non-nullable int.
        /// If the input value is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 42;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable bytes, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 255; // max byte value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this byte? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable short to convert.</param>
        /// <returns>
        /// The short value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable shorts, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 32767; // max short value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 32767
        /// 
        /// short? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this short? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned short to convert.</param>
        /// <returns>
        /// The unsigned short value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned shorts, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 65535; // max ushort value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 65535
        /// 
        /// ushort? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned integers, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 2147483647; // max int value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 2147483647
        /// 
        /// uint? largeValue = 4294967295; // max uint value
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// uint? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this uint? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable integers, returning a default value of 0
        /// when the input is null instead of throwing an exception. Since the input is already
        /// an integer, no actual type conversion takes place.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 123456789;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 123456789
        /// 
        /// int? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this int? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable long to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable long to convert.</param>
        /// <returns>
        /// The long value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable longs, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than Int32.MinValue or greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 2147483647; // max int value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 2147483647
        /// 
        /// long? largeValue = 9223372036854775807L; // max long value
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// long? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this long? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned long to convert.</param>
        /// <returns>
        /// The unsigned long value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned longs, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 2147483647; // max int value
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 2147483647
        /// 
        /// ulong? largeValue = 18446744073709551615UL; // max ulong value
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// ulong? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable float to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable float to convert.</param>
        /// <returns>
        /// The float value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable floats, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// The conversion from float to int truncates the decimal part.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than Int32.MinValue or greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 123.75f;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// float? largeValue = 3e9f; // 3 billion
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// float? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this float? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable double to convert.</param>
        /// <returns>
        /// The double value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable doubles, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// The conversion from double to int truncates the decimal part.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than Int32.MinValue or greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 123.75;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// double? largeValue = 3e9; // 3 billion
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// double? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this double? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable integer value.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value as an integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable decimals, returning a default value of 0
        /// when the input is null instead of throwing an exception.
        /// The conversion from decimal to int truncates the decimal part.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the value is less than Int32.MinValue or greater than Int32.MaxValue.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 123.75m;
        /// int result = nullableValue.ToInt32();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// decimal? largeValue = 3000000000m; // 3 billion
        /// try {
        ///     int overflowResult = largeValue.ToInt32();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value too large for Int32");
        /// }
        /// 
        /// decimal? nullValue = null;
        /// int resultForNull = nullValue.ToInt32();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static int ToInt32(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt32(value.Value) : 0;
        }

        #endregion ToInt32

        #region ToInt64

        /// <summary>
        /// Converts a nullable boolean to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// The boolean value as a long integer if it has a value (1 for true, 0 for false); otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable boolean values, returning 0 when the input is null.
        /// When the input has a value, true is converted to 1 and false is converted to 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// long result1 = trueValue.ToInt64();
        /// Console.WriteLine(result1); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// long result2 = falseValue.ToInt64();
        /// Console.WriteLine(result2); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// long result3 = nullValue.ToInt64();
        /// Console.WriteLine(result3); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this bool? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The character's Unicode code point as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable characters, returning 0 when the input is null.
        /// When the input has a value, the character is converted to its numeric Unicode code point.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? charValue = 'A';
        /// long result = charValue.ToInt64();
        /// Console.WriteLine(result); // Output: 65 (Unicode code point for 'A')
        /// 
        /// char? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this char? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// The signed byte value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable signed bytes, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? byteValue = 127;
        /// long result = byteValue.ToInt64();
        /// Console.WriteLine(result); // Output: 127
        /// 
        /// sbyte? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this sbyte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable bytes, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? byteValue = 255;
        /// long result = byteValue.ToInt64();
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this byte? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable short integers, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? shortValue = 32767;
        /// long result = shortValue.ToInt64();
        /// Console.WriteLine(result); // Output: 32767
        /// 
        /// short? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this short? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer to convert.</param>
        /// <returns>
        /// The unsigned short integer value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned short integers, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? ushortValue = 65535;
        /// long result = ushortValue.ToInt64();
        /// Console.WriteLine(result); // Output: 65535
        /// 
        /// ushort? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this ushort? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable integers, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? intValue = 2147483647;
        /// long result = intValue.ToInt64();
        /// Console.WriteLine(result); // Output: 2147483647
        /// 
        /// int? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this int? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned integers, returning 0 when the input is null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? uintValue = 4294967295;
        /// long result = uintValue.ToInt64();
        /// Console.WriteLine(result); // Output: 4294967295
        /// 
        /// uint? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this uint? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// The unsigned long integer value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable unsigned long integers, returning 0 when the input is null.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the unsigned long integer value is too large to represent as a long integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? validValue = 9223372036854775807; // Max long value
        /// long result;
        /// try {
        ///     result = validValue.ToInt64();
        ///     Console.WriteLine(result); // Output: 9223372036854775807
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value is too large for long");
        /// }
        /// 
        /// ulong? overflowValue = 18446744073709551615; // Max ulong value
        /// try {
        ///     long overflowResult = overflowValue.ToInt64();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value is too large for long");
        /// }
        /// 
        /// ulong? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this ulong? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable long integer to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// The long integer value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable long integers, returning 0 when the input is null.
        /// Since the input is already a long integer, no actual type conversion takes place.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? longValue = 9223372036854775807; // Max long value
        /// long result = longValue.ToInt64();
        /// Console.WriteLine(result); // Output: 9223372036854775807
        /// 
        /// long? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this long? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable floating-point value to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable floating-point value to convert.</param>
        /// <returns>
        /// The floating-point value as a long integer if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable floating-point values, returning 0 when the input is null.
        /// The decimal part of the floating-point value is truncated during conversion.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the floating-point value is too large or too small to represent as a long integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? floatValue = 123.45f;
        /// long result = floatValue.ToInt64();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// float? nullValue = null;
        /// long resultNull = nullValue.ToInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this float? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable double to convert. If null, the method returns 0.</param>
        /// <returns>
        /// The double value converted to a <see cref="long"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable double values, returning 0 when the input is null.
        /// The conversion uses <see cref="Convert.ToInt64(double)"/> which rounds the double value to the nearest 64-bit signed integer.
        /// The fractional part is truncated during the conversion.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the double value is less than <see cref="long.MinValue"/> or greater than <see cref="long.MaxValue"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 123.45;
        /// long result = nullableValue.ToInt64();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// double? nullValue = null;
        /// long resultForNull = nullValue.ToInt64();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// 
        /// double? largeValue = 9.2233720368548E+18; // Larger than long.MaxValue
        /// try {
        ///     long overflow = largeValue.ToInt64();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value is too large to convert to Int64");
        /// }
        /// </code>
        /// </example>
        public static long ToInt64(this double? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable decimal to convert. If null, the method returns 0.</param>
        /// <returns>
        /// The decimal value converted to a <see cref="long"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable decimal values, returning 0 when the input is null.
        /// The conversion uses <see cref="Convert.ToInt64(decimal)"/> which rounds the decimal value to the nearest 64-bit signed integer.
        /// The fractional part is truncated during the conversion.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the decimal value is less than <see cref="long.MinValue"/> or greater than <see cref="long.MaxValue"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 123.45m;
        /// long result = nullableValue.ToInt64();
        /// Console.WriteLine(result); // Output: 123 (decimal part is truncated)
        /// 
        /// decimal? nullValue = null;
        /// long resultForNull = nullValue.ToInt64();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// 
        /// decimal? maxDecimalValue = decimal.MaxValue;
        /// try {
        ///     long overflow = maxDecimalValue.ToInt64();
        /// } catch (OverflowException) {
        ///     Console.WriteLine("Value is too large to convert to Int64");
        /// }
        /// </code>
        /// </example>
        public static long ToInt64(this decimal? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable long integer value.
        /// </summary>
        /// <param name="value">The nullable DateTime to convert. If null, the method returns 0.</param>
        /// <returns>
        /// The DateTime value converted to a <see cref="long"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable DateTime values, returning 0 when the input is null.
        /// The conversion uses <see cref="Convert.ToInt64(DateTime)"/> which typically converts the DateTime to ticks
        /// (the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001).
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// May be thrown when attempting to convert a DateTime to Int64, depending on the implementation.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = new DateTime(2023, 1, 1);
        /// long result;
        /// try {
        ///     result = nullableValue.ToInt64();
        ///     Console.WriteLine(result); // Output: A large number representing ticks
        /// } catch (InvalidCastException) {
        ///     Console.WriteLine("Conversion not supported in this environment");
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// long resultForNull = nullValue.ToInt64();
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static long ToInt64(this DateTime? value)
        {
            return value.HasValue ? Convert.ToInt64(value.Value) : 0;
        }        

        #endregion ToInt64

        #region ToByte

        /// <summary>
        /// Converts a nullable boolean value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert. If null, returns 0.</param>
        /// <returns>
        /// The boolean value converted to <see cref="byte"/>: 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable boolean to a byte without having to check
        /// for null values. If the input is null, the method returns 0. Otherwise, true is converted to 1
        /// and false is converted to 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// byte result1 = trueValue.ToByte();
        /// Console.WriteLine(result1); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// byte result2 = falseValue.ToByte();
        /// Console.WriteLine(result2); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// byte result3 = nullValue.ToByte();
        /// Console.WriteLine(result3); // Output: 0
        /// </code>
        /// </example>
        public static byte ToByte(this bool? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable character value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable character value to convert. If null, returns 0.</param>
        /// <returns>
        /// The character value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable character to a byte without having to check
        /// for null values. The method converts the character to its numeric Unicode value as a byte.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the character's Unicode value is greater than 255 and cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char? charValue = 'A';
        /// byte result = charValue.ToByte();
        /// Console.WriteLine(result); // Output: 65 (ASCII code for 'A')
        /// 
        /// char? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// char? unicodeChar = 'Ω'; // Has a Unicode value > 255
        /// try {
        ///     byte resultOverflow = unicodeChar.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Cannot convert this character to byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this char? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable signed byte value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable signed byte value to convert. If null, returns 0.</param>
        /// <returns>
        /// The signed byte value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable signed byte to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the signed byte value is negative, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? positiveValue = 100;
        /// byte result = positiveValue.ToByte();
        /// Console.WriteLine(result); // Output: 100
        /// 
        /// sbyte? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// sbyte? negativeValue = -1;
        /// try {
        ///     byte resultOverflow = negativeValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Cannot convert negative value to byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this sbyte? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable short integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable short integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The short integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable short integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the short value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// short? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// short? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this short? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable unsigned short integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The unsigned short integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable unsigned short integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the unsigned short value is greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// ushort? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// ushort? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this ushort? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the integer value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// int? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// int? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this int? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        /// <summary>
        /// Converts a nullable unsigned integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The unsigned integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable unsigned integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the unsigned integer value is greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// uint? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// uint? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this uint? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable long integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable long integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The long integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable long integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the long integer value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// long? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// long? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this long? value) => value.HasValue ? Convert.ToByte(value.Value) : (byte)0;

        /// <summary>
        /// Converts a nullable unsigned long integer value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer value to convert. If null, returns 0.</param>
        /// <returns>
        /// The unsigned long integer value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable unsigned long integer to a byte without having to check
        /// for null values. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the unsigned long integer value is greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? validValue = 200;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200
        /// 
        /// ulong? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// ulong? overflowValue = 300; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this ulong? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable floating-point value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable floating-point value to convert. If null, returns 0.</param>
        /// <returns>
        /// The floating-point value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable floating-point number to a byte without having to check
        /// for null values. The conversion rounds the value to the nearest integral value. If the input is null, 
        /// the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the floating-point value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? validValue = 200.5f;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200 (rounded to nearest integer)
        /// 
        /// float? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// float? overflowValue = 300.5f; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this float? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point value to convert. If null, returns 0.</param>
        /// <returns>
        /// The double-precision floating-point value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable double-precision floating-point number to a byte without having to check
        /// for null values. The conversion rounds the value to the nearest integral value. If the input is null, 
        /// the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the double-precision floating-point value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? validValue = 200.5;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200 (rounded to nearest integer)
        /// 
        /// double? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// double? overflowValue = 300.5; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this double? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable decimal value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert. If null, returns 0.</param>
        /// <returns>
        /// The decimal value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable decimal number to a byte without having to check
        /// for null values. The conversion rounds the value to the nearest integral value. If the input is null, 
        /// the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the decimal value is negative or greater than 255, which cannot be represented in a byte.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? validValue = 200.5m;
        /// byte result = validValue.ToByte();
        /// Console.WriteLine(result); // Output: 200 (rounded to nearest integer)
        /// 
        /// decimal? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// 
        /// // Example of overflow
        /// decimal? overflowValue = 300.5m; // Greater than byte.MaxValue (255)
        /// try {
        ///     byte resultOverflow = overflowValue.ToByte();
        /// }
        /// catch (OverflowException ex) {
        ///     Console.WriteLine("Value too large for byte: " + ex.Message);
        /// }
        /// </code>
        /// </example>
        public static byte ToByte(this decimal? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        /// <summary>
        /// Converts a nullable DateTime value to a non-nullable byte value.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert. If null, returns 0.</param>
        /// <returns>
        /// The DateTime value converted to <see cref="byte"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method provides a safe way to convert a nullable DateTime to a byte without having to check
        /// for null values. The conversion uses the System.Convert.ToByte method to convert the DateTime
        /// to a byte, which typically represents DateTime as an OLE Automation date.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown when the DateTime value cannot be represented in a byte (which is almost always the case).
        /// </exception>
        /// <exception cref="InvalidCastException">
        /// May be thrown if the conversion from DateTime to byte is not supported in the current implementation.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? dateValue = new DateTime(2023, 1, 1);
        /// byte result;
        /// try {
        ///     result = dateValue.ToByte();
        ///     Console.WriteLine(result);
        /// }
        /// catch (Exception ex) {
        ///     Console.WriteLine("Cannot convert DateTime to byte: " + ex.Message);
        ///     // Most likely an exception will be thrown
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// byte resultNull = nullValue.ToByte();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static byte ToByte(this DateTime? value)
        {
            return value.HasValue ? Convert.ToByte(value.Value) : (byte)0;
        }

        #endregion ToByte

        #region ToSingle

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// The signed byte value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? nullableValue = 42;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(sbyte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? nullableValue = 255;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(byte? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The character's Unicode code point converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 65 (Unicode value of 'A')
        /// 
        /// char? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(char? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? nullableValue = 32767;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 32767
        /// 
        /// short? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(short? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable unsigned short to convert.</param>
        /// <returns>
        /// The unsigned short value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? nullableValue = 42;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// ushort? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(ushort? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? nullableValue = 123;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// int? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(int? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? nullableValue = 123;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// uint? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(uint? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable long integer to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// The long integer value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? nullableValue = 123456789;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123456789
        /// 
        /// long? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(long? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// The unsigned long integer value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? nullableValue = 123456789;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123456789
        /// 
        /// ulong? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(ulong? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point value to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point value to convert.</param>
        /// <returns>
        /// The single-precision floating-point value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable single-precision floating-point values.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float? nullableValue = 123.45f;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123.45
        /// 
        /// float? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(float? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point value to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point value to convert.</param>
        /// <returns>
        /// The double-precision floating-point value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point value to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double? nullableValue = 123.45;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123.45
        /// 
        /// double? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(double? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable decimal value to convert.</param>
        /// <returns>
        /// The decimal value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal? nullableValue = 123.45m;
        /// float result = ConverterMoreNullable2.ToSingle(nullableValue);
        /// Console.WriteLine(result); // Output: 123.45
        /// 
        /// decimal? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(decimal? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable boolean to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// The boolean value converted to <see cref="float"/>: 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to a single-precision floating-point value.
        /// If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// float result = ConverterMoreNullable2.ToSingle(trueValue);
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// float resultForFalse = ConverterMoreNullable2.ToSingle(falseValue);
        /// Console.WriteLine(resultForFalse); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(bool? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable DateTime to a non-nullable single-precision floating-point value.
        /// </summary>
        /// <param name="value">The nullable DateTime value to convert.</param>
        /// <returns>
        /// The DateTime value converted to <see cref="float"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable DateTime to a single-precision floating-point value.
        /// If the input is null, the method returns 0. The conversion uses the OLE Automation date format,
        /// where the integer part represents the date and the fractional part represents the time of day.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the DateTime value cannot be converted to a float.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? nullableValue = new DateTime(2023, 1, 1);
        /// float result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToSingle(nullableValue);
        ///     Console.WriteLine(result); // Output depends on the OLE Automation date representation
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// float resultForNull = ConverterMoreNullable2.ToSingle(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static float ToSingle(DateTime? value)
        {
            return value.HasValue ? Convert.ToSingle(value.Value) : 0;
        }

        #endregion ToSingle

        #region ToString          

        /// <summary>
        /// Converts a nullable boolean to a string representation.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <returns>
        /// A string representation of the boolean value if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to its string representation.
        /// If the input value is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// string result = nullableValue.ToString();
        /// Console.WriteLine(result); // Output: "True"
        /// 
        /// bool? nullValue = null;
        /// string resultForNull = nullableValue.ToString();
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(bool? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable boolean to a string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable boolean value to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information. Can be null.</param>
        /// <returns>
        /// A string representation of the boolean value if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to its string representation.
        /// If the input value is null, the method returns null.
        /// The format provider allows for culture-specific formatting, although boolean values typically
        /// have standard "True" or "False" representations.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? nullableValue = true;
        /// string result = nullableValue.ToString(CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "True"
        /// 
        /// bool? nullValue = null;
        /// string resultForNull = nullableValue.ToString(CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(bool? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable character to a string representation.
        /// </summary>
        /// <param name="value">The nullable character value to convert.</param>
        /// <returns>
        /// A string representation of the character value if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to its string representation.
        /// If the input value is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// string result = ConverterMoreNullable.ToString(nullableValue);
        /// Console.WriteLine(result); // Output: "A"
        /// 
        /// char? nullValue = null;
        /// string resultForNull = ConverterMoreNullable.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(char? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable character to a string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable character value to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information. Can be null.</param>
        /// <returns>
        /// A string representation of the character value if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to its string representation.
        /// If the input value is null, the method returns null.
        /// The format provider allows for culture-specific formatting, although character values typically
        /// have standard string representations.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? nullableValue = 'A';
        /// string result = ConverterMoreNullable.ToString(nullableValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "A"
        /// 
        /// char? nullValue = null;
        /// string resultForNull = ConverterMoreNullable.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(char? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable signed byte to its string representation.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// A string representation of the signed byte if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = -42;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "-42"
        /// 
        /// sbyte? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(sbyte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable signed byte to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the signed byte if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = -42;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "-42"
        /// 
        /// sbyte? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(sbyte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable byte to its string representation.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// A string representation of the byte if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "255"
        /// 
        /// byte? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(byte? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable byte to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the byte if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "255"
        /// 
        /// byte? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(byte? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="short"/> to its string representation.
        /// </summary>
        /// <param name="value">The nullable <see cref="short"/> to convert.</param>
        /// <returns>
        /// A string representation of the <see cref="short"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="short"/> to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// short? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(short? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="short"/> to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable <see cref="short"/> to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the <see cref="short"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="short"/> to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// short? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(short? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="ushort"/> to its string representation.
        /// </summary>
        /// <param name="value">The nullable <see cref="ushort"/> to convert.</param>
        /// <returns>
        /// A string representation of the <see cref="ushort"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="ushort"/> to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// ushort? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(ushort? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="ushort"/> to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable <see cref="ushort"/> to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the <see cref="ushort"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="ushort"/> to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// ushort? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(ushort? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="int"/> to its string representation.
        /// </summary>
        /// <param name="value">The nullable <see cref="int"/> to convert.</param>
        /// <returns>
        /// A string representation of the <see cref="int"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="int"/> to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// int? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(int? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="int"/> to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable <see cref="int"/> to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the <see cref="int"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="int"/> to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// int? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(int? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to its string representation.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// A string representation of the unsigned integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// uint? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(uint? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the unsigned integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 123;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123"
        /// 
        /// uint? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(uint? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable long integer to its string representation.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// A string representation of the long integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? value = 123456789;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123456789"
        /// 
        /// long? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(long? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable long integer to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the long integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable long integer to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? value = 123456789;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123456789"
        /// 
        /// long? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(long? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to its string representation.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// A string representation of the unsigned long integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 123456789;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123456789"
        /// 
        /// ulong? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(ulong? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the unsigned long integer if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned long integer to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 123456789;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123456789"
        /// 
        /// ulong? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(ulong? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to its string representation.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// A string representation of the floating-point number if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123.45"
        /// 
        /// float? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(float? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the floating-point number if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123.45"
        /// 
        /// float? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(float? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to its string representation.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// A string representation of the double-precision floating-point number if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.456;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123.456"
        /// 
        /// double? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(double? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the double-precision floating-point number if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.456;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123.456"
        /// 
        /// double? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(double? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable decimal to its string representation.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// A string representation of the decimal if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "123.45"
        /// 
        /// decimal? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(decimal? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable decimal to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the decimal if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "123.45"
        /// 
        /// decimal? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(decimal? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to its string representation.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// A string representation of the <see cref="DateTime"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to a string. If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// string result = ConverterMoreNullable2.ToString(value);
        /// Console.WriteLine(result); // Output: "1/1/2023 12:00:00 AM" (depending on culture)
        /// 
        /// DateTime? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(DateTime? value)
        {
            return value.HasValue ? Convert.ToString(value.Value) : null;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to its string representation using the specified format provider.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>
        /// A string representation of the <see cref="DateTime"/> if it has a value; otherwise, null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to a string using the specified format provider.
        /// If the input is null, the method returns null.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// string result = ConverterMoreNullable2.ToString(value, CultureInfo.InvariantCulture);
        /// Console.WriteLine(result); // Output: "01/01/2023 00:00:00" (depending on culture)
        /// 
        /// DateTime? nullValue = null;
        /// string resultForNull = ConverterMoreNullable2.ToString(nullValue, CultureInfo.InvariantCulture);
        /// Console.WriteLine(resultForNull); // Output: null
        /// </code>
        /// </example>
        public static string? ToString(DateTime? value, IFormatProvider? provider)
        {
            return value.HasValue ? Convert.ToString(value.Value, provider) : null;
        }

        #endregion ToString

        #region ToUInt16

        /// <summary>
        /// Converts a nullable boolean to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// The boolean value converted to <see cref="ushort"/>: 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? value = true;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(bool? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The character's Unicode code point as a <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? value = 'A';
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 65
        /// 
        /// char? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(char? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// The signed byte value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the signed byte value is negative, as it cannot be represented as an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = 42;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(byte? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the short integer value is negative, as it cannot be represented as an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// short? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(short? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the integer value is negative or exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// int? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(int? value) => value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer to convert.</param>
        /// <returns>
        /// The unsigned short integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ushort? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable signed 64-bit integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 64-bit integer to convert.</param>
        /// <returns>
        /// The signed 64-bit integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 64-bit integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the signed 64-bit integer value is negative or exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// long? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(long? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 64-bit integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 64-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 64-bit integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 64-bit integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned 64-bit integer value exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ulong? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// The single-precision floating-point number converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// float? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(float? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// The double-precision floating-point number converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.45;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// double? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(double? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the decimal value is negative or exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// decimal? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// The <see cref="DateTime"/> value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// ushort result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToUInt16(value);
        ///     Console.WriteLine(result);
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        /// <summary>
        /// Converts a nullable unsigned 32-bit integer to a non-nullable unsigned 16-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 32-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 32-bit integer value converted to <see cref="ushort"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 32-bit integer to an unsigned 16-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned 32-bit integer value exceeds the range of an unsigned 16-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 12345;
        /// ushort result = ConverterMoreNullable2.ToUInt16(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// uint? nullValue = null;
        /// ushort resultForNull = ConverterMoreNullable2.ToUInt16(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ushort ToUInt16(uint? value)
        {
            return value.HasValue ? Convert.ToUInt16(value.Value) : (ushort)0;
        }

        #endregion ToUInt16

        #region ToUInt32

        /// <summary>
        /// Converts a nullable boolean to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// The boolean value converted to <see cref="uint"/>: 1 for true, 0 for false or null.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable boolean to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? value = true;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 1
        /// 
        /// bool? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(bool? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable character to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable character to convert.</param>
        /// <returns>
        /// The character's Unicode code point as a <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable character to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? value = 'A';
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 65
        /// 
        /// char? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(char? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// The signed byte value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the signed byte value is negative, as it cannot be represented as an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = 42;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 42
        /// 
        /// sbyte? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(byte? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the short integer value is negative, as it cannot be represented as an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? value = 12345;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// short? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(short? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer to convert.</param>
        /// <returns>
        /// The unsigned short integer value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short integer to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 12345;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ushort? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the integer value is negative, as it cannot be represented as an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? value = 12345;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// int? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(int? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned 32-bit integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 32-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 32-bit integer value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 32-bit integer to a non-nullable unsigned 32-bit integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 123;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// uint? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(uint? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable signed 64-bit integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 64-bit integer to convert.</param>
        /// <returns>
        /// The signed 64-bit integer value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 64-bit integer to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the signed 64-bit integer value is negative or exceeds the range of an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? value = 12345;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// long? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(long? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned 64-bit integer to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 64-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 64-bit integer value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 64-bit integer to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the unsigned 64-bit integer value exceeds the range of an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 12345;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ulong? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable single-precision floating-point number to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// The single-precision floating-point number converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// float? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(float? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// The double-precision floating-point number converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.45;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// double? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(double? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the decimal value is negative or exceeds the range of an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// uint result = ConverterMoreNullable2.ToUInt32(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// decimal? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a non-nullable unsigned 32-bit integer.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// The <see cref="DateTime"/> value converted to <see cref="uint"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to an unsigned 32-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to an unsigned 32-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// uint result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToUInt32(value);
        ///     Console.WriteLine(result);
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// uint resultForNull = ConverterMoreNullable2.ToUInt32(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static uint ToUInt32(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt32(value.Value) : 0;
        }

        #endregion ToUInt32

        #region ToUInt64

        /// <summary>
        /// Converts a nullable character to a non-nullable unsigned long integer value.
        /// </summary>
        /// <param name="value">The nullable character to convert. If null, the method returns 0.</param>
        /// <returns>
        /// The character's Unicode code point as a <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable characters, returning 0 when the input is null.
        /// When the input has a value, the character is converted to its numeric Unicode code point as an unsigned long integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char? charValue = 'A';
        /// ulong result = charValue.ToUInt64();
        /// Console.WriteLine(result); // Output: 65 (Unicode code point for 'A')
        /// 
        /// char? unicodeValue = '€';
        /// ulong unicodeResult = unicodeValue.ToUInt64();
        /// Console.WriteLine(unicodeResult); // Output: 8364 (Unicode code point for '€')
        /// 
        /// char? nullValue = null;
        /// ulong resultNull = nullValue.ToUInt64();
        /// Console.WriteLine(resultNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(char? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable boolean to a non-nullable unsigned long integer value.
        /// </summary>
        /// <param name="value">The nullable boolean to convert. If null, the method returns 0.</param>
        /// <returns>
        /// The boolean value converted to a <see cref="ulong"/> if it has a value (1 for true, 0 for false); otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely handles nullable boolean values, returning 0 when the input is null.
        /// When the input has a value, true is converted to 1 and false is converted to 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool? trueValue = true;
        /// ulong result1 = trueValue.ToUInt64();
        /// Console.WriteLine(result1); // Output: 1
        /// 
        /// bool? falseValue = false;
        /// ulong result2 = falseValue.ToUInt64();
        /// Console.WriteLine(result2); // Output: 0
        /// 
        /// bool? nullValue = null;
        /// ulong result3 = nullValue.ToUInt64();
        /// Console.WriteLine(result3); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(bool? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable signed byte to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed byte to convert.</param>
        /// <returns>
        /// The signed byte value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed byte to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = -42;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 0 (due to unsigned conversion)
        /// 
        /// sbyte? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(sbyte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable byte to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable byte to convert.</param>
        /// <returns>
        /// The byte value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable byte to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 255;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 255
        /// 
        /// byte? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(byte? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable short integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable short integer to convert.</param>
        /// <returns>
        /// The short integer value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable short integer to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// short? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(short? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned short integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned short integer to convert.</param>
        /// <returns>
        /// The unsigned short integer value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned short integer to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ushort? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(ushort? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// The integer value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable integer to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// int? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(int? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// The unsigned integer value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned integer to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// uint? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(uint? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable signed 64-bit integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable signed 64-bit integer to convert.</param>
        /// <returns>
        /// The signed 64-bit integer value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable signed 64-bit integer to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// long? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(long? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable unsigned 64-bit integer to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable unsigned 64-bit integer to convert.</param>
        /// <returns>
        /// The unsigned 64-bit integer value if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable unsigned 64-bit integer to a non-nullable unsigned 64-bit integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 12345;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 12345
        /// 
        /// ulong? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(ulong? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }


        /// <summary>
        /// Converts a nullable single-precision floating-point number to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable single-precision floating-point number to convert.</param>
        /// <returns>
        /// The single-precision floating-point number converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable single-precision floating-point number to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 64-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// float? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(float? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable double-precision floating-point number to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable double-precision floating-point number to convert.</param>
        /// <returns>
        /// The double-precision floating-point number converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable double-precision floating-point number to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the floating-point number is negative or exceeds the range of an unsigned 64-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.45;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// double? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(double? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable decimal to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable decimal to convert.</param>
        /// <returns>
        /// The decimal value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable decimal to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// Thrown if the decimal value is negative or exceeds the range of an unsigned 64-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// ulong result = ConverterMoreNullable2.ToUInt64(value);
        /// Console.WriteLine(result); // Output: 123
        /// 
        /// decimal? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(decimal? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a non-nullable unsigned 64-bit integer.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// The <see cref="DateTime"/> value converted to <see cref="ulong"/> if it has a value; otherwise, 0.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to an unsigned 64-bit integer. If the input is null, the method returns 0.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown if the <see cref="DateTime"/> cannot be converted to an unsigned 64-bit integer.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// ulong result;
        /// try
        /// {
        ///     result = ConverterMoreNullable2.ToUInt64(value);
        ///     Console.WriteLine(result);
        /// }
        /// catch (InvalidCastException ex)
        /// {
        ///     Console.WriteLine("Conversion failed: " + ex.Message);
        /// }
        /// 
        /// DateTime? nullValue = null;
        /// ulong resultForNull = ConverterMoreNullable2.ToUInt64(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 0
        /// </code>
        /// </example>
        public static ulong ToUInt64(DateTime? value)
        {
            return value.HasValue ? Convert.ToUInt64(value.Value) : 0;
        }

        #endregion ToUInt64

        #region ToDateTimeOffset


        /// <summary>
        /// Converts a nullable <see cref="DateTime"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="DateTime"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="DateTime"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method safely converts a nullable <see cref="DateTime"/> to a <see cref="DateTimeOffset"/>.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime? value = new DateTime(2023, 1, 1);
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output: 1/1/2023 12:00:00 AM +00:00
        /// 
        /// DateTime? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this DateTime? value)
        {
            return value.HasValue ? new DateTimeOffset(value.Value) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="sbyte"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="sbyte"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="sbyte"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="sbyte"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="sbyte"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// sbyte? value = 1;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// sbyte? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this sbyte? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="byte"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="byte"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="byte"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="byte"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="byte"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// byte? value = 1;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// byte? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this byte? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="short"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="short"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="short"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="short"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="short"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// short? value = 1;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// short? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this short? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="ushort"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="ushort"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="ushort"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="ushort"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="ushort"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ushort? value = 1;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// ushort? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this ushort? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }


        /// <summary>
        /// Converts a nullable integer to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable integer to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the integer value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable integer to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the integer value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// int? value = 20230101;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// int? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this int? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable unsigned integer to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable unsigned integer to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the unsigned integer value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable unsigned integer to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the unsigned integer value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// uint? value = 20230101;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// uint? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this uint? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable long integer to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable long integer to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the long integer value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable long integer to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the long integer value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// long? value = 20230101;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// long? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this long? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable unsigned long integer to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable unsigned long integer to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the unsigned long integer value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable unsigned long integer to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the unsigned long integer value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// ulong? value = 20230101;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// ulong? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this ulong? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable boolean to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable boolean to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the boolean value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable boolean to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the boolean value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// bool? value = true;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// bool? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this bool? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }


        /// <summary>
        /// Converts a nullable <see cref="char"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="char"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="char"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="char"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="char"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// char? value = 'A';
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// char? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this char? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="float"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="float"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="float"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="float"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="float"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// float? value = 123.45f;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// float? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this float? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="double"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="double"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="double"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="double"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="double"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// double? value = 123.45;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// double? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this double? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        /// <summary>
        /// Converts a nullable <see cref="decimal"/> to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="value">The nullable <see cref="decimal"/> to convert.</param>
        /// <returns>
        /// A <see cref="DateTimeOffset"/> representing the <see cref="decimal"/> value if it has a value; otherwise, <see cref="DateTimeOffset.MinValue"/>.
        /// </returns>
        /// <remarks>
        /// This method converts a nullable <see cref="decimal"/> to a <see cref="DateTimeOffset"/> using <see cref="Convert.ToDateTime(object)"/>.
        /// </remarks>
        /// <exception cref="FormatException">
        /// Thrown if the <see cref="decimal"/> value cannot be converted to a valid <see cref="DateTime"/>.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// decimal? value = 123.45m;
        /// DateTimeOffset result = ConverterMoreNullable2.ToDateTimeOffset(value);
        /// Console.WriteLine(result); // Output depends on the conversion logic.
        /// 
        /// decimal? nullValue = null;
        /// DateTimeOffset resultForNull = ConverterMoreNullable2.ToDateTimeOffset(nullValue);
        /// Console.WriteLine(resultForNull); // Output: 1/1/0001 12:00:00 AM +00:00
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this decimal? value)
        {
            return value.HasValue ? new DateTimeOffset(Convert.ToDateTime(value.Value)) : DateTimeOffset.MinValue;
        }

        #endregion ToDateTimeOffset

    }

}
