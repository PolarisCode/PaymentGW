using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Exceptions.ValidationExceptions
{
    public class DuplicateRequestException : ApiException
    {
        public DuplicateRequestException(string message) : base(message)
        {
        }
    }
}
