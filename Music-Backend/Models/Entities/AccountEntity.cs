namespace Music_Backend.Models.Entities
{
    public class AccountEntity : Entity
    {
        public string AccountType { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? FacebookId { get; set; }
        public string? GoogleId { get; set; }

        public UserEntity User { get; set; }
    }
}
