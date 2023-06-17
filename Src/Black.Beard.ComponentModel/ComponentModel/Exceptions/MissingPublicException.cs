using System;

namespace Bb.ComponentModel.Exceptions
{
    [Serializable]
	public class MissingPublicException : Exception
	{
		public MissingPublicException() { }

        public MissingPublicException(Type type, params Type[] types) : this($"no constructor can't be resolved on '{type}' with specified arguments ({types})")
        {
				
        }
        public MissingPublicException(string message) : base(message) { }
		public MissingPublicException(string message, Exception inner) : base(message, inner) { }
		protected MissingPublicException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

}
