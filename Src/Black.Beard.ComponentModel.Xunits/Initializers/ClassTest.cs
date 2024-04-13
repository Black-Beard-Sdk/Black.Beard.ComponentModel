﻿using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using FluentAssertions;
using FluentAssertions.Execution;
using ICSharpCode.Decompiler.Semantics;
using NJsonSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Initializers
{
    public class ClassTest
    {

        [Fact]
        public void Test1()
        {

            var builder = new BuilderTest();

            var loader = new InitializationLoader<BuilderTest>()
                .LoadModules()
                .Execute(builder)
                ;

            builder.Ran.Should().BeTrue();
            builder.Ran.Should().BeTrue();
            loader.Executed.Count.Should().Be(1);

        }

        [Fact]
        public void GenerateSchema()
        {
            var schema = JsonSchema.FromType<ExposedAssemblyRepositories>();
            var schemaData = schema.ToJson();
        }

        public class BuilderTest
        {

            public BuilderTest()
            {
             
            }

            public bool Ran { get; set; }


        }

        [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IApplicationBuilderInitializer<BuilderTest>), LifeCycle =IocScopeEnum.Transiant)]
        public class InitializerTest : IApplicationBuilderInitializer<BuilderTest>
        {
            
            public string FriendlyName { get => GetType().Name; }

            public int OrderPriority => 1;

            public bool Initialized { get ; set; }

            public bool Configured { get; set; }

            public bool CanExecute(BuilderTest builder, InitializationLoader<BuilderTest> initializer)
            {
                return true;
            }

            public void Execute(BuilderTest builder)
            {
                builder.Ran = true;
            }

        }


    }
}
