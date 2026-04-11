using System;

namespace Works4me.Xurrent.Rest
{
    /// <summary>
    /// Represents errors that occur during Xurrent query creation.
    /// </summary>
    [Serializable]
    public class XurrentQueryException : XurrentException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentQueryException"/> class.
        /// </summary>
        public XurrentQueryException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentQueryException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public XurrentQueryException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentQueryException"/> class with a specified 
        /// error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>

        public XurrentQueryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

#if NETFRAMEWORK
        /// <summary>
        /// Initializes a new instance of the <see cref="XurrentQueryException"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected XurrentQueryException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
#endif
    }
}
