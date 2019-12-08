using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Payments.API.Contracts;
using Payments.API.Models;

namespace Payments.API.Adapters
{
    public class BillingAdapter : IBillingAdapter
    {
        private readonly IRequestSender<PaymentResponse> _requestSender;

        private string url = "http://Banking.Simulator:5002/api/billing";
        private string uriParameters = "";
        


        public BillingAdapter(IRequestSender<PaymentResponse> requestSender)
        {
            _requestSender = requestSender;
        }


        public async Task<PaymentResponse> SendRequest(PaymentRequest request)
        {
            string jsonString = JsonConvert.SerializeObject(request);

            return await _requestSender.SendAsync(url, uriParameters, jsonString);
        }
    }
}
