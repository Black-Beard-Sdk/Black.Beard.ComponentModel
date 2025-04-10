using Bb.Accessors;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace Black.Beard.Accessors
{

    public class AccessorAttributesTest
    {

        [Fact]
        public void Test0()
        {

            var list1 = typeof(Cls11).GetAccessors();
            var i = list1[nameof(Cls11.Name)];

            var lst1 = i.ContainsAttribute<KeyAttribute>();
            var lst2 = i.ContainsAttribute<KeyAttribute>(new Cls11());

            Assert.True(lst1 && lst2);

        }

        [Fact]
        public void Test1()
        {

            var list1 = typeof(Cls12).GetAccessors(MemberStrategys.Fields);
            var i = list1[nameof(Cls12.Name)];

            var lst1 = i.ContainsAttribute<KeyAttribute>();
            var lst2 = i.ContainsAttribute<KeyAttribute>(new Cls12());

            Assert.True(lst1 && lst2);

        }

        [Fact]
        public void Test2()
        {

            var list1 = typeof(Int32).GetAccessors(MemberStrategys.Static | MemberStrategys.Fields);
            foreach (var item in list1)
            {
                item.GetAttributes().ToList().ForEach(c => Console.WriteLine(c.GetType().Name));
            }

        }

    }


    public class Cls11
    {

        [Key]
        public string Name { get; set; }

    }

    public class Cls12
    {

        [Key]
        public string Name;

    }

}
