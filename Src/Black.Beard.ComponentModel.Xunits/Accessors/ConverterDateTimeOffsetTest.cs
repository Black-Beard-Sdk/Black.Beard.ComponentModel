﻿using Bb.ComponentModel.Accessors;
using Bb.Expressions;
using System;
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
            Assert.Equal(list1, list2);

            list1 = typeof(Cls1).GetAccessors(AccessorStrategyEnum.ConvertSettingIfDifferent);
            Assert.NotEqual(list1, list2);

            list2 = typeof(Cls1).GetAccessors(AccessorStrategyEnum.ConvertSettingIfDifferent);
            Assert.Equal(list1, list2);

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

            var list = typeof(Cls1).GetAccessors(AccessorStrategyEnum.ConvertSettingIfDifferent);

            list[nameof(Cls1.Name)].SetValue(cls, expected);

            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

        }


        [Fact]
        public void Test3()
        {

            Guid expected = Guid.NewGuid();

            var cls = new Cls1() { };

            var list = typeof(Cls1).GetAccessors(AccessorStrategyEnum.Direct);

            list[nameof(Cls1.Name)].ConvertBeforeSettingValue(cls, expected);

            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

        }


        [Fact]
        public void Test4()
        {

            string expected = Guid.NewGuid().ToString();

            var cls = new Cls2() { };

            var list = typeof(Cls2).GetAccessors(AccessorStrategyEnum.Direct);

            list[nameof(Cls2.Name)].SetValue(cls, expected);
            var value = list[nameof(Cls1.Name)].GetValue(cls);

            Assert.Equal(expected.ToString(), value);

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


}