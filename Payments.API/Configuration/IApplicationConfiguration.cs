using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Configuration
{
    /// <summary>
    /// Abstraction to hide real source of configuration
    /// </summary>
    public interface IApplicationConfiguration
    {
        string BillingUrl { get; set; }
    }
}
