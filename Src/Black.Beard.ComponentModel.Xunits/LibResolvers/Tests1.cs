using System;
using System.Collections.Generic;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.LibResolvers
{

    public sealed class Tests1
    {

        [Fact]
        public void ResolveCase1()
        {

            List<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> items =
                TypeDiscovery.Instance.GetExposedTypes("test1111", typeof(SubTest1))
                .ToList();

            items
                .Should()
                .NotBeNull()
                ;

        }

        [Fact]
        public void ResolveCase2()
        {

            List<KeyValuePair<Type, HashSet<ExposeClassAttribute>>> items =
                TypeDiscovery.Instance.GetExposedTypes("test1112", typeof(ISubTest2))
                .ToList();

            items
                .Should()
                .NotBeNull()
                ;

        }

        [ExposeClass("test1111", ExposedType = typeof(SubTest1), LifeCycle = IocScope.Singleton, Name = "t1")]
        private class SubTest1
        {

        }

        [ExposeClass("test1112", ExposedType = typeof(ISubTest2), LifeCycle = IocScope.Singleton, Name = "t2")]
        private class SubTest2 : ISubTest2
        {

        }

        public interface ISubTest2
        {

        }


    }

}
