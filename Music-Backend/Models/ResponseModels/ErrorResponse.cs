using System.Text.Json;

namespace Music_Backend.Models.ResponseModels
{
    public class ErrorResponse : OkResult<object>
    {
        public ErrorResponse(int statusCode = StatusCodes.Status400BadRequest, string messsage = "Message") : base(messsage)
        {
            StatusCode = statusCode;
            Metadata = null;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
