namespace Music_Backend.Models.ResponseModels
{
    public class BadResult : OkResult<object>
    {
        public BadResult(string message) : base()
        {
            StatusCode = StatusCodes.Status400BadRequest;
            Message = message;
            Metadata = null;
        }
    }
}
