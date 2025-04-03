using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.ComponentModel.Loaders;
using FluentAssertions;
using ICSharpCode.Decompiler.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xunit;

namespace DynamicDescriptors.Tests
{



    public sealed class ReflexionTest
    {


        [Fact]
        public void TestIsSystemDirectory()
        {
            var test = AssemblyDirectoryResolver.Instance.IsInSystemDirectory(new FileInfo(typeof(ReflexionTest).Assembly.Location).Directory);
            Assert.False(test);
        }

        [Fact]
        public void TestIsSystemDirectory2()
        {
            var ass = typeof(object).Assembly;
            var test = AssemblyDirectoryResolver
                .Instance
                .IsInSystemDirectory(new FileInfo(ass.Location).Directory);
            Assert.True(test);
        }

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

        //[Fact]
        //public void ResolveActivitySource()
        //{
        //    var names = DiagnosticProviderExtensions.GetActivityNames().ToArray();
        //    var test = names.Any();
        //    Assert.True(test);
        //}

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

            var item0 = new AddonsResolver(directories)
                .SearchAssemblies()
                  .FirstOrDefault();

            var item01 = new AddonsResolver(directories)
                    .WithReference(typeof(ExposeClassAttribute))
                    .SearchAssemblies()
                    .EnsureIsLoaded()
                      //.FirstOrDefault()
                      ;

            var item1 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .SearchTypes()
                    .First();

            var item2 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .WithBaseType(typeof(SubTestClass))
                    .SearchTypes()
                    .First();

            var item3 = new AddonsResolver(directories)
                    .InContext(ConstantsCore.Plugin)
                    .Implements(typeof(IInjectBuilder))
                    .SearchTypes()
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

            var instance = new UITest();

            var serviceProvider = new LocalServiceProvider();

            var loader = new InjectionLoader<UITest>(ConstantsCore.Plugin + "Test", serviceProvider);

            loader.LoadModules(c =>
            {

            }, d => { }).Execute(instance);

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
        public void FilterTest52()
        {

            var types = TypeDiscovery.Instance
                .Search(c =>
                {

                    var o = c.WithReference(typeof(IInjectBuilder))
                             .SearchListReferences(typeof(ReflexionTest).Assembly)
                             .Where(x => !x.IsSystemDirectory && !x.IsSdk)
                             .ToList();

                    Assert.True(o.Count() == 2);

                    c.AddRestrictAssemblies(o)
                     .InContext(ConstantsCore.Plugin)
                     .Implements(typeof(IInjectBuilder))
                     ;

                }).ToList();

            Assert.Single(types);

        }


        [Fact]
        public void FilterTest53()
        {

            var o = new AddonsResolver(AssemblyDirectoryResolver.Instance)
                .WithFile(c => !c.InSystemDirectory())
                .WithReference(typeof(IInjectBuilder))
                .WhereAssembly(c => !c.IsSdk())
                .SearchListReferences(typeof(ReflexionTest).Assembly)
                .ToList();

            Assert.True(o.Count() == 2);

        }

        [Fact]
        public void FilterTest54()
        {

            //var pp = typeof(System.Configuration.Configuration).Assembly.Location;

            var root = new FileInfo(typeof(ReflexionTest).Assembly.Location).Directory.FullName;
            var p = new AssemblyMatched()
            {
                AssemblyLocation = new FileInfo(Path.Combine(root, "System.Configuration.ConfigurationManager" + ".dll")),
            };

            p.Load();

            p.Assembly.Should().NotBeNull();

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
        public void GetLoadedAssembliesTest()
        {

            var dic = TypeDiscovery.Instance.GetLoadedAssemblies().ToList();

            foreach (var item in AppDomain.CurrentDomain.GetAssemblies())
                if (dic.Contains(item.FullName))
                    Assert.True(true);
                else
                    Assert.True(false, $"assembly {item.FullName} not found");

        }

        [Fact]
        public void Test()
        {


            var item = typeof(ReflexionTest).Assembly.Location;

            var items = new AddonsResolver()
                .SearchListReferences(item)
                ;

            var pp = items.Where(c => !c.IsLoaded && !c.IsSdk).ToList();

            Assert.True(pp.Count < 5);

        }

    }

    [ExposeClass(Context = ConstantsCore.Plugin + "Test")]
    public class TestClass3 : InjectBuilder<UITest>
    {

        public override object Execute(UITest context)
        {
            return null;
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

        public string FriendlyName => GetType().Name;

        public bool CanExecute(object context)
        {
            throw new NotImplementedException();
        }

        public object Execute(object context)
        {
            throw new NotImplementedException();
        }

    }

    public abstract class SubTestClass2 : IInjectBuilder
    {

        public string FriendlyName => GetType().Name;

        public abstract Type Type { get; }

        public abstract bool CanExecute(object context);

        public abstract object Execute(object context);

    }

    public interface ITest
    {

        string Name { get; set; }

    }


    public class UITest
    {

    }


}
