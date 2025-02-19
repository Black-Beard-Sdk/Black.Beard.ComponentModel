using System;
using System.Threading.Tasks;

namespace Bb
{

    /// <summary>
    /// Busy service
    /// </summary>
    /// <remarks>
    /// This service provides functionality for managing busy sessions.
    /// A busy session represents a period of time during which a specific instance is busy performing an action.
    /// The service allows subscribing to the BusyChanged event to be notified when the busy state changes.
    /// </remarks>
    public interface IBusyService
    {

        /// <summary>
        /// Event that is raised when the busy state changes.
        /// </summary>
        event EventHandler<BusyEventArgs> BusyChanged;

        /// <summary>
        /// Checks if the specified instance is busy and executes the specified action if it is not busy.
        /// </summary>
        /// <param name="instance">The instance to check for busy state.</param>
        /// <param name="title">The title of the busy session.</param>
        /// <param name="action">The action to execute if the instance is not busy.</param>
        /// <returns>The busy session associated with the instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the instance parameter is null.</exception>
        BusySession IsBusyFor(object instance, string title, Action<BusySession> action);

        /// <summary>
        /// Updates the specified busy session.
        /// </summary>
        /// <param name="session">The busy session to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the session parameter is null.</exception>
        Task Update(BusySession session);

    }

}
