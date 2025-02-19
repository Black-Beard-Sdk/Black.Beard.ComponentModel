using System;

namespace Bb
{

    /// <summary>
    /// Event arguments for evaluator
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EvaluatorEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Initialize the evaluator event arguments
        /// </summary>
        /// <param name="evaluator"></param>
        public EvaluatorEventArgs(Func<T, object, bool>? evaluator, Action<T, object>? action)
        {
            _evaluate = evaluator;
            _execute = action;
        }

        /// <summary>
        /// Evaluates the target object with the specified value.
        /// </summary>
        /// <remarks>
        /// This method evaluates the target object with the specified value using the provided evaluator function.
        /// If the evaluator function is null or returns true, the action function will be invoked with the target object and the value.
        /// </remarks>
        /// <param name="target">The target object to evaluate.</param>
        /// <param name="value">The value to evaluate the target object with.</param>
        /// <returns>True if the evaluation passes or if the evaluator function is null, otherwise false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the target object is null.</exception>
        public bool Evaluate(T target, object value)
        {

            var result = _evaluate == null || _evaluate(target, value);

            if (result)
                _execute?.Invoke(target, value);

            return result;

        }

        private readonly Func<T, object, bool> _evaluate;
        private readonly Action<T, object> _execute;

    }


}
