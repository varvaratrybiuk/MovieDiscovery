using MovieDiscovery.Server.Contracts.Movie;
using MovieDiscovery.Server.Helpers;
using MovieDiscovery.Server.Interfaces;
using System.Security.Claims;
using System.Web;

namespace MovieDiscovery.Server.Endpoints
{
    /// <summary>
    /// Клас, що містить ендпоїнти для обробки запитів, пов'язаних з фільмами.
    /// </summary>
    public static class MovieEndpoints
    {
        /// <summary>
        /// Реєструє всі ендпоїнти для обробки запитів, пов'язаних з фільмами.
        /// </summary>
        /// <param name="app">Інтерфейс для налаштування маршрутів.</param>
        /// <returns>Інтерфейс для налаштування маршрутів.</returns>
        public static IEndpointRouteBuilder MapMovieEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetAllMovies);

            app.MapGet("/random", GetRandomMovie);

            app.MapGet("/{name}", GetMovieByTitle);

            app.MapPost("/add", AddMovie)
               .AddEndpointFilter(async (context, next) =>
               {
                   var movie = context.GetArgument<CreateMovieRequest>(0);

                   var validationError = ValidationUtilities.ValidateMovieRequest(movie);

                   if (!string.IsNullOrEmpty(validationError))
                   {
                       return Results.Problem(validationError, statusCode: 400);
                   }

                   return await next(context);
               }).RequireAuthorization();

            return app;
        }

        /// <summary>
        /// Отримання списку всіх фільмів.
        /// </summary>
        /// <param name="service">Сервіс для роботи з фільмами.</param>
        /// <returns>Список фільмів.</returns>
        /// <response code="200">Успішно отримано список фільмів.</response>
        /// <response code="500">Внутрішня помилка.</response>
        private static async Task<IResult> GetAllMovies(IMovieService service)
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        }

        /// <summary>
        /// Отримання випадкового фільму.
        /// </summary>
        /// <param name="service">Сервіс для роботи з фільмами.</param>
        /// <returns>Випадковий фільм.</returns>
        /// <response code="200">Успішно отримано випадковий фільм.</response>
        /// <response code="404">Не знайдено жодного фільму.</response>
        /// <response code="500">Внутрішня помилка сервера.</response>
        private static async Task<IResult> GetRandomMovie(IMovieService service)
        {
            var result = await service.GetRandomMovieAsync();
            return result is not null ? Results.Ok(result) : Results.NotFound();
        }

        /// <summary>
        /// Отримання фільму за назвою.
        /// </summary>
        /// <param name="name">Назва фільму.</param>
        /// <param name="service">Сервіс для роботи з фільмами.</param>
        /// <returns>Інформація про фільм.</returns>
        /// <response code="200">Успішно отримано інформацію про фільм.</response>
        /// <response code="400">Некоректний запит.</response>
        /// <response code="404">Фільм із вказаною назвою не знайдено.</response>
        /// <response code="500">Внутрішня помилка сервера.</response>
        private static async Task<IResult> GetMovieByTitle(string name, IMovieService service)
        {
            var result = await service.GetByTitleAsync(name);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        }

        /// <summary>
        /// Додавання нового фільму.
        /// </summary>
        /// <param name="create">Об'єкт, що містить дані для додавання фільму.</param>
        /// <param name="service">Сервіс для роботи з фільмами.</param>
        /// <param name="httpContext">Контекст HTTP.</param>
        /// <returns>Повернення статусу 201 і об'єкта нового фільму.</returns>
        /// <response code="201">Фільм успішно додано.</response>
        /// <response code="400">Некоректний запит.</response>
        /// <response code="401">Користувач не увійшов у систему.</response>
        /// <response code="500">Внутрішня помилка сервера.</response>
        private static async Task<IResult> AddMovie(CreateMovieRequest create, IMovieService service, HttpContext httpContext)
        {
            var userIdClaim = httpContext.User.FindFirst(ClaimTypes.NameIdentifier);

            if (userIdClaim == null)
            {
                return Results.Unauthorized();
            }

            int userId = int.Parse(userIdClaim.Value);
            var result = await service.AddMovieAsync(create, userId);
            string encodedTitle = HttpUtility.UrlEncode(result.Title);

            return Results.Created($"movie/{encodedTitle}", result);
        }

    }
}
