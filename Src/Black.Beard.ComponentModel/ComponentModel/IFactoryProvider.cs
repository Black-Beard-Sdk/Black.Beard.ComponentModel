using System;

namespace Bb.ComponentModel.Factories
{
    /// <summary>
    /// IFactory base
    /// </summary>
    public interface IFactoryProvider
    {

        /// <summary>
        /// Creates this instance of the factory.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        IFactory<T> Create<T>(params dynamic[] args)
            where T : class;

        /// <summary>
        /// Creates this instance of the factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="types">The types.</param>
        /// <returns></returns>
        IFactory<T> CreateWithTypes<T>(params Type[] types)
            where T : class;

        /// <summary>
        /// Creates this instance of the factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The type.</param>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        IFactory<T> CreateFrom<T>(Type type, params dynamic[] args)
            where T : class;


        /// <summary>
        /// Creates this instance of the factory.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type">The types.</param>
        /// <param name="types">The types argument from the méthod.</param>
        /// <returns></returns>
        IFactory<T> CreateFromWithTypes<T>(Type type, params Type[] types)
            where T : class;

    }

}

