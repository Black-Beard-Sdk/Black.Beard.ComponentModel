using System;

namespace Bb.ComponentModel.Factories
{
    /// <summary>
    /// Call the initialize method after creation of the object.
    /// </summary>
    public interface IInitialize
    {

        /// <summary>
        /// Initializes the current service.
        /// </summary>
        /// <param name="services">The services.</param>
        void Initialize(IServiceProvider services);

    }


}

