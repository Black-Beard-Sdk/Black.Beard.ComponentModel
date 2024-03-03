using System;
using System.ComponentModel;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace DynamicDescriptors.Tests
{




    public sealed class Tests
    {

        [Fact]
        public void Constructor_DataIsNull_ThrowsArgumentNullException()
        {

            GenericTypeDescriptionProvider.Register<ExampleType>();

            var i = (ExampleType)TypeDescriptor.CreateInstance(null, typeof(ExampleType), null, null);
            i.Message.Should().Be("0");

            i = (ExampleType)TypeDescriptor.CreateInstance(null, typeof(ExampleType), new Type[] { typeof(int) }, new object[] { 0 });
            i.Message.Should().Be("1");

            i = (ExampleType)TypeDescriptor.CreateInstance(null, typeof(ExampleType), new Type[] { typeof(string) }, new object[] { "" });
            i.Message.Should().Be("2");

            i = (ExampleType)TypeDescriptor.CreateInstance(null, typeof(ExampleType), new Type[] { typeof(int), typeof(string) }, new object[] { 0, "" });
            i.Message.Should().Be("3");

            i = (ExampleType)TypeDescriptor.CreateInstance(null, typeof(ExampleType), new Type[] { typeof(int), typeof(string), typeof(DateTime) }, new object[] { 0, "", DateTime.Now });
            i.Message.Should().Be("4");



            var provider = TypeDescriptor.GetProvider(typeof(ExampleType));

            i = (ExampleType)provider.CreateInstance(null, typeof(ExampleType), new Type[] { typeof(int), typeof(string) }, new object[] { 0, "" });
            i.Message.Should().Be("3");

            var p = TypeDescriptor.GetProperties(i);
            var property = p[nameof(ExampleType.Message)];

            property.GetValue(i).Should().Be("3");

        }

        private sealed class ExampleType
        {

            public ExampleType()
            {
                this.Message = "0";
            }

            public ExampleType(int arg1)
            {
                this.Message = "1";

            }

            public ExampleType(string arg2)
            {
                this.Message = "2";

            }

            public ExampleType(int arg1, string arg2)
            {
                this.Message = "3";

            }

            public ExampleType(int arg1, string arg2, DateTime arg3)
            {
                this.Message = "4";

            }

            public string Message { get; }

        }

    }
}
