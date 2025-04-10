using System;
using System.Collections.Generic;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Provides data for refresh events.
    /// </summary>
    /// <remarks>
    /// This class is used to specify the objects that need to be refreshed during a refresh event.
    /// </remarks>
    public class RefreshEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="RefreshEventArgs"/> class with the specified objects to refresh.
        /// </summary>
        /// <param name="toRefresh">The objects that need to be refreshed.</param>
        /// <example>
        /// <code lang="C#">
        /// var args = new RefreshEventArgs(obj1, obj2);
        /// if (args.MustRefresh(obj1))
        /// {
        ///     // Perform refresh logic
        /// }
        /// </code>
        /// </example>
        public RefreshEventArgs(params object[] toRefresh)
        {
            this._objectToRefresh = new HashSet<object>(toRefresh);
        }

        /// <summary>
        /// Determines whether the specified object must be refreshed.
        /// </summary>
        /// <param name="o">The object to check.</param>
        /// <returns><c>true</c> if the object must be refreshed; otherwise, <c>false</c>.</returns>
        /// <example>
        /// <code lang="C#">
        /// if (args.MustRefresh(obj))
        /// {
        ///     // Perform refresh logic
        /// }
        /// </code>
        /// </example>
        public bool MustRefresh(object o)
        {
            return _objectToRefresh.Contains(o);
        }

        private readonly HashSet<object> _objectToRefresh;

    }

    /// <summary>
    /// Provides data for busy state events.
    /// </summary>
    /// <remarks>
    /// This class is used to indicate the source of a busy state during a busy event.
    /// </remarks>
    public class BusyEventArgs : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BusyEventArgs"/> class with the specified busy session.
        /// </summary>
        /// <param name="source">The source of the busy session.</param>
        /// <example>
        /// <code lang="C#">
        /// var busyArgs = new BusyEventArgs(session);
        /// Console.WriteLine(busyArgs.Source);
        /// </code>
        /// </example>
        public BusyEventArgs(BusySession source)
        {
            this.Source = source;
        }

        /// <summary>
        /// Gets the source of the busy session.
        /// </summary>
        /// <returns>The <see cref="BusySession"/> that represents the source of the busy state.</returns>
        public BusySession Source { get; }

    }

}
