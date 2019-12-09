using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, string errorCode) : base(message)
        {
            this.ErrorCode = errorCode;
        }

        public string ErrorCode { get; set; }
    }
}