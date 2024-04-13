namespace Bb.ComponentModel.Loaders
{


    public interface IApplicationBuilderInitializer
    {

        /// <summary>
        /// Friendly name of the builder
        /// </summary>
        string FriendlyName { get; }

        /// <summary>
        /// Order of initialization
        /// </summary>
        int OrderPriority { get;  }

        /// <summary>
        /// return true if the builder has been Initialized
        /// </summary>
        bool Initialized { get; set; }

    }


}
