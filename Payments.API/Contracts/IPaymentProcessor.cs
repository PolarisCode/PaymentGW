using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IPaymentProcessor
    {
        PaymentResponse Process(PaymentRequest request);
    }
}