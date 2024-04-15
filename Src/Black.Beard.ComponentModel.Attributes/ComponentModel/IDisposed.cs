using System;

namespace Bb.ComponentModel
{
    public interface IDisposed : IDisposable
    {

        event EventHandler<DisposedEventArgs> Disposed;

    }


    public class DisposedEventArgs : EventArgs
    {

        public DisposedEventArgs()
        {

        }

        public IDisposable Instance { get; set; }

    }


}
