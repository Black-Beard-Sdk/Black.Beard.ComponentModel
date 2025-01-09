using Bb.ComponentModel.Loaders;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{
    public class LocalServiceProvider : IServiceProvider
    {

        public LocalServiceProvider(IServiceProvider parent = null)
        {
            this._parent = parent;
            this._dic = new Dictionary<Type, Factory>();
            this._instances = new Dictionary<Type, object>();
        }

        public bool AutoAdd { get; set; }

        /// <summary>
        /// Get asked service
        /// </summary>
        /// <param name="serviceType">type to append</param>
        /// <returns>return the service</returns>
        public object? GetService(Type serviceType)
        {

            if (this._parent != null)
            {
                var result = this._parent.GetService(serviceType);
                if (result != null)
                    return result;
            }

            if (serviceType == typeof(IServiceProvider))
                return this;

            if (_instances.TryGetValue(serviceType, out var instance))
                return instance;

            if (_dic.TryGetValue(serviceType, out var factory))
                return factory.CallInstance(this);
            
            if (AutoAdd)
            {
                factory = ObjectCreatorByIoc.GetActivator<object>(serviceType);
                _dic.Add(serviceType, factory);
                return factory.CallInstance(this);
            }

            return null;

        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <typeparam name="T">type to append</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public LocalServiceProvider Add<T>()
            where T : class
        {
            return Add(ObjectCreatorByIoc.GetActivator<T>());
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <typeparam name="T">type to append for resolve</typeparam>
        /// <type name="type">implementation of the service</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public LocalServiceProvider Add<T>(Type type)
            where T : class
        {
            return Add(ObjectCreatorByIoc.GetActivator<T>(type));
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <type name="type">type to append for resolve</typeparam>
        /// <type name="instance">instance of the service</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public LocalServiceProvider Add(Type type, object instance)
        {
            _instances.Add(type, instance);
            return this;
        }

        /// <summary>
        /// Add a factory in the service provider
        /// </summary>
        /// <type name="factory">factory to append</typeparam>
        /// <returns><see cref="LocalServiceProvider"/></returns>
        public LocalServiceProvider Add(Factory factory)
        {
            _dic.Add(factory.ExposedType, factory);
            return this;
        }

        private readonly IServiceProvider _parent;
        private readonly Dictionary<Type, Factory> _dic;
        private readonly Dictionary<Type, object> _instances;

    }
}
