using System;

namespace Bb.Exceptions
{
    [Serializable]
    public class NotSettedExpressionException : Exception
    {
        public NotSettedExpressionException() { }
        public NotSettedExpressionException(string message) : base(message) { }
        public NotSettedExpressionException(string message, Exception inner) : base(message, inner) { }
        protected NotSettedExpressionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
