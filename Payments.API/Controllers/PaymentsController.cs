using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payments.API.Contracts;
using Payments.API.Exceptions;
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
        public async Task<ActionResult> Process([FromBody]PaymentRequest request)
        {
            try
            {
                PaymentResponse response = await _paymentProcessor.ProcessAsync(request);
                
                return Ok(response);
            }
            catch (ApiException exception)
            {
                return StatusCode(500, new ErrorResponse() { ErrorCode = "500", ErrorMessage = exception.Message });
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("{externalId}")]
        public async Task<ActionResult> RetrievePaymentInformation(string externalId)
        {
            PaymentDetails details = await _paymentProcessor.ReceivePaymentAsync(externalId);

            return Ok(details);
        }
    }
}
