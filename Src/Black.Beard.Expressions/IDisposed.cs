using System;

namespace Bb
{

    /// <summary>
    /// Represents the method that will handle the disposing of an object.
    /// event raised when instance is disposed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">An <see cref="EventArgs"/> object that contains the event data.</param>
    /// <remarks>
    /// This delegate represents the method that will be called when an object is being disposed.
    /// </remarks>
    public delegate void DisposedEventHandler(object? sender, EventArgs e);


    /// <summary>
    /// Represents an object that can be disposed.
    /// </summary>
    public interface IDisposed : IDisposable
    {

        /// <summary>
        /// Occurs when the instance is disposed.
        /// </summary>
        /// <remarks>
        /// This event is raised when the object is being disposed.
        /// </remarks>
        event DisposedEventHandler? Disposed;

    }

}
