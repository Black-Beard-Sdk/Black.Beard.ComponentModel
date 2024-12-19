using System;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Represents the method that will handle the <see cref="IDisposed"/>
    //  event raised when instance is disposed.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e"></param>
    public delegate void DisposedEventHandler(object? sender, EventArgs e);


    public interface IDisposed : IDisposable
    {

        /// <summary>
        ///     Occurs when the instance is disposed.
        /// </summary>
        event DisposedEventHandler? Disposed;

    }

}
