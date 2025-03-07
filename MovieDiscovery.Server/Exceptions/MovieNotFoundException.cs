namespace MovieDiscovery.Server.Exceptions
{
    /// <summary>
    /// Виключення, яке виникає, коли фільм з такою назвою не знайдено в базі даних.
    /// </summary>
    public class MovieNotFoundException : Exception
    {
        /// <summary>
        /// Конструктор для виключення <see cref="MovieNotFoundException"/>.
        /// </summary>
        /// <param name="title">Назва фільму, який не знайдено.</param>
        public MovieNotFoundException(string title)
            : base($"Фільм з назвою '{title}' не знайдено.") { }
    }
}
