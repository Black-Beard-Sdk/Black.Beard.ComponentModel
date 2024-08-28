using System;
using System.ComponentModel;
using Bb.ComponentModel.Accessors;

namespace Bb.ComponentModel.Binders
{


    public class InstanceBinder<TSource, TTarget> : IDisposed
        where TSource : class
    {


        /// <summary>
        /// Create a new instance of <see cref="InstanceBinder{TSource, TTarget}"/>
        /// </summary>
        /// <param name="configuration"></param>
        public InstanceBinder(PropertyBinder<TSource, TTarget> configuration)
        {
            this._configuration = configuration;
        }

        /// <summary>
        /// Bind the source on the target instance
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Bind(TSource source, TTarget target)
        {

            this._source = source as INotifyPropertyChanged;
            this._source.PropertyChanged += _source_PropertyChanged;
            _sourceReader = AccessorItem.Get(typeof(TSource));
            if (_source is IDisposed disposed1)
                disposed1.Disposed += Source_Disposed;


            this._target = target;
            if (_target is IDisposed disposed2)
                disposed2.Disposed += Target_Disposed;


        }

        public event DisposedEventHandler Disposed;


        /// <summary>
        /// instance make to dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }


        private void Dispose(bool disposing)
        {
            if (disposing)
            {

                _source.PropertyChanged -= _source_PropertyChanged;

                if (_source is IDisposed disposed1)
                    disposed1.Disposed -= Source_Disposed;

                if (_target is IDisposed disposed2)
                    disposed2.Disposed -= Target_Disposed;

                if (Disposed != null)
                    Disposed(this, EventArgs.Empty);

                IsDisposed = true;

            }
        }



        private void Source_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Target_Disposed(object sender, EventArgs e)
        {
            Dispose();
        }

        private void _source_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_configuration.TryGet(e.PropertyName, out var action))
                action(_target, _sourceReader[e.PropertyName].GetValue(_source));
        }


        private INotifyPropertyChanged _source;
        private PropertyBinder<TSource, TTarget> _configuration;
        private AccessorList _sourceReader;
        private TTarget _target;

        public bool IsDisposed { get; private set; }

    }

}

