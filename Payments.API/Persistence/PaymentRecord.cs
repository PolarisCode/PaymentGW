using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.API.Persistence
{
    public class PaymentRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(100)]
        public string ExternalID { get; set; }

        [StringLength(100)]
        public string BillingID { get; set; }

        [StringLength(3)]
        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }

        [StringLength(4)]
        public int CardExpirationYear { get; set; }

        [StringLength(2)]
        public int CardExpirationMonth { get; set; }

        public int CVV { get; set; }

        [StringLength(16)]
        public string CardNumber { get; set; }

        public bool BillingSuccess { get; set; }

        [StringLength(200)]
        public string ErrorDescription { get; set; }
    }
}
