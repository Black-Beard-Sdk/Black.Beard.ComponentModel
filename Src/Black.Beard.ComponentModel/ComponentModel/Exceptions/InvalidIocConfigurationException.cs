namespace Bb.ComponentModel.Exceptions
{
    [System.Serializable]
    public class InvalidIocConfigurationException : System.Exception
    {
        public InvalidIocConfigurationException() { }
        public InvalidIocConfigurationException(string message) : base(message) { }
        public InvalidIocConfigurationException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidIocConfigurationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
