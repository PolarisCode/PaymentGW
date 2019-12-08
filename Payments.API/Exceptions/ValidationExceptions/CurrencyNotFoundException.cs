using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class CurrencyNotFoundException : ApiException
    {
        public CurrencyNotFoundException(string message) : base(message)
        { }
    }
}
