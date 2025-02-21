﻿using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using Bb.Injections;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Initializers
{

    public class ClassTest
    {

        [Fact]
        public void TestFolder()
        {

            var i = new Initializer();
            i.AddFolder("configs", "c:\\test");
            i.GetFolderKeys.Count().Should().Be(1);
            var key = i.GetFolderKeys.First();
            key.Should().BeSameAs("configs");
            i.TryGetFolders(key, out var l).Should().BeTrue();
            l.Contains("c:\\test").Should().BeTrue();

            i.DelFolder("configs", "c:\\test");
            i.GetFolderKeys.Count().Should().Be(0);

            i.AddFolder("configs", "c:\\test");
            i.DelFolder("c:\\test");
            i.GetFolderKeys.Count().Should().Be(0);

            i.AddFolder("configs", "c:\\test");
            i.ContainsFolder("configs", "c:\\test").Should().BeTrue();
            i.ContainsFolder("c:\\test").Should().BeTrue();

        }

        [Fact]
        public void TestKey()
        {

            var i = new Initializer();
            i.AddOrReplace("Test", "Toto");
            i.GetKeys.Count().Should().Be(1);
            var key = i.GetKeys.First();
            key.Should().BeSameAs("Test");
            i.TryGetValue(key, out var n).Should().BeTrue();
            n.Should().BeSameAs("Toto");

            i.RemoveKey("Test");
            i.GetKeys.Count().Should().Be(0);

            i.AddOrReplace("Test", "Toto");
            i.RemoveKey("Test");
            i.GetKeys.Count().Should().Be(0);

            i.AddOrReplace("Test", "Toto");
            i.ContainsKey("Test").Should().BeTrue();

        }


            [Fact]
        public void TestNull()
        {

            var i = Initializer.Initialize();

        }

        [Fact]
        public void Test0()
        {

            var i = Initializer.Initialize(null
            , d =>
            {
                d.WithInjectValue((name) => name == "param4" ? "Toto=45" : null)
                ;
            },
            e =>
            {
                if (e is InitializerTest t)
                {
                    t.param4.Count.Should().Be(1);
                    t.param4["toto"].Should().Be("45");
                }
            }
            , "--param1:test", "--param3:6");


            i.GetKeys.Count().Should().Be(1);
            var key = i.GetKeys.First();
            key.Should().BeSameAs("Test");
            i.TryGetValue(key, out var n).Should().BeTrue();
            n.Should().BeSameAs("Toto");


            i.GetFolderKeys.Count().Should().Be(1);
            key = i.GetFolderKeys.First();
            key.Should().BeSameAs("configs");
            i.TryGetFolders(key, out var l).Should().BeTrue();
            l.Contains("c:\\test").Should().BeTrue();

        }

        [Fact]
        public void Test1()
        {

            bool ok = false;
            Initializer.Initialize(null,
            c =>
            {

            },
            d =>
            {
                if (d is InitializerTest t)
                {
                    t.param1.Should().Be("test");
                    t.ToInject.Should().NotBeNull();
                    ok = true;
                }
            }, "--param1:test");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test2()
        {

            bool ok = false;
            Initializer.Initialize(null,
            c =>
            {

            },
            d =>
            {
                if (d is InitializerTest t)
                {
                    t.param2.Should().BeTrue();
                    t.ToInject.Should().NotBeNull();
                    ok = true;
                }
            },
            "--param2:true");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test3()
        {

            bool ok = false;
            Initializer.Initialize(null,
            c =>
            {

            },
            d =>
            {
                if (d is InitializerTest t)
                {
                    t.param3.Should().Be(6);
                    t.ToInject.Should().NotBeNull();
                    ok = true;
                }
            },
            "--param3:6");

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test4()
        {

            bool ok = false;
            Initializer.Initialize(null,
            c =>
            {

            },
            d =>
            {
                if (d is InitializerTest t)
                {
                    t.ToInject.Should().NotBeNull();
                    t.ToInject2.Should().NotBeNull();
                    ok = true;
                }
            });

            ok.Should().BeTrue();

        }

        [Fact]
        public void Test5()
        {

            bool ok = false;
            Initializer.Initialize(null,
            c =>
            {

            },
            d =>
            {
                if (d is InitializerTest t)
                {
                    t.ToInject.Should().NotBeNull();
                    t.ToInject2.Should().NotBeNull();
                    ok = true;
                }
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

            context.AddOrReplace("Test", "Toto");
            context.AddFolder("configs", "c:\\test");

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
