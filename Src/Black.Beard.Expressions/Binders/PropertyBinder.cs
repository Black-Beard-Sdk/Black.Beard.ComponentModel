using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Bb.Expressions;

namespace Bb.Binders
{

    /// <summary>
    /// Creates a binding between a source and a target.
    /// </summary>
    /// <typeparam name="TTarget"></typeparam>
    public class PropertyBinder<TTarget>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBinder{TTarget}"/> class.
        /// </summary>
        /// <remarks>
        /// This constructor initializes the internal dictionary used to store property bindings.
        /// </remarks>
        public PropertyBinder()
        {
            this._dic = new Dictionary<string, Action<TTarget, object>>();
        }

        #region parameters

        /// <summary>
        /// Clears all property bindings from the binder.
        /// </summary>
        /// <remarks>
        /// This method removes all entries from the internal dictionary of property bindings.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;TargetClass&gt;();
        /// binder.Clear();
        /// </code>
        /// </example>
        public void Clear()
        {
            _dic.Clear();
        }

        /// <summary>
        /// Clears the binding for a specific property.
        /// </summary>
        /// <param name="propertyName">The name of the property whose binding should be removed. Must not be null or empty.</param>
        /// <remarks>
        /// This method removes the binding for the specified property if it exists in the internal dictionary.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;TargetClass&gt;();
        /// binder.Clear("MyProperty");
        /// </code>
        /// </example>
        public void Clear(string propertyName)
        {
            if (_dic.ContainsKey(propertyName))
                _dic.Remove(propertyName);
        }

        /// <summary>
        /// Binds a property from the source object to an action on the target object.
        /// </summary>
        /// <typeparam name="TSource">The type of the source object. Must implement <see cref="INotifyPropertyChanged"/>.</typeparam>
        /// <param name="expression">An expression identifying the property to bind. Must not be null.</param>
        /// <param name="action">The action to execute on the target object when the property changes. Must not be null.</param>
        /// <remarks>
        /// This method creates a binding between a property of the source object and an action to execute on the target object.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;TargetClass&gt;();
        /// binder.Bind&lt;SourceClass&gt;(x => x.MyProperty, (target, value) => target.Update(value));
        /// </code>
        /// </example>
        public void Bind<TSource>(Expression<Func<TSource, object>> expression, Action<TTarget, object> action)
            where TSource : class, INotifyPropertyChanged
        {
            var propertyName = expression.GetPropertyName();
            if (string.IsNullOrEmpty(propertyName))
                throw new InvalidOperationException(nameof(propertyName));
            Bind(propertyName, action);
        }

        /// <summary>
        /// Binds a property by its name to an action on the target object.
        /// </summary>
        /// <param name="propertyName">The name of the property to bind. Must not be null or empty.</param>
        /// <param name="action">The action to execute on the target object when the property changes. Must not be null.</param>
        /// <remarks>
        /// This method creates or updates a binding for the specified property, associating it with the provided action.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;TargetClass&gt;();
        /// binder.Bind("MyProperty", (target, value) => target.Update(value));
        /// </code>
        /// </example>
        public void Bind(string propertyName, Action<TTarget, object> action)
        {
            if (!_dic.TryGetValue(propertyName, out var a))
                _dic[propertyName] = action;
            else
                _dic[propertyName] = (o, t) =>
                {
                    a(o, t);
                    action(o, t);
                };
        }

        #endregion parameters

        /// <summary>
        /// Attempts to retrieve the action associated with a specific property binding.
        /// </summary>
        /// <param name="propertyName">The name of the property to retrieve the binding for. Must not be null or empty.</param>
        /// <param name="action">The action associated with the property, or <c>null</c> if no binding exists.</param>
        /// <returns>
        /// <c>true</c> if a binding exists for the specified property; otherwise, <c>false</c>.
        /// </returns>
        /// <remarks>
        /// This method checks if a binding exists for the specified property and retrieves the associated action if found.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var binder = new PropertyBinder&lt;TargetClass&gt;();
        /// if (binder.TryGet("MyProperty", out var action))
        /// {
        ///     Console.WriteLine("Binding found.");
        /// }
        /// else
        /// {
        ///     Console.WriteLine("No binding found.");
        /// }
        /// </code>
        /// </example>
        internal bool TryGet(string propertyName, out Action<TTarget, object>? action)
        {
            return _dic.TryGetValue(propertyName, out action);
        }

        private readonly Dictionary<string, Action<TTarget, object>> _dic;

    }

}
