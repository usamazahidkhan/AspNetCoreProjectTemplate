namespace ProjectTemplate.Domain
{
    public class UserWalletCreditTransaction : BaseAuditableEntity<int>
    {
        public decimal amount { get; set; }
        public string currency { get; set; } = "USD";
        public PaymentGateway paymentGateway { get; set; }
        public PaymentStatus status { get; set; }
        public string externalPaymentId { get; set; }
        public string userWalletId { get; set; }
        public UserWallet userWallet { get; set; }
    }
}
