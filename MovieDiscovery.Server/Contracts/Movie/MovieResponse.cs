namespace MovieDiscovery.Server.Contracts.Movie
{
    /// <summary>
    /// Представляє відповідь, що містить основну інформацію про фільм.
    /// </summary>
    public record MovieResponse
    {
        /// <summary>
        /// Унікальний ідентифікатор фільму.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Назва фільму.
        /// </summary>
        public required string Title { get; init; }

        /// <summary>
        /// Опис фільму (необов'язково).
        /// </summary>
        public string? Description { get; init; }

        /// <summary>
        /// Список жанрів, до яких належить фільм.
        /// </summary>
        public required List<string> Genres { get; init; }

        /// <summary>
        /// Рік випуску фільму.
        /// </summary>
        public int Year { get; init; }

        /// <summary>
        /// Рейтинг фільму (необов'язково).
        /// </summary>
        public float? Rating { get; init; }
    }
}
