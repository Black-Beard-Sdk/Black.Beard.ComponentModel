using Bb.ComponentModel.Accessors;
using Xunit;

namespace Black.Beard.Accessors
{
    public class AttributesTest
    {

        [Fact]
        public void GetAttributesTest()
        {

            var list1 = typeof(Cls5).GetAccessors();
            
            foreach (var item in list1)
            {
                var att = item.GetAttributes();
                Assert.NotNull(att);
            }

        }


    }


}
