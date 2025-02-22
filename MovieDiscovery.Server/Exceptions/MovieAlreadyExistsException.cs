namespace MovieDiscovery.Server.Exceptions
{
    public class MovieAlreadyExistsException : Exception
    {
        public MovieAlreadyExistsException(string title)
            : base($"Фільм з назвою '{title}' вже існує.") { }
    }

}
