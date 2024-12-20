using System.Globalization;
using System.Text;

namespace Bb.Converters
{



    public class ConverterContext
    {


        /// <summary>
        /// initialize a new instance of <see cref="ConverterContext"/>
        /// </summary>
        /// <param name="cultureInfo"></param>
        public ConverterContext(CultureInfo cultureInfo)
            : this(cultureInfo, ConverterContext.DefaultEncoding)
        {

        }

        /// <summary>
        /// initialize a new instance of <see cref="ConverterContext"/>
        /// </summary>
        public ConverterContext()
            : this(ConverterContext.DefaultCultureInfo, ConverterContext.DefaultEncoding)
        {

        }

        /// <summary>
        /// initialize a new instance of <see cref="ConverterContext"/>
        /// </summary>
        /// <param name="cultureInfo"></param>
        /// <param name="encoding"></param>
        public ConverterContext(CultureInfo cultureInfo, Encoding encoding)
        {
            this.Culture = cultureInfo;
            this.Encoding = encoding;
        }

        /// <summary>
        /// Culture used by default if the parameter is not specified
        /// </summary>
        public CultureInfo Culture { get; }

        /// <summary>
        /// Encoding used by default if the parameter is not specified
        /// </summary>
        public Encoding Encoding { get; }


        /// <summary>
        /// Culture used by default if the parameter is not specified
        /// </summary>
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


        //public static void AddToDefault(Type type, dynamic value)
        //{
        //    keyValuePairs.Add(type, value);
        //}

        //public static void AddToDefault<T>(T value)
        //{
        //    keyValuePairs.Add(typeof(T), value);
        //}

        //public static void AddToDefault(dynamic value)
        //{
        //    keyValuePairs.Add(value.GetType(), value);
        //}


        public static ConverterContext? Default
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

        //private static Dictionary<Type, dynamic> keyValuePairs = new Dictionary<Type, dynamic>();
        private static CultureInfo _defaultCultureInfo = CultureInfo.InvariantCulture;
        private static Encoding _defaultEncoding = Encoding.UTF8;
        private static ConverterContext? _default;
        private static object _lock = new object();

    }

}
