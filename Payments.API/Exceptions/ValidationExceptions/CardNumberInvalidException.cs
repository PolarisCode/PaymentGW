using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions
{
    public class CardNumberInvalidException : ApiException
    {
        public CardNumberInvalidException(string message) : base(message)
        {
        }
    }
}
