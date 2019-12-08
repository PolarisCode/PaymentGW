using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking.Simulator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        public BillingResponse Post([FromBody] BillingRequest value)
        {
            return new BillingResponse()
            {
                BillingTransactionID = DateTime.Now.Ticks.ToString(),
                Success = true,
                ErrorDescription = ""
            };
        }

    }
}