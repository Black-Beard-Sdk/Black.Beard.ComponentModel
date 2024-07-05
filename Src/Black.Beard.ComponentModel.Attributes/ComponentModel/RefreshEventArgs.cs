using System;
using System.Collections.Generic;

namespace Bb
{

    public class RefreshEventArgs : EventArgs
    {

        public RefreshEventArgs(params object[] toRefresh)
        {
            this._objectToRefresh = new HashSet<object>(toRefresh);
        }

        public bool MustRefresh(object o)
        {
            return _objectToRefresh.Contains(o);
        }

        private readonly HashSet<object> _objectToRefresh;

    }


    public class BusyEventArgs : EventArgs
    {

        public BusyEventArgs(BusySession source)
        {
            this.Source = source;
        }

        public BusySession Source { get; }
        


    }

}
