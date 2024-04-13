using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Loaders;
using FluentAssertions;
using ICSharpCode.Decompiler.Semantics;
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
                .Initialize(builder)
                .Configure(builder)
                ;

            builder.Initialized.Should().BeTrue();
            builder.Configured.Should().BeTrue();
            loader.Initialized.Count.Should().Be(1);
            loader.Configured.Count.Should().Be(1);


        }



        public class BuilderTest
        {

            public BuilderTest()
            {
             
            }

            public bool Initialized { get; set; }

            public bool Configured { get; set; }

        }

        [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IApplicationBuilderInitializer<BuilderTest>), LifeCycle =IocScopeEnum.Transiant)]
        public class InitializerTest : IApplicationBuilderInitializer<BuilderTest>
        {
            
            public string FriendlyName { get => GetType().Name; }

            public int OrderPriority => 1;

            public bool Initialized { get ; set; }

            public bool Configured { get; set; }


            public bool CanConfigure(BuilderTest builder, InitializationLoader<BuilderTest> initializer)
            {
                return true;
            }

            public bool CanInitialize(BuilderTest builder, InitializationLoader<BuilderTest> initializer)
            {
                return true;
            }

            public void Configure(BuilderTest builder)
            {
                builder.Configured = true;
            }

            public void Initialize(BuilderTest builder)
            {
                builder.Initialized = true;
            }

        }


    }
}
