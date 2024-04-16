using Bb.ComponentModel;
using Bb.ComponentModel.Binders;
using System;
using System.ComponentModel;
using Xunit;
using Bb.ComponentModel.Observables;
using ICSharpCode.Decompiler.CSharp;
using System.Linq;
using System.Diagnostics;

namespace Black.Beard.ComponentModel.Xunits.Binders
{

    public class class2
    {

        [Fact]
        public void Test1()
        {


            var newType = ObservableGenerator.CreateObservable<ObjectSource>();
            var instance = (ObjectSource)Activator.CreateInstance(newType);


            if (instance is INotifyPropertyChanged a)
                a.PropertyChanged += (s, e) =>
                {
                    Console.WriteLine(e.PropertyName);
                };

            var pp = instance.Name;


            instance.Name = "toto";



        }


        public class ObjectSource2 : ObjectSource, INotifyPropertyChanged //, IDisposed
        {


            public override string Name
            {
                get
                {
                    return base.Name;
                }
                set
                {
                    if (!object.Equals(base.Name, value))
                    {
                        base.Name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }

            public void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public event PropertyChangedEventHandler PropertyChanged;

        }


        public class ObjectSource : IDisposed
        {

            
            public event DisposedEventHandler Disposed;

            public virtual void Dispose()
            {
                if (Disposed != null)
                    Disposed?.Invoke(this, new DisposedEventArgs() { Instance = this });
            }



            public virtual string Name { get; set; }

            public virtual int Age { get; set; }

            private string _name;

        }



    }

}
