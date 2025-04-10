namespace Bb.ComponentModel
{

    /// <summary>
    /// specialized interface for Initialize service
    /// </summary>
    public interface IInjectBuilder<in T> : IInjectBuilder
    {

        /// <summary>
        /// Return true if the process can be ran
        /// </summary>
        /// <param name="context">specified context </param>
        /// <returns></returns>
        bool CanExecute(T context);


        /// <summary>
        /// Execute the initializing process with
        /// </summary>
        /// <param name="context">specified context</param>
        /// <returns></returns>
        void Execute(T context);

    }

}
