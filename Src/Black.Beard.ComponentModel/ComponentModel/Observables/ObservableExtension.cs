using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml.Linq;
using System.ComponentModel;

namespace Bb.ComponentModel.Observables
{


    public static class ObservableExtension
    {


        public static Type MakeObservable(this Type type)
        {
            return ObservableGenerator.CreateObservable(type);
        }

        public static Type MakeObservable<T>(this T instance)
            where T : class, new()
        {
            return ObservableGenerator.CreateObservable<T>();
        }

    }




}
