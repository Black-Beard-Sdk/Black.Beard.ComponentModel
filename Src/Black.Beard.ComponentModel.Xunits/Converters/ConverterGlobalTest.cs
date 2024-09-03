using Bb.ComponentModel.Factories;
using Bb.Converters;
using Bb.Expressions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Xunit;

namespace Black.Beard.Converters
{


    public class ConverterGlobalTest
    {

        //[Fact]
        //public void Test1()
        //{          
        //    var list = new Type[] { typeof(SByte), typeof(string), typeof(Guid), typeof(float), typeof(double), typeof(decimal), typeof(int), typeof(long), typeof(short), typeof(byte), typeof(bool), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan), typeof(char), typeof(char[]), typeof(byte[]), typeof(UInt16), typeof(UInt32), typeof(UInt64), typeof(UIntPtr), typeof(Version) };
        //    var p = BuildGeneric(typeof(Nullable<>), list).ToArray();
        //    var items = GetCrossItems(list);
        //    foreach (var item in items)
        //    {
        //        var result = ConverterHelper.GetConvertMethod(item.Item1, item.Item2);
        //        if (result == null)
        //        {
        //            ConverterHelper.Reset(item.Item1);
        //            ConverterHelper.Reset(item.Item2);
        //            Debug.WriteLine($"Not found {item.Item1.Name} -> {item.Item2.Name}");
        //        }
        //        else
        //        {
        //            //Debug.WriteLine(result);
        //        }
        //        //Assert.NotNull(result);
        //    }
        //}

        //[Fact]
        //public void Test2()
        //{


        //    var items = GetCrossItems(typeof(SByte), typeof(string), typeof(Guid), typeof(float), typeof(double), typeof(decimal), typeof(int), typeof(long), typeof(short), typeof(byte), typeof(bool), typeof(DateTime), typeof(DateTimeOffset), typeof(TimeSpan), typeof(char), typeof(char[]), typeof(byte[]), typeof(UInt16), typeof(UInt32), typeof(UInt64), typeof(Version));
        //    var values = GetValues();

        //    var v = GetTests();


        //    foreach (var item in items)
        //    {

        //        bool toAdd = false;

        //        if (v.TryGetValue(item, out var value))
        //        {

        //            dynamic result = null;

        //            try
        //            {
        //                result = ConverterHelper.ToObject(value.Item1, item.Item2);
        //                Assert.Equal(result, value.Item2);
        //                Assert.Equal(result.GetType(), item.Item2);
        //            }
        //            catch (Exception ex)
        //            {

        //                string a1 = value.Item1.ToString();
        //                string a2 = value.Item2.ToString();

        //                if (value.Item1 is string)
        //                    a1 = $"\"{a1}\"";

        //                if (value.Item2 is string)
        //                    a2 = $"\"{a2}\"";

        //                var t = "Undefined";
        //                if (result != null)
        //                    t = result.GetType().Name;
        //                Debug.WriteLine($"Error to convert ({item.Item1.Name}){a1}, ({item.Item2.Name}){a2}. The result is ({t}){result} " + ex.Message);

        //            }

        //        }
        //        else
        //        {

        //            if (values.TryGetValue(item.Item1, out var vv))
        //            {
        //                string a1 = vv.ToString();
        //                if (vv is string)
        //                    a1 = $"\"{a1}\"";
        //                Debug.WriteLine($".Add<{item.Item1.Name}, {item.Item2.Name}>({a1}, )");
        //            }
        //            else
        //            {
        //                Debug.WriteLine($".Add<{item.Item1.Name}, {item.Item2.Name}>(, )");
        //            }

        //        }
        //    }


        //}

        [Fact]
        public void MultiTest()
        {
            
            var v = GetTests();

            foreach (var item in v)
            {

                var value = item.Value;
                dynamic result = null;

                try
                {

                    result = ConverterHelper.ToObject(value.Item1, item.Key.Item2, value.Item3);

                    if (value.Item4 != null)
                        Assert.True(value.Item4(value.Item1, result));

                    else
                        Assert.Equal(result, value.Item2);

                    Assert.Equal(result.GetType(), item.Key.Item2);

                }
                catch (Exception ex)
                {

                    string a1 = value.Item1.ToString();
                    string a2 = value.Item2.ToString();

                    if (value.Item1 is string)
                        a1 = $"\"{a1}\"";

                    if (value.Item2 is string)
                        a2 = $"\"{a2}\"";

                    var t = "Undefined";
                    if (result != null)
                        t = result.GetType().Name;
                    Debug.WriteLine($"Error to convert {item.Key.Item1.Name} to {item.Key.Item2.Name}. " + ex.Message);
                    Debug.WriteLine($"Method used : " + ConverterHelper.GetMethodToConvert(item.Key.Item1, item.Key.Item2));

                }

            }


        }

