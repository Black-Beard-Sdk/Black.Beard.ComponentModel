using Bb.ComponentModel.Exceptions;
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Bb.ComponentModel.Factories
{

    /// <summary>
    /// define a factory
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    public delegate T ObjectCreator<T>(params object[] args);
    public delegate T ObjectCreatorByIoc<T>(IServiceProvider arg);


    /// <summary>
    /// dynamic factory
    /// </summary>
    public static class ObjectCreator
    {


        public static Type[] ResolveTypesOfArguments(params dynamic[] args )
        {

            Type[] results = new Type[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                var value = args[i];
                
                if (value == null)
                    results[i] = typeof(object);

                else
                    results[i] = value.GetType();

            }

            return results;

        }


        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// </summary>
        /// <typeparam name="T">is the type that contains the constructor with the specified arguments types</typeparam>
        /// <param name="types">arguments types of the constructor</param>
        /// <returns></returns>
        public static Factory<T> GetActivatorByArguments<T>(params Type[] types)
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
        public static Factory<T> GetActivatorByTypeAndArguments<T>(Type type, params Type[] types)
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
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static Factory<T> GetActivator<T>(ConstructorInfo methodBase, MethodDescription description)
            where T : class
        {

            return GetCallMethod<T>(methodBase, description);

        }


        /// <summary>
        /// Gets an customized method call factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor do a cast and is injected in the method.
        /// </summary>
        /// <typeparam name="T">is the type that contains the method</typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static Factory<T> GetCallMethod<T>(MethodBase methodBase, MethodDescription description)
        where T : class
        {

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp = new Expression[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;
                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
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
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectCreator<T>), newExp, param);

            //compile it
            ObjectCreator<T> compiled = (ObjectCreator<T>)lambda.Compile();

            return new Factory<T>(compiled, methodBase, paramsInfo, description);

        }

        /// <summary>
        /// Gets an customized activator factory for the specified ctor.
        /// Note if the generic is different of the declaring type of the ctor a cast is injected in the method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctor">The ctor.</param>
        /// <returns></returns>
        public static (ObjectCreator<T>, Type[]) GetActivator<T>(MethodBase methodBase)
            where T : class
        {

            Type type = methodBase.DeclaringType;
            ParameterInfo[] paramsInfo = methodBase.GetParameters();

            //create a single param of type object[]
            ParameterExpression param = Expression.Parameter(typeof(object[]), "args");

            Expression[] argsExp = new Expression[paramsInfo.Length];

            Type[] types = new Type[paramsInfo.Length];

            //pick each arg from the params array and create a typed expression of them
            for (int i = 0; i < paramsInfo.Length; i++)
            {
                Expression index = Expression.Constant(i);
                Type paramType = paramsInfo[i].ParameterType;
                types[i] = paramType;
                Expression paramAccessorExp = Expression.ArrayIndex(param, index);
                Expression paramCastExp = Expression.Convert(paramAccessorExp, paramType);
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
            LambdaExpression lambda = Expression.Lambda(typeof(ObjectCreator<T>), newExp, param);

            //compile it
            ObjectCreator<T> compiled = (ObjectCreator<T>)lambda.Compile();

            return (compiled, types);

        }

    }


}