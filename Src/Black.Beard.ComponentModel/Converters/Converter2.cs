using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Bb.Converters
{


    //public class Converters
    //{
    //    public Converters()
    //    {
    //        TypeConverter converter = TypeDescriptor.GetConverter(typeof(CultureInfo));
    //    }

    //}


    public class Converter<T, U>
    {


        public Func<T?, U?> SetFunc { get; set; }

        /// <summary>
        /// The culture info being used for decimal points, date and time format, etc.
        /// </summary>
        public CultureInfo Culture { get; set; } = ConverterContext.DefaultCultureInfo;

        public Action<string> OnError { get; set; }

        [MemberNotNullWhen(true, nameof(SetErrorMessage))]
        public bool SetError { get; set; }

        public string SetErrorMessage { get; set; }

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



        protected void UpdateSetError(string msg)
        {
            SetError = true;
            SetErrorMessage = msg;
            OnError?.Invoke(msg);
        }

    }

}
