using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
namespace KikuChatbotWrapper.RestApiHelper
{
    /// <summary>
    /// <see cref="IRestClientHelper"/> interface representing the Client Helper Class
    /// </summary>
    public interface IRestClientHelper
    {
        /// <summary>
        /// Method to process the POST HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as a string </returns>
        Task<T1> PostAsync<T1, T2>(Uri requestUri, T2 request);

        /// <summary>
        /// Method to process the POST HTTP API web request with headers.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="request">The request.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<T1> PostAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers);

        /// <summary>
        /// Method to process the POST HTTP API web request in FormUrlEncoded format.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="postData">The request.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<TResult> PostFormUrlEncodedAsync<TResult>(Uri requestUri, IEnumerable<KeyValuePair<string, string>> postData, IDictionary<string, string> headers);

        /// <summary>
        /// Method to process the Get HTTP API web request without request body
        /// </summary>
        /// <typeparam name="T">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <returns>HTTP response in Json format as generic return type T </returns>
        Task<T> GetAsync<T>(Uri requestUri);

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <param name="headers">Represents the headers</param>
        /// <returns>
        /// HTTP response in Json format as a string 
        /// </returns>
        Task<T1> GetAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers);

        /// <summary>
        /// Method to process the Get HTTP API web request with request body
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as generic return type T </returns>
        Task<T1> GetAsync<T1, T2>(Uri requestUri, T2 request);

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <param name="headers">Represents the headers</param>
        /// <returns>
        /// HTTP response in Json format as a string 
        /// </returns>
        Task<Stream> GetStreamAsync<T>(Uri requestUri, T request, IDictionary<string, string> headers);

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as generic return type T </returns>
        Task<T1> PutAsync<T1, T2>(Uri requestUri, T2 request);

        /// <summary>
        /// Method to process the Delete HTTP API web request without request body
        /// </summary>
        /// <typeparam name="T">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <returns>HTTP response in Json format as generic return type T </returns>
        Task<T> DeleteAsync<T>(Uri requestUri);

        /// <summary>
        /// Method to process the Delete HTTP API web request with request body
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as generic return type T </returns>
        Task<T1> DeleteAsync<T1, T2>(Uri requestUri, T2 request);

        /// <summary>
        /// Method to process Delete HTTP API web request with headers and request body
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="headers">Represents the headers </param>
        /// <returns>HTTP response in Json format as a string </returns>
        Task<T1> DeleteAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers);

        /// <summary>
        /// Method to process the PATCH HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as a string </returns>
        Task<T1> PatchAsync<T1, T2>(Uri requestUri, T2 request);

        /// <summary>
        /// Method to process the PATCH HTTP API web request with headers.
        /// </summary>
        /// <typeparam name="T1">The type of the 1.</typeparam>
        /// <typeparam name="T2">The type of the 2.</typeparam>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="request">The request.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        Task<T1> PatchAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers);

        /// <summary>
        /// Puts the content.
        /// </summary>
        /// <param name="requestUri">The request URI.</param>
        /// <param name="content">The content.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        Task<HttpStatusCode> PutContent(Uri requestUri, byte[] content, string contentType);
    }
}
