using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace api.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCode = exception switch
            {
                MovieNotFoundException => StatusCodes.Status404NotFound,
                NoMoviesFoundException => StatusCodes.Status404NotFound,
                ArgumentException or ArgumentNullException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var message = exception switch
            {
                ArgumentNullException => "Invalid request. Some required parameters are missing.",
                _ => exception.Message ?? "Виникла невідома помилка. Спробуйте, будь ласка, пізніше"
            };

            httpContext.Response.StatusCode = statusCode;

            await httpContext.Response.WriteAsJsonAsync(new
            {
                StatusCode = statusCode,
                Message = message
            }, cancellationToken);

            return true;
        }
    }
}
