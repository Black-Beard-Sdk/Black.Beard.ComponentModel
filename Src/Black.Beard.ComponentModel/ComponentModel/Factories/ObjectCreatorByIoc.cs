using Bb.ComponentModel.Attributes;
using Bb.ComponentModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    /// <summary>
    /// dynamic factory
    /// </summary>
    public static class ObjectCreatorByIoc
    {


        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="types">arguments types of the constructor</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivatorByArguments<T>(params Type[] types)
            where T : class
        {
            return GetActivatorByTypeAndArguments<T>(typeof(T), types);
        }


        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivator<T>()
            where T : class
        {
            return GetActivator<T>(typeof(T));
        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="type">type must see from external method call</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivator<T>(Type type)
            where T : class
        {

            MethodDescription description;

            var item = IocConstructorAttribute.GetMethods(type).FirstOrDefault();
            if (item.Item1 != null)
            {
                description = new MethodDescription(item.Item2.ToString(), item.Item2, item.Item1);
                return GetCallMethod<T>(item.Item2, description);
            }


            var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (ctors == null || ctors.Length == 0)
                throw new MissingPublicException(type, new Type[0]);
            if (ctors.Length > 1)
                throw new DuplicatedConstructorException(type, new Type[0]);

            var ctor = ctors[0];
            description = new MethodDescription(ctor.ToString(), ctor, null);

            return GetCallMethod<T>(ctor, description);


        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="type">type must see from external method call</param>
        /// <param name="types">arguments types of the constructor</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivatorByTypeAndArguments<T>(Type type, params Type[] types)
            where T : class
        {
            var ctor = type.GetConstructor(types);

            if (ctor == null)
                throw new MissingPublicException(type, types);

            var description = new MethodDescription(ctor.ToString(), ctor, null);
            return GetCallMethod<T>(ctor, description);
        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="methodBase">The ctor.</param>
        /// <param name="description">description of the method</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivator<T>(ConstructorInfo methodBase, MethodDescription description)
            where T : class
        {

            return GetCallMethod<T>(methodBase, description);

        }


        /// <summary>
        /// Set attribute to looking for inject instance
        /// </summary>
        /// <typeparam name="T">Type of attribute to looking for</typeparam>
        public static void SetInjectionAttribute<T>()
            where T : Attribute
        {
            _injectAttributes.Add(typeof(T));
        }

        /// <summary>
        /// Set attribute to looking for inject instance
        /// </summary>
        /// <param name="type">Type of attribute to looking for</param>
        public static void SetInjectionAttribute(Type type)
        {

            if (type == null || !typeof(Attribute).IsAssignableFrom(type))
                throw new ArgumentException("Type must be an attribute");

            _injectAttributes.Add(type);

        }


        /// <summary>
        /// Clear attribute to looking for inject instance
        /// </summary>
        public static void ClearSetInjectionAttribute()
        {
            _injectAttributes.Clear();
        }


        /// <summary>
        /// Gets an customized method call factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the method</typeparam>
        /// <param name="methodBase">The ctor.</param>
        /// <param name="description">description of the method</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetCallMethod<T>(MethodBase methodBase, MethodDescription description)
        where T : class
        {

            Type tt = typeof(T);

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            var testInitialize = typeof(IInitialize).IsAssignableFrom(type);
            List<Expression> blk = new List<Expression>();
            List<ParameterExpression> parameters = new List<ParameterExpression>();

            var methodGetService = typeof(IServiceProvider).GetMethod("GetService");

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(IServiceProvider), "arg");
            ParameterExpression paramResult = Expression.Parameter(tt, "param1");
            parameters.Add(paramResult);


            //pick each arg from the params array and create a typed expression of them
            Expression[] argsExp = new Expression[paramsInfo.Length];
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Type paramType = paramsInfo[i].ParameterType;
                var arg = Expression.Call(param, methodGetService, Expression.Constant(paramType));
                argsExp[i] = Expression.Convert(arg, paramType);
            }

            // Create instance
            Expression newInstanceExp;
            if (methodBase is ConstructorInfo c)
                newInstanceExp = Expression.New(c, argsExp);
            else
                newInstanceExp = Expression.Call(null, (MethodInfo)methodBase, argsExp);
            if (methodBase.DeclaringType != tt)
                newInstanceExp = Expression.Convert(newInstanceExp, tt);
            blk.Add(Expression.Assign(paramResult, newInstanceExp));


            // map property to inject
            var properties = TypeDescriptor.GetProperties(methodBase.DeclaringType);
            foreach (PropertyDescriptor property in properties)
                if (EvaluateToAdd(property, out Type typeToInject))
                {

                    Expression instance = paramResult;
                    if (!type.IsAssignableFrom(instance.Type))
                        instance = Expression.Convert(instance, type);

                    Expression c1 = Expression.Call(param, methodGetService, Expression.Constant(typeToInject));

                    if (c1.Type != property.PropertyType)
                        c1 = Expression.Convert(c1, property.PropertyType);

                    instance = Expression.Property(instance, property.Name);
                    blk.Add(Expression.Assign(instance, c1));

                }


            LabelTarget returnTarget = Expression.Label(tt);
            if (testInitialize)
            {
                var method2 = typeof(IInitialize).GetMethods(BindingFlags.Instance | BindingFlags.Public).First();
                ParameterExpression param2 = Expression.Parameter(typeof(IInitialize), "param2");
                parameters.Add(param2);

                blk.Add(Expression.Assign(param2, Expression.Convert(paramResult, typeof(IInitialize))));
                blk.Add(Expression.Call(param2, method2, param));

            }

            blk.Add(Expression.Label(returnTarget, paramResult));

            var block = Expression.Block(tt, parameters.ToArray(), blk.ToArray());
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectCreatorByIoc<T>), block, param);

            //compile it
            ObjectCreatorByIoc<T> compiled = (ObjectCreatorByIoc<T>)lambda.Compile();
            return new FactoryByIoc<T>(compiled, methodBase, paramsInfo, description);

        }

        internal static bool EvaluateToAdd(PropertyDescriptor property, out Type typeToInject)
        {

            typeToInject = property.PropertyType;
            var attributes = property.Attributes.Cast<Attribute>().ToList();
            foreach (Attribute attribute in attributes)
            {
                if (attribute is InjectByIocAttribute a)
                {

                    if (a.TypeToInject != null)
                    {

                        if (!property.PropertyType.IsAssignableFrom(a.TypeToInject))
                            throw new InvalidCastException($"Property {property.Name} can't be convert in {a.TypeToInject.Name}.");

                        typeToInject = a.TypeToInject;
                    }

                    return true;
                }

                if (attribute.GetType().Name == "InjectAttribute")
                    return true;

                foreach (var _injectAttribute in _injectAttributes)
                    if (attribute.GetType() == _injectAttribute)
                        return true;

            }

            return false;
        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor a cast is injected in the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static (ObjectCreatorByIoc<T>, Type[]) GetActivator<T>(MethodBase methodBase)
            where T : class
        {

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            var method = typeof(IServiceProvider).GetMethod("GetService");

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(IServiceProvider), "arg");

            Expression[] argsExp = new Expression[paramsInfo.Length];

            Type[] types = new Type[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Type paramType = paramsInfo[i].ParameterType;
                var arg = Expression.Call(param, method, Expression.Constant(paramType));
                Expression paramCastExp = Expression.Convert(arg, paramType);
                argsExp[i] = paramCastExp;
            }

            Expression newExp;

            if (methodBase is ConstructorInfo c)
                newExp = Expression.New(c, argsExp);
            else
                newExp = Expression.Call(null, (MethodInfo)methodBase, argsExp);

            if (methodBase.DeclaringType != typeof(T))
                newExp = Expression.Convert(newExp, typeof(T));

            //create a lambda with the New expression as body and our param object[] as arg
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectCreatorByIoc<T>), newExp, param);

            //compile it
            ObjectCreatorByIoc<T> compiled = (ObjectCreatorByIoc<T>)lambda.Compile();

            return (compiled, types);

        }

        private static HashSet<Type> _injectAttributes = new();

    }

}