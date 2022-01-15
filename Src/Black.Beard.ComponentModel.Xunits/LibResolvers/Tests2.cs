using System;
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

    public sealed class Tests2
    {


        [Fact]
        public void Constructor_DataIsNull_ThrowsArgumentNullException()
        {

            var items = ExposedTypes.Instance
                .GetTypes(ConstantsCore.Initialization, typeof(IInjectBuilder<MyContext>))
                .Where(c => typeof(IInjectBuilder<MyContext>).IsAssignableFrom(c.Key))
                .ToList()
                ;

            items.FirstOrDefault()
                .Should()
                .NotBeNull()
                ;

            var ctx = new MyContext();
            foreach (var item in items)
            {
                var instance = (IInjectBuilder<MyContext>)Activator.CreateInstance(item.Key);
                instance.Run(ctx);
            }

            ctx.Test.Should().BeTrue();

        }


        [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder<MyContext>))]
        public class InjectBuilder : IInjectBuilder<MyContext>
        {

            public Type Type => typeof(MyContext);


            public object Run(object context)
            {
                return Run((MyContext)context);
            }

            public object Run(MyContext context)
            {
                context.Test = true;
                // do action
                return null;
            }

        }

        public class MyContext
        {

            public bool Test { get; set; }

        }

    }

}
