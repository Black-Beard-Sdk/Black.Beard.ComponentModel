using Bb.TypeDescriptors;
using FluentAssertions;
using System.ComponentModel;
using Xunit;

namespace DynamicDescriptors.Tests.DynamicProperties
{
    public sealed class ConfigurationDescriptorRepositoryTests
    {
        [Fact]
        public void AddPRopertyIf()
        {


            var config = DynamicTypeDescriptionProvider.Configuration;

            config.Add<ExampleType>(c =>
            {

                c.AddProperty("Index", typeof(int), p =>
                {
                    p.DefaultValue(3);
                });

            }, f =>
            {
                return f.Type == "Make1";
            });

            var instance = new ExampleType() { Type = "Make1" };


            var p = TypeDescriptor.GetProperties(instance);
            var property = p["Index"];
            property.GetValue(instance).Should().Be(3);

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




}
