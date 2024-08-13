using Bb.Converters;
using System;
using System.Collections.Generic;

namespace Black.Beard.Converters
{
    public static class DictionnaryHelper
    {


        public static Dictionary<(Type, Type), (dynamic, dynamic, ConverterContext, Func<dynamic, dynamic, bool>)> Add<T1, T2>(this Dictionary<(Type, Type), (dynamic, dynamic, ConverterContext, Func<dynamic, dynamic, bool>)> self, T1 value1, T2 value2, ConverterContext? context = null, Func<T1, T2, bool> test = null)
        {

            Func<dynamic, dynamic, bool> test1 = null;
            if (test != null)
                test1 = (a, b) => test(a, b);

            self.Add((typeof(T1), typeof(T2)), (value1, value2, context, test1));
            return self;
        }


    }

}
