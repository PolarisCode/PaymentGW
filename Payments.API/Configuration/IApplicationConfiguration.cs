using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Configuration
{
    public interface IApplicationConfiguration
    {
        string BillingUrl { get; set; }
    }
}
