namespace Music_Backend.Models.RequestModels
{
    public class UserUpdateRequest
    {

        public string? Name { get; set; }
        public string? Gender { get; set; }
        public string? Image { get; set; }
        public DateTimeOffset? BirthDay { get; set; }
    }
}
