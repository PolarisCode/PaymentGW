using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Payments.API.Contracts;
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

        public PaymentResponse Process(PaymentRequest request)
        {
            try
            {
                if (_paymentValidator.Validate(request))
                {

                }  
            }
            catch (Exception)
            {

                throw;
            }

            //Validation of the request

            //sendin request to billing adapter
        }
    }
}
