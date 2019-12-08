using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public async Task<ActionResult> Process([FromBody]PaymentRequest request)
        {
            try
            {
               await _paymentProcessor.Process(request);
            }
            catch (ValidationException exception)
            {
                return StatusCode(500, new ErrorResponse() { ErrorCode = "500", ErrorMessage = exception.Message });
            }

            return Ok(null);
        }
    }
}
