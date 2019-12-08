using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Contracts;
using Payments.API.Models;

namespace Payments.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private IPaymentProcessor _paymentProcessor;

        public PaymentsController(IPaymentProcessor processor)
        {
            _paymentProcessor = processor;
        }

        [HttpPost]
        [Produces("application/json")]
        public Task<ActionResult> Process([FromBody]PaymentRequest request)
        {
            _paymentProcessor.Process(request);
            return Ok(null);
        }
    }
}
