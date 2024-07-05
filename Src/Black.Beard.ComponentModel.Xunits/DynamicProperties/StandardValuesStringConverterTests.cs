using System;
using System.Collections.Generic;
using System.Linq;
using Bb.Helpers;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace DynamicDescriptors.Tests.DynamicProperties
{
    public sealed class StandardValuesStringConverterTests
    {
        [Fact]
        public void EnumerableConstructor_ValuesIsNull_DoesNotThrowException()
        {
            Action act = () => new StandardValuesStringConverter(null as IEnumerable<string>);
            act.Should().NotThrow();
        }

        [Fact]
        public void FuncConstructor_ValuesIsNull_DoesNotThrowException()
        {
            Action act = () => new StandardValuesStringConverter(null as Func<string[]>);
            act.Should().NotThrow();
        }

        [Fact]
        public void GetStandardValues_NoValuesFactoryProvided_ReturnsEmptyCollection()
        {
            var converter = new StandardValuesStringConverter(null as Func<string[]>);
            ConvertTo(converter).Should().BeEmpty();

            converter = new StandardValuesStringConverter(null as IEnumerable<string>);
            ConvertTo(converter).Should().BeEmpty();
        }

        [Fact]
        public void GetStandardValues_UsesDeferredExecution()
        {
            var divisor = 1;
            var values = Enumerable.Range(1, 10).Where(i => i % divisor == 0).Select(i => i.ToString());
            var converter = new StandardValuesStringConverter(values);

            divisor = 2;
            ConvertTo(converter).Should().ContainInOrder(new string[] { "2", "4", "6", "8", "10" });

            divisor = 3;
            ConvertTo(converter).Should().ContainInOrder(new string[] { "3", "6", "9" });
        }


        private static string[] ConvertTo(StandardValuesStringConverter converter)
        {
            var items = converter.GetStandardValues();
            if (items != null)
            {
                var array = new string[items.Count];
                items.CopyTo(array, 0);
                return array;
            }

            return null;

        }

    }

}
