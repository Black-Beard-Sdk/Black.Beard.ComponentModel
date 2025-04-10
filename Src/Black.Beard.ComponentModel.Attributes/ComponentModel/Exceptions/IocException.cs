// Ignore Spelling: Ioc

using System;

namespace Bb.ComponentModel.Exceptions
{

    /// <summary>
    /// Represents an exception that occurs in the IoC container.
    /// </summary>
    /// <remarks>
    /// This exception is thrown when there is an error during the resolution or registration of dependencies in the IoC container.
    /// </remarks>
    [Serializable]
    public class IocException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IocException"/> class.
        /// </summary>
        public IocException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IocException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        public IocException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IocException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public IocException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IocException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected IocException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
