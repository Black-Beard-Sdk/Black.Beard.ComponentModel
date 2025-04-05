using System;
using System.Linq;
using Bb.ComponentModel;
using Bb.ComponentModel.Attributes;
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
                var instance = (IInjectBuilder)Activator.CreateInstance(item.Key);
                instance.Execute(ctx);
            }

            ctx.Test.Should().BeTrue();

        }


        [ExposeClass(ConstantsCore.Initialization, ExposedType = typeof(IInjectBuilder<MyContext>))]
        public class InjectBuilder : IInjectBuilder<MyContext>
        {

            public Type Type => typeof(MyContext);

            public string FriendlyName => GetType().Name;

            public bool CanExecute(MyContext context)
            {
                return true;
            }

            public bool CanExecute(object context)
            {
                return CanExecute((MyContext)context);
            }

            public void Execute(object context)
            {
                Execute((MyContext)context);
            }

            public void Execute(MyContext context)
            {
                context.Test = true;
                // do action

            }
        }

        public class MyContext
        {

            public bool Test { get; set; }

        }

    }

}
