using System;
using System.ComponentModel;

namespace Bb.ComponentModel
{


    public delegate void DisposedEventHandler(object? sender, DisposedEventArgs e);



    public interface IDisposed : IDisposable
    {

        event DisposedEventHandler Disposed;

    }


    public class DisposedEventArgs : EventArgs
    {

        public DisposedEventArgs()
        {

        }

        public IDisposable Instance { get; set; }

    }


}
