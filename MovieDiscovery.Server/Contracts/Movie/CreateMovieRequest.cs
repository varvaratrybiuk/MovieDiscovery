namespace MovieDiscovery.Server.Contracts.Movie
{
    /// <summary>
    /// Об'єкт, що представляє запит для створення нового фільму в системі.
    /// </summary>
    public record CreateMovieRequest
    {
        /// <summary>
        /// Назва фільму.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// Опис фільму.
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Список ідентифікаторів жанрів, до яких належить фільм.
        /// </summary>
        public required List<int> GenresID { get; init; }

        /// <summary>
        /// Рік випуску фільму.
        /// </summary>
        public int Year { get; init; }

        /// <summary>
        /// Рейтинг фільму.
        /// </summary>
        public float? Rating { get; init; }
    }
}
