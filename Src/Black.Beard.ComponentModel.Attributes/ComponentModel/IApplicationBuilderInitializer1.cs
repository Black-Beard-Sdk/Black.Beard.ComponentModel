using System;

namespace Bb.ComponentModel
{


    /// <summary>
    /// 
    /// </summary>
    public interface IApplicationBuilderInitializer
    {

        /// <summary>
        /// Friendly name of the builder
        /// </summary>
        /// <remarks>
        /// This method returns the friendly name of the builder.
        /// </remarks>
        string FriendlyName { get; }

        /// <summary>
        /// Order of initialization
        /// </summary>
        /// <remarks>
        /// This method returns the order to execute in the list of initialization.
        /// </remarks>
        int OrderPriority { get; }

        /// <summary>
        /// return true if the builder has been Initialized
        /// </summary>
        /// <remarks>
        /// This method returns a boolean value indicating whether the builder has been initialized.
        /// </remarks>
        bool Executed { get; set; }

        /// <summary>
        /// Return the type of service that should be passed by argument
        /// </summary>
        /// <remarks>
        /// This method returns the type of service that should be passed as an argument.
        /// </remarks>
        Type Type { get; }

    }


}
