using System;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.Factories
{
    public sealed class Tests
    {

        [Fact]
        public void TestGetPropertyToMap()
        {
            ObjectCreatorByIoc.SetInjectionAttribute<InjectByIocAttribute>();
            var i = new TestByIoc3();
            var items = i.GetPropertiesToMap().ToList();
            Assert.True(items.Count == 1);
        }

        [Fact]
        public void TestMapper()
        {
            ObjectCreatorByIoc.SetInjectionAttribute<InjectByIocAttribute>();
            var serviceProvider = new LocalServiceProvider();

            var i = new TestByIoc3();

            i.MapInjectProperties(serviceProvider);

            Assert.NotNull(i.Provider);

        }

        [Fact]
        public void Constructor_FactoryByIoc()
        {
            
            var serviceProvider = new LocalServiceProvider()
                .Add<TestByIoc1>()
                .Add<TestByIoc2>();

            var srv = (TestByIoc1)serviceProvider.GetService(typeof(TestByIoc1));

            ObjectCreatorByIoc.SetInjectionAttribute<InjectByIocAttribute>();
            var factory3 = ObjectCreatorByIoc.GetActivator<TestByIoc3>();
            var oo = factory3.Invoke(serviceProvider);

            (oo.Provider == serviceProvider).Should().BeTrue();

        }

        [Fact]
        public void Constructor_Factory1()
        {
            var factory = ObjectCreator.GetActivatorByTypeAndArguments<object>(typeof(Test1), typeof(string), typeof(int));
            Test1 result = (Test1)factory.CallInstance("t1", 1);
            result.Arg1.Should().Be("t1");
        }

        [Fact]
        public void Constructor_Factory2()
        {
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(typeof(string), typeof(int));
            Test1 result = factory.CallByKey(null, "t2", 1);
            result.Arg1.Should().Be("t2");
        }

        [Fact]
        public void Constructor_Factory3()
        {
            FactoryByIoc<InitializerTest3> factory = ObjectCreatorByIoc.GetActivator<InitializerTest3>(typeof(InitializerTest3));
            InitializerTest3 result = (InitializerTest3)factory.CallInstance();
            //result.Arg1.Should().Be("t1");
        }

        [Fact]
        public void Constructor_Factory4()
        {
            var serviceProvider = new LocalServiceProvider(true);
            var s = serviceProvider.GetService<InitializerTest4>();
            s.Should().NotBeNull();
            s.Instance.Should().NotBeNull();
        }

        [Fact]
        public void ResolveTypes()
        {
            var types = ObjectCreator.ResolveTypesOfArguments("t2", 1);
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(types);
            Test1 result = factory.CallByKey(null, "t2", 1);
            result.Arg1.Should().Be("t2");
        }

    }


    [ExposeClass(ConstantsCore.Service)]
    public class InitializerTest3
    {

        [IocConstructor(typeof(InitializerTest3))]
        public static InitializerTest3 Create()
        {
            return new InitializerTest3();
        }

    }

    [ExposeClass(ConstantsCore.Service)]
    public class InitializerTest4
    {

        public InitializerTest4(InitializerTest3 instance)
        {
            this.Instance = instance;
        }

        public InitializerTest3 Instance { get; }

        [IocConstructor(typeof(InitializerTest4))]
        public static InitializerTest4 Create(InitializerTest3 instance)
        {
            return new InitializerTest4(instance);
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


    //public class InjectAttribute : Attribute
    //{



    //}


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

        [InjectByIoc]
        public IServiceProvider Provider { get; set; }


    }

}
