using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Models;
using Payments.API.Persistence;

namespace Payments.API.Validators
{
    public class PaymentValidations : IPaymentValidator
    {
        private readonly IPaymentRepository _repository;

        public PaymentValidations(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ValidateAsync(PaymentRequest request)
        {
            await new CurrencyValidator().IsSatisfied(request);
            await new CardNumberValidator().IsSatisfied(request);
            await new DuplicateRequestValidator(_repository).IsSatisfied(request);

            return true;
        }
    }
}
