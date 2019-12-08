namespace Payments.API.Contracts
{
    public class PaymentResponse
    {
        public bool Success { get; set; }
        public string BillingTransactionID { get; set; }
        public string ErrorDescription { get; set; }
    }
}