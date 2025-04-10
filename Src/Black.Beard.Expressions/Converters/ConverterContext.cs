using System.Globalization;
using System.Text;

namespace Bb.Converters
{


    /// <summary>
    /// Represents the context for conversion operations, including culture and encoding settings.
    /// </summary>
    public class ConverterContext
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterContext"/> class with a specific culture.
        /// </summary>
        /// <param name="cultureInfo">The culture information to use for conversion operations. If null, the default culture info will be used.</param>
        /// <remarks>
        /// This constructor creates a new converter context that will use the specified culture and the default encoding.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var context = new ConverterContext(CultureInfo.GetCultureInfo("en-US"));
        /// </code>
        /// </example>
        public ConverterContext(CultureInfo cultureInfo)
            : this(cultureInfo, ConverterContext.DefaultEncoding)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterContext"/> class with default settings.
        /// </summary>
        /// <remarks>
        /// This constructor creates a new converter context using the default culture info and encoding.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var context = new ConverterContext();
        /// </code>
        /// </example>
        public ConverterContext()
            : this(ConverterContext.DefaultCultureInfo, ConverterContext.DefaultEncoding)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterContext"/> class with specific culture and encoding.
        /// </summary>
        /// <param name="cultureInfo">The culture information to use for conversion operations. If null, the default culture info will be used.</param>
        /// <param name="encoding">The text encoding to use for conversion operations. If null, the default encoding will be used.</param>
        /// <remarks>
        /// This constructor creates a new converter context that will use the specified culture and encoding for all conversion operations.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var context = new ConverterContext(CultureInfo.GetCultureInfo("en-US"), Encoding.UTF8);
        /// </code>
        /// </example>
        public ConverterContext(CultureInfo? cultureInfo, Encoding? encoding)
        {
            this.Culture = cultureInfo ?? ConverterContext.DefaultCultureInfo;
            this.Encoding = encoding ?? ConverterContext.DefaultEncoding;
        }

        /// <summary>
        /// Gets the culture used for conversion operations.
        /// </summary>
        /// <remarks>
        /// This property provides access to the culture information that will be used during conversion operations,
        /// especially for parsing and formatting culture-sensitive values like dates and numbers.
        /// </remarks>
        public CultureInfo Culture { get; }

        /// <summary>
        /// Gets the encoding used for conversion operations.
        /// </summary>
        /// <remarks>
        /// This property provides access to the text encoding that will be used during conversion operations
        /// involving string values, particularly when converting between strings and byte arrays.
        /// </remarks>
        public Encoding Encoding { get; }


        /// <summary>
        /// Gets or sets the default culture information used when no specific culture is provided.
        /// </summary>
        /// <remarks>
        /// This static property determines the culture that will be used by default for all converter contexts
        /// that do not specify a different culture. Changing this value affects all future instances where
        /// the culture is not explicitly specified.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConverterContext.DefaultCultureInfo = CultureInfo.GetCultureInfo("fr-FR");
        /// var context = new ConverterContext(); // Will now use French culture
        /// </code>
        /// </example>
        public static CultureInfo DefaultCultureInfo
        {
            get => _defaultCultureInfo;
            set
            {

                if (value != _defaultCultureInfo)
                {
                    lock (_lock)
                    {
                        _defaultCultureInfo = value;
                        _default = null;
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the default encoding used when no specific encoding is provided.
        /// </summary>
        /// <remarks>
        /// This static property determines the text encoding that will be used by default for all converter contexts
        /// that do not specify a different encoding. Changing this value affects all future instances where
        /// the encoding is not explicitly specified.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// ConverterContext.DefaultEncoding = Encoding.ASCII;
        /// var context = new ConverterContext(); // Will now use ASCII encoding
        /// </code>
        /// </example>
        public static Encoding DefaultEncoding
        {
            get => _defaultEncoding;
            set
            {
                if (value != _defaultEncoding)
                {
                    lock (_lock)
                    {
                        _defaultEncoding = value;
                        _default = null;
                    }

                }
            }
        }

        /// <summary>
        /// Gets the default <see cref="ConverterContext"/> instance.
        /// </summary>
        /// <remarks>
        /// This property provides a singleton instance of the <see cref="ConverterContext"/> class with default settings.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var defaultContext = ConverterContext.Default;
        /// </code>
        /// </example>
        public static ConverterContext Default
        {
            get
            {

                if (_default == null)
                    lock (_lock)
                        if (_default == null)
                            _default = new ConverterContext();

                return _default;

            }

        }

        private static CultureInfo _defaultCultureInfo = CultureInfo.InvariantCulture;
        private static Encoding _defaultEncoding = Encoding.UTF8;
        private static ConverterContext? _default;
        private static readonly object _lock = new object();

    }

}
