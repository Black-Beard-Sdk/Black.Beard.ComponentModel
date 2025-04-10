namespace Bb.Converters
{
   
    /// <summary>
    /// Converter from T to string
    /// Set converts to string
    /// Get converts from string
    /// </summary>
    public class Converter<T> : Converter<T, string>
    {
        /// <summary>
        /// Custom Format to be applied on bidirectional way.
        /// </summary>
        public string? Format { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter{T}"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor creates a converter that can transform between type T and string in both directions.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var converter = new Converter&lt;int&gt;();
        /// string result = converter.Set(42);
        /// int value = converter.Get("42");
        /// </code>
        /// </example>
        public Converter() : base()
        {
        }
    }

}
