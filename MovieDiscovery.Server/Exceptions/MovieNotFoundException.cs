namespace api.Exceptions
{
    public class MovieNotFoundException(string title) : Exception($"Фільм з такою назвою '{title}' не знайдено.")
    {
    }
}
