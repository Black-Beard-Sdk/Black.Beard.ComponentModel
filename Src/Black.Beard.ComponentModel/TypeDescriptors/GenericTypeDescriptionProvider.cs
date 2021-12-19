using Bb.ComponentModel.Factories;
using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Bb.TypeDescriptors
{


    public class GenericTypeDescriptionProvider
    {

        /// <summary>
        /// Register <see cref="GenericTypeDescriptionProvider"/> like the new Type descriptor provider
        /// </summary>
        public static void Register<T>()
            where T : class
        {

            TypeDescriptionProvider parentProvider = TypeDescriptor.GetProvider(typeof(T));

            if (parentProvider is GenericTypeDescriptionProvider<T>)
                return;

            var parentCtd = parentProvider.GetTypeDescriptor(typeof(T));
            

            var ourProvider = new GenericTypeDescriptionProvider<T>(parentProvider);

            TypeDescriptor.AddProvider(ourProvider, typeof(T));

        }

        /// <summary>
        /// remove <see cref="GenericTypeDescriptionProvider"/> like the new Type descriptor provider
        /// </summary>        
        public static void Unregister<T>()
        where T : class
        {
            TypeDescriptor.RemoveProvider(TypeDescriptor.GetProvider(typeof(T)), typeof(GenericTypeDescriptionProvider<T>));
        }

    }


    public class GenericTypeDescriptionProvider<T> : TypeDescriptionProvider
        where T : class
    {

        internal GenericTypeDescriptionProvider(TypeDescriptionProvider parent)
            : base(parent ?? TypeDescriptor.GetProvider(typeof(T)))
        {

            _factories = new ObjectActivatorResolver<T>();

        }

        public override Type GetReflectionType(Type objectType, object instance)
        {

            if (objectType.IsGenericType)
                return objectType.BaseType;

            return base.GetReflectionType(objectType, instance);

        }

        public override ICustomTypeDescriptor GetTypeDescriptor([DynamicallyAccessedMembers((DynamicallyAccessedMemberTypes)(-1))] Type objectType, object instance)
        {
            var parentCtd = base.GetTypeDescriptor(objectType, instance);
            var ourCtd = new DynamicTypeDescriptor(parentCtd);
            return ourCtd;
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {

            T result = default(T);

            if (argTypes == null)
                argTypes = new Type[0];

            if (args == null)
                args = new object[0];

            var activator = _factories.Get(argTypes);
            if (activator != null)
                result = activator(args);
            else
                result = (T)base.CreateInstance(provider, objectType, argTypes, args);

            return result;

        }

        private readonly ObjectActivatorResolver<T> _factories;

    }

}
