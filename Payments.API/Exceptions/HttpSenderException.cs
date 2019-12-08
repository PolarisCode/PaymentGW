using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class HttpSenderException : ApiException
    {
        public HttpSenderException(string statusCode, string message) : base(message)
        {
            this.StatusCode = statusCode;
        }

        public string StatusCode { get; set; }
    }
}

