using Bb;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.Diagnostics;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace DynamicDescriptors.Tests
{


    public sealed class ReflexionTest
    {


        [Fact]
        public void ResolveDirectory()
        {

            var directories = new AssemblyDirectoryResolver();


            AssemblyDirectoryResolver.Instance
                .AddDirectoryFromFiles(typeof(TestClass).Assembly.Location);

            TypeDiscovery.Initialize();

        }


        [Fact]
        public void FilterStatic()
        {
            var types = TypeDiscovery.Instance.GetStaticTypes().Any();
            Assert.True(types);
        }


        //[Fact]
        //public void ResolveMeterSource()
        //{
        //    var names = DiagnosticProviderExtensions.GetMeterNames().ToArray();
        //    var test = names.Any();
        //    Assert.True(test);
        //    ComponentModelMetricProvider.Counter.Add(1);
        //}


        [Fact]
        public void ResolveActivitySource()
        {
            var names = DiagnosticProviderExtensions.GetActivityNames().ToArray();
            var test = names.Any();
            Assert.True(test);
        }


        [Fact]
        public void ResolveActivitySource2()
        {
                                                                  
            ActivitySource.AddActivityListener(new ActivityListener()
            {
                ShouldListenTo = (activitySource) =>
                {
                    return true;
                },
                ActivityStarted = (activity) => 
                {
                    Console.WriteLine(activity.OperationName);
                },
            });

            TypeDiscovery.Initialize();

            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();

        }

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

            TypeDiscovery.Initialize();

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


        [Fact]
        public void GetLoadedAsseembliesTest()
        {

            var dic = TypeDiscovery.Instance.GetLoadedAssemblies().ToList();

            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
                if (dic.Contains(item.FullName))
                    Assert.True(true);
                else
                    Assert.True(false, $"assembly {item.FullName} not found");

        }


        [Fact]
        public void GetAllAsseembliesTest()
        {

            var dic = TypeDiscovery.Instance.GetAllAssemblies();

            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
                if (dic.ContainsKey(item.FullName))
                    Assert.True(dic[item.FullName].Value);
                else
                    Assert.True(false, $"assembly {item.FullName} not found");


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
