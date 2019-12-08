using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Simulator.Models
{
    public class BillingResponse
    {
        public bool Success { get; set; }
        public string BillingTransactionID { get; set; }
        public string ErrorDescription { get; set; }
    }
}
