using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Service.ResponseApi
{
    public class ApiNotFoundResponse : ApiResponse
    {
        public ApiNotFoundResponse(object result, string message = null)
            : base(404, result, message)
        {
        }
    }
}
