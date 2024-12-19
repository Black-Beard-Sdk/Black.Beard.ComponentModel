using System;
using System.Linq.Expressions;
using Bb.Expressions;

namespace Bb.ComponentModel.Binders
{

    /// <summary>
    /// Property class observer for follow changes of the source instance
    /// </summary>
    /// <typeparam name="TSource">Source type</typeparam>
    /// <typeparam name="TTarget">Target type</typeparam>
    /// <example>
    /// <code lang="csharp">
    /// 
    ///     var source = new ObjectSource();
    ///     var target = new ObjectTarget();
    ///     
    ///     var config = new PropertyBinder&lt;ObjectSource, ObjectTarget&gt;()
    ///         .Bind(c => c.Name, (d, e) => d.Name = e);
    ///     
    ///     var observe = config.Observe(source, target);
    ///     
    ///     source.Name = "toto";
    ///     Assert.Equal("toto", target.Name);
    ///     
    ///     source.Dispose();
    ///     Assert.True(observe.IsDisposed);
    /// 
    /// </code>
    /// </example>
    public class PropertyBinder<TSource, TTarget> : PropertyBinder<TTarget>
        where TSource : class
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBinder{TSource, TTarget}"/> class.
        /// </summary>
        public PropertyBinder()
            : base()
        {

        }

        /// <summary>
        /// Method to bind a property
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="expression"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public PropertyBinder<TSource, TTarget> Bind<TValue>(
            Expression<Func<TSource, TValue>> expression,
            Action<TTarget, TValue> action)
        {
            string propertyName = expression.GetPropertyName();
            Bind(propertyName, (a, b) => action(a, (TValue)b));

            return this;

        }


        /// <summary>
        /// Observe the source and update the target if the source change
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public InstanceBinder<TSource, TTarget> Observe(TSource source, TTarget target)
        {

            var observe = new InstanceBinder<TSource, TTarget>(this);
            observe.Bind(source, target);
            return observe;

        }


    }


}
