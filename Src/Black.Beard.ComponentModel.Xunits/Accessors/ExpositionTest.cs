using Bb.ComponentModel.Accessors;
using Xunit;

namespace Black.Beard.Accessors
{
    public class ExpositionTest
    {

        [Fact]
        public void ConvertIfDifferentTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.ConvertIfDifferent);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name)]);
        }

        [Fact]
        public void DirectTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Direct);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name)]);
        }

        [Fact]
        public void InstanceTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Instance);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name)]);
        }

        [Fact]
        public void DefaultTest()
        {
            var list1 = typeof(Cls5).GetAccessors();
            Assert.Equal(2, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name)]);
            Assert.NotNull(list1[nameof(Cls5.Name2)]);
        }

        [Fact]
        public void StaticTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Static);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name2)]);
        }

        [Fact]
        public void InstanceFieldTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Fields);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name3)]);
        }

        [Fact]
        public void InstanceFieldStaticTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Fields | MemberStrategy.Static);
            Assert.Equal(1, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name31)]);
        }

        [Fact]
        public void InstanceFieldStaticTest2()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Fields | MemberStrategy.Static | MemberStrategy.NotPublicFields);
            Assert.Equal(3, list1.Count);
            Assert.NotNull(list1["Name31"]);
            Assert.NotNull(list1["Name8"]);
        }

        [Fact]
        public void InstanceFieldPrivateTest()
        {
            var list1 = typeof(Cls5).GetAccessors(MemberStrategy.Fields | MemberStrategy.NotPublicFields);
            Assert.Equal(6, list1.Count);
            Assert.NotNull(list1[nameof(Cls5.Name3)]);
            Assert.NotNull(list1["Name4"]);
            Assert.NotNull(list1["Name5"]);
            Assert.NotNull(list1["Name7"]);
        }

    }


    public class Cls5
    {

        public string Name { get; set; }

        public static string Name2 { get; set; }

        public string Name3;

        public static string Name31;

        private string Name4;
        internal string Name5;
        private string Name6;
        protected string Name7;

        private static string Name8;

    }

}
