using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Factories
{
    public sealed class Tests
    {

        [Fact]
        public void Constructor_FactoryByIoc()
        {

            var factory2 = ObjectCreatorByIoc.GetActivator<TestByIoc1>();
            var factory1 = ObjectCreatorByIoc.GetActivator<TestByIoc2>();

            var serviceProvider = new CustomIServiceProvider();
            serviceProvider.Add(factory1);
            serviceProvider.Add(factory2);

            var srv = (TestByIoc1)serviceProvider.GetService(typeof(TestByIoc1));

            var instance = factory1.Invoke(serviceProvider);

            // Test1 result = (TestByIoc1)factory.Call(null, "t1", 1);
            //result.Arg1.Should().Be("t1");

            factory1.SetInjectionAttribute<InjectAttribute>();
            var factory3 = ObjectCreatorByIoc.GetActivator<TestByIoc3>();

            var oo = factory3.Invoke(serviceProvider);

            (oo.Provider == serviceProvider).Should().BeTrue();

        }

        [Fact]
        public void Constructor_Factory1()
        {
            var factory = ObjectCreator.GetActivatorByTypeAndArguments<object>(typeof(Test1), typeof(string), typeof(int));
            Test1 result = (Test1)factory.Call("t1", 1);
            result.Arg1.Should().Be("t1");
        }


        [Fact]
        public void Constructor_Factory2()
        {
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(typeof(string), typeof(int));
            Test1 result = factory.Call("t2", 1);
            result.Arg1.Should().Be("t2");
        }

        [Fact]
        public void ResolveTypes()
        {
            var types = ObjectCreator.ResolveTypesOfArguments("t2", 1);
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(types);
            Test1 result = factory.Call("t2", 1);
            result.Arg1.Should().Be("t2");
        }




        public class CustomIServiceProvider : IServiceProvider
        {

            public CustomIServiceProvider()
            {
                this._dic = new Dictionary<Type, Factory>();
            }

            public object? GetService(Type serviceType)
            {
                
                if (serviceType == typeof(IServiceProvider))
                    return this;

                return _dic[serviceType].CallInstance(this);

            }

            public void Add(Factory factory)
            {
                _dic.Add(factory.ExposedType, factory);
            }

            private readonly Dictionary<Type, Factory> _dic;

        }


    }


    public class Test1
    {

        public Test1(string arg1, int arg2)
        {
            this.Arg1 = arg1;
            this.Arg2 = arg2;
        }

        public string Arg1 { get; }

        public int Arg2 { get; }

    }


    public class Test3
    {

        public Test3()
        {

        }

      
    }


    public class InjectAttribute : Attribute
    {



    }


    public class TestByIoc1
    {

        public TestByIoc1(TestByIoc2 child)
        {
            Child = child;
        }

        public TestByIoc2 Child { get; }

    }


    public class TestByIoc2 : IInitialize
    {

        public TestByIoc2()
        {

        }

        public void Initialize(IServiceProvider services)
        {
        

        }

    }


    public class TestByIoc3
    {

        public TestByIoc3()
        {

        }        

        [Inject]
        public IServiceProvider Provider { get; set; }


    }

}
