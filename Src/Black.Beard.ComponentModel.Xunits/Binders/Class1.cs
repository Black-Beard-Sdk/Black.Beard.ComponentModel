﻿using Bb;
using Bb.Binders;
using System;
using System.ComponentModel;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Binders
{

    public class Class1
    {

        [Fact]
        public void Test1()
        {


            var source = new ObjectSource();
            var target = new ObjectTarget();

            var config = new PropertyBinder<ObjectSource, ObjectTarget>()
                .Bind(c => c.Name, (d, e) => d.Name = e);

            var observe = config.Observe(source, target);

            source.Name = "toto";
            Assert.Equal("toto", target.Name);


            source.Dispose();
            Assert.True(observe.IsDisposed);

        }



        public class ObjectSource : INotifyPropertyChanged, IDisposed
        {



            public void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            public void Dispose()
            {
                if (Disposed != null)
                    Disposed?.Invoke(this, EventArgs.Empty);
            }

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged(nameof(Name));
                    }
                }
            }

            public int Age
            {
                get => _age;
                set
                {

                    if (_age != value)
                    {
                        _age = value;
                        OnPropertyChanged(nameof(Age));
                    }
                }
            }


            public event PropertyChangedEventHandler PropertyChanged;
            public event DisposedEventHandler Disposed;

            private string _name;
            private int _age;

        }


        public class ObjectTarget
        {

            public string Name { get; set; }

            public int Age { get; set; }

        }



    }

}
