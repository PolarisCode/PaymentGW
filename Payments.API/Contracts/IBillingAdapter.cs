using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IBillingAdapter
    {
        PaymentResponse SendRequest(PaymentRequest request);
    }
}