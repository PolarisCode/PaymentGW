using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Payments.API.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public ApplicationConfiguration(IConfiguration configuration)
        {
            this.BillingUrl = configuration["Billing:Url"];
        }

        public string BillingUrl { get; set; }
    }
}
