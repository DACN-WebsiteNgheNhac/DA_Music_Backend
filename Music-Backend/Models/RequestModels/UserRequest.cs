namespace Music_Backend.Models.RequestModels
{
    public class UserRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTimeOffset BirthDay { get; set; }
    }
}
