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
        public async Task<bool> Validate(PaymentRequest request)
        {
            await new CurrencyValidator().IsSatisfied(request);
            await new CardNumberValidator().IsSatisfied(request);

            return true;
        }
    }
}
