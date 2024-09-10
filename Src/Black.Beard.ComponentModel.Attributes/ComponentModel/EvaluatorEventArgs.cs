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
        public EvaluatorEventArgs(Func<object, bool> evaluator)
        {
            Evaluate = evaluator;
        }

        /// <summary>
        /// Gets the evaluator
        /// </summary>
        public Func<object , bool> Evaluate { get; }

    }


}
