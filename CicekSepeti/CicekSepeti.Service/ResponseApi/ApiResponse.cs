using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Service.ResponseApi
{
    public class ApiResponse
    {
        public object Result { get; }
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }

        public ApiResponse(int statusCode, object result, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Result = result;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";
                case 500:
                    return "An unhandled error occurred";
                default:
                    return null;
            }
        }
    }
}
