using System;

namespace Bb.ComponentModel
{

    /// <summary>
    /// Event arguments for an evaluator that evaluates and executes actions on a target object.
    /// </summary>
    /// <typeparam name="T">The type of the target object to evaluate.</typeparam>
    public class EvaluatorEventArgs<T> : EventArgs
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EvaluatorEventArgs{T}"/> class.
        /// </summary>
        /// <param name="evaluator">The function used to evaluate the target object with a value. Can be <c>null</c>.</param>
        /// <param name="action">The action to execute if the evaluation passes. Can be <c>null</c>.</param>
        /// <remarks>
        /// The evaluator function determines whether the action should be executed. If the evaluator is <c>null</c>, the action will always be executed.
        /// </remarks>
        /// <example>
        /// <code lang="C#">
        /// var args = new EvaluatorEventArgs&lt;string&gt;(
        ///     (target, value) => target.Length > 5,
        ///     (target, value) => Console.WriteLine($"Target: {target}, Value: {value}")
        /// );
        /// args.Evaluate("Example", 42);
        /// </code>
        /// </example>
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
        /// If the evaluator function is <c>null</c> or returns <c>true</c>, the action function will be invoked with the target object and the value.
        /// </remarks>
        /// <param name="target">The target object to evaluate.</param>
        /// <param name="value">The value to evaluate the target object with.</param>
        /// <returns>
        /// <c>true</c> if the evaluation passes or if the evaluator function is <c>null</c>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="target"/> object is <c>null</c>.</exception>
        /// <example>
        /// <code lang="C#">
        /// var args = new EvaluatorEventArgs&lt;string&gt;(
        ///     (target, value) => target.Length > 5,
        ///     (target, value) => Console.WriteLine($"Target: {target}, Value: {value}")
        /// );
        /// bool result = args.Evaluate("Example", 42);
        /// </code>
        /// </example>
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
