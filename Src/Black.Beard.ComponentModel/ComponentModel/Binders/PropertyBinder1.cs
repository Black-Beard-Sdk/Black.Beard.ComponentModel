using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Bb.Expressions;

namespace Bb.ComponentModel.Binders
{


    public class PropertyBinder<TSource, TTarget> : PropertyBinder<TTarget>
        where TSource : class
    {

        public PropertyBinder()
            : base()
        {

        }

        public PropertyBinder<TSource, TTarget> Bind<TValue>(
            Expression<Func<TSource, TValue>> expression,
            Action<TTarget, TValue> action)
        {
            string propertyName = expression.GetPropertyName();
            Bind(propertyName, (a, b) => action(a, (TValue)b));

            return this;

        }


        /// <summary>
        /// Observe the source and for update the target
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
