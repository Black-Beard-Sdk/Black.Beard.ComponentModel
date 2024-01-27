using System;
using System.Linq;

namespace Bb.ComponentModel
{
    internal class Serializer
    {
        
        static Serializer()
        {

            var types = ComponentModel.TypeDiscovery.Instance.GetTypes(t => t.Assembly.GetName().Name == "Newtonsoft.Json"
                    && t.Namespace == "Newtonsoft.Json"
                    && t.Name == "JsonConvert")
                .ToArray();

            if (types.Length == 0)
                throw new MissingMethodException("no assembly Newtonsoft.Json is referenced in the project");

            var type = types[0];

            Serializer.DeserializeObject = GetDeserializeObjectMethod(type);

            Serializer.SerializeObject = GetSerializeObjectMethod(type);

            Serializer.PopulateObject = GetPopulateObjectMethod(type);

        }

        public static Func<string, Type, object> DeserializeObject { get; }
        public static Func<object, string> SerializeObject { get; }
        public static Action<string, object> PopulateObject { get; }

        private static Action<string, object> GetPopulateObjectMethod(Type type)
        {
            var m3 = type.GetMethod("PopulateObject", new Type[] { typeof(string), typeof(object) });
            var p1 = System.Linq.Expressions.Expression.Parameter(typeof(string), "payload");
            var p2 = System.Linq.Expressions.Expression.Parameter(typeof(object), "instance");
            var method = System.Linq.Expressions.Expression.Lambda<Action<string, object>>(System.Linq.Expressions.Expression.Call(null, m3, p1, p2), p1, p2).Compile();
            return method;
        }

        private static Func<object, string> GetSerializeObjectMethod(Type type)
        {
            var m2 = type.GetMethod("SerializeObject", new Type[] { typeof(object) });
            var p1 = System.Linq.Expressions.Expression.Parameter(typeof(object), "instance");
            var method = System.Linq.Expressions.Expression.Lambda<Func<object, string>>(System.Linq.Expressions.Expression.Call(null, m2, p1), p1).Compile();
            return method;
        }

        private static Func<string, Type, object> GetDeserializeObjectMethod(Type type)
        {
            var m1 = type.GetMethod("DeserializeObject", new Type[] { typeof(string), typeof(Type) });
            var p1 = System.Linq.Expressions.Expression.Parameter(typeof(string), "payload");
            var p2 = System.Linq.Expressions.Expression.Parameter(typeof(Type), "targetType");
            var method = System.Linq.Expressions.Expression.Lambda<Func<string, Type, object>>(System.Linq.Expressions.Expression.Call(null, m1, p1, p2), p1, p2)
                .Compile();
            return method;
        }
    
    }
}



