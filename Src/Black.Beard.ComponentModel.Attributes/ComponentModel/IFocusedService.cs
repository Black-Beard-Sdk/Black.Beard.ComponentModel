using System;

namespace Bb
{

    public interface IFocusedService
    {

        event EventHandler<EventArgs> FocusChanged;

        void FocusChange(object sender);

    }

}