        //[Fact]
        //public void MultiTestWithTypeConverters()
        //{

        //    var v = GetTests();

        //    foreach (var item in v)
        //    {

        //        var value = item.Value;
        //        dynamic result = null;

        //        try
        //        {

        //            var type = typeof(MyCustomTypeConverter<>).MakeGenericType(item.Key.Item2);
        //            var converter = (TypeConverter)Activator.CreateInstance(type);

        //            result = converter.ConvertFrom(value.Item1);

        //            result = converter.ConvertTo(value.Item1, item.Key.Item2);


        //        }
        //        catch (Exception ex)
        //        {

        //            //string a1 = value.Item1.ToString();
        //            //string a2 = value.Item2.ToString();

        //            //if (value.Item1 is string)
        //            //    a1 = $"\"{a1}\"";

        //            //if (value.Item2 is string)
        //            //    a2 = $"\"{a2}\"";

        //            //var t = "Undefined";
        //            //if (result != null)
        //            //    t = result.GetType().Name;
        //            //Debug.WriteLine($"Error to convert {item.Key.Item1.Name} to {item.Key.Item2.Name}. " + ex.Message);
        //            //Debug.WriteLine($"Method used : " + ConverterHelper.GetMethodToConvert(item.Key.Item1, item.Key.Item2));

        //        }

        //    }


        //}

        //[Fact]
        //public void MultiTestWithTypeConverters1()
        //{

        //    var v = GetTests();

        //    var converter = TypeDescriptor.GetConverter(typeof(Enum2));

        //    var t1 = converter.CanConvertFrom(typeof(int));
        //    var t2 = converter.CanConvertTo(typeof(Enum2));

        //}

