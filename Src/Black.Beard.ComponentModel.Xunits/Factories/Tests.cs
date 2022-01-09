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
        public void Constructor_Factory1()
        {
            var factory = ObjectCreator.GetActivatorByTypeAndArguments<object>(typeof(Test1), typeof(string), typeof(int));
            Test1 result = (Test1)factory.Call(null, "t1", 1);
            result.Arg1.Should().Be("t1");
        }


        [Fact]
        public void Constructor_Factory2()
        {
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(typeof(string), typeof(int));
            Test1 result = factory.Call(null, "t2", 1);
            result.Arg1.Should().Be("t2");
        }

        [Fact]
        public void ResolveTypes()
        {
            var types = ObjectCreator.ResolveTypesOfArguments("t2", 1);
            var factory = ObjectCreator.GetActivatorByArguments<Test1>(types);
            Test1 result = factory.Call(null, "t2", 1);
            result.Arg1.Should().Be("t2");
        }

        private class Test1
        {

            public Test1(string arg1, int arg2)
            {
                this.Arg1 = arg1;
                this.Arg2 = arg2;
            }

            public string Arg1 { get; }

            public int Arg2 { get; }

        }


    }
}
