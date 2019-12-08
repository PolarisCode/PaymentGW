using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Exceptions;
using Payments.API.Models;
using Payments.API.Persistence;

namespace Payments.API.Processors
{
    public class PaymentProcessor : IPaymentProcessor
    {
        private readonly IBillingAdapter _billingAdapter;
        private readonly IPaymentValidator _paymentValidator;
        private readonly IPaymentRepository _repository;

        public PaymentProcessor(IBillingAdapter billingAdapter, IPaymentValidator paymentValidator, IPaymentRepository repository)
        {
            _billingAdapter = billingAdapter;
            _paymentValidator = paymentValidator;
            _repository = repository;
        }

        public async Task<PaymentResponse> Process(PaymentRequest request)
        {
            if (await _paymentValidator.Validate(request))
            {
                PaymentResponse response = await _billingAdapter.SendRequest(request);

                if (response != null)
                {
                    await _repository.SavePaymentRecordAsync(new PaymentRecord()
                    {
                        ExternalID = request.ExternalID,
                        BillingID = response.BillingTransactionID,
                        Amount = request.Amount,
                        CardExpirationMonth = request.ExpiryMonth,
                        CardExpirationYear = request.ExpiryYear,
                        CardNumber = request.CardNumber,
                        CurrencyCode = request.CurrencyCode,
                        CVV = request.Cvv,
                        BillingSuccess = response.Success
                    });
                }

                return response;
            }
            else
            {
                throw new ApiException("Validation failed");
            }
        }
    }
}
