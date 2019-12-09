using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class HttpSenderException : ApiException
    {
        private const string _errorCode = "500.004";

        public HttpSenderException(string statusCode, string message) : base(message, _errorCode)
        {
           
        }
    }
}

