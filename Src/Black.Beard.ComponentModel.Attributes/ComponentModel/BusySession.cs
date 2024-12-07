using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bb
{
    public class BusySession : IDisposable, INotifyPropertyChanged
    {

        /// <summary>
        /// Initialize a new busy session
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="parentInstance"></param>
        public BusySession(IBusyService parent, string title, object parentInstance, Action<BusySession> action)
        {
            this.BusyStatus = BusyEnum.New;
            this._parent = parent;
            this.Instance = parentInstance;

            if (action != null)
                this._actions = new List<Action<BusySession>>(5) { action };
            else
                this._actions = new List<Action<BusySession>>(5);
            
            this.Title = title;
        }

        /// <summary>
        /// Append a new action to execute
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public BusySession Add(Action<BusySession> action)
        {
            if (action != null)
                _actions.Add(action);
            _actions.Add(action);
            return this;
        }

        /// <summary>
        /// Run the session
        /// </summary>
        /// <returns></returns>
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

                    foreach (var act in _actions)
                        if (act != null)
                            act(this);

                    //var n = DateTime.Now;
                    //if (n < startTime)
                    //    await Task.Delay((int)startTime.Subtract(n).TotalMilliseconds);

                }
                finally
                {
                    BusyStatus = BusyEnum.Completed;
                    await Close();
                }

            });
        }

        /// <summary>
        /// Update the message form busy session
        /// </summary>
        /// <param name="message"></param>
        /// <param name="percent"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Close the session
        /// </summary>
        /// <returns></returns>
        public async Task Close()
        {
            BusyStatus = BusyEnum.Completed;
            Message = string.Empty;
            ProgressPercent = 100;
            await _parent.Update(this);
        }

        /// <summary>
        /// Status of the busy session
        /// </summary>
        public BusyEnum BusyStatus { get; private set; }

        /// <summary>
        /// Title of the session
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Current message of the busy session
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Progress percent of the session
        /// </summary>
        public int ProgressPercent { get; private set; }

        /// <summary>
        /// Instance processed in the session
        /// </summary>
        public object Instance { get; }


        /// <summary>
        /// Dispose the session
        /// </summary>
        public void Dispose()
        {
            Task.Run(async () =>
            {
                await Close();
            });
        }

        private List<Action<BusySession>> _actions;
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
