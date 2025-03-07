namespace MovieDiscovery.Server.Exceptions
{
    /// <summary>
    /// Виключення, яке виникає, коли фільм з такою ж назвою вже існує в базі даних.
    /// </summary>
    public class MovieAlreadyExistsException : Exception
    {
        /// <summary>
        /// Конструктор для виключення <see cref="MovieAlreadyExistsException"/>.
        /// </summary>
        /// <param name="title">Назва фільму, який вже існує.</param>
        public MovieAlreadyExistsException(string title)
            : base($"Фільм з назвою '{title}' вже існує.") { }
    }

}
