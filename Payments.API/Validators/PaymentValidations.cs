using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Models;

namespace Payments.API.Validators
{
    public class PaymentValidations : IPaymentValidator
    {
        public bool Validate(PaymentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
