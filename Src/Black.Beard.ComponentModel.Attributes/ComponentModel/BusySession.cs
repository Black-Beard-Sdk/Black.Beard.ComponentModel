using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Represents a session that tracks and manages a busy state.
    /// </summary>
    /// <remarks>
    /// This class is used to manage actions that are executed in a busy state, providing progress updates and status tracking.
    /// </remarks>
    public class BusySession : IDisposable, INotifyPropertyChanged
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="BusySession"/> class.
        /// </summary>
        /// <param name="parent">The parent service managing the busy session.</param>
        /// <param name="title">The title of the busy session.</param>
        /// <param name="parentInstance">The instance being processed in the session.</param>
        /// <param name="action">The initial action to execute in the session.</param>
        /// <remarks>
        /// This constructor sets up the busy session with an optional initial action.
        /// </remarks>
        public BusySession(IBusyService parent, string title, object parentInstance, Action<BusySession> action)
        {
            this.BusyStatus = Busy.New;
            this._parent = parent;
            this.Instance = parentInstance;

            if (action != null)
                this._actions = new List<Action<BusySession>>(5) { action };
            else
                this._actions = new List<Action<BusySession>>(5);

            this.Title = title;
        }

        /// <summary>
        /// Appends a new action to execute in the busy session.
        /// </summary>
        /// <param name="action">The action to add to the session.</param>
        /// <returns>The current <see cref="BusySession"/> instance.</returns>
        /// <remarks>
        /// This method allows chaining multiple actions to be executed during the session.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// session.Add(s => Console.WriteLine("Action 1"))
        ///        .Add(s => Console.WriteLine("Action 2"));
        /// </code>
        /// </example>
        public BusySession Add(Action<BusySession> action)
        {
            if (action != null)
                _actions.Add(action);
            _actions.Add(action);
            return this;
        }

        /// <summary>
        /// Runs the busy session and executes all added actions.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method sets the session status to running, executes all actions, and then marks the session as completed.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// await session.Run();
        /// </code>
        /// </example>
        public async Task Run()
        {
            BusyStatus = Busy.Started;
            await Task.Run(async () =>
            {
                BusyStatus = Busy.Running;
                try
                {

                    foreach (var act in _actions)
                        if (act != null)
                            act(this);

                }
                finally
                {
                    BusyStatus = Busy.Completed;
                    await Close();
                }

            });
        }

        /// <summary>
        /// Updates the message and progress of the busy session.
        /// </summary>
        /// <param name="message">The new message to display (optional).</param>
        /// <param name="percent">The progress percentage (optional, default is -1).</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method updates the session's message and progress percentage and notifies subscribers of the changes.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// await session.Update("Processing...", 50);
        /// </code>
        /// </example>
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


            if (percent != -1 && ProgressPercent != percent)
            {
                ProgressPercent = percent;
                percentChanged = true;
            }


            await _parent.Update(this);


            if (messageChanged)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Message)));

            if (percentChanged)
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgressPercent)));

        }

        /// <summary>
        /// Closes the busy session and marks it as completed.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method sets the session status to completed, clears the message, and sets the progress to 100%.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// await session.Close();
        /// </code>
        /// </example>
        public async Task Close()
        {
            BusyStatus = Busy.Completed;
            Message = string.Empty;
            ProgressPercent = 100;
            await _parent.Update(this);
        }

        /// <summary>
        /// Gets the current status of the busy session.
        /// </summary>
        /// <returns>The current <see cref="Busy"/> status.</returns>
        public Busy BusyStatus { get; private set; }

        /// <summary>
        /// Gets or sets the title of the busy session.
        /// </summary>
        /// <returns>The title of the session.</returns>
        public string Title { get; set; }

        /// <summary>
        /// Gets the current message of the busy session.
        /// </summary>
        /// <returns>The current message.</returns>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the progress percentage of the busy session.
        /// </summary>
        /// <returns>The progress percentage.</returns>
        public int ProgressPercent { get; private set; }

        /// <summary>
        /// Gets the instance being processed in the busy session.
        /// </summary>
        /// <returns>The instance being processed.</returns>
        public object Instance { get; }

        private readonly List<Action<BusySession>> _actions;
        private readonly IBusyService _parent;
        private bool disposedValue;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Disposes the busy session and marks it as completed.
        /// </summary>
        /// <param name="disposing">Indicates whether the method is called from Dispose or the finalizer.</param>
        /// <remarks>
        /// This method ensures that the session is properly closed and resources are released.
        /// </remarks>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Task.Run(async () =>
                    {
                        await Close();
                    });
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Disposes the busy session and marks it as completed.
        /// </summary>
        /// <remarks>
        /// This method ensures that the session is properly closed and resources are released.
        /// </remarks>
        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }

    /// <summary>
    /// Represents the status of a busy session.
    /// </summary>
    public enum Busy
    {
        /// <summary>
        /// The session is newly created and has not started yet.
        /// </summary>
        New,

        /// <summary>
        /// The session has started but is not yet running.
        /// </summary>
        Started,

        /// <summary>
        /// The session is currently running.
        /// </summary>
        Running,

        /// <summary>
        /// The session has completed.
        /// </summary>
        Completed,
    }

}
