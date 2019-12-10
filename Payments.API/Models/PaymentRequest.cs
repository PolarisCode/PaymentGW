using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Models
{
    public class PaymentRequest
    {
        public string ExternalID { get; set; }
        public string CardNumber { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public int ExpiryMonth { get; set; }
        public int ExpiryYear { get; set; }
        public int Cvv { get; set; }

        public override string ToString()
        {
            return $"{ExternalID}, {CardNumber}, {Amount}, {CurrencyCode}, {ExpiryMonth}, {ExpiryYear}, {Cvv}";
        }
    }
}
