﻿using System;
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

            TypeDiscovery.Instance.LoadAssembliesFromFolders();

            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();
            TypeDiscovery.Instance.EnsureAllAssembliesAreLoaded();



            //var list = AppDomain.CurrentDomain.GetAssemblies();
            //HashSet<string> visited = new HashSet<string>();
            //foreach (Assembly assembly in list)
            //    if (!visited.Add(assembly.FullName))
            //        throw new Exception("Duplicated");

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
