using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KikuChatbotWrapper.RestApiHelper
{
    public class RestClientHelper : IRestClientHelper
    {
        private const string _httpResponseMessage = "Http API call failed, cast the exception to HttpResponseFailureException to see response message";
        private const string _responseMessage = "ResponseMessage";
        private static readonly HttpClient _httpClient = new HttpClient();
        
        /// <summary>
        /// Represents the Zp Liter Logger
        /// </summary>
        /// <summary>
        /// Method to set the wait time to 30 seconds
        /// </summary>
        public RestClientHelper()
        {
            _httpClient.Timeout = TimeSpan.FromSeconds(120);
        }

        /// <summary>
        /// Method to process Delete HTTP API web request with headers and request body
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="headers">Represents the headers </param>
        /// <returns>HTTP response in Json format as a string </returns>
        public async Task<T1> DeleteAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Delete, requestUri))
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var result = await _httpClient.SendAsync(httpRequest))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T1>(response);
                    }
                    else
                    {
                        var message = await result.Content.ReadAsStringAsync();
                        var ex = new HttpResponseFailureException(_httpResponseMessage)
                        {
                            ResponseMessage = message
                        };
                        ex.Data.Add(_responseMessage, message);
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the Requested URL</param>
        /// <param name="request">Represent the Body of the Request</param>
        /// <returns>HTTP response in Json format as a string</returns>
        public async Task<T1> DeleteAsync<T1, T2>(Uri requestUri, T2 request)
        {
            return await DeleteAsync<T1, T2>(requestUri, request, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <returns>HTTP response in Json format as a string </returns>
        public async Task<T> DeleteAsync<T>(Uri requestUri)
        {
            return await DeleteAsync<T, object>(requestUri, null, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <param name="headers">Represents the henoteaders</param>
        /// <returns>
        /// HTTP response in Json format as a string 
        /// </returns>
        public async Task<T1> GetAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (!Equals(request, default(T2)))
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            }

            using var result = await _httpClient.SendAsync(httpRequest);
            if (result.IsSuccessStatusCode)
            {
                var response = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T1>(response);
            }
            else
            {
                var message = await result.Content.ReadAsStringAsync();
                var ex = new HttpResponseFailureException(_httpResponseMessage)
                {
                    ResponseMessage = message
                };
                ex.Data.Add(_responseMessage, message);
                throw ex;
            }
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as a string </returns>
        public async Task<T1> GetAsync<T1, T2>(Uri requestUri, T2 request)
        {
            return await this.GetAsync<T1, T2>(requestUri, request, null).ConfigureAwait(false);
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T">Represents the Generic transaction response object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <returns>HTTP response in Json format as a string </returns>
        public async Task<T> GetAsync<T>(Uri requestUri)
        {
            return await this.GetAsync<T, object>(requestUri, null, null).ConfigureAwait(false);
        }

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
        public async Task<Stream> GetStreamAsync<T>(Uri requestUri, T request, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);
            if (headers != null && headers.Count > 0)
            {
                foreach (var header in headers)
                {
                    httpRequest.Headers.Add(header.Key, header.Value);
                }
            }

            if (!Equals(request, default(T)))
            {
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            }

            using var result = await _httpClient.SendAsync(httpRequest);
            if (result.IsSuccessStatusCode)
            {
                var stream = await result.Content.ReadAsStreamAsync();
                var response = new MemoryStream();
                await stream.CopyToAsync(response);
                response.Seek(0, SeekOrigin.Begin);
                return response;
            }
            else
            {
                var message = await result.Content.ReadAsStringAsync();
                var ex = new HttpResponseFailureException(_httpResponseMessage)
                {
                    ResponseMessage = message
                };
                ex.Data.Add(_responseMessage, message);
                throw ex;
            }
        }

        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as a string </returns>
        public Task<T1> PostAsync<T1, T2>(Uri requestUri, T2 request)
        {
            return PostAsync<T1, T2>(requestUri, request, null);
        }

        public async Task<T1> PostAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, requestUri))
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var result = await _httpClient.SendAsync(httpRequest))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T1>(response);
                    }
                    else
                    {
                        var message = await result.Content.ReadAsStringAsync();
                        var ex = new HttpResponseFailureException(_httpResponseMessage)
                        {
                            ResponseMessage = message
                        };
                        ex.Data.Add(_responseMessage, message);
                        throw ex;
                    }
                }
            }
        }

        public async Task<TResult> PostFormUrlEncodedAsync<TResult>(Uri url, IEnumerable<KeyValuePair<string, string>> postData, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (var content = new FormUrlEncodedContent(postData))
            {
                content.Headers.Clear();
                content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

                using (var httpRequest = new HttpRequestMessage(HttpMethod.Post, url) { Content = content })
                {
                    if (headers != null && headers.Count > 0)
                    {
                        foreach (var header in headers)
                        {
                            httpRequest.Headers.Add(header.Key, header.Value);
                        }
                    }

                    using (var result = await _httpClient.SendAsync(httpRequest))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var response = await result.Content.ReadAsStringAsync();
                            return JsonConvert.DeserializeObject<TResult>(response);
                        }
                        else
                        {
                            var message = await result.Content.ReadAsStringAsync();
                            var ex = new HttpResponseFailureException(_httpResponseMessage)
                            {
                                ResponseMessage = message
                            };
                            ex.Data.Add(_responseMessage, message);
                            throw ex;
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Method to process the HTTP API web request
        /// </summary>
        /// <typeparam name="T1">Represents the Generic transaction response object</typeparam>
        /// <typeparam name="T2">Represents the Generic transaction request object</typeparam>
        /// <param name="requestUri">Represents the requested URL</param>
        /// <param name="request">Represents the request </param>
        /// <returns>HTTP response in Json format as a string </returns>
        public async Task<T1> PutAsync<T1, T2>(Uri requestUri, T2 request)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (StringContent content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"))
            {
                using (var result = await _httpClient.PutAsync(requestUri, content))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T1>(response);
                    }
                    else
                    {
                        var message = await result.Content.ReadAsStringAsync();
                        var ex = new HttpResponseFailureException(_httpResponseMessage)
                        {
                            ResponseMessage = message
                        };
                        ex.Data.Add(_responseMessage, message);
                        throw ex;
                    }
                }
            }
        }

        /// <inheritdoc cref="IRestClientHelper.PutContent{T1, T2}(Uri, T2)/>
        public async Task<HttpStatusCode> PutContent(Uri requestUri, byte[] content, string contentType)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (ByteArrayContent byteArrayContent = new ByteArrayContent(content))
            {
                byteArrayContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                using (var result = await _httpClient.PutAsync(requestUri, byteArrayContent))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        return result.StatusCode;
                    }
                    else
                    {
                        var message = await result.Content.ReadAsStringAsync();
                        var ex = new HttpResponseFailureException(_httpResponseMessage)
                        {
                            ResponseMessage = message
                        };
                        ex.Data.Add(_responseMessage, message);
                        throw ex;
                    }
                }
            }
        }

        /// <inheritdoc cref="IRestClientHelper.PatchAsync{T1, T2}(Uri, T2)/>
        public Task<T1> PatchAsync<T1, T2>(Uri requestUri, T2 request)
        {
            return PatchAsync<T1, T2>(requestUri, request, null);
        }

        /// <inheritdoc cref="IRestClientHelper.PatchAsync{T1, T2}(Uri, T2, IDictionary{string, string})"/>
        public async Task<T1> PatchAsync<T1, T2>(Uri requestUri, T2 request, IDictionary<string, string> headers)
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.SystemDefault;
            using (var httpRequest = new HttpRequestMessage(HttpMethod.Patch, requestUri))
            {
                if (headers != null && headers.Count > 0)
                {
                    foreach (var header in headers)
                    {
                        httpRequest.Headers.Add(header.Key, header.Value);
                    }
                }
                httpRequest.Content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                using (var result = await _httpClient.SendAsync(httpRequest))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var response = await result.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T1>(response);
                    }
                    else
                    {
                        var message = await result.Content.ReadAsStringAsync();
                        var ex = new HttpResponseFailureException(_httpResponseMessage)
                        {
                            ResponseMessage = message
                        };
                        ex.Data.Add(_responseMessage, message);
                        throw ex;
                    }
                }
            }
        }
    }
}
