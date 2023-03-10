namespace ProjectTemplate.Domain
{
    public class UserWallet : BaseAuditableEntity<string>
    {
        /// <summary>
        /// for creation of object in domain
        /// </summary>
        /// <param name="userId"></param>
        public UserWallet(string userId)
        {
            id = PrimaryKey.GetUniqueNumStr();
            this.currency = "USD";
            this.currentBalance = 0;
            this.userId = userId;
        }

        /// <summary>
        /// For ORM
        /// </summary>
        private UserWallet()
        { }

        public decimal currentBalance { get; private set; }
        public string currency { get; private set; }
        public string userId { get; init; }
    }
}
