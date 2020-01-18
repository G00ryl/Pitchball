using System;
using System.Runtime.Serialization;

namespace Pitchball.Controllers
{
    [Serializable]
    internal class InternalSystemException : Exception
    {
        public InternalSystemException()
        {
        }

        public InternalSystemException(string message) : base(message)
        {
        }

        public InternalSystemException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InternalSystemException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}