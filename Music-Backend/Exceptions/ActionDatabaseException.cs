namespace Music_Backend.Exceptions
{
    public class ActionDatabaseException : Exception
    {
        public ActionDatabaseException(string message = "Database interaction operation failed") : base(message)
        {

        }
    }
}
