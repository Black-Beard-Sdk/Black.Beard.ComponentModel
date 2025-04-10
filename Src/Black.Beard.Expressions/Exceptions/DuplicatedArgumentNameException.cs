using System;

namespace Bb.Exceptions
{


    /// <summary>
    /// Exception thrown when an argument name is duplicated in a function or method signature.
    /// </summary>
    [Serializable]
    public class DuplicatedArgumentNameException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedArgumentNameException"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor creates a new instance of the exception with no message or inner exception.
        /// </remarks>
        public DuplicatedArgumentNameException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedArgumentNameException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error. Must not be null.</param>
        /// <remarks>
        /// This constructor creates a new instance of the exception with a specified error message.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// throw new DuplicatedArgumentNameException("An argument with the same name already exists.");
        /// </code>
        /// </example>
        public DuplicatedArgumentNameException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedArgumentNameException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error. Must not be null.</param>
        /// <param name="inner">The exception that is the cause of the current exception. Can be null.</param>
        /// <remarks>
        /// This constructor creates a new instance of the exception with a specified error message and an inner exception.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// try
        /// {
        ///     // Some code that causes an exception
        /// }
        /// catch (Exception ex)
        /// {
        ///     throw new DuplicatedArgumentNameException("An argument with the same name already exists.", ex);
        /// }
        /// </code>
        /// </example>
        public DuplicatedArgumentNameException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DuplicatedArgumentNameException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown. Must not be null.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination. Must not be null.</param>
        /// <remarks>
        /// This constructor is used during deserialization to reconstruct the exception object transmitted over a stream.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="info"/> is null.</exception>
        /// <example>
        /// This constructor is typically used by the .NET runtime during deserialization and is not called directly in user code.
        /// </example>
        protected DuplicatedArgumentNameException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
