namespace api.Exceptions
{
    public class MovieNotFoundException(string title) : Exception($"Фільм з назвою '{title}' не знайдено.")
    {
    }
}
