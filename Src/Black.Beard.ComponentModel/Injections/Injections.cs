//using Bb.ComponentModel.Attributes;
//using Bb.ComponentModel.Exceptions;
//using Bb.ComponentModel.Loaders;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Bb.Injections
//{


//    public static class Injections
//    {

//        public static void InjectServices(this TypesToInject self)
//        {

//            IServiceCollection services = self.Builder.Services;

//            // Inject individual types in the ioc
//            foreach (var item in self)
//            {

//                switch (item.LifeCycle)
//                {

//                    case IocScopeEnum.Singleton:
//                        if (item.ImplementationType != null)
//                            services.Add(ServiceDescriptor.Singleton(item.Type, item.ImplementationType));

//                        else if (item.Instance != null)
//                            services.Add(ServiceDescriptor.Singleton(item.Type, item.Instance));

//                        else if (item.Function != null)
//                            services.Add(ServiceDescriptor.Singleton(item.Type, item.Function));

//                        else
//                        {

//                        }
//                        break;

//                    case IocScopeEnum.Scoped:
//                        if (item.ImplementationType != null)
//                            services.Add(ServiceDescriptor.Scoped(item.Type, item.ImplementationType));

//                        else if (item.Instance != null)
//                            services.Add(ServiceDescriptor.Scoped(item.Type, (c) => item.Instance));

//                        else if (item.Function != null)
//                            services.Add(ServiceDescriptor.Scoped(item.Type, item.Function));

//                        else
//                        {

//                        }

//                        break;

//                    case IocScopeEnum.Transiant:
//                    default:

//                        if (item.ImplementationType != null)
//                            services.Add(ServiceDescriptor.Transient(item.Type, item.ImplementationType));

//                        else if (item.Instance != null)
//                            services.Add(ServiceDescriptor.Transient(item.Type, (c) => item.Instance));

//                        else if (item.Function != null)
//                            services.Add(ServiceDescriptor.Transient(item.Type, item.Function));

//                        else
//                        {

//                        }
//                        break;

//                }

//            }

//            return self;

//        }

//    }

//    public class TypesToInject : IEnumerable<TypeToInject>
//    {

//        public TypesToInject()
//        {
//            this._items = new List<TypeToInject>();
//            this._types = new HashSet<Type>();

//        }

//        public bool Add(IocScopeEnum lifeCycle, Type exposedType, Type implementationType)
//        {

//            if (exposedType == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(exposedType)} can't be null");

//            if (implementationType == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(implementationType)} can't be null");

//            if (this._types.Add(exposedType))
//            {
//                var instance = new TypeToInject()
//                {
//                    LifeCycle = lifeCycle,
//                    Type = exposedType,
//                    ImplementationType = implementationType,
//                };

//                _items.Add(instance);

//                return true;

//            }

//            return false;


//        }

//        public bool Add(IocScopeEnum lifeCycle, Type exposedType, Func<IServiceProvider, object> func)
//        {

//            if (exposedType == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(exposedType)} can't be null");

//            if (func == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(func)} can't be null");

//            if (this._types.Add(exposedType))
//            {

//                var instance = new TypeToInject()
//                {
//                    LifeCycle = lifeCycle,
//                    Type = exposedType,
//                    Function = func,
//                };

//                _items.Add(instance);

//                return true;

//            }

//            return false;


//        }

//        public bool Add(IocScopeEnum lifeCycle, Type exposedType, object instance)
//        {

//            if (exposedType == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(exposedType)} can't be null");

//            if (instance == null)
//                throw new InvalidIocConfigurationException($"argument {nameof(instance)} can't be null");

//            if (this._types.Add(exposedType))
//            {

//                var _instance = new TypeToInject()
//                {
//                    LifeCycle = lifeCycle,
//                    Type = exposedType,
//                    Instance = instance,
//                };

//                _items.Add(_instance);

//                return true;

//            }

//            return false;


//        }

//        public IEnumerator<TypeToInject> GetEnumerator()
//        {
//            return _items.GetEnumerator();
//        }

//        IEnumerator IEnumerable.GetEnumerator()
//        {
//            return _items.GetEnumerator();
//        }


//        private readonly List<TypeToInject> _items;
//        private readonly HashSet<Type> _types;

//    }



//}
