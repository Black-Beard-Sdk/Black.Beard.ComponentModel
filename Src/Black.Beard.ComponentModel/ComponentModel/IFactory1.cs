namespace Bb.ComponentModel.Factories
{


    /// <summary>
    /// I factory generic
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFactory<T> : IFactory
        where T : class
    {

        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        T CallByKey(string name, params dynamic[] args);

    }


}

