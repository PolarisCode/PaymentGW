using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Persistence
{
    public class PaymentRecord
    {
        [Key]
        public int ID { get; set; }
        public string ExternalID { get; set; }
        public string BillingID { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public int CardExpirationYear { get; set; }
        public int CardExpirationMonth { get; set; }
        public int CVV { get; set; }
        public string CardNumber { get; set; }
    }
}
