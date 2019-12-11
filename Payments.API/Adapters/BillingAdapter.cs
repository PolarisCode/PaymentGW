using System.Threading.Tasks;
using Newtonsoft.Json;
using Payments.API.Configuration;
using Payments.API.Contracts;
using Payments.API.Models;

namespace Payments.API.Adapters
{
    public class BillingAdapter : IBillingAdapter
    {
        private readonly IRequestSender<PaymentResponse> _requestSender;
        private readonly IApplicationConfiguration _configuration;      

        public BillingAdapter(IRequestSender<PaymentResponse> requestSender, IApplicationConfiguration configuration)
        {
            _requestSender = requestSender;
            _configuration = configuration;
        }

        public async Task<PaymentResponse> SendRequestAsync(PaymentRequest request)
        {
            string jsonString = JsonConvert.SerializeObject(request);

            return await _requestSender.SendAsync(_configuration.BillingUrl, "", jsonString);
        }
    }
}
