using System;
using Banking.Simulator.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Simulator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [Produces("application/json")]
        public ActionResult Post([FromBody] BillingRequest value)
        {
            return Ok(new BillingResponse()
            {
                BillingTransactionID = DateTime.Now.Ticks.ToString(),
                Success = true,
                ErrorDescription = ""
            });
        }

    }
}