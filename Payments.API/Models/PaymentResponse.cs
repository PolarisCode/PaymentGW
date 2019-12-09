namespace Payments.API.Contracts
{
    public class PaymentResponse
    {
        public string BillingTransactionID { get; set; }

        public bool Success { get; set; }
       
        public string ErrorDescription { get; set; }
    }
}