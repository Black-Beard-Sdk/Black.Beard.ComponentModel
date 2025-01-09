using Bb.ComponentModel.Loaders;
using FluentAssertions;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.Initializers
{
    public class CommandLineParserTest
    {

        [Fact]
        public void Test1()
        {

            new CommandLineParser("--param1:test").GetValueString("param1").Should().Be("test");
            new CommandLineParser("--param2:true").GetValue<bool>("param2").Should().BeTrue();
            new CommandLineParser("--param3:10").GetValue<int>("param3").Should().Be(10);
            new CommandLineParser("--param3:-10").GetValue<int>("param3").Should().Be(-10);
            new CommandLineParser("--param3:10.4").GetValue<decimal>("param3").Should().Be(10.4M);

            new CommandLineParser("--param1=test").GetValueString("param1").Should().Be("test");
            new CommandLineParser("--param2=true").GetValue<bool>("param2").Should().BeTrue();
            new CommandLineParser("--param3=10").GetValue<int>("param3").Should().Be(10);
            new CommandLineParser("--param3=-10").GetValue<int>("param3").Should().Be(-10);
            new CommandLineParser("--param3=10.4").GetValue<decimal>("param3").Should().Be(10.4M);

            new CommandLineParser("--param1", "test").GetValueString("param1").Should().Be("test");
            new CommandLineParser("--param2", "true").GetValue<bool>("param2").Should().BeTrue();
            new CommandLineParser("--param3", "10").GetValue<int>("param3").Should().Be(10);
            new CommandLineParser("--param3", "-10").GetValue<int>("param3").Should().Be(-10);
            new CommandLineParser("--param3", "10.4").GetValue<decimal>("param3").Should().Be(10.4M);

            new CommandLineParser("--param1").GetValueString("param1").Should().BeNull();
            new CommandLineParser("-param1").Contains("param1").Should().BeTrue();

        }


    }


}
