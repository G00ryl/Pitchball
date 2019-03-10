using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Pitchball.Infrastructure.Extensions.Exceptions
{
    [Serializable]
    public class CorruptedOperationException : Exception
    {
        public CorruptedOperationException() { }

        public CorruptedOperationException(string message) : base(message) { }

        public CorruptedOperationException(string message, Exception innerException) : base(message, innerException) { }

        protected CorruptedOperationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
