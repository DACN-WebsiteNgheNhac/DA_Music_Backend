using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Controllers
{
    public static class ControllerBaseExtension
    {
        public static IActionResult OkResponse<T>(this ControllerBase controller, T metadata, string message = "Successful.", int statusCode = 200, Pagination? pagination = null)
        {
            var response = new OkResult<T>(metadata, message, statusCode, pagination);
            if (metadata == null)
                response = new OkResult<T>(metadata, "Not found object", StatusCodes.Status404NotFound);
            return new OkObjectResult(response);
        }

        public static IActionResult FailedActionDelete(this ControllerBase controller, string message = "The delete operation failed because the object was not found")
        {
            var response = new OkResult<string>(null, message, StatusCodes.Status400BadRequest, null);
            return new BadRequestObjectResult(response);
        }

        public static IActionResult? CheckMultiDataRequest(this ControllerBase controller, string message = "All fields need fill", params object[] data)
        {
            foreach (var item in data)
            {
                var validate = CheckDataRequest(controller, item, message);
                if (validate != null)
                    return validate;
            }
            return null;
        }

        public static IActionResult? CheckDataRequest(this ControllerBase controller, object data, string message = "All fields need fill")
        {
            if(data == null)
            {
                var response = new BadResult(message);
                return new BadRequestObjectResult(response);
            }
            return null;
        }
    }
}
