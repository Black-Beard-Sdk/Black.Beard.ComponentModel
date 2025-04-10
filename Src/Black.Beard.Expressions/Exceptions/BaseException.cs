// NOSONAR
using System;

namespace Bb.Exceptions
{
    /// <summary>
    /// Represents errors that occur during application execution related to unsupported keywords.
    /// </summary>
    [Serializable]
    public class BaseException : Exception
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        public BaseException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The unsupported keyword that caused the exception.</param>
        /// <remarks>
        /// The error message is formatted to indicate that the specified keyword is not supported.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// throw new Exceptions("SELECT");
        /// </code>
        /// </example>
        public BaseException(string message) : base($"The keyword '{message}' is not supported.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception.</param>
        /// <remarks>
        /// This constructor is used to provide additional context for the exception by including an inner exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// try
        /// {
        ///     // Some operation that throws an exception
        /// }
        /// catch (Exception ex)
        /// {
        ///     throw new Exceptions("An error occurred.", ex);
        /// }
        /// </code>
        /// </example>
        public BaseException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        /// <remarks>
        /// This constructor is used during deserialization to reconstitute the exception object transmitted over a stream.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="info"/> is <c>null</c>.</exception>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when the class name is <c>null</c> or <see cref="Exception.HResult"/> is zero.</exception>
        protected BaseException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
