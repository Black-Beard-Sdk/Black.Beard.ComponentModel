using Bb.ComponentModel;
using System;
using System.ComponentModel;
using Xunit;
using Bb.ComponentModel.Observables;
using System.Linq;


namespace Black.Beard.ComponentModel.Xunits.Binders
{

    public class class4
    {

        [Fact]
        public void Test1()
        {
            DynamicGenerator.Intercept(typeof(ObjectSource), false, true, out var result);
            Assert.False(result.IsObservable);
            Assert.True(result.IsDisposable);
        }

        [Fact]
        public void Test2()
        {
            DynamicGenerator.Intercept(typeof(ObjectSource), true, false, out var result);
            Assert.True(result.IsObservable);
            Assert.False(result.IsDisposable);
        }

        [Fact]
        public void Test3()
        {
            DynamicGenerator.Intercept(typeof(ObjectSource), true, true, out var result);
            Assert.True(result.IsObservable);
            Assert.True(result.IsDisposable);
        }


        public class ObjectSource2 : ObjectSource
        {

  
            public void Dispose()
            {
                OnDisposed();
            }

            public void OnDisposed()
            {
                if (Disposed != null)
                    Disposed(this, EventArgs.Empty);
            }


            public event DisposedEventHandler Disposed;


        }


        public class ObjectSource
        {

            public void Dispose()
            {
                
            }
           
        }



    }

}
