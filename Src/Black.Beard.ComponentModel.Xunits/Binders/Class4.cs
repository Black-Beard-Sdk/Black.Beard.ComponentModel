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
            Assert.False(result.IsDisposable);
            Assert.False(result.IsObservable);
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
