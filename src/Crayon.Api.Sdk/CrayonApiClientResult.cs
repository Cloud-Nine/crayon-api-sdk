using Crayon.Api.Sdk.Domain;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;

namespace Crayon.Api.Sdk
{
    public class CrayonApiClientResult<T> : CrayonApiClientResult
    {
        public CrayonApiClientResult(T data, HttpResponseMessage response)
            : base(response)
        {
            if (IsSuccessStatusCode)
            {
                Data = data;
            }
        }

        public T Data { get; }

        public T GetData()
        {
            if (IsSuccessStatusCode)
            {
                return Data;
            }

            if (Error == null)
            {
                throw new ApiHttpException(StatusCode, Content);
            }

            var message = $"{Error.ErrorCode}: {Error.Message}";
            var innerException = new Exception(Error.Message);

            throw new ApiHttpException(StatusCode, message, innerException) {
                InnerStackTrace = string.Empty
            };
        }
    }

    public class CrayonApiClientResult
    {
        public CrayonApiClientResult(HttpResponseMessage response)
        {
            if (response.Content != null)
            {
                Content = SynchronousExecutor.SynchronousExecute(() => response.Content.ReadAsStringAsync());
            }
            else
            {
                Content = string.Empty;
            }

            if (response.RequestMessage != null)
            {
                ResponseUri = response.RequestMessage.RequestUri;
            }

            StatusCode = response.StatusCode;
            IsSuccessStatusCode = response.IsSuccessStatusCode;

            if (!IsSuccessStatusCode)
            {
                Error = HandleFailureStatusCode(response);
            }
        }

        public string Content { get; }
        public Error Error { get; }
        public Uri ResponseUri { get; }
        public HttpStatusCode StatusCode { get; }
        public bool IsSuccessStatusCode { get; }

        private Error HandleFailureStatusCode(HttpResponseMessage response)
        {
            if (Content == null)
            {
                return new Error {
                    Message = response.StatusCode == HttpStatusCode.NotFound ? "Not found" : string.Empty,
                    ErrorCode = response.StatusCode.ToString()
                };
            }

            try
            {
                return JsonConvert.DeserializeObject<Error>(Content);
            }
            catch (JsonException ex)
            {
                return new Error {
                    Message = ex.Message,
                    ErrorCode = response.StatusCode.ToString()
                };
            }
        }

        public static CrayonApiClientResult<T> NotFound<T>()
        {
            return new CrayonApiClientResult<T>(default(T), new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }
}