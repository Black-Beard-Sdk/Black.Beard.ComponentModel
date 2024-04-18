using Bb.ComponentModel;
using System;
using System.ComponentModel;
using Xunit;
using Bb.ComponentModel.Observables;
using System.Linq;


namespace Black.Beard.ComponentModel.Xunits.Binders
{

    public class class5
    {

        [Fact]
        public void Test1()
        {

            if (!DynamicGenerator.Intercept(typeof(ObjectSource), true, true, out var result))
                throw new Exception("Intercept failed");
            var newType = result.Type;

            var args = new object[] { "gael", 51, "Paris" };

            var instance = (ObjectSource)Activator.CreateInstance(newType, args);


            bool observed = false;
            if (instance is INotifyPropertyChanged a)
                a.PropertyChanged += (s, e) =>
                {
                    observed = true;
                };

            instance.Town = "Provins";
            Assert.True(observed);


            bool disposeIntercepted = false;
            if (instance is IDisposed b)
                b.Disposed += (s, e) =>
                {
                    disposeIntercepted = true;
                };

            if (instance is IDisposable c)
                c.Dispose();

            Assert.True(disposeIntercepted);

        }

        //public class ObjectSource2 : ObjectSource
        //{
        //    public ObjectSource2(string name, int age) 
        //        : base(name, age)
        //    {
        //    }
        //}


        public class ObjectSource
        {


            public ObjectSource(string name, int age, string town)
            {
                this.Name = name;
                this.Age = age;
                this.Town = town;
            }


            public virtual string Name { get; set; }

            public virtual int Age { get; set; }

            public virtual string Town { private get; set; }

        }



    }

}
