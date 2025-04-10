using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Bb.Converters
{

    public static partial class ConverterHelper
    {

        #region ToDictionary

        /// <summary>
        /// Converts a string to a dictionary of string keys and string values.
        /// </summary>
        /// <param name="self">The string to parse. Must not be null.</param>
        /// <returns>
        /// A <see cref="Dictionary{String, String}"/> containing key-value pairs parsed from the input string.
        /// </returns>
        /// <remarks>
        /// This method parses a string in the format "key1=value1;key2=value2" into a dictionary.        
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string connectionString = "server=localhost;database=mydb;user=admin;password=secret";
        /// var dictionary = ConverterHelper.ToDictionaryString(connectionString);
        /// foreach (var kvp in dictionary)
        /// {
        ///     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        /// }
        /// </code>
        /// </example>
        public static Dictionary<string, string> ToDictionaryString(string self)
        {
            return self.GetKeyValues();
        }

        /// <summary>
        /// Converts a string to a dictionary of string keys and object values.
        /// </summary>
        /// <param name="self">The string to parse. Must not be null.</param>
        /// <returns>
        /// A <see cref="Dictionary{String, Object}"/> containing key-value pairs parsed from the input string.
        /// </returns>
        /// <remarks>
        /// This method parses a string in the format "key1=value1;key2=value2" into a dictionary.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string connectionString = "server=localhost;database=mydb;user=admin;password=secret";
        /// var dictionary = ConverterHelper.ToDictionaryObject(connectionString);
        /// foreach (var kvp in dictionary)
        /// {
        ///     Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        /// }
        /// </code>
        /// </example>
        public static Dictionary<string, object> ToDictionaryObject(string self)
        {
            var result = new Dictionary<string, object>();
            foreach (var item in self.GetKeyValues())
                result.Add(item.Key, item.Value);
            return result;
        }

        #endregion ToDictionary


        #region ToBoolean

        /// <summary>
        /// Converts a string to a boolean value.
        /// </summary>
        /// <param name="self">The string to convert. Must not be null.</param>
        /// <returns>
        /// <c>true</c> if the string is "true", "1", or "vrai" (case-insensitive); otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method performs a case-insensitive comparison after trimming the input string.
        /// It considers "true", "1", and the French word "vrai" as representing true values.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool result1 = ConverterHelper.ToBoolean("true");  // true
        /// bool result2 = ConverterHelper.ToBoolean("1");     // true
        /// bool result3 = ConverterHelper.ToBoolean("vrai");  // true
        /// bool result4 = ConverterHelper.ToBoolean("false"); // false
        /// </code>
        /// </example>
        public static bool ToBoolean(string self)
        {
            var v1 = self.Trim().ToLower();
            var value = v1.Equals("true") || v1.Equals("1") || v1.Equals("vrai");
            return value;
        }

        /// <summary>
        /// Converts an integer to a boolean value.
        /// </summary>
        /// <param name="self">The integer to convert.</param>
        /// <returns>
        /// <c>true</c> if the integer is not zero; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method checks if the integer value is greater than 0.
        /// Non-positive values are considered false, while positive values are considered true.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool result1 = ConverterHelper.ToBoolean(1);  // true
        /// bool result2 = ConverterHelper.ToBoolean(42); // true
        /// bool result3 = ConverterHelper.ToBoolean(0);  // false
        /// bool result4 = ConverterHelper.ToBoolean(-1); // false
        /// </code>
        /// </example>
        public static bool ToBoolean(int self)
        {
            var value = self != 0;
            return value;
        }

        #endregion ToBoolean


        #region Array

        /// <summary>
        /// Converts a single item to an array containing that item.
        /// </summary>
        /// <typeparam name="T">The type of the item.</typeparam>
        /// <param name="item">The item to convert to an array.</param>
        /// <returns>
        /// A new array of specified type T containing the single item.
        /// </returns>
        /// <remarks>
        /// This internal method is a utility for creating a singleton array from a single item.
        /// </remarks>
        internal static T[] ToArray<T>(T item)
        {
            return new T[] { item };
        }

        /// <summary>
        /// Converts an array of one type to an array of another type.
        /// </summary>
        /// <typeparam name="T">The source array element type.</typeparam>
        /// <typeparam name="U">The target array element type.</typeparam>
        /// <param name="self">The source array to convert. Must not be null.</param>
        /// <param name="ctx">The converter context to use for the conversion. Can be null.</param>
        /// <returns>
        /// A new array of type specified type U with the converted values.
        /// </returns>
        /// <remarks>
        /// This internal method converts each element of the source array to the target type,
        /// using the provided converter context for type conversion.
        /// </remarks>
        /// <exception cref="InvalidCastException">
        /// Thrown when the conversion from type T to type U is not possible.
        /// </exception>
        internal static U[] ConvertArray<T, U>(T[] self, ConverterContext ctx)
        {
            var source = self.ToArray();
            U[] target = new U[source.Length];
            var function = GetFunctionForConvert(typeof(T), typeof(U));

            if (function == null)
                throw new InvalidCastException($"Cannot convert {typeof(T).Name} to {typeof(U).Name}");

            for (int i = 0; i < source.Length; i++)
            {
                T? s = source[i];
                if (!EqualityComparer<T>.Default.Equals(s, default))
                    target[i] = (U)function(s, ctx);
            }
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
        /// <param name="value">Character array representing a GUID string</param>
        /// <returns>A Guid object parsed from the character array</returns>
        /// <remarks>
        /// Converts a character array to a Guid by parsing the string representation.
        /// </remarks>
        /// <exception cref="FormatException">Thrown when the input is not a valid GUID format</exception>
        /// <example>
        /// <code lang="C#">
        /// char[] guidChars = "12345678-1234-1234-1234-123456789012".ToCharArray();
        /// Guid result = guidChars.ToGuid();
        /// </code>
        /// </example>
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
        /// <param name="value">Character array to convert</param>
        /// <returns>The first byte of the character array, or 0 if empty</returns>
        /// <remarks>
        /// Returns the byte value of the first character in the array, or 0 if the array is empty.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char[] chars = new char[] { 'A', 'B', 'C' };
        /// byte result = chars.ToByte(); // Returns 65 (ASCII code for 'A')
        /// </code>
        /// </example>
        public static byte ToByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (byte)value[0];
        }

        /// <summary>
        /// Convert a string to byte
        /// </summary>
        /// <param name="value">Byte array to convert</param>
        /// <returns>The first byte of the array, or 0 if empty</returns>
        /// <remarks>
        /// Returns the first byte in the array, or 0 if the array is empty.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte[] bytes = new byte[] { 10, 20, 30 };
        /// byte result = bytes.ToByte(); // Returns 10
        /// </code>
        /// </example>
        public static byte ToByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return value[0];
        }

        /// <summary>
        /// Convert a string to byte
        /// </summary>
        /// <param name="self">Single (float) value to convert</param>
        /// <returns>The float value converted to a byte</returns>
        /// <remarks>
        /// Converts a float to a byte by first casting to int then to byte.
        /// This will truncate the decimal portion and may result in overflow.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float floatValue = 65.75f;
        /// byte result = floatValue.ToByte(); // Returns 65
        /// </code>
        /// </example>
        public static byte ToByte(this Single self)
        {
            return (byte)((int)self);
        }

        #endregion ToByte


        #region ToSByte

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value">Character array to convert</param>
        /// <returns>The first character converted to sbyte, or 0 if empty</returns>
        /// <remarks>
        /// Returns the sbyte value of the first character in the array, or 0 if the array is empty.
        /// This may cause overflow if the character value is greater than 127.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char[] chars = new char[] { 'A', 'B', 'C' };
        /// sbyte result = chars.ToSByte(); // Returns 65 (ASCII code for 'A') as sbyte
        /// </code>
        /// </example>
        public static sbyte ToSByte(this char[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value">Byte array to convert</param>
        /// <returns>The first byte converted to sbyte, or 0 if empty</returns>
        /// <remarks>
        /// Returns the first byte in the array cast to sbyte, or 0 if the array is empty.
        /// This may cause overflow if the byte value is greater than 127.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte[] bytes = new byte[] { 100, 200, 30 };
        /// sbyte result = bytes.ToSByte(); // Returns 100 as sbyte
        /// </code>
        /// </example>
        public static sbyte ToSByte(this Byte[] value)
        {
            if (value.Length == 0)
                return 0;
            return (sbyte)value[0];
        }

        /// <summary>
        /// Convert a string to sbyte
        /// </summary>
        /// <param name="value">Sbyte array to convert</param>
        /// <returns>The first sbyte in the array, or 0 if empty</returns>
        /// <remarks>
        /// Returns the first sbyte in the array, or 0 if the array is empty.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte[] values = new sbyte[] { 10, 20, 30 };
        /// sbyte result = values.ToSByte(); // Returns 10
        /// </code>
        /// </example>
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
        /// <param name="value">String to convert</param>
        /// <returns>Byte array representation of the string</returns>
        /// <remarks>
        /// Converts a string to a byte array using the default encoding from ConverterContext.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// string text = "Hello";
        /// byte[] bytes = text.ToByteArray();
        /// </code>
        /// </example>
        public static Byte[]? ToByteArray(this string value)
        {
            if (value == null)
                return null;
            return ConverterContext.DefaultEncoding.GetBytes(value, 0, value.Length);
        }

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value">Character array to convert</param>
        /// <returns>Byte array representation of the character array</returns>
        /// <remarks>
        /// Converts a character array to a byte array by casting each character to a byte.
        /// This may cause data loss for characters with values greater than 255.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char[] chars = new char[] { 'A', 'B', 'C' };
        /// byte[] bytes = chars.ToByteArray();
        /// </code>
        /// </example>
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
        /// <param name="value">Character to convert</param>
        /// <returns>Single-element byte array containing the character value</returns>
        /// <remarks>
        /// Creates a new byte array with one element containing the byte value of the character.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char c = 'A';
        /// byte[] bytes = c.ToByteArray(); // Returns [65]
        /// </code>
        /// </example>
        public static byte[] ToByteArray(this char value)
        {
            return new byte[] { (byte)value };
        }

        /// <summary>
        /// Convert a string to byte array
        /// </summary>
        /// <param name="value">Integer to convert</param>
        /// <returns>Single-element byte array containing the integer value</returns>
        /// <remarks>
        /// Creates a new byte array with one element containing the byte value of the integer.
        /// This may cause data loss for integer values greater than 255.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int i = 42;
        /// byte[] bytes = i.ToByteArray(); // Returns [42]
        /// </code>
        /// </example>
        public static byte[] ToByteArray(this Int32 value)
        {
            return new byte[] { (byte)value };
        }


        #endregion ToByteArray


        #region ToCharArray

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value">Integer to convert</param>
        /// <returns>Single-element character array containing the integer value</returns>
        /// <remarks>
        /// Creates a new character array with one element containing the char value of the integer.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int i = 65;
        /// char[] chars = i.ToCharArray(); // Returns ['A']
        /// </code>
        /// </example>
        public static char[] ToCharArray(this Int32 value)
        {
            return new char[] { (char)value };
        }

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value">GUID to convert</param>
        /// <returns>Character array representation of the GUID</returns>
        /// <remarks>
        /// Converts a GUID to its string representation and then to a character array.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// Guid guid = Guid.NewGuid();
        /// char[] chars = guid.ToCharArray();
        /// </code>
        /// </example>
        public static char[] ToCharArray(this Guid value)
        {
            return value.ToString().ToCharArray();
        }

        /// <summary>
        /// Convert a string to char array
        /// </summary>
        /// <param name="value">Byte array to convert</param>
        /// <returns>Character array representation of the byte array</returns>
        /// <remarks>
        /// Converts a byte array to a character array by casting each byte to a char.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte[] bytes = new byte[] { 65, 66, 67 };
        /// char[] chars = bytes.ToCharArray(); // Returns ['A', 'B', 'C']
        /// </code>
        /// </example>
        public static char[] ToCharArray(this Byte[] value)
        {
            string.Concat(value).ToByteArray();
            var r = new char[value.Length];
            for (int i = 0; i < value.Length; i++)
                r[i] = (char)value[i];
            return r;
        }

        #endregion ToCharArray



        #region ToChar

        /// <summary>
        /// Converts a Single (float) value to a character.
        /// </summary>
        /// <param name="self">The Single value to convert.</param>
        /// <returns>A character representation of the numeric value.</returns>
        /// <remarks>
        /// The conversion first casts the float to an integer, then to a character.
        /// This will truncate any decimal portion of the float value.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float value = 65.75f;
        /// char result = value.ToChar(); // Returns 'A' (ASCII 65)
        /// </code>
        /// </example>
        public static char ToChar(this Single self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Converts a double value to a character.
        /// </summary>
        /// <param name="self">The double value to convert.</param>
        /// <returns>A character representation of the numeric value.</returns>
        /// <remarks>
        /// The conversion first casts the double to an integer, then to a character.
        /// This will truncate any decimal portion of the double value.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double value = 66.75;
        /// char result = value.ToChar(); // Returns 'B' (ASCII 66)
        /// </code>
        /// </example>
        public static char ToChar(this double self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Converts a Boolean value to a character.
        /// </summary>
        /// <param name="self">The Boolean value to convert.</param>
        /// <returns>Character '1' if true, '0' if false.</returns>
        /// <remarks>
        /// Maps Boolean true to '1' and false to '0', providing a simple character representation.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// char result = value.ToChar(); // Returns '1'
        /// 
        /// value = false;
        /// result = value.ToChar(); // Returns '0'
        /// </code>
        /// </example>
        public static char ToChar(this Boolean self)
        {
            return self ? '1' : '0';
        }

        /// <summary>
        /// Converts a decimal value to a character.
        /// </summary>
        /// <param name="self">The decimal value to convert.</param>
        /// <returns>A character representation of the numeric value.</returns>
        /// <remarks>
        /// The conversion first casts the decimal to an integer, then to a character.
        /// This will truncate any decimal portion of the value.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 67.75m;
        /// char result = value.ToChar(); // Returns 'C' (ASCII 67)
        /// </code>
        /// </example>
        public static char ToChar(this decimal self)
        {
            return (char)((int)self);
        }

        /// <summary>
        /// Converts an integer value to a character.
        /// </summary>
        /// <param name="self">The integer value to convert.</param>
        /// <returns>A character with the corresponding ASCII/Unicode value.</returns>
        /// <remarks>
        /// Directly casts the integer to its character representation according to the ASCII/Unicode table.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int value = 68;
        /// char result = value.ToChar(); // Returns 'D' (ASCII 68)
        /// </code>
        /// </example>
        public static char ToChar(this Int32 self)
        {
            return (char)self;
        }

        /// <summary>
        /// Converts a byte array to a character.
        /// </summary>
        /// <param name="value">The byte array to convert.</param>
        /// <returns>The first byte converted to a character, or null character if array is empty.</returns>
        /// <remarks>
        /// Returns the character representation of the first byte in the array.
        /// If the array is empty, returns the null character '\0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte[] bytes = new byte[] { 69, 70, 71 };
        /// char result = bytes.ToChar(); // Returns 'E' (ASCII 69)
        /// 
        /// byte[] emptyBytes = new byte[0];
        /// char nullChar = emptyBytes.ToChar(); // Returns '\0'
        /// </code>
        /// </example>
        public static char ToChar(this Byte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        /// <summary>
        /// Converts an sbyte array to a character.
        /// </summary>
        /// <param name="value">The sbyte array to convert.</param>
        /// <returns>The first sbyte converted to a character, or null character if array is empty.</returns>
        /// <remarks>
        /// Returns the character representation of the first sbyte in the array.
        /// If the array is empty, returns the null character '\0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte[] bytes = new sbyte[] { 70, 71, 72 };
        /// char result = bytes.ToChar(); // Returns 'F' (ASCII 70)
        /// 
        /// sbyte[] emptyBytes = new sbyte[0];
        /// char nullChar = emptyBytes.ToChar(); // Returns '\0'
        /// </code>
        /// </example>
        public static char ToChar(this sbyte[] value)
        {
            if (value.Length == 0)
                return '\0';
            return (char)value[0];
        }

        /// <summary>
        /// Returns the first character from a character array.
        /// </summary>
        /// <param name="value">The character array to convert.</param>
        /// <returns>The first character in the array, or null character if array is empty.</returns>
        /// <remarks>
        /// Returns the first character in the array.
        /// If the array is empty, returns the null character '\0'.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char[] chars = new char[] { 'G', 'H', 'I' };
        /// char result = chars.ToChar(); // Returns 'G'
        /// 
        /// char[] emptyChars = new char[0];
        /// char nullChar = emptyChars.ToChar(); // Returns '\0'
        /// </code>
        /// </example>
        public static char ToChar(this char[] value)
        {
            if (value.Length == 0)
                return '\0';
            return value[0];
        }

        #endregion ToChar


        #region ToDateTimeOffset

        /// <summary>
        /// Converts a TimeSpan to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The TimeSpan value to convert.</param>
        /// <returns>A DateTimeOffset representing the time components of the TimeSpan.</returns>
        /// <remarks>
        /// Creates a new DateTimeOffset with zero date components (year, month, day) and
        /// time components (hours, minutes, seconds, milliseconds) from the TimeSpan.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// TimeSpan timeSpan = new TimeSpan(5, 30, 15);
        /// DateTimeOffset result = timeSpan.ToDateTimeOffser();
        /// // Result represents 0000-00-00 05:30:15
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this TimeSpan value)
        {
            var a = new DateTime(0, 0, 0, value.Hours, value.Minutes, value.Seconds, value.Milliseconds, DateTimeKind.Utc);
            return new DateTimeOffset(a);
        }

        /// <summary>
        /// Converts a string to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The string to parse as a DateTimeOffset.</param>
        /// <param name="cultureInfo">The culture-specific formatting information. If null, uses ConverterContext.DefaultCultureInfo or CultureInfo.InvariantCulture.</param>
        /// <returns>A DateTimeOffset parsed from the string.</returns>
        /// <remarks>
        /// Parses the string using DateTimeOffset.Parse with the specified or default culture information.
        /// </remarks>
        /// <exception cref="FormatException">Thrown when the string is not in a valid DateTimeOffset format.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
        /// <example>
        /// <code lang="C#">
        /// string dateString = "2023-04-15 10:30:00 +02:00";
        /// DateTimeOffset result = dateString.ToDateTimeOffset();
        /// 
        /// // With specific culture
        /// CultureInfo culture = new CultureInfo("fr-FR");
        /// DateTimeOffset frenchResult = "15/04/2023 10:30:00 +02:00".ToDateTimeOffset(culture);
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this string value, CultureInfo? cultureInfo = null)
        {
            var result = DateTimeOffset.Parse(value, cultureInfo ?? ConverterContext.DefaultCultureInfo ?? CultureInfo.InvariantCulture);
            return result;
        }

        /// <summary>
        /// Converts a DateTime to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The DateTime value to convert.</param>
        /// <returns>A DateTimeOffset initialized with the specified DateTime.</returns>
        /// <remarks>
        /// Creates a new DateTimeOffset using the DateTime value with the system's local time offset.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime dateTime = new DateTime(2023, 4, 15, 10, 30, 0);
        /// DateTimeOffset result = dateTime.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this DateTime value)
        {
            return new DateTimeOffset(value);
        }

        /// <summary>
        /// Converts an sbyte to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The sbyte value to convert.</param>
        /// <returns>A DateTimeOffset converted from the sbyte value.</returns>
        /// <remarks>
        /// First converts the sbyte to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// sbyte value = 10;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this sbyte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a byte to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The byte value to convert.</param>
        /// <returns>A DateTimeOffset converted from the byte value.</returns>
        /// <remarks>
        /// First converts the byte to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// byte value = 20;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this byte value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a short to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The short value to convert.</param>
        /// <returns>A DateTimeOffset converted from the short value.</returns>
        /// <remarks>
        /// First converts the short to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// short value = 2023;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this short value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an ushort to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The ushort value to convert.</param>
        /// <returns>A DateTimeOffset converted from the ushort value.</returns>
        /// <remarks>
        /// First converts the ushort to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ushort value = 2023;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this ushort value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts an int to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The int value to convert.</param>
        /// <returns>A DateTimeOffset converted from the int value.</returns>
        /// <remarks>
        /// First converts the int to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// int value = 20230415;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this int value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a uint to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The uint value to convert.</param>
        /// <returns>A DateTimeOffset converted from the uint value.</returns>
        /// <remarks>
        /// First converts the uint to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// uint value = 20230415;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this uint value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a long to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The long value to convert.</param>
        /// <returns>A DateTimeOffset converted from the long value.</returns>
        /// <remarks>
        /// First converts the long to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// long value = 20230415103000;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this long value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a ulong to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The ulong value to convert.</param>
        /// <returns>A DateTimeOffset converted from the ulong value.</returns>
        /// <remarks>
        /// First converts the ulong to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ulong value = 20230415103000;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this ulong value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a bool to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The bool value to convert.</param>
        /// <returns>A DateTimeOffset converted from the bool value.</returns>
        /// <remarks>
        /// First converts the bool to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// bool value = true;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this bool value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a char to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The char value to convert.</param>
        /// <returns>A DateTimeOffset converted from the char value.</returns>
        /// <remarks>
        /// First converts the char to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char value = 'A';
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this char value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a float to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>A DateTimeOffset converted from the float value.</returns>
        /// <remarks>
        /// First converts the float to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float value = 20230415.5f;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this float value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a double to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>A DateTimeOffset converted from the double value.</returns>
        /// <remarks>
        /// First converts the double to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// double value = 20230415.5;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this double value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts a decimal to a DateTimeOffset.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <returns>A DateTimeOffset converted from the decimal value.</returns>
        /// <remarks>
        /// First converts the decimal to a DateTime using Convert.ToDateTime, then creates a DateTimeOffset from that DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// decimal value = 20230415.5m;
        /// DateTimeOffset result = value.ToDateTimeOffset();
        /// </code>
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this decimal value)
        {
            return new DateTimeOffset(Convert.ToDateTime(value));
        }

        #endregion ToDateTimeOffset


        #region ToDateTime

        /// <summary>
        /// Converts a DateTimeOffset to a DateTime in UTC.
        /// </summary>
        /// <param name="value">The DateTimeOffset to convert.</param>
        /// <returns>A DateTime representation in UTC time.</returns>
        /// <remarks>
        /// First converts the DateTimeOffset to UTC time, then returns the UTC DateTime component.
        /// This preserves the point in time while removing the time zone information.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTimeOffset offset = new DateTimeOffset(2023, 4, 15, 10, 30, 0, TimeSpan.FromHours(2));
        /// DateTime utcDateTime = offset.ToDateTime(); // Returns 2023-04-15 08:30:00 UTC
        /// </code>
        /// </example>
        public static DateTime ToDateTime(this DateTimeOffset value)
        {
            var value2 = value.ToUniversalTime();
            return value2.UtcDateTime;
        }

        #endregion ToDateTime


        #region ToTimeSpan

        /// <summary>
        /// Extracts the time component of a DateTime as a TimeSpan.
        /// </summary>
        /// <param name="value">The DateTime to extract time from.</param>
        /// <returns>A TimeSpan representing the time portion of the DateTime.</returns>
        /// <remarks>
        /// Returns the TimeOfDay property which represents the time elapsed since midnight in the DateTime.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTime dateTime = new DateTime(2023, 4, 15, 10, 30, 45);
        /// TimeSpan timeSpan = dateTime.ToTimeSpan(); // Returns 10:30:45 as TimeSpan
        /// </code>
        /// </example>
        public static TimeSpan ToTimeSpan(this DateTime value)
        {
            return value.TimeOfDay;
        }

        /// <summary>
        /// Extracts the time component of a DateTimeOffset as a TimeSpan.
        /// </summary>
        /// <param name="value">The DateTimeOffset to extract time from.</param>
        /// <returns>A TimeSpan representing the time portion of the DateTimeOffset.</returns>
        /// <remarks>
        /// Returns the TimeOfDay property which represents the time elapsed since midnight in the DateTimeOffset.
        /// This does not include the offset information.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// DateTimeOffset dateTimeOffset = new DateTimeOffset(2023, 4, 15, 10, 30, 45, TimeSpan.FromHours(2));
        /// TimeSpan timeSpan = dateTimeOffset.ToTimeSpan(); // Returns 10:30:45 as TimeSpan
        /// </code>
        /// </example>
        public static TimeSpan ToTimeSpan(this DateTimeOffset value)
        {
            return value.TimeOfDay;
        }

        #endregion


        #region ToString

        /// <summary>
        /// Converts a dictionary of string keys and string values to a string representation.
        /// </summary>
        /// <param name="value">The dictionary to convert. Can be null.</param>
        /// <returns>
        /// A string in the format "key1=value1;key2=value2", or null if the input dictionary is null.
        /// </returns>
        /// <remarks>
        /// This method creates a string representation of a dictionary, with key-value pairs
        /// separated by semicolons. Special characters in values (\, ;, =) are escaped with a backslash.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var dictionary = new Dictionary&lt;string, string&gt;
        /// {
        ///     { "server", "localhost" },
        ///     { "database", "mydb" },
        ///     { "user", "admin" }
        /// };
        /// string result = ConverterHelper.ToString(dictionary);
        /// // Result: "server=localhost;database=mydb;user=admin"
        /// </code>
        /// </example>
        public static string? ToString(this Dictionary<string, string> value)
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

        /// <summary>
        /// Converts a dictionary of string keys and object values to a string representation.
        /// </summary>
        /// <param name="value">The dictionary to convert. Can be null.</param>
        /// <returns>
        /// A string in the format "key1=value1;key2=value2", or null if the input dictionary is null.
        /// </returns>
        /// <remarks>
        /// This method creates a string representation of a dictionary, with key-value pairs
        /// separated by semicolons. Object values are first converted to strings.
        /// Special characters in values (\, ;, =) are escaped with a backslash.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var dictionary = new Dictionary&lt;string, object&gt;
        /// {
        ///     { "id", 123 },
        ///     { "name", "Test Product" },
        ///     { "price", 49.99m }
        /// };
        /// string result = ConverterHelper.ToString(dictionary);
        /// // Result: "id=123;name=Test Product;price=49.99"
        /// </code>
        /// </example>
        public static string? ToString(this Dictionary<string, object> value)
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

                string? valueItem;
                if (item.Value is string str)
                    valueItem = str;
                else
                    valueItem = (string?)item.Value.ConvertTo(typeof(string));

                if (!string.IsNullOrEmpty(valueItem))
                {

                    if (valueItem.Contains("\\"))
                        valueItem = valueItem.Replace("\\", "\\\\");

                    if (valueItem.Contains(";"))
                        valueItem = valueItem.Replace(";", "\\;");

                    if (valueItem.Contains("="))
                        valueItem = valueItem.Replace("=", "\\=");

                    sb.Append(valueItem);
                
                }
            }

            var result = sb.ToString();
            return result;
        }

        /// <summary>
        /// Converts a Guid to its string representation.
        /// </summary>
        /// <param name="value">The Guid value to convert. Cannot be null.</param>
        /// <returns>
        /// A string representation of the Guid in the format "00000000-0000-0000-0000-000000000000".
        /// </returns>
        /// <remarks>
        /// This method uses the default Guid.ToString() implementation which returns a 32-digit 
        /// hexadecimal number in the standard format.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// Guid id = Guid.NewGuid();
        /// string guidString = id.ToString();
        /// // Result might be: "12345678-9abc-def0-1234-56789abcdef0"
        /// </code>
        /// </example>
        public static string ToString(this Guid value)
        {
            var result = value.ToString();
            return result;
        }

        /// <summary>
        /// Converts a character array to a string.
        /// </summary>
        /// <param name="self">The character array to convert. Can be null or empty.</param>
        /// <returns>
        /// A string created by concatenating all characters in the array, or an empty string if the array is empty.
        /// </returns>
        /// <remarks>
        /// This method uses string.Concat to efficiently join all characters from the array into a single string.
        /// If the input array is null, a NullReferenceException will be thrown by the underlying method.
        /// </remarks>
        /// <exception cref="NullReferenceException">Thrown when the input array is null.</exception>
        /// <example>
        /// <code lang="C#">
        /// char[] chars = new char[] { 'H', 'e', 'l', 'l', 'o' };
        /// string result = chars.ToString();
        /// // Result: "Hello"
        /// </code>
        /// </example>
        public static string ToString(this char[] self)
        {
            return string.Concat(self);
        }

        /// <summary>
        /// Converts a byte array to a string using the default encoding or UTF8.
        /// </summary>
        /// <param name="self">The byte array to convert. Cannot be null.</param>
        /// <returns>
        /// A string decoded from the byte array using the specified encoding.
        /// </returns>
        /// <remarks>
        /// This method converts the byte array to a string using either the encoding specified in 
        /// ConverterContext.DefaultEncoding, or UTF8 if no default encoding is specified.
        /// </remarks>
        /// <exception cref="NullReferenceException">Thrown when the input array is null.</exception>
        /// <exception cref="DecoderFallbackException">Thrown when the byte array contains invalid encoding sequences.</exception>
        /// <example>
        /// <code lang="C#">
        /// byte[] bytes = new byte[] { 72, 101, 108, 108, 111 };
        /// string result = bytes.ToString();
        /// // Result: "Hello"
        /// </code>
        /// </example>
        public static string ToString(this Byte[] self)
        {
            var e = ConverterContext.DefaultEncoding ?? Encoding.UTF8;
            return e.GetString(self, 0, self.Length);
        }

        #endregion ToString


        #region ToInt16

        /// <summary>
        /// Converts a float value to Int16 (short).
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>
        /// The float value cast to Int16, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from float to Int16, which truncates any decimal portion.
        /// Values outside the range of Int16 (-32,768 to 32,767) will cause overflow.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the float value is outside the range of Int16.</exception>
        /// <example>
        /// <code lang="C#">
        /// float floatValue = 123.75f;
        /// short result = floatValue.ToInt16();
        /// // Result: 123
        /// </code>
        /// </example>
        public static Int16 ToInt16(this float value)
        {
            return (Int16)value;
        }

        /// <summary>
        /// Converts a double value to Int16 (short).
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>
        /// The double value cast to Int16, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from double to Int16, which truncates any decimal portion.
        /// Values outside the range of Int16 (-32,768 to 32,767) will cause overflow.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the double value is outside the range of Int16.</exception>
        /// <example>
        /// <code lang="C#">
        /// double doubleValue = 456.75;
        /// short result = doubleValue.ToInt16();
        /// // Result: 456
        /// </code>
        /// </example>
        public static Int16 ToInt16(this double value)
        {
            return (Int16)value;
        }

        /// <summary>
        /// Converts a character to Int16 (short) using its Unicode value.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// The Unicode value of the character cast to Int16.
        /// </returns>
        /// <remarks>
        /// This method converts the character to its integer Unicode value, then casts to Int16.
        /// Since Unicode characters have values from 0 to 65,535, and Int16 has a maximum value of 32,767,
        /// this may cause overflow for characters with high Unicode values.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the character's Unicode value exceeds 32,767.</exception>
        /// <example>
        /// <code lang="C#">
        /// char charValue = 'A';
        /// short result = charValue.ToInt16();
        /// // Result: 65 (Unicode value of 'A')
        /// </code>
        /// </example>
        public static Int16 ToInt16(this char value)
        {
            return (Int16)(int)value;
        }

        #endregion ToInt16


        #region ToInt32

        /// <summary>
        /// Converts a float value to Int32 (int).
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>
        /// The float value cast to Int32, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from float to Int32, which truncates any decimal portion.
        /// Values outside the range of Int32 (-2,147,483,648 to 2,147,483,647) will cause overflow.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the float value is outside the range of Int32.</exception>
        /// <example>
        /// <code lang="C#">
        /// float floatValue = 123.75f;
        /// int result = floatValue.ToInt32();
        /// // Result: 123
        /// </code>
        /// </example>
        public static Int32 ToInt32(this float value)
        {
            return (Int32)value;
        }

        /// <summary>
        /// Converts a double value to Int32 (int).
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>
        /// The double value cast to Int32, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from double to Int32, which truncates any decimal portion.
        /// Values outside the range of Int32 (-2,147,483,648 to 2,147,483,647) will cause overflow.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the double value is outside the range of Int32.</exception>
        /// <example>
        /// <code lang="C#">
        /// double doubleValue = 456.75;
        /// int result = doubleValue.ToInt32();
        /// // Result: 456
        /// </code>
        /// </example>
        public static Int32 ToInt32(this double value)
        {
            return (Int32)value;
        }

        /// <summary>
        /// Converts a character to Int32 (int) using its Unicode value.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// The Unicode value of the character as Int32.
        /// </returns>
        /// <remarks>
        /// This method converts the character to its integer Unicode value.
        /// Since a char in C# represents a Unicode character, this effectively returns
        /// the numerical Unicode code point of the character.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char charValue = 'A';
        /// int result = charValue.ToInt32();
        /// // Result: 65 (Unicode value of 'A')
        /// </code>
        /// </example>
        public static Int32 ToInt32(this char value)
        {
            return (int)value;
        }

        #endregion ToInt32


        #region ToInt64

        /// <summary>
        /// Converts a float value to Int64 (long).
        /// </summary>
        /// <param name="value">The float value to convert.</param>
        /// <returns>
        /// The float value cast to Int64, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from float to Int64, which truncates any decimal portion.
        /// The range of Int64 (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807) is large enough
        /// to contain all possible float values without overflow.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// float floatValue = 123.75f;
        /// long result = floatValue.ToInt64();
        /// // Result: 123
        /// </code>
        /// </example>
        public static Int64 ToInt64(this float value)
        {
            return (Int64)value;
        }

        /// <summary>
        /// Converts a double value to Int64 (long).
        /// </summary>
        /// <param name="value">The double value to convert.</param>
        /// <returns>
        /// The double value cast to Int64, with any fractional portion truncated.
        /// </returns>
        /// <remarks>
        /// This method performs a direct cast from double to Int64, which truncates any decimal portion.
        /// Values outside the range of Int64 (-9,223,372,036,854,775,808 to 9,223,372,036,854,775,807) 
        /// will cause overflow, though this is unlikely for most practical double values.
        /// </remarks>
        /// <exception cref="OverflowException">Thrown when the double value is outside the range of Int64.</exception>
        /// <example>
        /// <code lang="C#">
        /// double doubleValue = 456.75;
        /// long result = doubleValue.ToInt64();
        /// // Result: 456
        /// </code>
        /// </example>
        public static Int64 ToInt64(this double value)
        {
            return (Int64)value;
        }

        /// <summary>
        /// Converts a character to Int64 (long) using its Unicode value.
        /// </summary>
        /// <param name="value">The character to convert.</param>
        /// <returns>
        /// The Unicode value of the character as Int64.
        /// </returns>
        /// <remarks>
        /// This method converts the character to its integer Unicode value, then casts to Int64.
        /// Since Unicode characters have values that are well within the Int64 range, no overflow is possible.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char charValue = 'A';
        /// long result = charValue.ToInt64();
        /// // Result: 65 (Unicode value of 'A')
        /// </code>
        /// </example>
        public static Int64 ToInt64(this char value)
        {
            return (Int64)(int)value;
        }

        #endregion ToInt64


        #region ToSingle

        /// <summary>
        /// Converts a character to its Single (float) numeric value.
        /// </summary>
        /// <param name="value">The character to convert to a Single value. This represents the character's Unicode value.</param>
        /// <returns>A Single (float) value representing the numeric Unicode value of the character.</returns>
        /// <remarks>
        /// This method performs a two-step conversion. First, the character is converted to its integer Unicode value,
        /// then that integer is converted to a Single (float) value. The resulting value will be the same as the 
        /// character's Unicode code point.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char character = 'A';
        /// float numericValue = character.ToSingle();
        /// // numericValue will be 65.0f (the Unicode value of 'A')
        /// 
        /// char symbol = '€';
        /// float euroValue = symbol.ToSingle();
        /// // euroValue will be 8364.0f (the Unicode value of '€')
        /// </code>
        /// </example>
        public static Single ToSingle(this char value)
        {
            return (Single)(int)value;
        }

        #endregion ToSingle


        #region ToDouble

        /// <summary>
        /// Converts a character to its Double numeric value.
        /// </summary>
        /// <param name="value">The character to convert to a Double value. This represents the character's Unicode value.</param>
        /// <returns>A Double value representing the numeric Unicode value of the character.</returns>
        /// <remarks>
        /// This method performs a two-step conversion. First, the character is converted to its integer Unicode value,
        /// then that integer is converted to a Double value. The resulting value will be the same as the 
        /// character's Unicode code point.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char character = 'B';
        /// double numericValue = character.ToDouble();
        /// // numericValue will be 66.0 (the Unicode value of 'B')
        /// 
        /// char symbol = '¥';
        /// double yenValue = symbol.ToDouble();
        /// // yenValue will be 165.0 (the Unicode value of '¥')
        /// </code>
        /// </example>
        public static Double ToDouble(this char value)
        {
            return (Double)(int)value;
        }

        #endregion ToDouble


        #region ToDecimal

        /// <summary>
        /// Converts a character to its Decimal numeric value.
        /// </summary>
        /// <param name="value">The character to convert to a Decimal value. This represents the character's Unicode value.</param>
        /// <returns>A Decimal value representing the numeric Unicode value of the character.</returns>
        /// <remarks>
        /// This method performs a two-step conversion. First, the character is converted to its integer Unicode value,
        /// then that integer is converted to a Decimal value. The resulting value will be the same as the 
        /// character's Unicode code point as a decimal number with no fractional part.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// char character = 'C';
        /// decimal numericValue = character.ToDecimal();
        /// // numericValue will be 67.0m (the Unicode value of 'C')
        /// 
        /// char symbol = '©';
        /// decimal copyrightValue = symbol.ToDecimal();
        /// // copyrightValue will be 169.0m (the Unicode value of '©')
        /// </code>
        /// </example>
        public static decimal ToDecimal(this char value)
        {
            return (decimal)(int)value;
        }

        #endregion ToDecimal


    }


}
