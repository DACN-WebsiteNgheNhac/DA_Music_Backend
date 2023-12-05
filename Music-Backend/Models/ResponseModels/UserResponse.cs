namespace Music_Backend.Models.ResponseModels
{
    public class UserResponse
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }

    }
}
