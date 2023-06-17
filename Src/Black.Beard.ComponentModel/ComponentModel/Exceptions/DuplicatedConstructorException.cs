using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bb.ComponentModel.Exceptions
{

    [Serializable]
	public class DuplicatedConstructorException : Exception
	{
		public DuplicatedConstructorException() { }
		public DuplicatedConstructorException(Type type, params Type[] types) : this($"more of one constructor is resolved on '{type}' with specified arguments ({types})") { }

        public DuplicatedConstructorException(string message) : base(message) { }
		public DuplicatedConstructorException(string message, Exception inner) : base(message, inner) { }
		protected DuplicatedConstructorException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

}
