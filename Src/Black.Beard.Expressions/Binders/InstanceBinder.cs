using System;
using System.ComponentModel;
using Bb.Accessors;

namespace Bb.Binders
{


    /// <summary>
    /// Create a binding between a source and a target.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public class InstanceBinder<TSource, TTarget> : IDisposed
        where TSource : class, INotifyPropertyChanged
        where TTarget : INotifyPropertyChanged
    {


        /// <summary>
        /// Creates a new instance of <see cref="InstanceBinder{TSource, TTarget}"/>.
        /// </summary>
        /// <param name="configuration">The configuration used to bind properties between the source and target. Must not be null.</param>
        /// <remarks>
        /// This constructor initializes the binder with the specified property binding configuration.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var configuration = new PropertyBinder&lt;SourceClass, TargetClass&gt;();
        /// var binder = new InstanceBinder&lt;SourceClass, TargetClass&gt;(configuration);
        /// </code>
        /// </example>
        public InstanceBinder(PropertyBinder<TSource, TTarget> configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Binds the source object to the target object.
        /// </summary>
        /// <param name="source">The source object to bind. Must implement <see cref="INotifyPropertyChanged"/>.</param>
        /// <param name="target">The target object to bind. Can implement <see cref="IDisposed"/> for cleanup.</param>
        /// <remarks>
        /// This method establishes a binding between the source and target objects, allowing property changes in the source to be reflected in the target.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the source or target is null.
        /// </exception>
        /// <example>
        /// <code lang="C#">
        /// var source = new SourceClass();
        /// var target = new TargetClass();
        /// var configuration = new PropertyBinder&lt;SourceClass, TargetClass&gt;();
        /// var binder = new InstanceBinder&lt;SourceClass, TargetClass&gt;(configuration);
        /// binder.Bind(source, target);
        /// </code>
        /// </example>
        public void Bind(TSource source, TTarget target)
        {

            this._source = source ?? throw new ArgumentNullException(nameof(source), "Source cannot be null.");
            this._target = target ?? throw new ArgumentNullException(nameof(target), "Target cannot be null.");

            this._source.PropertyChanged += _source_PropertyChanged;
            _sourceReader = AccessorItem.GetPropertiesImpl(typeof(TSource), MemberStrategy.Direct | MemberStrategy.Instance | MemberStrategy.Properties, null, null);
            if (_source is IDisposed disposed1)
                disposed1.Disposed += Source_Disposed;


            if (_target is IDisposed disposed2)
                disposed2.Disposed += Target_Disposed;

        }

        /// <summary>
        /// Occurs when the binder is disposed.
        /// </summary>
        public event DisposedEventHandler? Disposed;


        /// <summary>
        /// Disposes the binder and releases associated resources.
        /// </summary>
        /// <remarks>
        /// This method un-subscribes from events and cleans up resources associated with the binder.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// binder.Dispose();
        /// </code>
        /// </example>
        public void Dispose()
        {
            Dispose(true);
        }


        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_source != null)
                {

                    _source.PropertyChanged -= _source_PropertyChanged;

                    if (_source is IDisposed disposed1)
                        disposed1.Disposed -= Source_Disposed;

                    if (_target is IDisposed disposed2)
                        disposed2.Disposed -= Target_Disposed;

                    Disposed?.Invoke(this, EventArgs.Empty);

                }

                IsDisposed = true;

            }
        }

        private void Source_Disposed(object? sender, EventArgs e)
        {
            Dispose();
        }

        private void Target_Disposed(object? sender, EventArgs e)
        {
            Dispose();
        }



        private void _source_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {

            if (_sourceReader != null
                && _source != null
                && _target != null
                && !string.IsNullOrEmpty(e.PropertyName)
                && _configuration.TryGet(e.PropertyName, out var action) && action != null)
            {

                var src = _sourceReader[e.PropertyName];

                if (src == null)
                    throw new InvalidOperationException($"Property '{e.PropertyName}' not found in source type '{typeof(TSource).Name}'.");

                if (src.GetValue == null)
                    throw new InvalidOperationException($"Property '{e.PropertyName}' is null in source type '{typeof(TSource).Name}'.");

                action(_target, src.GetValue(_source));
            }
        }


        /// <summary>
        /// Indicates whether the binder has been disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if the binder is disposed; otherwise, <c>false</c>.
        /// </value>
        /// <remarks>
        /// This property indicates the disposal state of the binder.
        /// </remarks>
        public bool IsDisposed { get; private set; }

        private INotifyPropertyChanged? _source;
        private readonly PropertyBinder<TSource, TTarget> _configuration;
        private AccessorList? _sourceReader;
        private TTarget? _target;

    }

}

