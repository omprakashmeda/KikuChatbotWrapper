using System;
using System.Net.Http;
using System.Runtime.Serialization;
namespace KikuChatbotWrapper.RestApiHelper
{
    /// <summary>
    /// <see cref="HttpResponseFailureException"/> class represents the HTTP Failure Exception
    /// across payment module
    /// </summary>
    [Serializable]
    public class HttpResponseFailureException : Exception
    {
        /// <summary>
        /// Represents the HTTP Response Message
        /// </summary>
        public string ResponseMessage { get; set; }

        /// <summary>
        /// Represents the HTTP Response Failure Exception
        /// </summary>
        public HttpResponseFailureException()
        {

        }

        /// <summary>
        /// Represents the HTTP Response Failure Exception
        /// </summary>
        /// <param name="message">Represents the message</param>
        public HttpResponseFailureException(string message) : base(message)
        {

        }

        /// <summary>
        /// Represents the HTTP Response Failure Exception
        /// </summary>
        /// <param name="serializationInfo">Represents Serialization Info</param>
        /// <param name="streamingContext">Represents Streaming Context</param>
        protected HttpResponseFailureException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {
        }

        public HttpResponseFailureException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
