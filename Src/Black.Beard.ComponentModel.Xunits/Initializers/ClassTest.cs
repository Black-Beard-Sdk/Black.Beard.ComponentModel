using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using Bb.Injections;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Initializers
{

    public class ClassTest
    {


        [Fact]
        public void Test0()
        {

            Initializer.Initialize(c =>
            {

                c.SetInjectValue((name) => name == "param4" ? "Toto=45" : null)
                 .OnInitialization = d =>
                 {
                     if (d is InitializerTest t)
                     {
                         t.param4.Count.Should().Be(1);
                         t.param4["toto"].Should().Be("45");
                     }
                 };

            }, "--param1:test", "--param3:6");

        }

        [Fact]
        public void Test1()
        {

            bool ok = false;
            Initializer.Initialize(c =>
            {

                c.OnInitialization = d =>
                {
                    if (d is InitializerTest t)
                    {
                        t.param1.Should().Be("test");
                        //t.param2.Should().BeTrue();
                        //t.param3.Should().Be(1);
                        t.ToInject.Should().NotBeNull();
                        ok = true;
                    }

                };

            }, "--param1:test");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test2()
        {

            bool ok = false;
            Initializer.Initialize(c =>
            {

                c.OnInitialization = d =>
                {
                    if (d is InitializerTest t)
                    {
                        t.param2.Should().BeTrue();
                        t.ToInject.Should().NotBeNull();
                        ok = true;
                    }


                };

            }, "--param2:true");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test3()
        {

            bool ok = false;
            Initializer.Initialize(c =>
            {

                c.OnInitialization = d =>
                {
                    if (d is InitializerTest t)
                    {
                        t.param3.Should().Be(6);
                        t.ToInject.Should().NotBeNull();
                        ok = true;
                    }
                };

            }, "--param3:6");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test4()
        {

            bool ok = false;
            Initializer.Initialize(c =>
            {

                c.OnInitialization = d =>
                {
                    if (d is InitializerTest t)
                    {
                        t.ToInject.Should().NotBeNull();
                        t.ToInject2.Should().NotBeNull();
                        ok = true;
                    }
                };

            });

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test5()
        {

            bool ok = false;
            Initializer.Initialize(c =>
            {

                c.OnInitialization = d =>
                {
                    if (d is InitializerTest t)
                    {
                        t.ToInject.Should().NotBeNull();
                        t.ToInject2.Should().NotBeNull();
                        ok = true;
                    }
                };

                c.InjectRescue = (e, n, d) =>
                {
                    return null;
                };

            });

            ok.Should().BeTrue();

        }

        public class BuilderTest
        {

            public BuilderTest()
            {

            }

            public bool Ran { get; set; }


        }

    }


    [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder<Initializer>))]
    public class InitializerTest : IInjectBuilder<Initializer>
    {

        public InitializerTest()
        {

        }

        public string FriendlyName => typeof(InitializerTest).Name;

        public Type Type => typeof(InitializerTest);

        public bool CanExecute(Initializer context)
        {

            var p = this;

            return true;
        }

        public bool CanExecute(object context)
        {
            return true;
        }

        public object Execute(Initializer context)
        {
            return null;
        }

        public object Execute(object context)
        {
            return null;
        }

        [InjectValue("param1")]
        public string param1 { get; set; }


        [InjectValue("param2")]
        public bool param2 { get; set; }

        [InjectValue("param3")]
        public int param3 { get; set; }

        [InjectValue("param4")]
        public Dictionary<string, string> param4 { get; set; }

        [Inject]
        public Test1 ToInject { get; set; }


        [Inject(typeof(Test2))]
        public ITest ToInject2 { get; set; }

    }

    public class Test1
    {


    }

    public class Test2 : ITest
    {
        public string Name { get; set; }

    }

    public interface ITest
    {

        string Name { get; set; }

    }

}
