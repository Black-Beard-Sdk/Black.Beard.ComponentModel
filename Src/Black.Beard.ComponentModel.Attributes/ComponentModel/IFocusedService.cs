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
        /// <param name="test">Test to evaluate before change the focus</param>
        /// <param name="sender"></param>
        void FocusChange(Func<T, object, bool> test, object sender);

    }

}
