using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Factories;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.TypeDiscoveries
{
    public sealed class Tests
    {

        [Fact]
        public void Constructor_Factory1()
        {


            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();



        }


    }
}
