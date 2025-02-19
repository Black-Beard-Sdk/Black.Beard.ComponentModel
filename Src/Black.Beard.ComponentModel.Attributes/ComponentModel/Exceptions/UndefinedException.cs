using System;

namespace Bb.ComponentModel.Exceptions
{

    /// <summary>
    /// Represents an exception that is thrown when a variable cannot be resolved.
    /// </summary>
    /// <remarks>
    /// This exception is thrown when a variable cannot be resolved in the current context.
    /// </remarks>
    [Serializable]
    public class UndefinedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedException"/> class.
        /// </summary>
        public UndefinedException() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedException"/> class with the specified variable name.
        /// </summary>
        /// <param name="variableName">The name of the variable that cannot be resolved.</param>
        public UndefinedException(string variableName) : base($"var '{variableName}' can't be resolved") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public UndefinedException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UndefinedException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The <see cref="System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        protected UndefinedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
