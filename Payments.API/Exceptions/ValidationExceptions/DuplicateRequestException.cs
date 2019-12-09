using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions.ValidationExceptions
{
    public class DuplicateRequestException : ApiException
    {
        private const string _errorCode = "500.003";

        public DuplicateRequestException(string message) : base(message, _errorCode)
        {
        }
    }
}
