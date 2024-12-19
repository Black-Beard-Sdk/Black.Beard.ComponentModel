
namespace Bb.Converters
{
   
    /// <summary>
    /// Converter from T to string
    ///
    /// Set converts to string
    /// Get converts from string
    /// </summary>
    public class Converter<T> : Converter<T, string>
    {
        /// <summary>
        /// Custom Format to be applied on bidirectional way.
        /// </summary>
        public string Format { get; set; } = null;
    }

}
