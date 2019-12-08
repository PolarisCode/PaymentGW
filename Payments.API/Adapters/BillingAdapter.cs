using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Models;

namespace Payments.API.Adapters
{
    public class BillingAdapter : IBillingAdapter
    {
        public PaymentResponse SendRequest(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
