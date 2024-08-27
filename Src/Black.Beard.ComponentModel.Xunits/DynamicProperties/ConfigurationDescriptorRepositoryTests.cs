using Bb.TypeDescriptors;
using FluentAssertions;
using System.ComponentModel;
using Xunit;

namespace DynamicDescriptors.Tests.DynamicProperties
{
    public sealed class ConfigurationDescriptorRepositoryTests
    {

        [Fact]
        public void AddPropertyIfOnInstance()
        {

            var instance = new ExampleType() { Type = "Make1" };

            var provider = DynamicTypeDescriptionProvider.Configure(instance, c =>
            {

                c.AddProperty("Index", typeof(int), p =>
                {
                    p.DefaultValue(3);
                });

            }, f =>
            {
                return f.Type == "Make1";
            });



            var p = TypeDescriptor.GetProperties(instance);
            var property = p["Index"];
            property.GetValue(instance).Should().Be(3);

            property = p["Type"];
            property.GetValue(instance).Should().Be("Make1");


            p = TypeDescriptor.GetProperties(instance);
            property = p["Index"];
            property.Should().Be(3);

            provider.Dispose(); 

        }


        [Fact]
        public void AddPropertyIfOnType()
        {

            var provider = DynamicTypeDescriptionProvider<ExampleType>.InstanceType.Configure(c =>
            {

                c.AddProperty("Index", typeof(int), p =>
                {
                    p.DefaultValue(3);
                });

            }, f =>
            {
                return f.Type == "Make1";
            });

            var p = TypeDescriptor.GetProperties(typeof(ExampleType));

            provider.Dispose();

            var instance = new ExampleType() { Type = "Make1" };
            var property = p["Index"];
            property.Should().BeNull();


        }


    }

    public class ExampleType : IDynamicDescriptorInstance
    {

        public ExampleType()
        {
            this._container = new DynamicDescriptorInstanceContainer(this);
        }

        public string Type { get; set; }

        public object GetProperty(string name) => this._container.GetProperty(name);

        public void SetProperty(string name, object value) => this._container.SetProperty(name, value);

        private readonly DynamicDescriptorInstanceContainer _container;

    }



}
