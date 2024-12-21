using Bb.ComponentModel.Accessors;
using System;
using System.Linq;
using Xunit;

namespace Black.Beard.Accessors
{


    public class ConverterDateTimeOffsetTest
    {

        [Fact]
        public void Test0()
        {

            var list1 = typeof(Cls1).GetAccessors();
            var list2 = typeof(Cls1).GetAccessors();
            Assert.Equal(list1, list1);

            list1 = typeof(Cls1).GetAccessors(MemberStrategy.ConvertIfDifferent);
            Assert.NotEqual(list1, list1);

            list2 = typeof(Cls1).GetAccessors(MemberStrategy.ConvertIfDifferent);
            Assert.Equal(list1, list1);

        }

        [Fact]
        public void Test1()
        {

            string expected = Guid.NewGuid().ToString();

            var cls = new Cls1() { };

            var list = typeof(Cls1).GetAccessors();

            list[nameof(Cls1.Name)].SetValue(cls, expected);

            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected, value);

        }

        [Fact]
        public void Test2()
        {

            Guid expected = Guid.NewGuid();

            var cls = new Cls1() { };

            var list = typeof(Cls1).GetAccessors(MemberStrategy.ConvertIfDifferent);

            list[nameof(Cls1.Name)].SetValue(cls, expected);

            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

        }

        [Fact]
        public void Test3()
        {

            Guid expected = Guid.NewGuid();

            var cls = new Cls1() { };

            var list = typeof(Cls1).GetAccessors(MemberStrategy.Direct);

            list[nameof(Cls1.Name)].ConvertBeforeSettingValue(cls, expected);

            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

        }

        [Fact]
        public void Test4()
        {

            string expected = Guid.NewGuid().ToString();

            var cls = new Cls2() { };

            var list = typeof(Cls2).GetAccessors(MemberStrategy.Direct);

            list[nameof(Cls2.Name)].SetValue(cls, expected);
            var value = list[nameof(Cls2.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

        }

        [Fact]
        public void Test5()
        {

            string expected = Guid.NewGuid().ToString();

            var cls = new Cls3() { };

            var list = typeof(Cls3).GetAccessors(MemberStrategy.Direct);
            var item = list[nameof(Cls3.Name)];
            Assert.Null(item.SetValue);

        }

        [Fact]
        public void Test6()
        {

            string expected = Guid.NewGuid().ToString();

            var cls = new Cls4() { };

            var list = typeof(Cls4).GetAccessors(MemberStrategy.Direct);
            var item = list[nameof(Cls3.Name)];
            Assert.Null(item);

        }

    }

    public class Cls1
    {

        public string Name { get; set; }

    }

    public class Cls2
    {

        public string Name;

    }

    public class Cls3
    {

        public string Name { get; }

    }

    public class Cls4
    {

        public string this[string item]
        {
            get { return _name; }
            set { _name = null; }
        }


        private string _name = null;

    }

}
