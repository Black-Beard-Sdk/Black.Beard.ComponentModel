using System;

namespace Bb.Exceptions
{

	/// <summary>
	/// Represents errors that occur during translation operations.
	/// </summary>
	[Serializable]
	public class TranslatorException : Exception
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="TranslatorException"/> class.
		/// </summary>
		public TranslatorException() { }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TranslatorException"/> class with a specified error message.
		/// </summary>
		/// <param name="message">The error message that explains the reason for the exception.</param>
		/// <example>
		/// <code lang="C#">
		/// throw new TranslatorException("Translation failed.");
		/// </code>
		/// </example>
		public TranslatorException(string message) : base(message) { }
		
		/// <summary>
		/// Initializes a new instance of the <see cref="TranslatorException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
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
		///     throw new TranslatorException("An error occurred during translation.", ex);
		/// }
		/// </code>
		/// </example>
		public TranslatorException(string message, Exception inner) : base(message, inner) { }
	
	}

}
