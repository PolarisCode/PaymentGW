using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class CurrencyNotFoundException : ApiException
    {
        private const string _errorCode = "500.002";

        public CurrencyNotFoundException(string message) : base(message, _errorCode)
        { }
    }
}
