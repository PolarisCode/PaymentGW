using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IBillingAdapter
    {
        Task<PaymentResponse> SendRequest(PaymentRequest request);
    }
}