using System;
using Bb.ComponentModel;
using Xunit;

namespace ComponentModels.Tests.TypeDiscoveries
{
    public sealed class Tests
    {

        [Fact]
        public void Constructor_Factory1()
        {

            TypeDiscovery.Instance.LoadAssembliesFromFolders(AssemblyDirectoryResolver.Instance.GetDirectories());

            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();
            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();

        }

        [Fact]
        public void Constructor_Factory2()
        {


            TypeDiscovery.Instance.CreateFromWithTypes<object>(typeof(ClassTest), new Type[] { });



        }


        public class ClassTest
        {

            public string Name { get; }


        }


    }



}
