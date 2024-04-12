using Bb.ComponentModel.Attributes;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Xunit;

namespace Black.Beard.ComponentModel.Xunits.ProviderList
{

    public class UnitTest
    {

        [Fact]
        public void Test1()
        {

            var class1 = new Class1()
            {
                Culture = CultureInfo.CurrentCulture,
            };

            var property = typeof(Class1).GetPropertyDescriptors("Culture").First();
            var attribute = property.GetAttribute<ListProviderAttribute>();
            var provider = (CultureProviderList)attribute.GetProvider(property, class1);
            var items = provider.GetItems();

            var current = items.First(c => c.Tag.IetfLanguageTag == CultureInfo.CurrentCulture.IetfLanguageTag);

            var current1 = items.First(c => c.Selected);


            var f = items.First();

            var t1 = current1.Compare(CultureInfo.CurrentCulture);
            var t2 = current1.Compare(current);
            var t3 = current1.Compare(f);
            var t4 = current1.Compare(null);
            var t5 = current1.Compare(CultureInfo.InvariantCulture);

            Assert.True(t1);
            Assert.True(t2);
            Assert.False(t3);
            Assert.False(t4);
            Assert.False(t5);

            var a = f.GetOriginalValue();


        }

    }



    public class Class1
    {

        [ListProvider(typeof(CultureProviderList))]
        public CultureInfo Culture { get; set; }

    }

    public enum Enum1
    {
        Value1,
        Value2,
        Value3,
    }


}
