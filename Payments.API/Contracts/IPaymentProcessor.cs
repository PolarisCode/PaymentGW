using System.Threading.Tasks;
using Payments.API.Models;

namespace Payments.API.Contracts
{
    public interface IPaymentProcessor
    {
        Task<PaymentResponse> ProcessAsync(PaymentRequest request);

        Task<PaymentDetails> ReceivePaymentAsync(string externalID);
    }
}