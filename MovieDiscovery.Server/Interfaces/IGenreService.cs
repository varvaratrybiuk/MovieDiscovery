using MovieDiscovery.Server.Contracts.Genre;

namespace MovieDiscovery.Server.Interfaces
{
    /// <summary>
    /// Інтерфейс для сервісу жанрів.
    /// </summary>
    public interface IGenreService
    {
        /// <summary>
        /// Отримання всіх жанрів.
        /// </summary>
        /// <returns>Колекція жанрів у вигляді <see cref="GenreResponse"/>.</returns>
        Task<IEnumerable<GenreResponse>> GetAllAsync();
    }
}
