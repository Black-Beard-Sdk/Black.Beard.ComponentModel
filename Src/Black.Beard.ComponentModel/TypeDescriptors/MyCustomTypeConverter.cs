//using Bb.Expressions;
//using System;
//using System.ComponentModel;
//using System.Globalization;

//namespace Bb.TypeDescriptors
//{

//    public class MyCustomTypeConverter<T> : TypeConverter
//    {



//        public MyCustomTypeConverter()
//        {
//            this._tartetType = typeof(T);
//        }



//        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
//        {
//            var function = sourceType.GetFunctionForConvert(_tartetType);
//            if (function != null)
//                return true;
//            return base.CanConvertFrom(context, sourceType);
//        }

//        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
//        {
//            var function = destinationType.GetFunctionForConvert(destinationType);
//            return base.CanConvertTo(context, destinationType);
//        }




//        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
//        {

//            if (value == null)
//                return null;

//            Type typeSource = value.GetType();

//            var function = typeSource.GetFunctionForConvert(_tartetType);

//            if (function != null)
//                return function(value, null);

//            return base.ConvertFrom(context, culture, value);

//        }

//        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
//        {

//            if (value == null)
//                return null;

//            Type typeSource = value.GetType();

//            var function = typeSource.GetFunctionForConvert(destinationType);

//            if (function != null)
//                return function(value, null);


//            return base.ConvertTo(context, culture, value, destinationType);
//        }

//        private readonly Type _tartetType;

//    }

//}
