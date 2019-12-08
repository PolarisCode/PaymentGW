using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Exceptions;
using Payments.API.Models;

namespace Payments.API.Validators
{
    public class CardNumberValidator : IValidator
    {
        private readonly int cardNumberLength = 16; //TODO: value should come from configuration

        public Task<bool> IsSatisfied(PaymentRequest request)
        {
            if (request.CardNumber.Length != cardNumberLength)
                throw new CardNumberInvalidException($"Card number in payload is invalid. Card number length must be {cardNumberLength}");

            return Task.FromResult(true);
        }
    }
}
