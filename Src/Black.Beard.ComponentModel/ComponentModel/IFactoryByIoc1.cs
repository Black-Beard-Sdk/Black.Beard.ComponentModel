using System;

namespace Bb.ComponentModel.Factories
{
    /// <summary>
    /// I factory generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactoryByIoc<T> : IFactory<T>
        where T : class
    {

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        T Call(string name, IServiceProvider provider);

    }

}

