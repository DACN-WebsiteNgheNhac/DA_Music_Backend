namespace Music_Backend.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message = "404 not found") : base(message)
        {

        }
    }
}
