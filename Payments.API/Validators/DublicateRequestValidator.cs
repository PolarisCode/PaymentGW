using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Exceptions.ValidationExceptions;
using Payments.API.Models;
using Payments.API.Persistence;

namespace Payments.API.Validators
{
    public class DuplicateRequestValidator : IValidator
    {
        private readonly IPaymentRepository _repository;

        public DuplicateRequestValidator(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsSatisfied(PaymentRequest request)
        {
            if (await _repository.IsExternalIDExistAsync(request.ExternalID))
            {
                throw new DuplicateRequestException($"Message with ExternalID '{request.ExternalID}' already was processed");
            }

            return true;
        }
    }
}
