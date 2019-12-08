using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking.Simulator.Models
{
    // Seperate class was introduced to Simulator 
    // part for not creating dependency with Payment.API
    public class BillingRequest
    {
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryDay { get; set; }
        public int Cvv { get; set; }
    }
}
