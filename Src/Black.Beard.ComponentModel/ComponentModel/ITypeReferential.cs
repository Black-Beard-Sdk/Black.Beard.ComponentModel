using Bb.ComponentModel.Factories;
using System;
using System.Collections.Generic;
using System.Reflection;

public interface ITypeReferential
{

    /// <summary>
    /// return a list of type that assignable from the specified baseType
    /// </summary>
    /// <param name="baseType">The type.</param>
    /// <returns></returns>
    /// <exception cref="System.NullReferenceException">type</exception>
    List<Type> GetTypesWithAttributes(Type baseType);

    /// <summary>
    /// return a list of type that assignable from the specified type
    /// </summary>
    /// <param name="baseType">The base type.</param>
    /// <param name="attributeType">The type.</param>
    /// <returns></returns>
    /// <exception cref="System.NullReferenceException">type</exception>
    List<Type> GetTypesWithAttributes(Type baseType, Type attributeType);

    /// <summary>
    /// return a list of type that assignable from the specified type
    /// </summary>
    /// <param name="baseType">The base type.</param>
    /// <param name="attributeType">The type.</param>
    /// <returns></returns>
    /// <exception cref="System.NullReferenceException">type</exception>
    List<Type> GetTypesWithAttributes<T>(Type baseType, Func<T, bool> filter) where T : Attribute;

    /// <summary>
    /// return a list of type that assignable from the specified base type
    /// </summary>
    /// <param name="baseType">The type.</param>
    /// <returns></returns>
    /// <exception cref="System.NullReferenceException">type</exception>
    List<Type> GetTypes(Type baseType);

    /// <summary>
    /// Resolves the name by specified target name.
    /// </summary>
    /// <param name="targetTypeName">Type of the target.</param>
    /// <returns></returns>
    Type ResolveByName(string targetTypeName);

    /// <summary>
    /// Return a list of type that match with the specified filter
    /// </summary>
    /// <param name="fnc">The FNC.</param>
    /// <returns></returns>
    /// <exception cref="System.NullReferenceException">fnc</exception>
    List<Type> GetTypes(Func<Type, bool> fnc);

    Assembly AddAssemblyFile(string assemblyName, bool withPdb);

    /// <summary>
    /// Resolve types argument and Creates an optimized factory for the specified arguments.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    IFactory<T> Create<T>(params dynamic[] args)
        where T : class;

    /// <summary>
    /// Creates an optimized factory for the specified arguments.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    IFactory<T> CreateWithTypes<T>(params Type[] types)
        where T : class;

    /// <summary>
    /// Resolve types argument and Creates an optimized factory for the specified arguments. The real type instance is the specified type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type">The real type instance.</param>
    /// <param name="args">The arguments.</param>
    /// <returns></returns>
    IFactory<T> CreateFrom<T>(Type type, params dynamic[] args)
        where T : class;

    /// <summary>
    /// Creates an optimized factory for the specified arguments. The real type instance is the specified type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="type">The real type instance.</param>
    /// <param name="types">The types.</param>
    /// <returns></returns>
    IFactory<T> CreateFromWithTypes<T>(Type type, params Type[] types)
        where T : class;

}

