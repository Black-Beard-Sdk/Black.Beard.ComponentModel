using System;
using System.Collections.Generic;
using System.Text;

namespace Bb.ComponentModel.Exceptions
{


    [Serializable]
    public class IocException : Exception
    {
        public IocException() { }
        public IocException(string message) : base(message) { }
        public IocException(string message, Exception inner) : base(message, inner) { }
        protected IocException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
