using Microsoft.AspNetCore.Diagnostics;

namespace MovieDiscovery.Server.Exceptions
{
    /// <summary>
    /// Глобальний обробник виключень, який обробляє різні типи виключень у застосунку.
    /// </summary>
    public class GlobalExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Метод, який асинхронно обробляє виключення, якщо це можливо.
        /// </summary>
        /// <param name="httpContext">Поточний HTTP контекст.</param>
        /// <param name="exception">Виключення, яке потрібно обробити.</param>
        /// <param name="cancellationToken">Токен для моніторингу запитів на скасування.</param>
        /// <returns>Повертає `true`, якщо виключення було успішно оброблене, і `false` в іншому випадку.</returns>
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var statusCode = exception switch
            {
                MovieNotFoundException => StatusCodes.Status404NotFound,
                NoMoviesFoundException => StatusCodes.Status404NotFound,
                MovieAlreadyExistsException => StatusCodes.Status400BadRequest,
                ArgumentException or ArgumentNullException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var message = exception switch
            {
                ArgumentNullException => "Недійсний запит. Деякі обов’язкові параметри відсутні.",
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
