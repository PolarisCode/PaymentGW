using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IPaymentValidator
    {
        bool Validate(PaymentRequest request);
    }
}