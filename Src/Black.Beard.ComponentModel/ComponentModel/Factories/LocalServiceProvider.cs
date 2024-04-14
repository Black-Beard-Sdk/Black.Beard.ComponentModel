using ICSharpCode.Decompiler.CSharp.Syntax;
using System;
using System.Collections.Generic;

namespace Bb.ComponentModel.Factories
{
    public class LocalServiceProvider : IServiceProvider
    {

        public LocalServiceProvider(IServiceProvider parent = null)
        {
            this._parent = parent;
            this._dic = new Dictionary<Type, Factory>();
        }

        public bool AutoAdd { get; set; }

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

        public LocalServiceProvider Add<T>()
            where T : class
        {
            return Add(ObjectCreatorByIoc.GetActivator<T>());
        }

        public LocalServiceProvider Add<T>(Type type)
            where T : class
        {
            return Add(ObjectCreatorByIoc.GetActivator<T>(type));
        }

        public LocalServiceProvider Add(Factory factory)
        {
            _dic.Add(factory.ExposedType, factory);
            return this;
        }

        private readonly IServiceProvider _parent;
        private readonly Dictionary<Type, Factory> _dic;

    }
}
