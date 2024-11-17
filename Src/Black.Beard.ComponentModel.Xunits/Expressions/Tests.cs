using Bb.Expressions;
using System;
using System.Linq.Expressions;
using Xunit;

namespace ComponentModels.Tests.Expressions
{
    public sealed class Tests
    {

        [Fact]
        public void TestCallMethod()
        {

            var Cls = new   Cls1() {  Name = Guid.NewGuid().ToString() };

            var p = Expression.Parameter(typeof(Cls1), "p");
            var f1 = p.Call(typeof(Cls1), nameof(Cls1.GetName));
            var f = Expression.Lambda<Func<Cls1, string>>(f1, p).Compile();

            var result = f.Invoke(Cls);
            Assert.Equal(Cls.Name, result);

        }

        [Fact]
        public void TestCallMethod1()
        {
            var pl = Expression.Parameter(typeof(Type), "l");
            var pr = Expression.Parameter(typeof(Type), "r");
            var f1 = pl.CallIsAssignableFrom(pr);
            var f = Expression.Lambda<Func<Type, Type, bool>>(f1, pl, pr).Compile();

            var result = f.Invoke(typeof(Cls1), typeof(Cls2));
            Assert.True(result);

            result = f.Invoke(typeof(Cls2), typeof(Cls1));

            Assert.False(result);
        }

    }


    public class Cls2 : Cls1
    {

    }

        public class Cls1
    {

        
        public string Name { get; set; }


        public string GetName()
        {
            return this.Name;
        }


    }

}
