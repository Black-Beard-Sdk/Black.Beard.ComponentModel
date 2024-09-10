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
