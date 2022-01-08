﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
using Bb.TypeDescriptors;
using FluentAssertions;
using Xunit;

namespace ComponentModels.Tests.LibResolvers
{
    public sealed class Tests
    {

        [Fact]
        public void Constructor_DataIsNull_ThrowsArgumentNullException()
        {

            ExposedTypes.Instance
                .GetTypes("test1111")
                .Where(c => c.Key == typeof(Test1))
                .FirstOrDefault()
                .Should()
                .NotBeNull()
                ;

        }

        [ExposeClass("test1111", ExposedType = typeof(Test1), LifeCycle = IocScopeEnum.Singleton, Name = "t1")]
        private class Test1
        {

        }


    }
}
