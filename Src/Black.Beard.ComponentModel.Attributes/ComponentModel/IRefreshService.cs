using System;

namespace Bb
{

    public interface IRefreshService
    {

        event EventHandler<RefreshEventArgs> RefreshRequested;

        void CallRequestRefresh(object sender, params object[] toRefresh);

    }

}
