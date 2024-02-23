
using System.Net;
using System.Text.Json;

namespace API.Utilities.Middlewares
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError; 
                context.Response.ContentType = "application/json";

                var customErrorResponse = new
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = HttpStatusCode.InternalServerError.ToString(),
                    Message = "Internal server error occured. Please contact the administrator for information.",
                    ErrorDetails = ex.InnerException?.Message ?? ex.Message
                };

                var serializedErrorResponse = JsonSerializer.Serialize(customErrorResponse);
                await context.Response.WriteAsync(serializedErrorResponse);
            }
        }
    }
}
