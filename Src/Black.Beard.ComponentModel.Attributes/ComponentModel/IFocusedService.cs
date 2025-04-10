using System;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Project the focused object on target object
    /// </summary>
    public interface IFocusedService<T>
    {

        /// <summary>
        /// Listen the focus change
        /// </summary>
        event EventHandler<EvaluatorEventArgs<T>>? FocusChanged;

        /// <summary>
        /// Project the object on focus
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="test">Test to evaluate before change the focus</param>
        void FocusChange(object sender, Func<T, object, bool>? test = null);

        /// <summary>
        /// Project the object on focus
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="test">Test to evaluate before change the focus</param>
        /// <param name="action">method to execute</param>
        void FocusChange(object sender, Func<T, object, bool>? test, Action<T, object>? action = null);

    }

    /// <summary>
    /// Project the focused object on target object
    /// </summary>
    public interface IProjectedService<T>
    {

        /// <summary>
        /// Listen the focus change
        /// </summary>
        /// <param name="action">action to execute</param>
        void Execute(Action<T, object> action);

        /// <summary>
        /// Register the service
        /// </summary>
        /// <param name="service"></param>
        void Register(T service);

        /// <summary>
        /// Project the object on focus
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="test">Test to evaluate before change the focus</param>
        void FocusChange(object sender, Func<T, object, bool> test);

    }
}
