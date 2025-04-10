namespace Bb.Expressions
{

    /// <summary>
    /// internal unique index generator
    /// </summary>
    public static class PrivatesIndex
    {

        /// <summary>
        /// return unique index.this method is thread safe.
        /// </summary>
        /// <returns>unique index</returns>
        public static int GetNewIndex()
        {
            lock (_lock)
            {

                if (_indexVariables == int.MaxValue)
                    _indexVariables = 0;

                return ++_indexVariables;

            }

        }

        /// <summary>
        /// reset the list of variables
        /// </summary>
        public static void Reset()
        {
            _indexVariables = 0;
        }

        private static readonly object _lock = new();
        private static volatile int _indexVariables = 0;

    }

}
