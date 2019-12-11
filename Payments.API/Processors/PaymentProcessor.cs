using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
using Payments.API.Encryption;
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
        private readonly IEncryptor _encryptor;

        public PaymentProcessor(IBillingAdapter billingAdapter, IPaymentValidator paymentValidator, 
            IPaymentRepository repository, IEncryptor encryptor)
        {
            _billingAdapter = billingAdapter;
            _paymentValidator = paymentValidator;
            _repository = repository;
            _encryptor = encryptor;
        }

        /// <summary>
        /// Process Payment Request by sending request to acquiring Bank
        /// </summary>
        /// <param name="request">Payment request to send</param>
        /// <returns>Processed response from bank</returns>
        public async Task<PaymentResponse> ProcessAsync(PaymentRequest request)
        {
            if (await _paymentValidator.ValidateAsync(request))
            {
                PaymentResponse response = await _billingAdapter.SendRequestAsync(request);

                if (response != null)
                {
                    await _repository.SavePaymentRecordAsync(new PaymentRecord()
                    {
                        ExternalID = request.ExternalID,
                        BillingID = response.BillingTransactionID,
                        Amount = request.Amount,
                        CardExpirationMonth = request.ExpiryMonth,
                        CardExpirationYear = request.ExpiryYear,
                        CardNumber = _encryptor.Encrypt(request.CardNumber),
                        CurrencyCode = request.CurrencyCode,
                        CVV = request.Cvv,
                        BillingSuccess = response.Success
                    });
                }

                return await Task.FromResult(response);
            }
            else
            {
                throw new ApiException("Validation failed", "500");
            }
        }

        /// <summary>
        /// Receive Payment Details based on externalID
        /// </summary>
        /// <param name="externalID">unique id of previously processed request</param>
        /// <returns>Details of payment operation from Payment API storage</returns>
        public async Task<PaymentDetails> ReceivePaymentAsync(string externalID)
        {
            PaymentDetails paymentDetails = null;

            PaymentRecord dbRecord = await _repository.GetPaymentRecordAsync(externalID);

            if (dbRecord != null)
            {
                string decryptedCardNumber = _encryptor.Decrypt(dbRecord.CardNumber);

                //PaymentDetails is just POCO class, no need for injection
                paymentDetails = new PaymentDetails()
                {
                    BillingTransactionID = dbRecord.BillingID,
                    Success = dbRecord.BillingSuccess,
                    ErrorDescription = dbRecord.ErrorDescription,
                    ExpirtyYear = dbRecord.CardExpirationYear.ToString(),
                    ExpiryMonth = dbRecord.CardExpirationMonth.ToString(),
                    MaskedCardNumber = MaskCreditCardNumber(decryptedCardNumber)
                };
            }

            return paymentDetails;
        }

        private string MaskCreditCardNumber(string cardNumber)
        {
            var last4digits = cardNumber.Substring(cardNumber.Length - 4);

            return $"**** **** **** {last4digits}";
        }
    }
}
