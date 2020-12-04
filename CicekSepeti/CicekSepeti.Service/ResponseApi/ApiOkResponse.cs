using System;
using System.Collections.Generic;
using System.Text;

namespace CicekSepeti.Service.ResponseApi
{
    public class ApiOkResponse : ApiResponse
    {
        public ApiOkResponse(object result)
            : base(200, result)
        {
        }
    }
}
