using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;

namespace Payments.API.Models
{
    public class PaymentDetails: PaymentResponse
    {
        public string MaskedCardNumber { get; set; }

        public string ExpiryMonth { get; set; }

        public string ExpirtyYear { get; set; }
    }
}
