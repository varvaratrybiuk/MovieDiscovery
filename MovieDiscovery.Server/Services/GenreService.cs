using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Context;
using MovieDiscovery.Server.Contracts.Genre;
using MovieDiscovery.Server.Interfaces;

namespace MovieDiscovery.Server.Services
{
    /// <summary>
    /// Сервіс для роботи з жанрами фільмів.
    /// </summary>
    public class GenreService : IGenreService
    {
        private readonly MovieDBContext _context;

        /// <summary>
        /// Ініціалізує новий екземпляр <see cref="GenreService"/>.
        /// </summary>
        /// <param name="context">Контекст бази даних.</param>
        public GenreService(MovieDBContext context) => _context = context;

        /// <summary>
        /// Отримання списку усіх жанрів із бази даних.
        /// </summary>
        /// <returns>Колекція жанрів у вигляді <see cref="GenreResponse"/>.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
        public async Task<IEnumerable<GenreResponse>> GetAllAsync()
        {
            return await _context.Genres
                .Select(g => new GenreResponse
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }
    }
}
