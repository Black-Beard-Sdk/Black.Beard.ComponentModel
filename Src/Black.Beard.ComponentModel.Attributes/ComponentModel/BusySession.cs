using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bb
{
    public class BusySession : IDisposable, INotifyPropertyChanged
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="parentInstance"></param>
        public BusySession(IBusyService parent, string title, object parentInstance, Action<BusySession> action)
        {
            this.BusyStatus = BusyEnum.New;
            this._parent = parent;
            this.Instance = parentInstance;
            this._action = action;
            this.Title = title;
        }


        public async Task Run()
        {
            BusyStatus = BusyEnum.Started;
            await Task.Run(async () =>
            {

                int wait = 3;
                var startTime = DateTime.Now.AddSeconds(wait);

                BusyStatus = BusyEnum.Running;
                try
                {
                
                    _action(this);

                    var n = DateTime.Now;
                    if (n < startTime)
                        await Task.Delay((int)startTime.Subtract(n).TotalMilliseconds);
                
                }
                finally
                {
                    BusyStatus = BusyEnum.Completed;
                    await Close();
                }

            });
        }

        public async Task Update(string? message = null, int percent = -1)
        {

            bool messageChanged = false;
            bool percentChanged = false;

            if (message != null)
            {
                if (Message != message)
                {
                    Message = message;
                    messageChanged = true;
                }
            }
            else
            {
                if (Message != string.Empty)
                {
                    Message = string.Empty;
                    messageChanged = true;
                }
            }


            if (percent != -1)
            {
                if (ProgressPercent != percent)
                {
                    ProgressPercent = percent;
                    percentChanged = true;
                }
            }

            
            await _parent.Update(this);


            if (messageChanged)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));

            if (percentChanged)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgressPercent)));

        }

        public async Task Close()
        {
            BusyStatus = BusyEnum.Completed;
            Message = string.Empty;
            ProgressPercent = 100;
            await _parent.Update(this);
        }

        public BusyEnum BusyStatus { get; private set; }

        public string Title { get; set; }

        public string Message { get; private set; }

        public int ProgressPercent { get; private set; }

        public object Instance { get; }

        private Action<BusySession> _action;

        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Close();
            });
        }

        private readonly IBusyService _parent;

        public event PropertyChangedEventHandler? PropertyChanged;
    }


    public enum BusyEnum
    {
        New,
        Started,
        Running,
        Completed,
    }


}
