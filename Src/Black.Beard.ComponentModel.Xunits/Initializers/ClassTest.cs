using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using ComponentModels.Tests.Factories;
using FluentAssertions;
using Namotion.Reflection;
using System;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Initializers
{


    public class ClassTest
    {

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

        [EnvironmentMap("param1")]
        public string param1 { get; set; }


        [EnvironmentMap("param2")]
        public bool param2 { get; set; }

        [EnvironmentMap("param3")]
        public int param3 { get; set; }


        [Inject]
        public Test1 ToInject { get; set; }

    }

    public class Test1
    {


    }


}
