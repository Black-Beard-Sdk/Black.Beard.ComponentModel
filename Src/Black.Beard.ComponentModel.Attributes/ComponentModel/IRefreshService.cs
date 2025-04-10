using System;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Defines a service for handling refresh requests.
    /// </summary>
    /// <remarks>
    /// This interface provides an event and a method to request refresh operations for specific objects.
    /// </remarks>
    public interface IRefreshService
    {

        /// <summary>
        /// Occurs when a refresh is requested.
        /// </summary>
        /// <remarks>
        /// This event is triggered to notify subscribers that specific objects need to be refreshed.
        /// </remarks>
        event EventHandler<RefreshEventArgs> RefreshRequested;

        /// <summary>
        /// Requests a refresh for the specified objects.
        /// </summary>
        /// <param name="sender">The source of the refresh request.</param>
        /// <param name="toRefresh">The objects that need to be refreshed.</param>
        /// <remarks>
        /// This method raises the <see cref="RefreshRequested"/> event to notify subscribers about the refresh request.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// IRefreshService refreshService = ...;
        /// refreshService.CallRequestRefresh(this, obj1, obj2);
        /// </code>
        /// </example>
        void CallRequestRefresh(object sender, params object[] toRefresh);

    }

}
