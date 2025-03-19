using MovieDiscovery.Server.Contracts.Movie;

namespace MovieDiscovery.Server.Interfaces
{
    /// <summary>
    /// Інтерфейс для сервісу фільмів.
    /// </summary>
    public interface IMovieService
    {
        /// <summary>
        /// Додавання нового фільму.
        /// </summary>
        /// <param name="movieRequest">Об'єкт, що містить дані для створення фільму.</param>
        /// <param name="userId">Ідентифікатор користувача, що додає фільм.</param>
        /// <returns>Об'єкт <see cref="MovieResponse"/> з інформацією про доданий фільм.</returns>
        Task<MovieResponse> AddMovieAsync(CreateMovieRequest movieRequest, int userId);

        /// <summary>
        /// Отримання випадкового фільму.
        /// </summary>
        /// <returns>Об'єкт <see cref="MovieResponse"/> з випадковим фільмом або null, якщо фільмів немає.</returns>
        Task<MovieResponse?> GetRandomMovieAsync();

        /// <summary>
        /// Отримання фільму(ів) за назвою.
        /// </summary>
        /// <param name="title">Назва фільму, який потрібно знайти.</param>
        /// <returns>Об'єкт <see cref="MovieResponse"/> з фільмом(ами) або null, якщо фільм не знайдено.</returns>
        Task<IEnumerable<MovieResponse>> GetByTitleAsync(string title);

        /// <summary>
        /// Отримання всіх фільмів.
        /// </summary>
        /// <returns>Колекція фільмів у вигляді <see cref="MovieResponse"/>.</returns>
        Task<IEnumerable<MovieResponse>> GetAllAsync();
    }
}
