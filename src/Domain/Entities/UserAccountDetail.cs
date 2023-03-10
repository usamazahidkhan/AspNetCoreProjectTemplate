namespace ProjectTemplate.Domain
{
    public class UserAccountDetail : BaseAuditableEntity<int>
    {
        /// <summary>
        /// For EF Core
        /// </summary>
        private UserAccountDetail()
        { }

        /// <summary>
        /// Create empty db record when user signup with userid only
        /// </summary>
        /// <param name="userId"></param>
        public UserAccountDetail(string userId)
        {
            this.userId = userId;
        }

        public string userId { get; private set; }
        public string? company { get; set; }
        public string? address { get; set; }
        public string? zipCode { get; set; }
        public string? country { get; set; }
        public string? website { get; set; }
        public string? skypeId { get; set; }
        public string? telphone { get; set; }
    }
}
