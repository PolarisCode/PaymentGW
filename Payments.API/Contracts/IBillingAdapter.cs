using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IBillingAdapter
    {
        Task<PaymentResponse> SendRequestAsync(PaymentRequest request);
    }
}