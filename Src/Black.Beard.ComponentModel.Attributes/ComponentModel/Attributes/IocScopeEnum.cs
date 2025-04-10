// Ignore Spelling: Ioc

namespace Bb.ComponentModel.Attributes
{

    /// <summary>
    /// Specifies the scope of an IoC (Inversion of Control) container registration.
    /// </summary>
    /// <remarks>
    /// This enumeration is used to define the life cycle of a service in an IoC container.
    /// </remarks>
    public enum IocScope
    {
        /// <summary>
        /// Specifies that a new instance of the service will be created each time it is requested.
        /// </summary>
        Transiant,

        /// <summary>
        /// Specifies that a single instance of the service will be created and shared across all requests.
        /// </summary>
        Singleton,

        /// <summary>
        /// Specifies that a new instance of the service will be created for each scope.
        /// </summary>
        Scoped
    }

}
