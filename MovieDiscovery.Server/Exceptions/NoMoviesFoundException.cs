namespace MovieDiscovery.Server.Exceptions
{
    /// <summary>
    /// Виключення, яке виникає, коли в базі даних немає фільмів.
    /// </summary>
    public class NoMoviesFoundException : Exception
    {
        /// <summary>
        /// Конструктор для виключення <see cref="NoMoviesFoundException"/>.
        /// </summary>
        public NoMoviesFoundException()
            : base("Немає фільмів в базі даних") { }
    }
}