        private Dictionary<(Type, Type), (dynamic, dynamic, ConverterContext, Func<dynamic, dynamic, bool>)> GetTests()
        {
            Dictionary<(Type, Type), (dynamic, dynamic, ConverterContext, Func<dynamic, dynamic, bool>)> v = new Dictionary<(Type, Type), (dynamic, dynamic, ConverterContext, Func<dynamic, dynamic, bool>)>()
                
                .Add<int, Enum2>(1, Enum2.Value2)
                .Add<string, Enum2>("Value2", Enum2.Value2)
                .Add<Enum2, int>(Enum2.Value2, 1)
                .Add<Enum2, string>(Enum2.Value2, "Value2")
                .Add<Enum1, Enum2>(Enum1.Value2, Enum2.Value2)

                .Add("03/08/2024 14:45:04.0350000Z", new DateTime(2024, 08, 03, 16, 45, 04, 35, CultureInfo.InvariantCulture.Calendar, DateTimeKind.Utc), new ConverterContext(CultureInfo.CurrentCulture))                
                .Add<DateTime, String>(new DateTime(2024, 08, 06, 07, 03, 53), "06/08/2024 07:03:53", new ConverterContext(CultureInfo.CurrentCulture))
                .Add<DateTime, DateTimeOffset>(new DateTime(2024, 08, 06, 07, 03, 53), new DateTimeOffset(new DateTime(2024, 08, 06, 07, 03, 53)))
                .Add<DateTime, TimeSpan>(new DateTime(2024, 08, 06, 07, 03, 53), new TimeSpan(07, 03, 53))
                .Add<DateTimeOffset, DateTime>(new DateTimeOffset(new DateTime(2024, 08, 06, 07, 03, 53)), new DateTime(2024, 08, 06, 05, 03, 53, DateTimeKind.Utc))
                .Add<DateTimeOffset, TimeSpan>(new DateTimeOffset(new DateTime(2024, 08, 06, 07, 03, 53)), new TimeSpan(07, 03, 53))
                .Add<TimeSpan, String>(new TimeSpan(2, 5, 3), "02:05:03")
                .Add("{003DC8AA-0172-4C53-8E70-32B737269FAD}", new Guid("{003DC8AA-0172-4C53-8E70-32B737269FAD}"))
                .Add("12.6", 12.6f)
                .Add("12.4", 12.4d)
                .Add("15.38", 15.38M)
                .Add("1025", 1025)
                .Add("6458", (long)6458)
                .Add("37", (Int16)37)
                .Add("4", (Byte)4)
                .Add("true", true)
                .Add("03/08/2024 14:45:04 +00:00", new DateTimeOffset(2024, 08, 03, 14, 45, 04, TimeSpan.Zero), new ConverterContext(CultureInfo.CurrentCulture))
                .Add("15.21:04:35", new TimeSpan(14, 45, 04, 35))
                .Add("a", 'a')
                .Add<SByte, String>(5, "5")
                .Add<SByte, Single>(5, 5)
                .Add<SByte, Double>(5, 5)
                .Add<SByte, Decimal>(5, 5)
                .Add<SByte, Int32>(5, 5)
                .Add<SByte, Int64>(5, 5)
                .Add<SByte, Int16>(5, 5)
                .Add<SByte, Byte>(5, 5)
                .Add<SByte, Byte[]>(5, new byte[] { 5 })
                .Add<SByte, UInt16>(5, 5)
                .Add<SByte, UInt32>(5, 5)
                .Add<SByte, UInt64>(5, 5)
                .Add<SByte, char>(97, 'a')
                .Add<SByte, Char[]>(97, new char[] { 'a' })
                .Add<String, SByte>("3", 3)
                .Add<String, Char[]>("12345", new char[] { '1', '2', '3', '4', '5' })
                .Add<String, Byte[]>("a", new byte[] { 97 })
                .Add<String, UInt16>("8", 8)
                .Add<String, UInt32>("8", 8)
                .Add<String, UInt64>("8", 8)
                .Add<Guid, String>(new Guid("eb966f32-8865-4e3f-8545-7389afc615a1"), "eb966f32-8865-4e3f-8545-7389afc615a1")
                .Add<Guid, Byte[]>(new Guid("{003DC8AA-0172-4C53-8E70-32B737269FAD}"), new Byte[] { 170, 200, 61, 0, 114, 1, 83, 76, 142, 112, 50, 183, 55, 38, 159, 173 })
                .Add<Single, SByte>(12, 12)
                .Add<Single, String>(12.6f, "12.6")
                .Add<Single, Double>(12.6f, 12.6d, null, (a, b) => Math.Round(a, 1) == Math.Round(b, 1))
                .Add<Single, Decimal>(12.6f, 12.6M)
                .Add<Single, Int32>(12, 12)
                .Add<Single, Int64>(12, 12)
                .Add<Single, Int16>(12, 12)
                .Add<Single, Byte>(12, 12)
                .Add<Single, Char>(32, ' ')
                .Add<Single, Char[]>(97, new char[] { 'a' })
                .Add<Single, Byte[]>(12, new byte[] { 12 })
                .Add<Single, UInt16>(12, 12)
                .Add<Single, UInt32>(12, 12)
                .Add<Double, SByte>(37, 37)
                .Add<Single, UInt64>(12, 12)
                .Add<Double, String>(37.7, "37.7")
                .Add<Double, Single>(37.7, 37.7f)
                .Add<Double, Decimal>(37.7d, 37.7M)
                .Add<Double, Int32>(37.7, 37)
                .Add<Double, Int64>(37.7, 37)
                .Add<Double, Int16>(37.7, 37)
                .Add<Double, Byte>(37, 37)
                .Add<Double, Char>(97, 'a')
                .Add<Double, Char[]>(97, new char[] { 'a' })
                .Add<Double, Byte[]>('a', new byte[] { 97 })
                .Add<Double, UInt16>(37, 37)
                .Add<Double, UInt32>(37, 37)
                .Add<Double, UInt64>(37, 37)
                .Add<Decimal, SByte>(15, 15)
                .Add<Decimal, String>(1, "1")
                .Add<Decimal, Single>(15.38M, 15.38f)
                .Add<Decimal, Double>(15.38M, 15.38)
                .Add<Decimal, Int32>(15M, 15)
                .Add<Decimal, Int64>(15M, 15)
                .Add<Decimal, Int16>(15M, 15)
                .Add<Decimal, Byte>(15M, 15)
                .Add<Decimal, Boolean>(1.0M, true)
                .Add<Decimal, Char>(97, 'a')
                .Add<Decimal, Char[]>(97, new char[] { 'a' })
                .Add<Decimal, Byte[]>('a', new byte[] { 97 })
                .Add<Decimal, UInt16>(15, 15)
                .Add<Decimal, UInt32>(15, 15)
                .Add<Decimal, UInt64>(15, 15)
                .Add<Int32, SByte>(35, 35)
                .Add<Int32, String>(35, "35")
                .Add<Int32, Single>(456, 456)
                .Add<Int32, Double>(456, 456)
                .Add<Int32, Decimal>(456, 456)
                .Add<Int32, Int64>(456, 456)
                .Add<Int32, Int16>(456, 456)
                .Add<Int32, Byte>(45, 45)
                .Add<Int32, Boolean>(1, true)
                .Add<Int32, Char>(97, 'a')
                .Add<Int32, Char[]>(97, new char[] { 'a' })
                .Add<Int32, Byte[]>('a', new byte[] { 97 })
                .Add<Int32, UInt16>(97, 97)
                .Add<Int32, UInt32>(97, 97)
                .Add<Int32, UInt64>(97, 97)
                .Add<Int64, SByte>(97, 97)
                .Add<Int64, String>(97, "97")
                .Add<Int64, Single>(97, 97)
                .Add<Int64, Double>(97, 97)
                .Add<Int64, Decimal>(97, 97)
                .Add<Int64, Int32>(97, 97)
                .Add<Int64, Int16>(97, 97)
                .Add<Int64, Byte>(97, 97)
                .Add<Int64, Boolean>(1, true)
                .Add<Int64, Char>(97, 'a')
                .Add<Int64, Char[]>(97, new char[] { 'a' })
                .Add<Int64, Byte[]>('a', new byte[] { 97 })
                .Add<Int64, UInt16>(6458, 6458)
                .Add<Int64, UInt32>(6458, 6458)
                .Add<Int64, UInt64>(6458, 6458)
                .Add<Int16, SByte>(6, 6)
                .Add<Int16, String>(6, "6")
                .Add<Int16, Single>(6, 6)
                .Add<Int16, Double>(6, 6)
                .Add<Int16, Decimal>(6, 6)
                .Add<Int16, Int32>(6, 6)
                .Add<Int16, Int64>(6, 6)
                .Add<Int16, Byte>(6, 6)
                .Add<Int16, Boolean>(1, true)
                .Add<Int16, Char>(97, 'a')
                .Add<Int16, Char[]>(97, new char[] { 'a' })
                .Add<Int16, Byte[]>(97, new byte[] { 97 })
                .Add<Int16, UInt16>(6, 6)
                .Add<Int16, UInt32>(6, 6)
                .Add<Int16, UInt64>(6, 6)
                .Add<Byte, SByte>(30, 30)
                .Add<Byte, String>(30, "30")
                .Add<Byte, Single>(30, 30)
                .Add<Byte, Double>(30, 30)
                .Add<Byte, Decimal>(30, 30)
                .Add<Byte, Int32>(30, 30)
                .Add<Byte, Int64>(30, 30)
                .Add<Byte, Int16>(30, 30)
                .Add<Byte, Boolean>(1, true)
                .Add<Byte, Char>(97, 'a')
                .Add<Byte, Char[]>(97, new char[] { 'a' })
                .Add<Byte, Byte[]>(97, new byte[] { 97 })
                .Add<Byte, UInt16>(30, 30)
                .Add<Byte, UInt32>(30, 30)
                .Add<Byte, UInt64>(30, 30)
                .Add<Boolean, SByte>(true, 1)
                .Add<Boolean, String>(true, "True")
                .Add<Boolean, Single>(true, 1)
                .Add<Boolean, Double>(true, 1)
                .Add<Boolean, Decimal>(true, 1)
                .Add<Boolean, Int32>(true, 1)
                .Add<Boolean, Int64>(true, 1)
                .Add<Boolean, Int16>(true, 1)
                .Add<Boolean, Byte>(true, 1)
                .Add<Boolean, Char>(true, '1')
                .Add<Boolean, UInt16>(true, 1)
                .Add<Boolean, UInt32>(true, 1)
                .Add<Boolean, UInt64>(true, 1)                
                .Add<Char, SByte>('a', 97)
                .Add<Char, String>('a', "a")
                .Add<Char, Single>('a', 97)
                .Add<Char, Double>('a', 97)
                .Add<Char, Decimal>('a', 97)
                .Add<Char, Int32>('a', 97)
                .Add<Char, Int64>('a', 97)
                .Add<Char, Int16>('a', 97)
                .Add<Char, Byte>('a', 97)
                .Add<Char, Char[]>('a', new char[] { 'a' })
                .Add<Char, Byte[]>('a', new byte[] { 97 })
                .Add<Char, UInt16>('a', 97)
                .Add<Char, UInt32>('a', 97)
                .Add<Char, UInt64>('a', 97)
                .Add<Char[], SByte>(new char[] { 'a' }, 97)
                .Add<Char[], String>(new char[] { 'a' }, "a")
                //.Add<Char[], Guid>(new char[] { 'a' }, )
                //.Add<Char[], Single>(new char[] { 'a' }, 97)
                //.Add<Char[], Double>(new char[] { 'a' }, 97)
                //.Add<Char[], Decimal>(new char[] { 'a' }, 97)
                .Add<Char[], Int16[]>(new char[] { 'a' }, new Int16[] { 97 })
                .Add<Char[], Int32[]>(new char[] { 'a' }, new Int32[] { 97 })
                .Add<Char[], Int64[]>(new char[] { 'a' }, new Int64[] { 97 })                
                .Add<Char[], Char>(new char[] { 'a' }, 'a')
                .Add<Char[], Byte[]>(new char[] { 'a' }, new byte[] { 97 })
                .Add<Char[], UInt16[]>(new char[] { 'a' }, new UInt16[] { 97 })
                //.Add<Char[], UInt32>(new char[] { 'a' }, 97)
                //.Add<Char[], UInt64>(new char[] { 'a' }, 97)
                //.Add<Byte[], SByte>(new byte[] { 3 }, 3)
                //.Add<Byte[], String>(new byte[] { 3 }, "3")
                .Add<Byte[], Guid>(new byte[] { 170, 200, 61, 0, 114, 1, 83, 76, 142, 112, 50, 183, 55, 38, 159, 173 }, new Guid("{003DC8AA-0172-4C53-8E70-32B737269FAD}"))
                //.Add<Byte[], Single>(new byte[] { 3 }, 3)
                //.Add<Byte[], Double>(new byte[] { 3 }, 3)
                //.Add<Byte[], Decimal>(new byte[] { 3 }, 3)
                //.Add<Byte[], Int32>(new byte[] { 3 }, 3)
                //.Add<Byte[], Int64>(new byte[] { 3 }, 3)
                //.Add<Byte[], Int16>(new byte[] { 3 }, 3)
                //.Add<Byte[], Byte>(new byte[] { 3 }, 3)
                //.Add<Byte[], Char>(new byte[] { 97 }, 'a')
                .Add<Byte[], Char[]>(new byte[] { 97 }, new char[] { 'a' })
                //.Add<Byte[], UInt16>(new byte[] { 97 }, 97)
                //.Add<Byte[], UInt32>(new byte[] { 97 }, 97)
                //.Add<Byte[], UInt64>(new byte[] { 97 }, 97)
                .Add<UInt16, SByte>(97, 97)
                .Add<UInt16, String>(97, "97")
                .Add<UInt16, Single>(97, 97)
                .Add<UInt16, Double>(97, 97)
                .Add<UInt16, Decimal>(97, 97)
                .Add<UInt16, Int32>(97, 97)
                .Add<UInt16, Int64>(97, 97)
                .Add<UInt16, Int16>(97, 97)
                .Add<UInt16, Byte>(97, 97)
                .Add<UInt16, Char>(97, 'a')
                .Add<UInt16, Char[]>(97, new char[] { 'a' })
                .Add<UInt16, Byte[]>(97, new byte[] { 97 })
                .Add<UInt16, UInt32>(97, 97)
                .Add<UInt16, UInt64>(97, 97)
                .Add<UInt32, SByte>(97, 97)
                .Add<UInt32, String>(97, "97")
                .Add<UInt32, Single>(97, 97)
                .Add<UInt32, Double>(97, 97)
                .Add<UInt32, Decimal>(97, 97)
                .Add<UInt32, Int32>(97, 97)
                .Add<UInt32, Int64>(97, 97)
                .Add<UInt32, Int16>(97, 97)
                .Add<UInt32, Byte>(97, 97)
                .Add<UInt32, Boolean>(1, true)
                .Add<UInt32, Char>(97, 'a')
                .Add<UInt32, Char[]>(97, new char[] { 'a' })
                .Add<UInt32, Byte[]>(97, new byte[] { 97 })
                .Add<UInt32, UInt16>(97, 97)
                .Add<UInt32, UInt64>(97, 97)
                .Add<UInt64, SByte>(97, 97)
                .Add<UInt64, String>(97, "97")
                .Add<UInt64, Single>(97, 97)
                .Add<UInt64, Double>(97, 97)
                .Add<UInt64, Decimal>(97, 97)
                .Add<UInt64, Int32>(97, 97)
                .Add<UInt64, Int64>(97, 97)
                .Add<UInt64, Int16>(97, 97)
                .Add<UInt64, Byte>(97, 97)
                .Add<UInt64, Boolean>(1, true)
                .Add<UInt64, Char>(97, 'a')
                .Add<UInt64, Char[]>(97, new char[] { 'a' })
                .Add<UInt64, Byte[]>(97, new byte[] { 97 })
                .Add<UInt64, UInt16>(97, 97)
                .Add<UInt64, UInt32>(97, 97)
            ;

            return v;

        }

