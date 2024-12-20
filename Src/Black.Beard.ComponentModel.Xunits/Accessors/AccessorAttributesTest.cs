using Bb.ComponentModel.Accessors;
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

            var lst1 = i.ContainsAttribute<KeyAttribute>(true);
            var lst2 = i.ContainsAttribute<KeyAttribute>(false);

            Assert.True(lst1 && lst2);

        }

        [Fact]
        public void Test1()
        {

            var list1 = typeof(Cls12).GetAccessors();
            var i = list1[nameof(Cls12.Name)];

            var lst1 = i.ContainsAttribute<KeyAttribute>(true);
            var lst2 = i.ContainsAttribute<KeyAttribute>(false);

            Assert.True(lst1 && lst2);

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
