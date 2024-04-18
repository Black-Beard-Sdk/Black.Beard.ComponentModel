using Bb.ComponentModel;
using System;
using System.ComponentModel;
using Xunit;
using Bb.ComponentModel.Observables;
using System.Linq;


namespace Black.Beard.ComponentModel.Xunits.Binders
{

    public class class3
    {

        [Fact]
        public void Test1()
        {

            if (!DynamicGenerator.Intercept(typeof(ObjectSource), true, true, out var result))
                throw new Exception("Intercept failed");
            var newType = result.Type;

            var instance = (ObjectSource)Activator.CreateInstance(newType);

            var e = newType.GetEvents().ToList();

            e[0].RaiseMethod.Invoke(instance, new object[] { "" });
            e[1].RaiseMethod.Invoke(instance, new object[] { });

            bool propertyIntercepted = false;
            bool disposeIntercepted = false;

            if (instance is INotifyPropertyChanged a)
                a.PropertyChanged += (s, e) =>
                {
                    propertyIntercepted = true;
                };

            if (instance is IDisposed b)
                b.Disposed += (s, e) =>
                {
                    disposeIntercepted = true;
                };


            var pp = instance.Name;
            instance.Name = "toto";
            Assert.True(propertyIntercepted);


            if (instance is IDisposable c)
                c.Dispose();
            Assert.True(disposeIntercepted);


        }

        public class ObjectSource : IDisposable
        {


            public void Dispose()
            {
                Dispose(true);
            }


            public virtual void Dispose(bool disposing)
            {
                IsDisposed = true;
            }



            public virtual string Name { get; set; }

            public virtual int Age { get; set; }

            public bool IsDisposed { get; private set; }
        }



    }

}
