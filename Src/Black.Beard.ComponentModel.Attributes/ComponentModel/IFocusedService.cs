using System;

namespace Bb
{

    /// <summary>
    /// Project the focused object on target object
    /// </summary>
    public interface IFocusedService<T>
    {

        /// <summary>
        /// Listen the focus change
        /// </summary>
        event EventHandler<EvaluatorEventArgs<T>> FocusChanged;

        /// <summary>
        /// Project the object on focus
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="test">Test to evaluate before change the focus</param>
        void FocusChange(object sender, Func<T, object, bool> test);

    }

    /// <summary>
    /// Project the focused object on target object
    /// </summary>
    public interface IProjectedService<T>
    {

        void Register(T service);

        /// <summary>
        /// Project the object on focus
        /// </summary>
        /// <param name="sender">object source</param>
        /// <param name="test">Test to evaluate before change the focus</param>
        void FocusChange(Func<T, object> action, Func<T, object, bool> test);

    }
}
