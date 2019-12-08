using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Enums;
using Payments.API.Exceptions;
using Payments.API.Models;

namespace Payments.API.Validators
{
    public class CurrencyValidator : IValidator
    {
        public async Task<bool> IsSatisfied(PaymentRequest request)
        {
            var result = Enum.GetNames(typeof(Currencies)).Contains(request.CurrencyCode.ToUpper());

            if (!result)
                throw new CurrencyNotFoundException($"Currency in request payload {request.CurrencyCode} is not supported");

            return await Task.FromResult(true);
        }
    }
}
