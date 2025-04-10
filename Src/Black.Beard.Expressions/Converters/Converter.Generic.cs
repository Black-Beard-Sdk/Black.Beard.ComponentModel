using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Bb.Converters
{

    /// <summary>
    /// Generic converter class that provides a way to convert between two types T and U.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class Converter<T, U>
    {

        /// <summary>
        /// Gets or sets the function that converts from type T to type U.
        /// </summary>
        /// <remarks>
        /// This property stores the delegate used for converting values from the source type T to the target type U.
        /// When set to null, the <see cref="Set"/> method will return the default value of type U.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int, string&gt;();
        /// converter.SetFunc = value => value.ToString();
        /// </code>
        /// </example>
        public Func<T?, U?> SetFunc { get; set; }

        /// <summary>
        /// The culture info being used for decimal points, date and time format, etc.
        /// </summary>
        public CultureInfo Culture { get; set; } = ConverterContext.DefaultCultureInfo;

        /// <summary>
        /// Gets or sets the delegate that is invoked when a conversion error occurs.
        /// </summary>
        /// <remarks>
        /// This action is called with the error message whenever a conversion error happens, 
        /// allowing for custom error handling and logging strategies.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int, string&gt;();
        /// converter.OnError = message => Console.WriteLine($"Error: {message}");
        /// </code>
        /// </example>
        public Action<string>? OnError { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether an error occurred during the last conversion operation.
        /// </summary>
        /// <remarks>
        /// This flag is set to true when a conversion fails in the <see cref="Set"/> method.
        /// When true, the <see cref="SetErrorMessage"/> property contains the error details.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int, string&gt;();
        /// var result = converter.Set(42);
        /// if (converter.SetError)
        /// {
        ///     Console.WriteLine(converter.SetErrorMessage);
        /// }
        /// </code>
        /// </example>
        [MemberNotNullWhen(true, nameof(SetErrorMessage))]
        public bool SetError { get; set; }

        /// <summary>
        /// Gets or sets the error message from the last failed conversion.
        /// </summary>
        /// <remarks>
        /// This property contains detailed information about what went wrong during conversion.
        /// It is set to null at the beginning of each conversion and populated only if an error occurs.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int, string&gt;();
        /// converter.Set(42);
        /// if (converter.SetError)
        /// {
        ///     Console.WriteLine(converter.SetErrorMessage);
        /// }
        /// </code>
        /// </example>
        public string? SetErrorMessage { get; set; }

        /// <summary>
        /// Converts a value from type T to type U using the configured conversion function.
        /// </summary>
        /// <param name="value">The value to convert. Can be null.</param>
        /// <returns>
        /// The converted value of type U, or the default value of U if the conversion fails or <see cref="SetFunc"/> is null.
        /// </returns>
        /// <remarks>
        /// This method attempts to convert the value using the delegate stored in <see cref="SetFunc"/>.
        /// Before the conversion, it resets error flags. If an exception occurs during conversion, 
        /// it captures the error information and returns the default value of type U.
        /// </remarks>
        /// <exception cref="Exception">
        /// Any exception thrown by the <see cref="SetFunc"/> delegate is caught internally.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int, string&gt;
        /// {
        ///     SetFunc = value => value.ToString()
        /// };
        /// string result = converter.Set(42);
        /// Console.WriteLine(result); // Output: "42"
        /// </code>
        /// </example>
        public U? Set(T? value)
        {
            SetError = false;
            SetErrorMessage = null;
            if (SetFunc == null)
                return default;
            try
            {
                return SetFunc(value);
            }
            catch (Exception e)
            {
                SetError = true;
                SetErrorMessage = $"Conversion from {typeof(T).Name} to {typeof(U).Name} failed: {e.Message}";
            }
            return default;
        }

        /// <summary>
        /// Updates the error state with the specified message.
        /// </summary>
        /// <param name="msg">The error message. Should be descriptive of what went wrong.</param>
        /// <remarks>
        /// This method sets the error flag to true, updates the error message,
        /// and invokes the <see cref="OnError"/> delegate if it's not null.
        /// </remarks>
        protected void UpdateSetError(string msg)
        {
            SetError = true;
            SetErrorMessage = msg;
            OnError?.Invoke(msg);
        }

    }

}
