using Bb.ComponentModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
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
        /// <param name="type">type must see from external method call</param>
        /// <param name="types">arguments types of the constructor</param>
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
        /// <param name="types">arguments types of the constructor</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivator<T>(Type type)
            where T : class
        {
            var ctors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);

            if (ctors == null || ctors.Length == 0)
                throw new MissingPublicException(type, new Type[0]);

            if (ctors.Length > 1)
                throw new DuplicatedConstructorException(type, new Type[0]);

            var ctor = ctors[0];

            var description = new MethodDescription(ctor.ToString(), ctor);

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

            var description = new MethodDescription(ctor.ToString(), ctor);
            return GetCallMethod<T>(ctor, description);
        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetActivator<T>(ConstructorInfo methodBase, MethodDescription description)
            where T : class
        {

            return GetCallMethod<T>(methodBase, description);

        }


        /// <summary>
        /// Set attribute to looking for inject instance
        /// </summary>
        /// <typeparam name="T1">Type of attribute to looking for</typeparam>
        public static void SetInjectionAttribute<T>()
            where T : Attribute
        {
            _injectAttribute = typeof(T);
        }


        /// <summary>
        /// Clear attribute to looking for inject instance
        /// </summary>
        public static void ClearSetInjectionAttribute()
        {
            _injectAttribute = null;
        }


        /// <summary>
        /// Gets an customized method call factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the method</typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static FactoryByIoc<T> GetCallMethod<T>(MethodBase methodBase, MethodDescription description)
        where T : class
        {

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            var testInitialize = typeof(IInitialize).IsAssignableFrom(type);
            List<Expression> blk = new List<Expression>();
            List<ParameterExpression> parameters = new List<ParameterExpression>();

            var method = typeof(IServiceProvider).GetMethod("GetService");

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(IServiceProvider), "arg");
            ParameterExpression param1 = Expression.Parameter(typeof(T), "param1");
            parameters.Add(param1);

            Expression[] argsExp = new Expression[paramsInfo.Length];

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

            blk.Add(Expression.Assign(param1, newExp));

            LambdaExpression lambda;

            if (_injectAttribute != null)
            {

                List<PropertyDescriptor> _props = new List<PropertyDescriptor>();

                var properties = TypeDescriptor.GetProperties(methodBase.DeclaringType);
                foreach (PropertyDescriptor property in properties)
                {

                    var attributes = property.Attributes.Cast<Attribute>().ToList();
                    foreach (Attribute attribute in attributes)
                        if (attribute.GetType() == _injectAttribute)
                        {
                        
                            Expression instance = param1;
                            if (methodBase.DeclaringType != typeof(T))
                                instance = Expression.Convert(instance, typeof(T));

                            var arg1 = Expression.Convert(Expression.Call(param, method, Expression.Constant(property.PropertyType)), property.PropertyType);
                            
                            if (methodBase.DeclaringType != typeof(T))
                                instance = Expression.Convert(param1, typeof(T));

                            instance = Expression.Property(instance, property.Name);

                            blk.Add(Expression.Assign(instance, arg1));

                        }

                }

            }

            LabelTarget returnTarget = Expression.Label(typeof(T));

            if (testInitialize)
            {


                var method2 = typeof(IInitialize).GetMethods(BindingFlags.Instance | BindingFlags.Public).First();

                ParameterExpression param2 = Expression.Parameter(typeof(IInitialize), "param2");

                parameters.Add(param2);

                blk.Add(Expression.Assign(param2, Expression.Convert(param1, typeof(IInitialize))));
                blk.Add(Expression.Call(param2, method2, param));
                //blk.Add(Expression.Label(returnTarget, param1));

            }
            //else
            //{
            //    //create a lambda with the New expression as body and our param object[] as arg
            //    //lambda = Expression.Lambda(typeof(ObjectCreatorByIoc<T>), newExp, param);
            //}

            blk.Add(Expression.Label(returnTarget, param1));

            var block = Expression.Block(typeof(T), parameters.ToArray(), blk.ToArray());
            lambda = Expression.Lambda(typeof(ObjectCreatorByIoc<T>), block, param);

            //compile it
            ObjectCreatorByIoc<T> compiled = (ObjectCreatorByIoc<T>)lambda.Compile();
            return new FactoryByIoc<T>(compiled, methodBase, paramsInfo, description);

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

        private static Type _injectAttribute;

    }


}