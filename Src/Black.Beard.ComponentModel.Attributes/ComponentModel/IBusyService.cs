using System;
using System.Threading.Tasks;

namespace Bb
{

    /// <summary>
    /// Busy service
    /// </summary>
    public interface IBusyService
    {

        event EventHandler<BusyEventArgs> BusyChanged;

        BusySession IsBusyFor(object instance, string title, Action<BusySession> action);

        Task Update(BusySession session);

    }

}
