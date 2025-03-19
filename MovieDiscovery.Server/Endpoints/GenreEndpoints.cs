using MovieDiscovery.Server.Interfaces;

namespace MovieDiscovery.Server.Endpoints
{
    /// <summary>
    /// Клас, що містить ендпоїнти для обробки запитів, пов'язаних з жанрами.
    /// </summary>
    public static class GenreEndpoints
    {
        /// <summary>
        /// Реєструє всі ендпоїнти для обробки запитів, пов'язаних з жанрами.
        /// </summary>
        /// <param name="app">Інтерфейс для налаштування маршрутів.</param>
        /// <returns>Інтерфейс для налаштування маршрутів.</returns>
        public static IEndpointRouteBuilder MapGenreEndPoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", GetAllGenres);

            return app;
        }

        /// <summary>
        /// Отримання списку усіх жанрів.
        /// </summary>
        /// <param name="service">Сервіс для отримання жанрів.</param>
        /// <returns>Результат у вигляді HTTP-відповіді з кодом 200 або 500.</returns>
        /// <response code="200">Успішно отримано список жанрів.</response>
        /// <response code="500">Внутрішня помилка.</response>
        private static async Task<IResult> GetAllGenres(IGenreService service)
        {
            var result = await service.GetAllAsync();
            return Results.Ok(result);
        }
    }
}
