using System;
using System.ComponentModel;
using System.Linq.Expressions;
using Bb.Expressions;

namespace Bb.Binders
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
        where TSource : class, INotifyPropertyChanged
        where TTarget : INotifyPropertyChanged
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBinder{TSource, TTarget}"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the property binder for observing changes in the source and updating the target.
        /// </remarks>
        public PropertyBinder()
            : base()
        {
        }

        /// <summary>
        /// Binds a property from the source object to an action on the target object.
        /// </summary>
        /// <typeparam name="TValue">The type of the property value.</typeparam>
        /// <param name="expression">An expression identifying the property to bind. Must not be null.</param>
        /// <param name="action">The action to execute on the target object when the property changes. Must not be null.</param>
        /// <returns>
        /// The current <see cref="PropertyBinder{TSource, TTarget}"/> instance for method chaining.
        /// </returns>
        /// <remarks>
        /// This method creates a binding between a property of the source object and an action to execute on the target object.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;SourceClass, TargetClass&gt;();
        /// binder.Bind(x => x.PropertyName, (target, value) => target.Update(value));
        /// </code>
        /// </example>
        public PropertyBinder<TSource, TTarget> Bind<TValue>(
            Expression<Func<TSource, TValue>> expression,
            Action<TTarget, TValue> action)
        {
            string propertyName = expression.GetPropertyName();
            Bind(propertyName, (a, b) => action(a, (TValue)b));

            return this;
        }

        /// <summary>
        /// Observes the source object and updates the target object when the source changes.
        /// </summary>
        /// <param name="source">The source object to observe. Must not be null.</param>
        /// <param name="target">The target object to update. Must not be null.</param>
        /// <returns>
        /// An <see cref="InstanceBinder{TSource, TTarget}"/> that manages the binding between the source and target.
        /// </returns>
        /// <remarks>
        /// This method establishes an observation mechanism where changes in the source object are reflected in the target object.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var source = new SourceClass();
        /// var target = new TargetClass();
        /// var binder = new PropertyBinder&lt;SourceClass, TargetClass&gt;();
        /// binder.Bind(x => x.PropertyName, (t, v) => t.Update(v));
        /// var observer = binder.Observe(source, target);
        /// </code>
        /// </example>
        public InstanceBinder<TSource, TTarget> Observe(TSource source, TTarget target)
        {
            var observe = new InstanceBinder<TSource, TTarget>(this);
            observe.Bind(source, target);
            return observe;
        }

    }

}
