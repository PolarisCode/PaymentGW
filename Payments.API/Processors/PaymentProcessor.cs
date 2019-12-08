using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Exceptions;
using Payments.API.Models;

namespace Payments.API.Processors
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IBillingAdapter _billingAdapter;
        private readonly IPaymentValidator _paymentValidator;

        public PaymentProcessor(IBillingAdapter billingAdapter, IPaymentValidator paymentValidator)
        {
            _billingAdapter = billingAdapter;
            _paymentValidator = paymentValidator;
        }

        public async Task<PaymentResponse> Process(PaymentRequest request)
        {
            if (await _paymentValidator.Validate(request))
            {
                return await _billingAdapter.SendRequest(request);
            }
            else
            {
                throw new ApiException("Validation failed");
            }
        }
    }
}
