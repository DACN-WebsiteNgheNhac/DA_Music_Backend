using Microsoft.AspNetCore.Http;
using Music_Backend.Exceptions;
using Music_Backend.Models.ResponseModels;

namespace Music_Backend.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                //var formData = context.Request.Form;
                //var test = context.Request.Body;
                //string formValue = formData["fieldName"];
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = (int)StatusCodes.Status500InternalServerError;
            string message = ex.Message;
            string title = "";
            switch (ex)
            {
                case NotFoundException:
                    statusCode = StatusCodes.Status404NotFound;
                    break;
                case UnauthorizedException:
                    statusCode = StatusCodes.Status401Unauthorized;
                    break;
                case ActionDatabaseException:
                    int endChar = message.IndexOf("The statement has been terminated");
                    if(endChar != -1)
                    {
                        message = message.Substring(0, endChar);

                    }
                    else if(message.Contains("The database operation was expected to affect 1 row(s)"))
                    {
                        message = "Succesfull update, but actually affected 0 row ";
                    }
                    statusCode = StatusCodes.Status400BadRequest;
                    title = "Failed Action";
                    break;
                default:

                    break;
            }

            var errorResponse = new ErrorResponse(messsage: message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }

    // Configure
    public static class ExceptionMiddleWareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
