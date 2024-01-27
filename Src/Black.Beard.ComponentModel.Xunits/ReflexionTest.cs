using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using System;
using System.Linq;
using Xunit;

namespace DynamicDescriptors.Tests
{


    public sealed class ReflexionTest
    {


        [Fact]
        public void FilterTest1()
        {

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);


            var item1 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .Search()
                    .First();

            var item2 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .WithBaseType(typeof(SubTestClass))
                    .Search()
                    .First();

            var item3 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .Implements(typeof(IInjectBuilder))
                    .Search()
                    .First();

        }


        [Fact]
        public void FilterTest2()
        {

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize(directories);

            var types = TypeDiscovery.Instance
                .Search(c =>
                    c.InContext(ConstantsCore.Plugin)
                    .Implements(typeof(ITest))
                , true)
                .ToList()
                ;

            types.Single(c => c.FullName == typeof(TestClass).FullName);
        
        }


        [Fact]
        public void FilterTest3()
        {

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize(directories);

            var types = TypeDiscovery.Instance
                .Search(c =>
                    c.InContext(ConstantsCore.Plugin)
                    .WithBaseType(typeof(SubTestClass))
                , true)
                .ToList()
                ;

            types.Single(c => c.FullName == typeof(TestClass).FullName);

        }

        [Fact]
        public void FilterTest4()
        {

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize(directories);

            var types = TypeDiscovery.Instance
                .Search(c =>
                    c.InContext(ConstantsCore.Plugin)
                    .ExcludeAbstractTypes(false)
                    .ExcludeGenericTypes(false)
                    .Implements(typeof(IInjectBuilder))
                , true)
                .ToList()
                ;

            Assert.True(types.Count >= 2);

            types.Single(c => c.FullName == typeof(TestClass).FullName);

        }

        [Fact]
        public void FilterTest5()
        {

            var autoloadTypes = true;

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize(directories);

            var types = TypeDiscovery.Instance
                .Search(c =>
                    c.InContext(ConstantsCore.Plugin)
                    .Implements(typeof(IInjectBuilder))
                , autoloadTypes)
                .ToList()
                ;

            Assert.Single(types);

            types.Single(c => c.FullName == typeof(TestClass).FullName);

        }

        [Fact]
        public void FilterTest6()
        {

            var directories = new AssemblyDirectoryResolver()
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize(directories);

            var types = TypeDiscovery.Instance
                .Search(c =>
                    c.InContext(ConstantsCore.Plugin)
                    .ExcludeGenericTypes()
                    .Implements(typeof(IInjectBuilder))
                , true)
                .ToList()
                ;

            Assert.Single(types);

            types.Single(c => c.FullName == typeof(TestClass).FullName);

        }

    }

    [ExposeClass(Context = ConstantsCore.Plugin)]
    public class TestClass : SubTestClass, ITest
    {

        public TestClass(string test)
        {

        }

        public string Name { get; set; }


    }

    [ExposeClass(Context = ConstantsCore.Plugin)]
    public abstract class SubTestClass : IInjectBuilder
    {

        public Type Type => throw new NotImplementedException();

        public bool CanExecute(object context)
        {
            throw new NotImplementedException();
        }

        public object Run(object context)
        {
            throw new NotImplementedException();
        }

    }

    public abstract class SubTestClass2 : IInjectBuilder
    {

        public abstract Type Type { get; }

        public abstract bool CanExecute(object context);

        public abstract object Run(object context);

    }

    public interface ITest
    {

        string Name { get; set; }

    }

}
