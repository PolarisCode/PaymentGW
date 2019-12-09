using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class CardNumberInvalidException : ApiException
    {
        private const string _errorCode = "500.001";

        public CardNumberInvalidException(string message) : base(message, _errorCode)
        {
        }
    }
}
