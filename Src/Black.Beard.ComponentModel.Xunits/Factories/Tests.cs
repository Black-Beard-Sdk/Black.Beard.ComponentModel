﻿using System;
using Bb.ComponentModel.Factories;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Factories
{
    public sealed class Tests
    {

        [Fact]
        public void Constructor_FactoryByIoc()
        {
            
            var serviceProvider = new LocalServiceProvider()
                .Add<TestByIoc1>()
                .Add<TestByIoc2>();

            var srv = (TestByIoc1)serviceProvider.GetService(typeof(TestByIoc1));

            ObjectCreatorByIoc.SetInjectionAttribute<InjectAttribute>();
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