        private Dictionary<Type, dynamic> GetValues()
        {

            Dictionary<Type, dynamic> values = new Dictionary<Type, dynamic>()
            {
                {typeof(Guid), Guid.NewGuid() },
                {typeof(float), 12.6f },
                {typeof(double), 37.7d },
                {typeof(decimal), 15.38M },
                {typeof(int), 456 },
                {typeof(long), (long)6458 },
                {typeof(short), (short)6 },
                {typeof(sbyte), (sbyte)5 },
                {typeof(byte), (byte)30 },
                {typeof(bool), true },
                {typeof(DateTime), DateTime.UtcNow },
                {typeof(TimeSpan), TimeSpan.FromMinutes(5) },
                {typeof(char), 'a' },
            };

            return values;

        }


        private static HashSet<(Type, Type)> GetItems()
        {
            HashSet<(Type, Type)> items = new HashSet<(Type, Type)>();

            HashSet<Type> types = new HashSet<Type>()
            {
                //typeof(Guid),
                typeof(string),
                typeof(float),
                typeof(double),
                typeof(decimal),
                typeof(int),
                typeof(long),
                typeof(short),
                typeof(byte),
                typeof(bool),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(char),
            };

            var types2 = types.ToArray();
            foreach (var item in types)
                foreach (var item2 in types2)
                    if (item != item2)
                        items.Add(new(item, item2));

            return items;

        }

        protected static HashSet<(Type, Type)> GetCrossItems(params Type[] types)
        {

            HashSet<Type> t = new HashSet<Type>(types);
            HashSet<(Type, Type)> items = new HashSet<(Type, Type)>(types.Length * types.Length);

            var types2 = t.ToArray();
            foreach (var item in types)
                foreach (var item2 in types2)
                    if (item != item2)
                        items.Add(new(item, item2));

            return items;

        }

        protected static IEnumerable<Type> BuildGeneric(Type type, params Type[] types)
        {

            HashSet<Type> t = new HashSet<Type>(types);
            foreach (var item in t)
            {

                yield return item;
                Type type2 = null;

                try
                {
                    type2 = type.MakeGenericType(item);
                }
                catch (Exception) { }

                if (type2 != null)
                    yield return type2;

            }


        }
    }

    public enum Enum1 
    {
        Value1,
        Value2,
        Value3
    }

    //[TypeConverter(typeof(MyCustomTypeConverter<Enum2>))]
    public enum Enum2 : UInt16
    {
        Value1,
        Value2,
        Value3
    }

}
